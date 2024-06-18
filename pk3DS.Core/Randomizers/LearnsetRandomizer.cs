using pk3DS.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pk3DS.Core.Randomizers
{
    // https://twitter.com/Drayano60/status/807297858244411397
    // ORAS: 10682 moves learned on levelup/birth.
    // 5593 are STAB. 52.3% are STAB.
    // Steelix learns the most @ 25 (so many level 1)!
    // Move relearner ingame glitch fixed (52 tested), but keep below 75
    public class LearnsetRandomizer : IRandomizer
    {
        private readonly MoveRandomizer moverand;
        private readonly GameConfig Config;
        private readonly Learnset[] Learnsets;

        public LearnsetRandomizer(GameConfig config, Learnset[] sets)
        {
            Config = config;
            moverand = new MoveRandomizer(config);
            Learnsets = sets;
            STABPercent = 52.3m;
        }

        public bool Expand = true;
        public int ExpandTo = 25;
        public bool Spread = true;
        public int SpreadTo = 75;
        public bool STABFirst = true;
        public bool Learn4Level1 = false;
        public bool OrderByPower = true;

        public bool STAB { set => moverand.rSTAB = value; }
        public IList<int> BannedMoves { set => moverand.BannedMoves = value; }
        public decimal STABPercent { set => moverand.rSTABPercent = value; }

        public void Execute()
        {
            for (var i = 0; i < Learnsets.Length; i++)
                Randomize(Learnsets[i], i);
        }

        private void Randomize(Learnset set, int index)
        {
            int[] moves = GetRandomMoves(set.Count, index);
            int[] levels = GetRandomLevels(set, moves.Length);

            if (Learn4Level1)
            {
                for (int i = 0; i < Math.Min(4, levels.Length); ++i)
                    levels[i] = 1;
            }

            set.Moves = moves;
            set.Levels = levels;
        }

        private int[] GetRandomLevels(Learnset set, int count)
        {
            int[] levels = new int[count];
            if (count == 0)
                return levels;
            //平均分布
            if (Spread)
            {
                levels[0] = 1;
                decimal increment = SpreadTo / (decimal)count;
                for (int i = 1; i < count; i++)
                    levels[i] = (int)(i * increment);
                return levels;
            }

            int baselevel = 1;
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    levels[i] = 1;
                } else
                {
                    int startNum;
                    int endNum;
                    int randNum;

                    //使低等级学习更多招式
                    if (i < 5)
                    {
                        startNum = 1;
                        endNum = 3;
                        randNum = random.Next(startNum, endNum);
                    } else
                    {
                        if (count > 25 && count <= 50)
                        {
                            startNum = 1;
                            endNum = 4;
                            randNum = random.Next(startNum, endNum);
                        }
                        else if (count > 50 && count <= 100)
                        {
                            startNum = 1;
                            endNum = 3;
                            randNum = random.Next(startNum, endNum);
                        } else
                        {
                            startNum = 1;
                            endNum = 6;
                            randNum = random.Next(startNum, endNum);
                        }
                    }
                    levels[i] = Math.Min(baselevel + randNum, 100);
                    baselevel += randNum;
                }
            }

            return levels;
        }

        private int[] GetRandomMoves(int count, int index)
        {
            count = Expand ? ExpandTo : count;

            int[] moves = new int[count];
            if (count == 0)
                return moves;
            moves[0] = STABFirst ? moverand.GetRandomFirstMove(index) : MoveRandomizer.GetRandomFirstMoveAny();
            var rand = moverand.GetRandomLearnset(index, count - 1);

            // STAB Moves (if requested) come first; randomize the order of moves
            Util.Shuffle(rand);
            if (OrderByPower)
                moverand.ReorderMovesPower(rand);
            rand.CopyTo(moves, 1);
            return moves;
        }

        public int[] GetHighPoweredMoves(int species, int form, int count = 4)
        {
            int index = Config.Personal.GetFormIndex(species, form);
            var moves = Learnsets[index].Moves.OrderByDescending(move => Config.Moves[move].Power).Distinct().Take(count).ToArray();
            Array.Resize(ref moves, count);
            return moves;
        }

        public int[] GetCurrentMoves(int species, int form, int level, int count = 4)
        {
            int i = Config.Personal.GetFormIndex(species, form);
            var moves = Learnsets[i].GetEncounterMoves(level);
            Array.Resize(ref moves, count);
            return moves;
        }
    }
}
