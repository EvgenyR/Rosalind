using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    //Problems from Week 6: How Do We Compare Biological Sequences?
    public static class CompareSequences
    {
        //Helper structures
        public static int[,] RightMatrix;
        public static int[,] DownMatrix;
        public static int[,] PathMatrix;

        public static string Result = string.Empty;
        public static string Result2 = string.Empty;

        //1. The change problem
        //Usage: CompareSequences.DPCHANGE(40, "1,5,10,20,25,50");
        public static int DPCHANGE(int val, string denoms)
        {
            int[] idenoms = Array.ConvertAll(denoms.Split(','), int.Parse);
            Array.Sort(idenoms);
            int[] minNumCoins = new int[val + 1];

            minNumCoins[0] = 0;
            for (int m = 1; m <= val; m++)
            {
                minNumCoins[m] = Int32.MaxValue - 1;
                for (int i = 1; i <= idenoms.Count() - 1; i++)
                {
                    if (m >= idenoms[i])
                    {
                        if (minNumCoins[m - idenoms[i]] + 1 < minNumCoins[m])
                        {
                            minNumCoins[m] = minNumCoins[m - idenoms[i]] + 1;
                        }
                    }
                }
            }

            return minNumCoins[val];
        }

        //2. Manhattan tourist
        //input in the form of
        //4 
        //4
        //1 0 2 4 3
        //4 6 5 2 1
        //4 4 5 2 1
        //5 6 8 5 3
        //-
        //3 2 4 0
        //3 2 4 2
        //0 7 3 3
        //3 3 0 2
        //1 3 2 2
        //Answer is in PathMatrix[i, j] (34)
        public static void ManhattanProblem()
        {
            List<string> input = Helper.ParseTextFileToStrings();
            int n = Int32.Parse(input[0]);
            int m = Int32.Parse(input[1]);

            DownMatrix = new int[n, m + 1];
            RightMatrix = new int[n + 1, m];
            PathMatrix = new int[n + 1, m + 1];

            for (int i = 2; i <= 1 + n; i++)
            {
                string[] sp = input[i].Split(' ');
                for (int j = 0; j < m + 1; j++)
                {
                    DownMatrix[i - 2, j] = Int32.Parse(sp[j]);
                }
            }

            for (int i = 3 + n; i <= 3 + 2 * n; i++)
            {
                string[] sp = input[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    RightMatrix[i - n - 3, j] = Int32.Parse(sp[j]);
                }
            }

            PathMatrix[0, 0] = 0;

            for (int i = 1; i <= n; i++)
            {
                PathMatrix[i, 0] = PathMatrix[i - 1, 0] + DownMatrix[i - 1, 0];
            }

            for (int j = 1; j <= m; j++)
            {
                PathMatrix[0, j] = PathMatrix[0, j - 1] + RightMatrix[0, j - 1];
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    PathMatrix[i, j] = Math.Max(PathMatrix[i - 1, j] + DownMatrix[i - 1, j], PathMatrix[i, j - 1] + RightMatrix[i, j - 1]);
                }
            }
        }

        //3. Longest common subsequence
        public static void LongestCommonSubsequence(string s1, string s2)
        {
            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    int a = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    if (s1[i - 1] == s2[j - 1]) a = Math.Max(a, matrix[i - 1, j - 1] + 1);
                    matrix[i, j] = a;

                    if (matrix[i, j] == matrix[i - 1, j]) backtrack[i, j] = -1;
                    else if (matrix[i, j] == matrix[i, j - 1]) backtrack[i, j] = -2;
                    else if (matrix[i, j] == matrix[i - 1, j - 1] + 1) backtrack[i, j] = 1;
                }
            }

            OUTPUTLCS(backtrack, s2, s1l, s2l);

            string aligned = Helper.ReverseString(Result);
        }

        public static void OUTPUTLCS(int[,] backtrack, string v, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (backtrack[i, j] == -1)
                OUTPUTLCS(backtrack, v, i - 1, j);
            else if (backtrack[i, j] == -2)
                OUTPUTLCS(backtrack, v, i, j - 1);
            else
            {
                Result = Result + v[j - 1];
                OUTPUTLCS(backtrack, v, i - 1, j - 1);
            }
        }

        //4. Longest Path in a DAG Problem
        public static void SortGraph()
        {
            List<string> input = Helper.ParseTextFileToStrings();

            List<KeyValuePair<int, KeyValuePair<int, int>>> graph = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
            List<KeyValuePair<int, KeyValuePair<int, int>>> sortedgraph = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
            Dictionary<int, bool> nodes = new Dictionary<int, bool>();

            for (int i = 2; i < input.Count(); i++)
            {
                string s = input[i];
                s = s.Replace("-", "");
                string[] ss = s.Split('>');
                int one = Int32.Parse(ss[0]);
                string[] sss = ss[1].Split(':');
                int two = Int32.Parse(sss[0]);
                int three = Int32.Parse(sss[1]);

                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(two, three);
                graph.Add(new KeyValuePair<int, KeyValuePair<int, int>>(one, kvp));
                if (!nodes.ContainsKey(one)) nodes.Add(one, false);
                if (!nodes.ContainsKey(two)) nodes.Add(two, false);
            }

            List<int> candidates = new List<int>();
            candidates.Add(Int32.Parse(input[0]));

            //sort the graph
            while (candidates.Count > 0)
            {
                int b = candidates[0];
                candidates.Remove(b);
                List<KeyValuePair<int, KeyValuePair<int, int>>> test = graph.Where(m => m.Key == b).ToList();

                foreach (KeyValuePair<int, KeyValuePair<int, int>> kvp in test)
                {
                    sortedgraph.Add(kvp);
                    candidates.Add(kvp.Value.Key);
                    graph.Remove(kvp);
                }
            }

            List<KeyValuePair<int, KeyValuePair<int, int>>> updatedgraph = CloneGraph2(sortedgraph);
            foreach (KeyValuePair<int, KeyValuePair<int, int>> kvp in sortedgraph)
            {
                AdjustOneUp(sortedgraph, updatedgraph, kvp);
            }

            List<string> temp = new List<string>();
            foreach (KeyValuePair<int, KeyValuePair<int, int>> kvp in updatedgraph)
            {
                string s = kvp.Key + "->" + kvp.Value.Key + ":" + kvp.Value.Value;
                temp.Add(s);
            }

            Helper.WriteStringsToTextFile(temp);
        }

        public static List<KeyValuePair<int, KeyValuePair<int, int>>> CloneGraph2(List<KeyValuePair<int, KeyValuePair<int, int>>> graph)
        {
            List<KeyValuePair<int, KeyValuePair<int, int>>> result = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
            foreach (KeyValuePair<int, KeyValuePair<int, int>> kvp in graph)
            {
                result.Add(new KeyValuePair<int, KeyValuePair<int, int>>(kvp.Key, new KeyValuePair<int, int>(kvp.Value.Key, kvp.Value.Value)));
            }
            return result;
        }

        private static void AdjustOneUp(List<KeyValuePair<int, KeyValuePair<int, int>>> sortedgraph, List<KeyValuePair<int, KeyValuePair<int, int>>> updatedgraph, KeyValuePair<int, KeyValuePair<int, int>> kvp)
        {
            int index = sortedgraph.IndexOf(kvp);
            int val = kvp.Key;
            for (int i = index - 1; i >= 0; i--)
            {
                KeyValuePair<int, KeyValuePair<int, int>> testKvp = sortedgraph[i];
                if (testKvp.Value.Key == val)
                {
                    KeyValuePair<int, KeyValuePair<int, int>> newKvp =
                        new KeyValuePair<int, KeyValuePair<int, int>>(sortedgraph[index].Key,
                            new KeyValuePair<int, int>(sortedgraph[index].Value.Key, sortedgraph[index].Value.Value + testKvp.Value.Value));
                    updatedgraph[index] = newKvp;
                    return;
                }
            }
            return;
        }

        //5. Global Alignment Problem
        public static void GlobalAlignment(string s1, string s2)
        {
            int indelPenalty = -5;

            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            for (int i = 0; i <= s1l; i++) matrix[i, 0] = indelPenalty * i;
            for (int j = 0; j <= s2l; j++) matrix[0, j] = indelPenalty * j;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    //deletion
                    int delCoef = matrix[i - 1, j] + indelPenalty;
                    //insertion
                    int insCoef = matrix[i, j - 1] + indelPenalty;
                    //match / mismatch
                    int mCoef = matrix[i - 1, j - 1] + AlignmentHelper.GetMatrixCoeff(s1[i - 1], s2[j - 1], AlignmentHelper.BlosumScoringMatrix);

                    matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                }
            }

            //for (int i = 0; i <= s1l; i++)
            //{
            //    for (int j = 0; j <= s2l; j++)
            //    {
            //        Console.Write(matrix[i, j].ToString().PadLeft(4));
            //    }
            //    Console.WriteLine();
            //}

            //get the max element from the matrix and its i,j coordinates
            int matrixmax = 0;
            int jmax;
            int imax;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++)
                {
                    if (matrix[i, j] > matrixmax)
                    {
                        matrixmax = matrix[i, j];
                        imax = i;
                        jmax = j;
                    }
                }

            OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = Helper.ReverseString(Result);
            string aligned2 = Helper.ReverseString(Result2);

            List<string> results = new List<string>();
            results.Add(matrixmax.ToString());
            results.Add(aligned1);
            results.Add(aligned2);
            Helper.WriteStringsToTextFile(results);

        }

        public static void OUTPUTLCSALIGN(int[,] backtrack, string v, string w, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (backtrack[i, j] == -1)
            {
                Result = Result + "-";
                Result2 = Result2 + w[i - 1];
                OUTPUTLCSALIGN(backtrack, v, w, i - 1, j);
            }
            else if (backtrack[i, j] == -2)
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + "-";
                OUTPUTLCSALIGN(backtrack, v, w, i, j - 1);
            }
            else
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + w[i - 1];
                OUTPUTLCSALIGN(backtrack, v, w, i - 1, j - 1);
            }
        }

        //6. Local Alignment Problem
    }
}
