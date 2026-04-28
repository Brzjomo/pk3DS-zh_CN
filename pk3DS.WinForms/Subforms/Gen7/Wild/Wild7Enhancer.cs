using System;
using System.Collections.Generic;
using pk3DS.Core;
using pk3DS.Core.Randomizers;

namespace pk3DS.WinForms
{
    public class Wild7Enhancer
    {
        public bool EvoLevelAdjust { get; set; }
        public int EvoMid { get; set; } = 10;
        public int EvoHigh { get; set; } = 45;

        public bool LegendEnable { get; set; }
        public int LegendMinLevel { get; set; } = 40;
        public int LegendRate { get; set; } = 1;
        public bool LegendMoveWeather { get; set; }

        private EvoChainBuilder _evoChain;
        private HashSet<int> _legendarySet;
        private List<int> _nonLegendaryCache;
        private int _maxSpeciesId;

        public void Execute(Area7[] areas, LazyGARCFile encdata)
        {
            _maxSpeciesId = Main.Config.MaxSpeciesID;

            // 始终构建进化链，供 AdjustByEvolution 和 ClearLegendaries 使用
            _evoChain = new EvoChainBuilder(Main.Config.Evolutions, _maxSpeciesId);
            _evoChain.Build();

            if (LegendEnable)
            {
                _legendarySet = new HashSet<int>(
                    Main.Config.USUM ? Legal.Legendary_USUM : Legal.Legendary_SM
                );
                // Also include Mythical
                var mythical = Main.Config.USUM ? Legal.Mythical_USUM : Legal.Mythical_SM;
                foreach (var m in mythical) _legendarySet.Add(m);

                _nonLegendaryCache = new List<int>();
                for (int i = 1; i <= _maxSpeciesId; i++)
                {
                    if (!_legendarySet.Contains(i))
                        _nonLegendaryCache.Add(i);
                }
            }

            foreach (var area in areas)
            {
                foreach (var table in area.Tables)
                {
                    if (EvoLevelAdjust)
                        AdjustByEvolution(table);
                    if (LegendEnable)
                        ProcessLegendaries(table);
                    table.Write();
                }
                encdata[area.FileNumber] = Area7.GetDayNightTableBinary(area.Tables);
            }
        }

        private void AdjustByEvolution(EncounterTable table)
        {
            int minLevel = table.MinLevel;
            int maxLevel = table.MaxLevel;
            int totalRange = maxLevel - minLevel;

            // Calculate stage weights from the full level range
            double s0w, s1w, s2w;

            if (totalRange <= 0)
            {
                if (minLevel < EvoMid)      { s0w = 1; s1w = 0; s2w = 0; }
                else if (minLevel >= EvoHigh) { s0w = 0; s1w = 0; s2w = 1; }
                else                         { s0w = 1; s1w = 1; s2w = 1; }
            }
            else
            {
                double low  = Math.Max(0, Math.Min(EvoMid,  maxLevel) - minLevel);
                double mid  = Math.Max(0, Math.Min(EvoHigh, maxLevel) - Math.Max(EvoMid,  minLevel));
                double high = Math.Max(0, maxLevel - Math.Max(EvoHigh, minLevel));

                s0w = low  + mid / 3.0;
                s1w = mid  / 3.0;
                s2w = high + mid / 3.0;
            }

            double totalWeight = s0w + s1w + s2w;
            if (totalWeight <= 0)
                return;

            // Process regular encounter sets (0-7); index 8 is an alias for AdditionalSOS
            for (int set = 0; set < table.Encounter7s.Length - 1; set++)
            {
                var slots = table.Encounter7s[set];
                for (int i = 0; i < slots.Length; i++)
                {
                    var enc = slots[i];
                    int targetStage = RollStage(s0w, s1w, s2w, totalWeight);

                    // Fill empty slots or replace stage-mismatched species
                    if (enc.Species != 0 && enc.Species < _evoChain.EvolutionStage.Length)
                    {
                        int curStage = _evoChain.EvolutionStage[(int)enc.Species];
                        if (curStage == targetStage && !IsLegendary(enc.Species))
                            continue;
                    }

                    int newSpecies = GetRandomSpeciesForStage(targetStage);
                    if (newSpecies > 0)
                    {
                        enc.Species = (uint)newSpecies;
                        enc.Forme = 0;
                    }
                }
            }

            // Process AdditionalSOS separately (only once)
            for (int i = 0; i < table.AdditionalSOS.Length; i++)
            {
                var enc = table.AdditionalSOS[i];
                int targetStage = RollStage(s0w, s1w, s2w, totalWeight);

                if (enc.Species != 0 && enc.Species < _evoChain.EvolutionStage.Length)
                {
                    int curStage = _evoChain.EvolutionStage[(int)enc.Species];
                    if (curStage == targetStage && !IsLegendary(enc.Species))
                        continue;
                }

                int newSpecies = GetRandomSpeciesForStage(targetStage);
                if (newSpecies > 0)
                {
                    enc.Species = (uint)newSpecies;
                    enc.Forme = 0;
                }
            }
        }

        private static int RollStage(double s0w, double s1w, double s2w, double total)
        {
            double roll = Random.Shared.NextDouble() * total;
            if (roll < s0w) return 0;
            if (roll < s0w + s1w) return 1;
            return 2;
        }

