using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    //problems from week 4: How Do We Assemble Genomes? (Part 1)
    public static class AssembleGenomes
    {
        //1. String Composition Problem
        public static List<string> StringComposition(int k, string inp)
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= inp.Length - k; i++)
            {
                result.Add(inp.Substring(i, k));
            }

            result.Sort();

            return result;
        }

        //2. Overlap graph problem

        //### usage start
        //List<string> input = Helper.ParseTextFileToStrings();
        //List<string> output = AssembleGenomes.DirectedGraph(input);
        //Helper.WriteStringsToTextFile(output);
        //### usage end

        public static List<string> DirectedGraph(List<string> input)
        {
            List<KeyValuePair<string, string>> dict = DirectedGraphDict(input);
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                result.Add(kvp.Key + " -> " + kvp.Value);
            }
            return result;
        }

        private static List<KeyValuePair<string, string>> DirectedGraphDict(List<string> input)
        {
            input.Sort();
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            foreach (string s in input)
            {
                string suf = s.Substring(1, s.Length - 1);
                foreach (string s2 in input)
                {
                    string pref = s2.Substring(0, s.Length - 1);
                    if (suf == pref)
                    {
                        string entry = s + " -> " + s2;
                        result.Add(new KeyValuePair<string, string>(s, s2));
                    }
                }
            }
            return result;
        }

        //3. De Bruijn Graph from a String Problem
        //### usage start
        //List<string> output = AssembleGenomes.DeBruijnGraphFromString("CGGTCTGACGTGATCAACAAGTGTTGGTTAATTACTACGAGAGATCCGTTCACATTCCACCGGGACGTCTACAACAGAGGGCCTGTCTGTGAATTACCGTGTTAGTGGTAATGCCTAAGTTGCCGCGTGGACTGGTGGGGTAGAATTCAATTGTTGTGCTACATCTTACCTCTGCCGAATATGTGGTGTCAATAGATAACTTCCCGAGGACTCTAAAAGAGTCCTTGGCTTGACCATCCAAACTGAAAGGGTATGACGCCGGGGTCCAGACGTACCTGGTAGTTAAATGAACTGAGAATTACATTATGCAAATCGACGGGAGCGCTTCTCTCGGGGCCTAGAGCGTTGGCAGGATACAGGTTGGTGGAGCAGCAGTTTAGAGATTCAGATGCCCAATACTACGAAGCAACAGTCTACTGGTTGGTTCGGAGGATCCTACAAGACGATTCAGGTAAGCCAGAATGGGTCGTGCAGATCGGATAGATCTCTTCTGATTCGGTCGACGTCTTCCATGGTGTCAAAGGTGCGTTTAAAGATACTTAGTATATAGGGGTTTTCCCAACAACCATTATTGCTCTCTTCGGTTCCATTAAATGTGCCGAGCAAATCATTACATAGTCGGATTGCGCTGCCTAGTCACCATGTGGTTCACACGGAACTACGAACGTCCTTGGGTCAAGCACCGACCCTAGCCATCCGTCGAAAATGCGGCCTCTTACGCGGAGCAGAGGGGATTAGGATAGCTCCCTTAAGAATGGGTCGCACATTTCGCGGCGATCCATTCATAAATACTTCAGAAGTAACGTTGCTAGGCGTTCAACAACAAAGGCGAAGAAAGCTGCCATTTTGGACGAGGTGGTTTGACTGACACGCAGAGCGGGGCTTTCTATACTCCATCTCGCTGTCCGACGCGGGGGTGTTTATATCGCGACTCCCCCTTAACGATGTATGCGCTACACGCTGCTTCAGACCAGTGGATCATATGAAAGGACCGAGCGTAACAGCCGGGACGGGGTATAGGACTGCACCTCTGCAGATTGCATGGGCCTCTGCGAAATCACGTTAGCTACTCTTATCGCCCCGATTACGCAAGTCAGGCCACATCGGCGGGCAGAGCTTGCAGTGCGGCGTGGCATTAGCGATATATAGTATTGGTCTTGCGCGTATTAGCGCACCACGATGCCCCAATATAGGAGTAGGGACCATCGGTGACGAGACTACATGCGAGCGCTGCCCTCCTACCCTCGAACACTGTTAAGTGTTTAATTCTAACAGCGGTCCATGCGCCTATAGACATATCGCAAACGAGAGCACCCTGACTAGATCCGCTTGGGCTTATACTTCAAGCCCCATGCCGAGAAACGGGATGTGTGGAACCCTGGCCATGCCCTGCGCGATCGATGTTAGTCATTGGATGGCCTCATAGCGCCATGGTATAATGTTTCGCTATTAGGTAGATCGTAGCCGGGATAGACTGGACTATGACCGAATGTCATAAGGCCGTTCGACAAGTCCGGTCACTTCATCGATCACACTCCAGTAGTGACAGTGTCCGTACCGCCGTGGAGTAGAGCCCATATTACTGGGCGCTAGAGGCAGCCCTTTAATGAGAGGTATCCGGTAGTTATACAGCTGTTCGGCCGCCACTTCGGATGGCGCAGGTTGACGTACGCCCACGCCTCCCAAATCTACTTGCATAGTGCCTATACGAAGTGTCGTAAATCGACAACACGCCGAAAGGGCGGCCGACGTCGCATAGCACGCTGCCAGACCTTCTGAACACGAGCGGTTTAACTTTGGTCGATTGCTACGAAACCGTCTGGCGCTTTATACGGCCCGTCTCCGGGCTTCCGACATTAGACTTAAGGCAACCAGTCAAATAATTCATCTCATCAGAATAGTTGGTTGAAGTGTTGGCCAGAGTCGTAAGTAGGGATCCCCGGCCGGATCCGACCGGGACTTTCCCTCGTTTTTCACCCGGTACGGACATGAGTCAATTA", 12);
        //Helper.WriteStringsToTextFile(output);
        //### usage end

        public static List<string> DeBruijnGraphFromString(string input, int len)
        {
            List<string> result = new List<string>();
            List<string> composition = StringComposition(len, input);

            Dictionary<string, string> dict = GraphFromComposition(composition);

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                result.Add(kvp.Key + " -> " + kvp.Value);
            }

            return result;
        }

        private static Dictionary<string, string> GraphFromComposition(List<string> composition)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (string s in composition)
            {
                string pref = s.Substring(0, s.Length - 1);
                string suff = s.Substring(1, s.Length - 1);

                if (dict.ContainsKey(pref))
                {
                    dict[pref] = dict[pref] + "," + suff;
                }
                else
                {
                    dict.Add(pref, suff);
                }
            }
            return dict;
        }

        //4. De Bruijn Graph from k-mers Problem
        //### usage start
        //List<string> input = Helper.ParseTextFileToStrings();
        //List<string> output = AssembleGenomes.DeBruijnGraphFromKmers(input);
        //Helper.WriteStringsToTextFile(output);        
        //### usage end
        public static List<string> DeBruijnGraphFromKmers(List<string> input)
        {
            Dictionary<string, string> dict = GraphFromComposition(input);

            List<string> result = new List<string>();

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                result.Add(kvp.Key + " -> " + kvp.Value);
            }

            return result;
        }

        //5. Eulerian Cycle Problem 
        //### usage start
        //List<KeyValuePair<int, List<int>>> graph = Helper.ParseDirectedGraph();
        //List<int> result = AssembleGenomes.EulerianCycle(graph);

        //string formattedResult = string.Empty;
        //foreach (int i in result)
        //{
        //    formattedResult = formattedResult + i + "->";
        //}
        //### usage end
        public static List<int> EulerianCycle(List<KeyValuePair<int, List<int>>> graph)
        {
            //    EULERIANCYCLE(Graph)
            //form a cycle Cycle by randomly walking in Graph (never visit an edge twice!)

            List<KeyValuePair<int, List<int>>> remainingGraph = new List<KeyValuePair<int, List<int>>>();
            List<int> cycle = GraphHelper.GetFirstCycleInGraph(graph, out remainingGraph);

            //while there are unexplored edges

            while (remainingGraph.Count() > 0)
            {
                //Debug.WriteLine(remainingGraph.Count());
                //    select a node newStart in Cycle with still unexplored edges
                //    form Cycle’ by traversing Cycle (starting at newStart) and randomly walking
                KeyValuePair<int, List<int>> pair = remainingGraph.FirstOrDefault(kvp => cycle.Contains(kvp.Key));
                cycle = GraphHelper.RearrangeCycle(cycle, pair.Key);
                cycle = GraphHelper.GetCycleInGraph(graph, remainingGraph, cycle);

                //    Cycle ← Cycle’
                //cycle = CombineCycles(cycle, cycle2);
            }
            return cycle;
        }

        //6. Eulerian Path Problem
        //### usage start
        //List<KeyValuePair<int, List<int>>> graph = Helper.ParseDirectedGraph();
        //List<int> result = AssembleGenomes.EulerianPath(graph);

        //string formattedResult = string.Empty;
        //foreach (int i in result)
        //{
        //    formattedResult = formattedResult + i + "->";
        //}
        //### usage end
        public static List<int> EulerianPath(List<KeyValuePair<int, List<int>>> graph)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            foreach (KeyValuePair<int, List<int>> kvp in graph)
            {
                for (int i = 0; i < kvp.Value.Count(); i++)
                {
                    left.Add(kvp.Key);
                }
                right.AddRange(kvp.Value);
            }

            int unbalancedLeft = 0;
            int unbalancedRight = 0;

            while (left.Count > 0)
            {
                int val = left[0];
                if (right.Contains(val))
                {
                    right.Remove(val);
                    left.Remove(val);
                }
                else
                {
                    unbalancedLeft = val;
                    left.Remove(val);
                }
            }

            unbalancedRight = right[0];

            graph.Insert(0, new KeyValuePair<int, List<int>>(unbalancedRight, new List<int> { unbalancedLeft }));

            List<int> result = EulerianCycle(graph);

            List<int> key1List = Enumerable.Range(0, result.Count).Where(i => result[i] == unbalancedRight).ToList();

            result = GraphHelper.BreakCycle(result, unbalancedRight, unbalancedLeft);

            result.RemoveAt(result.Count - 1);

            return result;
        }

        //7. String reconstruction problem
        //### usage start
        //List<KeyValuePair<string, List<string>>> graph = Helper.ParseStringGraph();
        //string res = AssembleGenomes.StringReconstruction(graph);
        //### usage end
        public static string StringReconstruction(List<KeyValuePair<string, List<string>>> graph)
        {
            List<KeyValuePair<int, List<int>>> intgraph = new List<KeyValuePair<int, List<int>>>();
            Dictionary<int, string> DictStringToInt = GraphHelper.MapStringToIntGraph(graph, out intgraph);
            List<int> path = AssembleGenomes.EulerianPath(intgraph);

            string result = string.Empty;
            for (int i = 0; i < path.Count; i++)
            {
                int val = path[i];
                string str = DictStringToInt[val];
                if (i == 0)
                {
                    result = result + str;
                }
                else
                {
                    if (!result.Contains(str)) result = result + str.Substring(str.Length - 1, 1);
                }
            }
            return result;
        }
    }
}
