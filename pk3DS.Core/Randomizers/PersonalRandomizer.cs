using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pk3DS.Core.Structures;
using pk3DS.Core.Structures.PersonalInfo;

namespace pk3DS.Core.Randomizers
{
    public class PersonalRandomizer : IRandomizer
    {
        internal readonly Random rnd = Util.Rand;

        internal const decimal LearnTMPercent = 35; // Average Learnable TMs is 35.260.
        internal const decimal LearnTypeTutorPercent = 2; //136 special tutor moves learnable by species in Untouched ORAS.
        internal const decimal LearnMoveTutorPercent = 30; //10001 tutor moves learnable by 826 species in Untouched ORAS.
        internal const int tmcount = 100;
        internal const int eggGroupCount = 16;

        internal readonly GameConfig Game;
        internal readonly PersonalInfo[] Table;

        // Randomization Settings
        public int TypeCount;
        public bool ModifyCatchRate = true;
        public bool ModifyLearnsetTM = true;
        public bool ModifyLearnsetHM = true;
        public bool ModifyLearnsetTypeTutors = true;
        public bool ModifyLearnsetMoveTutors = true;
        public bool ModifyHeldItems = true;

        public bool ModifyAbilities = true;
        public bool AllowWonderGuard = true;

        // 智能捕获率
        public bool ModifyCatchRateSmart;
        public EvoChainBuilder CatchRateChain;
        public IReadOnlyCollection<int> LegendarySpecies;
        public IReadOnlyCollection<int> MegaBaseSpecies;
        public int CatchRateTargetBST = 520;

        public bool ModifyStats = true;
        public bool ShuffleStats = true;
        public decimal StatDeviation = 25;
        public bool[] StatsToRandomize = { true, true, true, true, true, true };

        public bool ModifyTypes = true;
        public decimal SameTypeChance = 50;
        public bool ModifyEggGroup = true;
        public decimal SameEggGroupChance = 50;

        //public bool Advanced { get; set; } = false;
        public bool TMInheritance { get; set; }
        public bool ModifyLearnsetSmartly { get; set; }

        public ushort[] MoveIDsTMs { private get; set; }
        public Move[] Moves => Game.Moves;
        public EvolutionSet[] Evos => Game.Evolutions;

        public PersonalRandomizer(PersonalInfo[] table, GameConfig game)
        {
            Game = game;
            Table = table;
            if (File.Exists("bannedabilites.txt"))
            {
                var data = File.ReadAllLines("bannedabilities.txt");
                var list = new List<int>(BannedAbilities);
                list.AddRange(data.Select(z => Convert.ToInt32(z)));
                BannedAbilities = list;
            }
        }

        public void Execute()
        {
            for (var i = 1; i < Table.Length; i++)
                Randomize(Table[i], i);

            if (TMInheritance)
                PropagateTMs(Table, Evos);
        }

        internal void PropagateTMs(PersonalInfo[] table, EvolutionSet[] evos)
        {
            int specCount = Game.MaxSpeciesID;
            var HandledIndexes = new HashSet<int>();

            for (int species = 1; species <= specCount; species++)
            {
                var entry = table[species];
                PropagateDown(entry, species, 0);
                for (int form = 0; form < entry.FormeCount; form++)
                    PropagateDown(entry, species, form);
            }

            void PropagateDown(PersonalInfo pi, int species, int form)
            {
                int index = pi.FormeIndex(species, form);
                if (index == species && form != 0)
                    return;

                if (index >= evos.Length)
                    index = species;
                PropagateDownIndex(pi, index);
            }

            void PropagateDownIndex(PersonalInfo pi, int index)
            {
                if (HandledIndexes.Contains(index))
                    return;

                var evoList = evos[index];
                foreach (var evo in evoList.PossibleEvolutions.Where(z => z.Species != 0))
                {
                    var espec = evo.Species;
                    var eform = evo.Form;
                    var evoIndex = table[espec].FormeIndex(espec, eform);
                    if (evoIndex >= table.Length)
                        continue;

                    if (!HandledIndexes.Contains(evoIndex))
                        table[evoIndex].TMHM = pi.TMHM;
                    else // pre-evolution encountered! take the higher evolution's TM's since they have been propagated up already...
                        pi.TMHM = table[evoIndex].TMHM;

                    HandledIndexes.Add(evoIndex);
                    PropagateDownIndex(pi, evoIndex); // recurse for the rest of the evo chain
                }
            }
        }

