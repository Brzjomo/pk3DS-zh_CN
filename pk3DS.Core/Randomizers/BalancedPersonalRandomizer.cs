using System;
using System.Collections.Generic;
using System.Linq;
using pk3DS.Core.Structures.PersonalInfo;

namespace pk3DS.Core.Randomizers
{
    public class BalancedPersonalRandomizer : PersonalRandomizer
    {
        public BalancedPersonalRandomizer(PersonalInfo[] table, GameConfig game) : base(table, game)
        {
        }

        public new void Execute()
        {
            for (var i = 1; i < Table.Length; i++)
                Randomize(Table[i], i);

            if (TMInheritance)
                PropagateTMs(Table, Evos);
        }

        public new void Randomize(PersonalInfo z, int index)
        {
            if (ModifyLearnsetTM || ModifyLearnsetHM)
            {
                if (!ModifyLearnsetSmartly)
                    RandomizeTMHMSimple(z);
                else
                    RandomizeTMHMAdvanced(z);
            }
            if (ModifyLearnsetTypeTutors)
                RandomizeTypeTutors(z, index);
            if (ModifyLearnsetMoveTutors)
                RandomizeSpecialTutors(z);
            if (ModifyAbilities)
                RandomizeAbilities(z);
            if (ModifyEggGroup)
                RandomizeEggGroups(z);
            if (ModifyHeldItems)
                RandomizeHeldItems(z);
            if (ModifyTypes)
                RandomizeTypes(z);
            if (ModifyCatchRate)
                z.CatchRate = rnd.Next(3, 251);
        }

        /// <summary>
        /// 在进化链约束下分配种族值。
        /// 自底向上：先定终态 BST，再按阶段回溯非终态，确保阶梯式递增。
        /// </summary>
        /// <param name="targetBST">目标种族值总和（普通最终形态的目标值）</param>
        /// <param name="chain">进化链关系</param>
        /// <param name="legendarySpecies">传说宝可梦 species ID 集合</param>
        /// <param name="megaBaseSpecies">拥有 Mega 形态的 base species ID 集合</param>
        public void ExecuteBalanced(
            int targetBST,
            EvoChainBuilder chain,
            IReadOnlyCollection<int> legendarySpecies,
            IReadOnlyCollection<int> megaBaseSpecies)
        {
            int tableLen = Table.Length;
            int maxSpecies = Math.Min(chain.MaxSpeciesId, tableLen - 1);

            var legendarySet = new HashSet<int>(legendarySpecies);
            var megaSet = new HashSet<int>(megaBaseSpecies);

            var assignedBST = new int[tableLen];
            var isFinal = new bool[tableLen];
            var isLegendary = new bool[tableLen];
            var isMegaForm = new bool[tableLen];

            // 分类所有条目（含形态条目）
            for (int i = 1; i < tableLen; i++)
            {
                if (i <= maxSpecies)
                {
                    isFinal[i] = chain.IsFinalForm[i];
                    isLegendary[i] = legendarySet.Contains(i);
                    isMegaForm[i] = megaSet.Contains(i);
                }
                else
                {
                    // 形态条目 → 找基础 species
                    var sf = Game.Personal?.GetSpeciesForm(i, Game);
                    if (sf != null && sf[0] > 0 && sf[0] <= maxSpecies)
                    {
                        int baseSpecies = sf[0];
                        isLegendary[i] = legendarySet.Contains(baseSpecies);
                        isMegaForm[i] = megaSet.Contains(baseSpecies);
                        // 形态条目跟随基础 species 的终态状态
                        isFinal[i] = chain.IsFinalForm[baseSpecies];
                    }
                }
            }

            // ====== Step 1: 分配最终形态 ======
            const int maxBST = 720;

            for (int i = 1; i < tableLen; i++)
            {
                if (!isFinal[i])
                    continue;
                if (Table[i] == null)
                    continue;
                if (Table[i].HP == 1 && Table[i].BST < 50)
                    continue; // 保护脱壳忍者

                int bst;
                if (isLegendary[i] && isMegaForm[i])
                    bst = Math.Min(maxBST, targetBST + rnd.Next(200, 261));
                else if (isLegendary[i])
                    bst = Math.Min(maxBST, targetBST + rnd.Next(100, 201));
                else if (isMegaForm[i])
                    bst = Math.Min(maxBST, targetBST + rnd.Next(80, 151));
                else
                    bst = targetBST;

                assignedBST[i] = bst;
            }

            // ====== Step 2: 按阶段从高到低分配非终态 ======
            int maxStage = chain.EvolutionStage.Max();

            // 阶段 → 各阶段距离终态的步数（仅对进化链范围内的 species）
            var distToFinal = new int[tableLen];
            int chainLen = Math.Min(tableLen, chain.NextEvolutions.Length);
            for (int i = 0; i < chainLen; i++)
                distToFinal[i] = CalcDistToFinal(i, chain);

            for (int stage = maxStage; stage >= 0; stage--)
            {
                for (int i = 1; i <= maxSpecies; i++)
                {
                    if (isFinal[i]) continue;
                    if (chain.EvolutionStage[i] != stage) continue;
                    if (i >= Table.Length || Table[i] == null) continue;
                    if (Table[i].HP == 1) continue; // 保护脱壳忍者

                    var nextList = chain.NextEvolutions[i];
                    if (nextList == null || nextList.Count == 0) continue;

                    // 取所有进化形态中最低的 BST
                    int minEvoBST = int.MaxValue;
                    foreach (int n in nextList)
                    {
                        if (n < assignedBST.Length && assignedBST[n] > 0 && assignedBST[n] < minEvoBST)
                            minEvoBST = assignedBST[n];
                    }
                    if (minEvoBST == int.MaxValue) continue;

                    // ---- 上限 ----
                    int upperByGap = minEvoBST - 1;
                    double ratioCap = (distToFinal[i] >= 2) ? 0.70 : 0.85;
                    int upperByRatio = (int)(minEvoBST * ratioCap);
                    int effectiveMax = Math.Min(upperByGap, upperByRatio);

                    // ---- 下限 ----
                    int minGap = (distToFinal[i] >= 2) ? 60 : 40;
                    int lowerByGap = Math.Max(10, minEvoBST - minGap);
                    double ratioFloor = (distToFinal[i] >= 2) ? 0.55 : 0.60;
                    int lowerByRatio = Math.Max(10, (int)(minEvoBST * ratioFloor));
                    int effectiveMin = Math.Max(lowerByGap, lowerByRatio);

                    if (effectiveMin > effectiveMax)
                        effectiveMin = effectiveMax;

                    int newBST = rnd.Next(effectiveMin, effectiveMax + 1);
                    assignedBST[i] = newBST;
                }
            }

            // ====== Step 3: 分配 6 维属性 ======
            for (int i = 1; i < tableLen; i++)
            {
                if (assignedBST[i] == 0) continue;
                if (i >= Table.Length || Table[i] == null) continue;

                // 给还没被分配的非终态一个兜底
                if (isFinal[i] && assignedBST[i] == 0)
                    assignedBST[i] = targetBST;

                if (assignedBST[i] <= 0) continue;

                // 特殊保护：脱壳忍者
                if (Table[i].HP == 1 && Table[i].BST < 50)
                {
                    Table[i].Stats = new[] { 1, 90, 45, 40, 30, 30 };
                    continue;
                }

                DistributeStats(Table[i], assignedBST[i]);
            }
        }

