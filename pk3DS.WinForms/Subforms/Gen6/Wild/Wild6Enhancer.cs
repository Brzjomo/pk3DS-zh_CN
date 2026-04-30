using System;
using System.Collections.Generic;
using System.Windows.Forms;
using pk3DS.Core;
using pk3DS.Core.Randomizers;

namespace pk3DS.WinForms
{
    public class Wild6Enhancer
    {
        // === 配置属性 ===
        public bool EvoLevelAdjust { get; set; }

        public bool LegendEnable { get; set; }
        public int LegendMinLevel { get; set; } = 40;
        public int LegendRate { get; set; } = 1;

        // === 数据属性（通过 WinForms 控件数组传递） ===
        public ComboBox[] AllSpecies { private get; set; }
        public NumericUpDown[] AllMin { private get; set; }
        public NumericUpDown[] AllMax { private get; set; }

        // === 槽位总数（61 for ORAS, 94 for XY） ===
        public int SlotCount { private get; set; }

        // === 概率表（硬编码，由 RSWE/XYWE 传入） ===
        public int[] SlotRates { private get; set; }

        // === 内部数据 ===
        private EvoChainBuilder _evoChain;
        private HashSet<int> _legendarySet;
        private int _maxSpeciesId;

        public void Execute()
        {
            _maxSpeciesId = Main.Config.MaxSpeciesID;

            // 始终构建进化链，供 AdjustByEvolution 和传说清除使用
            _evoChain = new EvoChainBuilder(Main.Config.Evolutions, _maxSpeciesId);
            _evoChain.Build();

            if (LegendEnable)
            {
                _legendarySet = new HashSet<int>(Legal.Legendary_6);
                foreach (var m in Legal.Mythical_6)
                    _legendarySet.Add(m);
            }

            // 计算地图最高等级（所有槽位 MaxLevel 的最大值），用于传说等级阈值判断
            int maxMapLevel = 0;
            for (int i = 0; i < SlotCount; i++)
            {
                int level = (int)AllMax[i].Value;
                if (level > maxMapLevel) maxMapLevel = level;
            }

            // Pass 1: 进化链等级调整
            if (EvoLevelAdjust)
            {
                for (int i = 0; i < SlotCount; i++)
                    AdjustSlotByEvolution(i);
            }

            // Pass 2: 传说宝可梦处理
            if (LegendEnable)
            {
                // 清除所有槽位中的传说
                for (int i = 0; i < SlotCount; i++)
                    ClearSlotLegendary(i);

                // 地图达到等级阈值时，在低概率路上/水中槽放置传说
                if (maxMapLevel >= LegendMinLevel)
                    PlaceLegendaries();
            }

            // Pass 3: 群聚类型统一（仅 ORAS，独立于功能开关）
            if (SlotCount == 61)
                NormalizeSwarmTypes();
        }

        /// <summary>
        /// 统一 ORAS 群聚 3 槽（24-26）的宝可梦属性。
        /// 确保同群聚组的宝可梦至少共享一个属性。
        /// </summary>
        private void NormalizeSwarmTypes()
        {
            const int swarmStart = 24;
            const int swarmEnd = 27; // exclusive

            // 收集已填充的群聚槽物种
            int[] species = new int[3];
            int filled = 0;
            for (int i = swarmStart; i < swarmEnd; i++)
            {
                species[i - swarmStart] = AllSpecies[i].SelectedIndex;
                if (species[i - swarmStart] > 0 && species[i - swarmStart] <= _maxSpeciesId)
                    filled++;
            }

            if (filled < 2)
                return; // 少于 2 个已填充，无需统一

            // 找出已填充物种的共同属性
            var commonTypes = new HashSet<int>();
            bool first = true;
            for (int i = 0; i < 3; i++)
            {
                if (species[i] <= 0 || species[i] > _maxSpeciesId) continue;
                var types = Main.SpeciesStat[species[i]].Types;
                if (types == null) continue;

                var typeSet = new HashSet<int>();
                foreach (int t in types) { if (t >= 0) typeSet.Add(t); }

                if (first)
                {
                    commonTypes = typeSet;
                    first = false;
                }
                else
                {
                    commonTypes.IntersectWith(typeSet);
                }
            }

            // 有共同属性则无需修改
            if (commonTypes.Count > 0)
                return;

            // 无共同属性：以第一个填充槽的属性为基准，替换其他槽
            int baseSlot = -1;
            var baseTypes = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                if (species[i] <= 0 || species[i] > _maxSpeciesId) continue;
                if (baseSlot >= 0) break;
                baseSlot = swarmStart + i;
                var types = Main.SpeciesStat[species[i]].Types;
                if (types != null)
                {
                    foreach (int t in types) { if (t >= 0) baseTypes.Add(t); }
                }
            }

            if (baseSlot < 0 || baseTypes.Count == 0)
                return;