        public void Randomize(PersonalInfo z, int index)
        {
            // Fiddle with Learnsets
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
            if (ModifyStats)
                RandomizeStats(z);
            if (ShuffleStats)
                RandomShuffledStats(z);
            if (ModifyAbilities)
                RandomizeAbilities(z);
            if (ModifyEggGroup)
                RandomizeEggGroups(z);
            if (ModifyHeldItems)
                RandomizeHeldItems(z);
            if (ModifyTypes)
                RandomizeTypes(z);
            if (ModifyCatchRate)
            {
                if (ModifyCatchRateSmart && CatchRateChain != null)
                    z.CatchRate = GenerateCatchRate(index, z.BST, CatchRateChain, CatchRateTargetBST,
                        LegendarySpecies?.Contains(index) == true,
                        MegaBaseSpecies?.Contains(index) == true);
                else
                    z.CatchRate = rnd.Next(3, 251);
            }
        }

        internal void RandomizeTMHMAdvanced(PersonalInfo z)
        {
            var tms = z.TMHM;
            //var types = z.Types;

            bool CanLearn(Move _)
            {
                //var type = m.Type;
                //bool typeMatch = types.Any(t => t == type);
                // todo: how do I learn move?
                return rnd.Next(0, 100) < LearnTMPercent;
            }

            if (ModifyLearnsetTM)
            {
                for (int j = 0; j < tmcount; j++)
                {
                    var moveID = MoveIDsTMs[j];
                    var move = Moves[moveID];
                    tms[j] = CanLearn(move);
                }
            }
            if (ModifyLearnsetHM)
            {
                for (int j = tmcount; j < tms.Length; j++)
                {
                    var moveID = MoveIDsTMs[j];
                    var move = Moves[moveID];
                    tms[j] = CanLearn(move);
                }
            }

            z.TMHM = tms;
        }

        internal void RandomizeTMHMSimple(PersonalInfo z)
        {
            var tms = z.TMHM;

            if (ModifyLearnsetTM)
            {
                for (int j = 0; j < tmcount; j++)
                    tms[j] = rnd.Next(0, 100) < LearnTMPercent;
            }

            if (ModifyLearnsetHM)
            {
                for (int j = tmcount; j < tms.Length; j++)
                    tms[j] = rnd.Next(0, 100) < LearnTMPercent;
            }

            z.TMHM = tms;
        }

        internal void RandomizeTypeTutors(PersonalInfo z, int index)
        {
            var t = z.TypeTutors;
            for (int i = 0; i < t.Length; i++)
                t[i] = rnd.Next(0, 100) < LearnTypeTutorPercent;

            // Make sure Rayquaza can learn Dragon Ascent.
            if (!Game.XY && (index == 384 || index == 814))
                t[7] = true;

            z.TypeTutors = t;
        }

        internal void RandomizeSpecialTutors(PersonalInfo z)
        {
            var tutors = z.SpecialTutors;
            foreach (bool[] tutor in tutors)
            {
                for (int i = 0; i < tutor.Length; i++)
                    tutor[i] = rnd.Next(0, 100) < LearnMoveTutorPercent;
            }

            z.SpecialTutors = tutors;
        }

        internal void RandomizeAbilities(PersonalInfo z)
        {
            var abils = z.Abilities;
            for (int i = 0; i < abils.Length; i++)
                abils[i] = GetRandomAbility();
            z.Abilities = abils;
        }

        internal void RandomizeEggGroups(PersonalInfo z)
        {
            var egg = z.EggGroups;
            egg[0] = GetRandomEggGroup();
            egg[1] = rnd.Next(0, 100) < SameEggGroupChance ? egg[0] : GetRandomEggGroup();
            z.EggGroups = egg;
        }

        internal void RandomizeHeldItems(PersonalInfo z)
        {
            var item = z.Items;
            for (int j = 0; j < item.Length; j++)
                item[j] = GetRandomHeldItem();
            z.Items = item;
        }

        internal void RandomizeTypes(PersonalInfo z)
        {
            var t = z.Types;
            t[0] = GetRandomType();
            t[1] = rnd.Next(0, 100) < SameTypeChance ? t[0] : GetRandomType();
            z.Types = t;
        }