        /// <summary>计算 species 到最近终态的步数</summary>
        private static int CalcDistToFinal(int species, EvoChainBuilder chain)
        {
            if (chain.IsFinalForm[species])
                return 0;
            int maxDist = 0;
            foreach (int next in chain.NextEvolutions[species])
            {
                if (next >= chain.NextEvolutions.Length) continue;
                int d = CalcDistToFinal(next, chain);
                if (d + 1 > maxDist) maxDist = d + 1;
            }
            return maxDist;
        }

        /// <summary>将 totalBST 按比例分配到 6 维属性</summary>
        private static void DistributeStats(PersonalInfo info, int totalBST)
        {
            var r1 = Math.Max(1, (int)(totalBST * 0.25));
            var r2 = Math.Max(1, (int)(totalBST * 0.20));
            var r3 = Math.Max(1, (int)(totalBST * 0.17));
            var r4 = Math.Max(1, (int)(totalBST * 0.17));
            var r5 = Math.Max(1, (int)(totalBST * 0.10));
            var r6 = Math.Max(1, totalBST - r1 - r2 - r3 - r4 - r5);

            var v1 = Variate(r1, 0.15);
            var v2 = Variate(r2, 0.17);
            var v3 = Variate(r3, 0.18);
            var v4 = Variate(r4, 0.18);
            var v5 = Variate(r5, 0.22);
            var v6 = Variate(r6, 0.15);

            int[] stats = [v1, v2, v3, v4, v5, v6];
            ShuffleWithPattern(stats);

            stats = stats.Select(s => Math.Clamp(s, 1, 255)).ToArray();
            info.Stats = stats;
        }

        /// <summary>在指定值附近 ±rate 随机波动</summary>
        private static int Variate(int value, double rate)
        {
            int low = Math.Max(1, (int)(value * (1.0 - rate)));
            int high = Math.Max(low + 1, (int)(value * (1.0 + rate)));
            return Util.Rand.Next(low, high);
        }

        /// <summary>对 6 维进行不同模式的排列，增加多样性</summary>
        private static void ShuffleWithPattern(int[] stats)
        {
            if (stats.Length != 6) return;
            var rnd = Util.Rand;
            double d = rnd.NextDouble();

            int[] indices = d switch
            {
                < 0.25 => [1, 0, 2, 3, 4, 5],
                < 0.50 => [1, 3, 2, 4, 0, 5],
                < 0.75 => [5, 3, 0, 4, 2, 1],
                _      => [5, 2, 3, 0, 1, 4],
            };

            int[] result = new int[6];
            for (int i = 0; i < 6; i++)
                result[i] = stats[indices[i]];
            for (int i = 0; i < 6; i++)
                stats[i] = result[i];
        }
    }
}
