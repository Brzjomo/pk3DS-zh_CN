using System.Collections.Generic;
using pk3DS.Core.Structures;

namespace pk3DS.Core.Randomizers
{
    /// <summary>
    /// 从 ROM 进化数据构建进化链关系树。
    /// 用于进化链约束的种族值随机化。
    /// </summary>
    public class EvoChainBuilder
    {
        private readonly EvolutionSet[] _evolutions;

        /// <summary>最大 species ID（含）</summary>
        public int MaxSpeciesId { get; }

        /// <summary>每个 species 的直接前驱 (-1 = 无)</summary>
        public int[] PreEvolution { get; private set; }

        /// <summary>每个 species 的直接后继列表</summary>
        public List<int>[] NextEvolutions { get; private set; }

        /// <summary>是否为最终形态（无后继）</summary>
        public bool[] IsFinalForm { get; private set; }

        /// <summary>进化阶段深度 (0=基础, 1=中间, 2=最终)</summary>
        public int[] EvolutionStage { get; private set; }

        public EvoChainBuilder(EvolutionSet[] evolutions, int maxSpeciesId)
        {
            _evolutions = evolutions;
            MaxSpeciesId = maxSpeciesId;
        }

        public void Build()
        {
            int count = MaxSpeciesId + 1;
            PreEvolution = new int[count];
            NextEvolutions = new List<int>[count];
            IsFinalForm = new bool[count];
            EvolutionStage = new int[count];

            for (int i = 0; i < count; i++)
            {
                PreEvolution[i] = -1;
                NextEvolutions[i] = new List<int>();
            }

            // 构建前驱/后继映射
            for (int i = 1; i < count; i++)
            {
                if (i >= _evolutions.Length)
                {
                    IsFinalForm[i] = true;
                    continue;
                }

                var evos = _evolutions[i]?.PossibleEvolutions;
                if (evos == null)
                {
                    IsFinalForm[i] = true;
                    continue;
                }

                bool hasEvolution = false;
                foreach (var evo in evos)
                {
                    if (evo.Species > 0 && evo.Species != i && evo.Species < count)
                    {
                        hasEvolution = true;
                        NextEvolutions[i].Add(evo.Species);
                        // 记录前驱（仅第一个，用于建链）
                        if (PreEvolution[evo.Species] == -1)
                            PreEvolution[evo.Species] = i;
                    }
                }
                IsFinalForm[i] = !hasEvolution;
            }

            // BFS 计算阶段深度
            var visited = new bool[count];
            var queue = new Queue<int>();

            for (int i = 1; i < count; i++)
            {
                if (PreEvolution[i] == -1)
                {
                    EvolutionStage[i] = 0;
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (int next in NextEvolutions[current])
                {
                    if (!visited[next] && next < count)
                    {
                        visited[next] = true;
                        EvolutionStage[next] = EvolutionStage[current] + 1;
                        queue.Enqueue(next);
                    }
                }
            }

            // 孤立终态标记为 stage 0
            for (int i = 1; i < count; i++)
            {
                if (!visited[i])
                    EvolutionStage[i] = 0;
            }
        }

        /// <summary>获取从指定 species 到基础形态的完整进化链（含自身）</summary>
        public List<int> GetEvoChain(int species)
        {
            var chain = new List<int> { species };
            int current = species;
            while (PreEvolution[current] != -1)
            {
                current = PreEvolution[current];
                chain.Insert(0, current);
            }
            return chain;
        }

        /// <summary>获取最终进化形态（多分支返回所有终端）</summary>
        public List<int> GetTerminalForms(int species)
        {
            var terminals = new List<int>();
            CollectTerminals(species, terminals);
            return terminals;
        }

        private void CollectTerminals(int species, List<int> terminals)
        {
            if (IsFinalForm[species])
            {
                terminals.Add(species);
                return;
            }
            foreach (int next in NextEvolutions[species])
                CollectTerminals(next, terminals);
        }
    }
}
