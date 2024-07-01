using pk3DS.Core.Structures.PersonalInfo;
using System;
using System.Diagnostics;

namespace pk3DS.Core.Randomizers
{
    public class BalancedPersonalRandomizer : PersonalRandomizer
    {
        //public bool ifBalanceBST = true;
        //public int targetBST = 520;
        //public bool finalStageOnly = true;
        //public bool includeMegaForm = true;
        //public bool includeLegendary = true;

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
            //if (ModifyStats)
            //    RandomizeStats(z);
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

        internal new void RandomizeStats(PersonalInfo z)
        {
            var stats = z.Stats;
            if (stats[0] == 1)
                return;
            for (int i = 0; i < stats.Length; i++)
            {
                if (!StatsToRandomize[i])
                    continue;
                var l = Math.Min(255, (int)(stats[i] * (1 - (StatDeviation / 100))));
                var h = Math.Min(255, (int)(stats[i] * (1 + (StatDeviation / 100))));
                stats[i] = Math.Max(5, rnd.Next(l, h));
            }
            z.Stats = stats;
        }
    }
}
