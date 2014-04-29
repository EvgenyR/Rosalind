using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class GraphHelper
    {
        public static List<int> RearrangeCycle(List<int> cycle, int key)
        {
            List<int> rearrangedCycle = new List<int>();
            int newStart = cycle.IndexOf(key);
            if (newStart > -1)
            {
                for (int i = newStart; i < cycle.Count(); i++)
                {
                    rearrangedCycle.Add(cycle[i]);
                }
                for (int i = 1; i < newStart; i++)
                {
                    rearrangedCycle.Add(cycle[i]);
                }
                rearrangedCycle.Add(rearrangedCycle[0]);
            }
            return rearrangedCycle;
        }

        public static List<int> GetCycleInGraph(List<KeyValuePair<int, List<int>>> graph, List<KeyValuePair<int, List<int>>> resultingGraph, List<int> cycle)
        {
            List<int> result = new List<int>(cycle);
            //start with the first
            KeyValuePair<int, List<int>> pair = new KeyValuePair<int, List<int>>();
            pair = resultingGraph.FirstOrDefault(kvp => kvp.Key == cycle.Last());

            //result.Add(pair.Key);
            result.Add(pair.Value[0]);
            if (pair.Value.Count() > 1)
            {
                resultingGraph[resultingGraph.IndexOf(pair)].Value.Remove(pair.Value[0]);
            }
            else
            {
                resultingGraph.Remove(pair);
            }

            //continue
            bool stuck = false;
            while (!stuck)
            {
                int last = result[result.Count() - 1];
                pair = resultingGraph.FirstOrDefault(kvp => kvp.Key == last);
                if (pair.Value == null)
                {
                    stuck = true;
                    pair = resultingGraph.FirstOrDefault(kvp => kvp.Key == last && result.Contains(kvp.Value[0]) && kvp.Value.Count() == 1);
                    if (pair.Value != null)
                    {
                        result.Add(pair.Value[0]);
                        resultingGraph.Remove(pair);
                    }
                }
                else
                {
                    result.Add(pair.Value[0]);
                    if (pair.Value.Count() > 1)
                    {
                        pair.Value.Remove(pair.Value[0]);
                    }
                    else
                    {
                        resultingGraph.Remove(pair);
                    }
                }
            }

            return result;
        }

        public static List<int> GetFirstCycleInGraph(List<KeyValuePair<int, List<int>>> graph, out List<KeyValuePair<int, List<int>>> resultingGraph)
        {
            List<int> result = new List<int>();

            resultingGraph = CloneGraph(graph);
            //start with the first
            KeyValuePair<int, List<int>> pair = new KeyValuePair<int, List<int>>();
            pair = resultingGraph[0];

            result.Add(pair.Key);
            result.Add(pair.Value[0]);
            if (pair.Value.Count() > 1)
            {
                resultingGraph[resultingGraph.IndexOf(pair)].Value.Remove(pair.Value[0]);
            }
            else
            {
                resultingGraph.Remove(pair);
            }

            //continue
            bool stuck = false;
            while (!stuck)
            {
                int last = result[result.Count() - 1];
                pair = resultingGraph.FirstOrDefault(kvp => kvp.Key == last);
                if (pair.Value == null)
                {
                    stuck = true;
                    pair = resultingGraph.FirstOrDefault(kvp => kvp.Key == last && result.Contains(kvp.Value[0]) && kvp.Value.Count() == 1);
                    if (pair.Value != null)
                    {
                        result.Add(pair.Value[0]);
                        resultingGraph.Remove(pair);
                    }
                }
                else
                {
                    result.Add(pair.Value[0]);
                    if (pair.Value.Count() > 1)
                    {
                        pair.Value.Remove(pair.Value[0]);
                    }
                    else
                    {
                        resultingGraph.Remove(pair);
                    }
                }
            }

            return result;
        }

        private static List<KeyValuePair<int, List<int>>> CloneGraph(List<KeyValuePair<int, List<int>>> graph)
        {
            List<KeyValuePair<int, List<int>>> result = new List<KeyValuePair<int, List<int>>>();
            foreach (KeyValuePair<int, List<int>> kvp in graph)
            {
                result.Add(new KeyValuePair<int, List<int>>(kvp.Key, new List<int>(kvp.Value)));
            }
            return result;
        }

        public static List<int> BreakCycle(List<int> cycle, int key1, int key2)
        {
            List<int> rearrangedCycle = new List<int>();
            List<int> key1List = Enumerable.Range(0, cycle.Count).Where(i => cycle[i] == key1).ToList();

            foreach (int val in key1List)
            {
                if (cycle[val + 1] == key2)
                {
                    int newStart = val + 1;
                    for (int i = newStart; i < cycle.Count(); i++)
                    {
                        rearrangedCycle.Add(cycle[i]);
                    }
                    for (int i = 1; i < newStart; i++)
                    {
                        rearrangedCycle.Add(cycle[i]);
                    }
                    rearrangedCycle.Add(rearrangedCycle[0]);
                    return rearrangedCycle;
                }
            }

            return null;
        }

        public static Dictionary<int, string> MapStringToIntGraph(List<KeyValuePair<string, List<string>>> graph, out List<KeyValuePair<int, List<int>>> intgraph)
        {
            List<KeyValuePair<int, List<int>>> mappedGraph = new List<KeyValuePair<int, List<int>>>();
            Dictionary<int, string> result = new Dictionary<int, string>();

            int i = 1;

            foreach (KeyValuePair<string, List<string>> kvp in graph)
            {
                int newKvpKey = 0;
                List<int> newKvpValue = new List<int>();
                string key = kvp.Key;
                if (!result.ContainsValue(key))
                {
                    result.Add(i, key);
                    newKvpKey = i;
                    i++;
                }
                else
                {
                    newKvpKey = result.First(s => s.Value == key).Key;
                }
                List<string> val = kvp.Value;
                foreach (string str in val)
                {
                    if (!result.ContainsValue(str))
                    {
                        result.Add(i, str);
                        newKvpValue.Add(i);
                        i++;
                    }
                    else
                    {
                        newKvpValue.Add(result.First(s => s.Value == str).Key);
                    }
                }
                mappedGraph.Add(new KeyValuePair<int, List<int>>(newKvpKey, newKvpValue));
            }

            intgraph = mappedGraph;

            return result;
        }

        public static List<KeyValuePair<string, List<string>>> GraphFromComposition2(List<string> composition)
        {
            List<KeyValuePair<string, List<string>>> result = new List<KeyValuePair<string, List<string>>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (string s in composition)
            {
                string pref = s.Substring(0, s.Length - 1);
                string suff = s.Substring(1, s.Length - 1);

                if (dict.ContainsKey(pref))
                {
                    dict[pref].Add(suff);
                }
                else
                {
                    dict.Add(pref, new List<string> { suff });
                }
            }

            foreach (KeyValuePair<string, List<string>> kvp in dict)
            {
                result.Add(kvp);
            }
            return result;
        }
    }
}