        internal void RandomizeStats(PersonalInfo z)
        {
            // Fiddle with Base Stats, don't muck with Shedinja.
            var stats = z.Stats;
            if (stats[0] == 1)
                return;
            for (int i = 0; i < stats.Length; i++)
            {
                if (!StatsToRandomize[i])
                    continue;
                var l = Math.Min(255, (int) (stats[i] * (1 - (StatDeviation / 100))));
                var h = Math.Min(255, (int) (stats[i] * (1 + (StatDeviation / 100))));
                stats[i] = Math.Max(5, rnd.Next(l, h));
            }
            z.Stats = stats;
        }

        internal void RandomShuffledStats(PersonalInfo z)
        {
            // Fiddle with Base Stats, don't muck with Shedinja.
            var stats = z.Stats;
            if (stats[0] == 1)
                return;

            Util.Shuffle(stats);
            z.Stats = stats;
        }

        internal int GetRandomType() => rnd.Next(0, TypeCount);
        internal int GetRandomEggGroup() => rnd.Next(1, eggGroupCount);
        internal int GetRandomHeldItem() => Game.Info.HeldItems[rnd.Next(1, Game.Info.HeldItems.Length)];
        internal readonly IList<int> BannedAbilities = Array.Empty<int>();

        internal int GetRandomAbility()
        {
            const int WonderGuard = 25;
            int newabil;
            do newabil = rnd.Next(1, Game.Info.MaxAbilityID + 1);
            while ((newabil == WonderGuard && !AllowWonderGuard) || BannedAbilities.Contains(newabil));
            return newabil;
        }

        /// <summary>
        /// 根据进化阶段、Mega 能力、传说状态和 BST 偏差生成智能捕获率。
        /// </summary>
        public static int GenerateCatchRate(
            int species,
            int bst,
            EvoChainBuilder chain,
            int targetBST,
            bool isLegendary,
            bool isMegaBase)
        {
            const int minCatchRate = 15;
            const int maxCatchRate = 255;

            // 传说/幻之宝可梦：直接给低值
            if (isLegendary)
            {
                int legendaryValue = Util.Rand.Next(3, 26); // 3-25
                return Math.Clamp(legendaryValue, minCatchRate, maxCatchRate);
            }

            // 确定进化阶段
            int stage = -1;
            bool isFinal = false;
            bool hasPrevo = false;

            if (species < chain.EvolutionStage.Length)
            {
                stage = chain.EvolutionStage[species];
                isFinal = chain.IsFinalForm[species];
                hasPrevo = chain.PreEvolution[species] != -1;
            }

            // 基础捕获率范围（降上限、扩跨度，避免扎堆 255）
            int minRange, maxRange;

            if (stage <= 0 && isFinal && !hasPrevo)
            {
                // 单形态宝可梦（无进化链）
                minRange = 100; maxRange = 176;
            }
            else if (stage <= 0)
            {
                // 初始形态
                minRange = 130; maxRange = 211;
            }
            else if (stage == 1)
            {
                // 中间形态
                if (isMegaBase)
                    { minRange = 50; maxRange = 106; }
                else
                    { minRange = 75; maxRange = 151; }
            }
            else
            {
                // 最终形态（stage >= 2）
                if (isMegaBase)
                    { minRange = 25; maxRange = 66; }
                else
                    { minRange = 40; maxRange = 96; }
            }

            int baseCatchRate = Util.Rand.Next(minRange, maxRange);

            // BST 修正（仅非传说）
            if (bst > 0)
            {
                double ratio = (double)(bst - targetBST) / targetBST;

                if (ratio > 0)
                {
                    // 高于 Target BST → 更难抓
                    double factor = Math.Min(ratio, 0.5);
                    baseCatchRate = (int)(baseCatchRate * (1.0 - factor));
                }
                else if (ratio < 0)
                {
                    // 低于 Target BST → 更好抓
                    double factor = Math.Min(-ratio, 0.4);
                    baseCatchRate = (int)(baseCatchRate * (1.0 + factor));
                }
            }

            return Math.Clamp(baseCatchRate, minCatchRate, maxCatchRate);
        }
    }
}