        private int GetRandomSpeciesForStage(int targetStage)
        {
            var candidates = new List<int>();
            for (int i = 1; i <= _maxSpeciesId; i++)
            {
                if (i >= _evoChain.EvolutionStage.Length)
                    continue;
                if (_evoChain.EvolutionStage[i] != targetStage)
                    continue;
                if (_legendarySet != null && _legendarySet.Contains(i))
                    continue;
                candidates.Add(i);
            }
            return candidates.Count > 0 ? candidates[Random.Shared.Next(candidates.Count)] : 0;
        }

        private void ProcessLegendaries(EncounterTable table)
        {
            // 地图最高等级未达到阈值 → 清除所有传说宝可梦（含常规+天气）
            if (table.MaxLevel < LegendMinLevel)
            {
                ClearLegendaries(table);
                return;
            }

            // 地图达到阈值：先清除常规遭遇（Encounter7s[0-7]）中的传说，
            // 确保传说只出现在低概率的闯入对战槽中
            ClearLegendariesFromRegular(table);

            // 在低概率列放置传说宝可梦到闯入对战
            for (int col = 0; col < table.Rates.Length; col++)
            {
                if (table.Rates[col] > LegendRate)
                    continue;

                int legendary = GetRandomLegendary();
                if (legendary <= 0) continue;

                if (LegendMoveWeather)
                {
                    // 放入特殊天气闯入对战，随机选槽均匀分布
                    int slotIdx = Random.Shared.Next(table.AdditionalSOS.Length);
                    table.AdditionalSOS[slotIdx].Species = (uint)legendary;
                    table.AdditionalSOS[slotIdx].Forme = 0;
                }
                else
                {
                    // 放入普通闯入对战（Encounter7s[1-7]，随机选一组）
                    int sosSet = Random.Shared.Next(1, 8); // 1-7
                    if (col < table.Encounter7s[sosSet].Length)
                    {
                        table.Encounter7s[sosSet][col].Species = (uint)legendary;
                        table.Encounter7s[sosSet][col].Forme = 0;
                    }
                }
            }
        }

        private void ClearLegendaries(EncounterTable table)
        {
            // 清除所有常规遭遇组中的传说宝可梦，替换为随机非传说
            for (int set = 0; set < table.Encounter7s.Length - 1; set++)
            {
                var slots = table.Encounter7s[set];
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Species > 0 && _legendarySet.Contains((int)slots[i].Species))
                    {
                        slots[i].Species = (uint)GetRandomSpeciesForStage(0);
                        slots[i].Forme = 0;
                    }
                }
            }
            // 清除天气闯入对战中的传说宝可梦
            for (int i = 0; i < table.AdditionalSOS.Length; i++)
            {
                if (table.AdditionalSOS[i].Species > 0 && _legendarySet.Contains((int)table.AdditionalSOS[i].Species))
                {
                    table.AdditionalSOS[i].Species = (uint)GetRandomSpeciesForStage(0);
                    table.AdditionalSOS[i].Forme = 0;
                }
            }
        }

        /// <summary>
        /// 清除常规遭遇组中的传说宝可梦，按地图等级分布替换为合适的非传说物种。
        /// </summary>
        private void ClearLegendariesFromRegular(EncounterTable table)
        {
            for (int set = 0; set < table.Encounter7s.Length - 1; set++)
            {
                var slots = table.Encounter7s[set];
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Species > 0 && _legendarySet.Contains((int)slots[i].Species))
                    {
                        int stage = PickStageForLevel(table.MinLevel, table.MaxLevel);
                        slots[i].Species = (uint)GetRandomSpeciesForStage(stage);
                        slots[i].Forme = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 根据地图等级范围，按 AdjustByEvolution 相同的权重算法选一个进化阶段。
        /// </summary>
        private int PickStageForLevel(int minLevel, int maxLevel)
        {
            int totalRange = maxLevel - minLevel;
            double s0w, s1w, s2w;

            if (totalRange <= 0)
            {
                if (minLevel < EvoMid)      { s0w = 1; s1w = 0; s2w = 0; }
                else if (minLevel >= EvoHigh) { s0w = 0; s1w = 0; s2w = 1; }
                else                         { s0w = 1; s1w = 1; s2w = 1; }
            }
            else
            {
                double low  = Math.Max(0, Math.Min(EvoMid,  maxLevel) - minLevel);
                double mid  = Math.Max(0, Math.Min(EvoHigh, maxLevel) - Math.Max(EvoMid,  minLevel));
                double high = Math.Max(0, maxLevel - Math.Max(EvoHigh, minLevel));
                s0w = low  + mid / 3.0;
                s1w = mid  / 3.0;
                s2w = high + mid / 3.0;
            }

            double total = s0w + s1w + s2w;
            if (total <= 0) return 0;
            return RollStage(s0w, s1w, s2w, total);
        }

        private bool IsLegendary(uint species)
        {
            return _legendarySet != null && species > 0 && (int)species <= _maxSpeciesId
                && _legendarySet.Contains((int)species);
        }

        private int GetRandomLegendary()
        {
            var list = new List<int>(_legendarySet);
            return list.Count > 0 ? list[Random.Shared.Next(list.Count)] : 0;
        }

        private int GetRandomNonLegendary()
        {
            return _nonLegendaryCache.Count > 0
                ? _nonLegendaryCache[Random.Shared.Next(_nonLegendaryCache.Count)]
                : 0;
        }
    }
}