            for (int i = swarmStart; i < swarmEnd; i++)
            {
                if (i == baseSlot) continue;
                if (AllSpecies[i].SelectedIndex <= 0) continue;

                var curTypes = Main.SpeciesStat[AllSpecies[i].SelectedIndex].Types;
                if (curTypes != null)
                {
                    bool hasMatch = false;
                    foreach (int t in curTypes)
                    {
                        if (baseTypes.Contains(t)) { hasMatch = true; break; }
                    }
                    if (hasMatch) continue; // 已有匹配属性，保留
                }

                // 替换为与基准类型匹配的物种
                int curStage = AllSpecies[i].SelectedIndex < _evoChain.EvolutionStage.Length
                    ? _evoChain.EvolutionStage[AllSpecies[i].SelectedIndex]
                    : 0;
                int newSpecies = GetRandomSpeciesForStage(curStage, baseTypes);
                if (newSpecies > 0)
                    AllSpecies[i].SelectedIndex = newSpecies;
            }
        }

        /// <summary>
        /// 对单个槽位根据其等级范围进行进化链调整。
        /// 传说宝可梦也会被替换（由 Pass 2 统一处理放置）。
        /// </summary>
        private void AdjustSlotByEvolution(int slotIndex)
        {
            int species = AllSpecies[slotIndex].SelectedIndex;
            int minLevel = (int)AllMin[slotIndex].Value;
            int maxLevel = (int)AllMax[slotIndex].Value;

            // 无等级数据时跳过
            if (minLevel <= 0 && maxLevel <= 0)
                return;

            // 若某一端为 0，用另一端代替
            if (minLevel <= 0) minLevel = maxLevel;
            if (maxLevel <= 0) maxLevel = minLevel;

            GetStageWeights(minLevel, maxLevel, out double s0w, out double s1w, out double s2w);
            double totalWeight = s0w + s1w + s2w;
            if (totalWeight <= 0)
                return;

            int targetStage = RollStage(s0w, s1w, s2w, totalWeight);

            // 非空且阶段匹配且非传说 → 保留
            if (species > 0 && species < _evoChain.EvolutionStage.Length)
            {
                int curStage = _evoChain.EvolutionStage[species];
                if (curStage == targetStage && !IsLegendary(species))
                    return;
            }

            // 替换为阶段合适的非传说物种（群聚槽优先同属性）
            int newSpecies = GetRandomSpeciesForStage(targetStage, GetSwarmPreferredTypes(slotIndex));
            if (newSpecies > 0)
                AllSpecies[slotIndex].SelectedIndex = newSpecies;
        }

        /// <summary>
        /// 获取群聚槽位（ORAS 24-26）的偏好属性集合。
        /// 收集同群聚组中其他已填充槽位的属性，使替换物种保持属性一致。
        /// </summary>
        private HashSet<int> GetSwarmPreferredTypes(int slotIndex)
        {
            if (!IsSwarmSlot(slotIndex))
                return null;

            var types = new HashSet<int>();
            for (int i = 24; i <= 26; i++)
            {
                if (i == slotIndex) continue;
                int species = AllSpecies[i].SelectedIndex;
                if (species <= 0 || species > _maxSpeciesId) continue;

                var speciesTypes = Main.SpeciesStat[species].Types;
                if (speciesTypes == null) continue;
                foreach (int t in speciesTypes)
                {
                    if (t >= 0) types.Add(t);
                }
            }
            return types.Count > 0 ? types : null;
        }

        private bool IsSwarmSlot(int slotIndex)
        {
            // ORAS 群聚槽位：索引 24-26（3 组）
            return SlotCount == 61 && slotIndex >= 24 && slotIndex <= 26;
        }

        /// <summary>
        /// 清除指定槽位的传说宝可梦，替换为阶段合适的非传说。
        /// </summary>
        private void ClearSlotLegendary(int slotIndex)
        {
            int species = AllSpecies[slotIndex].SelectedIndex;
            if (species <= 0 || species > _maxSpeciesId)
                return;
            if (_legendarySet == null || !_legendarySet.Contains(species))
                return;

            int minLevel = (int)AllMin[slotIndex].Value;
            int maxLevel = (int)AllMax[slotIndex].Value;

            int targetStage = PickStageForLevel(minLevel, maxLevel);
            int newSpecies = GetRandomSpeciesForStage(targetStage, GetSwarmPreferredTypes(slotIndex));
            if (newSpecies > 0)
                AllSpecies[slotIndex].SelectedIndex = newSpecies;
        }

        /// <summary>
        /// 在符合条件的路上组/水中组低概率槽位中放置传说宝可梦。
        /// 仅当槽位概率 &lt;= LegendRate 时才放置。
        /// </summary>
        private void PlaceLegendaries()
        {
            for (int i = 0; i < SlotCount; i++)
            {
                if (!IsLandOrWaterSlot(i))
                    continue;
                if (SlotRates == null || i >= SlotRates.Length)
                    continue;
                if (SlotRates[i] > LegendRate)
                    continue;

                int legendary = GetRandomLegendary();
                if (legendary <= 0) continue;

                AllSpecies[i].SelectedIndex = legendary;
            }
        }

        private static readonly (int Min, int Max, double S0, double S1, double S2)[] _stageDistributions =
        {
            (1, 15,  0.80, 0.20, 0.00),
            (16, 30, 0.15, 0.80, 0.05),
            (31, 55, 0.00, 0.20, 0.80),
            (56, 100, 0.00, 0.00, 1.00),
        };

        private static void GetStageWeights(int minLevel, int maxLevel,
            out double s0w, out double s1w, out double s2w)
        {
            s0w = s1w = s2w = 0;
            foreach (var band in _stageDistributions)
            {
                int overlapStart = Math.Max(minLevel, band.Min);
                int overlapEnd = Math.Min(maxLevel, band.Max);
                int overlap = Math.Max(0, overlapEnd - overlapStart + 1);
                if (overlap <= 0) continue;
                s0w += overlap * band.S0;
                s1w += overlap * band.S1;
                s2w += overlap * band.S2;
            }
        }

        /// <summary>
        /// 根据等级范围选择目标进化阶段。
        /// </summary>
        private int PickStageForLevel(int minLevel, int maxLevel)
        {
            if (minLevel <= 0 && maxLevel <= 0)
                return 0;

            if (minLevel <= 0) minLevel = maxLevel;
            if (maxLevel <= 0) maxLevel = minLevel;

            GetStageWeights(minLevel, maxLevel, out double s0w, out double s1w, out double s2w);
            double total = s0w + s1w + s2w;
            if (total <= 0) return 0;
            return RollStage(s0w, s1w, s2w, total);
        }

        private static int RollStage(double s0w, double s1w, double s2w, double total)
        {
            double roll = Random.Shared.NextDouble() * total;
            if (roll < s0w) return 0;
            if (roll < s0w + s1w) return 1;
            return 2;
        }

        /// <summary>
        /// 判断槽位索引是否属于路上组或水中组（可放置传说的组别）。
        /// 根据 SlotCount 自动判断 ORAS (61) 或 XY (94)。
        /// </summary>
        private bool IsLandOrWaterSlot(int slotIndex)
        {
            if (SlotCount == 61) // ORAS
            {
                // 路上组：Grass (0-11), Tall Grass (12-23)
                if (slotIndex < 24) return true;
                // 水中组：Surf (27-31), Old Rod (37-39), Good Rod (40-42), Super Rod (43-45)
                if (slotIndex >= 27 && slotIndex < 32) return true;
                if (slotIndex >= 37 && slotIndex < 46) return true;
            }
            else // XY (94)
            {
                // 路上组：Grass (0-11), Yellow (12-23), Purple (24-35), Red (36-47), RT (48-59)
                if (slotIndex < 60) return true;
                // 水中组：Surf (60-64), Old Rod (70-72), Good Rod (73-75), Super Rod (76-79)
                if (slotIndex >= 60 && slotIndex < 65) return true;
                if (slotIndex >= 70 && slotIndex < 79) return true;
            }
            return false;
        }

        /// <summary>
        /// 从指定进化阶段的非传说候选池中随机选一个物种。
        /// 若指定了偏好属性（群聚用），优先选匹配属性的物种。
        /// </summary>
        private int GetRandomSpeciesForStage(int targetStage, HashSet<int> preferredTypes = null)
        {
            var candidates = new List<int>();
            for (int i = 1; i <= _maxSpeciesId; i++)
            {
                if (i >= _evoChain.EvolutionStage.Length)
                    continue;
                if (_legendarySet != null && _legendarySet.Contains(i))
                    continue;

                bool match = targetStage switch
                {
                    0 => _evoChain.EvolutionStage[i] == 0,
                    1 => _evoChain.EvolutionStage[i] > 0 && !_evoChain.IsFinalForm[i],
                    2 => _evoChain.IsFinalForm[i] && _evoChain.EvolutionStage[i] > 0,
                    _ => false,
                };
                if (!match) continue;
                candidates.Add(i);
            }

            if (candidates.Count == 0)
                return 0;

            // 有偏好属性时，优先从匹配属性中选
            if (preferredTypes != null && preferredTypes.Count > 0)
            {
                var typed = new List<int>();
                foreach (int s in candidates)
                {
                    var types = Main.SpeciesStat[s].Types;
                    if (types == null) continue;
                    foreach (int t in types)
                    {
                        if (preferredTypes.Contains(t))
                        {
                            typed.Add(s);
                            break;
                        }
                    }
                }
                if (typed.Count > 0)
                    return typed[Random.Shared.Next(typed.Count)];
            }

            return candidates[Random.Shared.Next(candidates.Count)];
        }

        private int GetRandomLegendary()
        {
            if (_legendarySet == null || _legendarySet.Count == 0)
                return 0;
            var list = new List<int>(_legendarySet);
            return list[Random.Shared.Next(list.Count)];
        }

        private bool IsLegendary(int species)
        {
            return _legendarySet != null && species > 0 && species <= _maxSpeciesId
                && _legendarySet.Contains(species);
        }
    }
}
