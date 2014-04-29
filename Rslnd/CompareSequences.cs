using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Rslnd
{
    public static class CompareSequences
    {
        public static int[,] RightMatrix;
        public static int[,] DownMatrix;
        public static int[,] PathMatrix;

        public static string Result = string.Empty;
        public static string Result2 = string.Empty;

        public static int GetOverlapCoeff(char a, char b)
        {
            if (a == b) return 1;
            //if (a == b) return 4;
            //return -1;
            return -2;
        }

        public static int GetFittingCoeff(char a, char b)
        {
            if (a == b) return 1;
            return -1;
        }

        public static int GetDistanceCoeff(char a, char b)
        {
            if (a == b) return 0;
            return -1;
        }

        public static int GetMatrixCoeff(char a, char b, int[,] matrix)
        {
            int iA = AminoAcidIndexes.First(s => s.Value == a).Key;
            int iB = AminoAcidIndexes.First(s => s.Value == b).Key;

            return matrix[iA, iB];
        }

        public static void MiddleEdge(string s1, string s2)
        {
            int indelPenalty = -5;

            int s1l = s1.Length;
            int s2l = s2.Length;

            //bool isOdd = s1l % 2 != 0;

            int middle = s2l/2;

            //if (isOdd) middle = s1l / 2 - 1;
            //else middle = (s1l-1) / 2;

            

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
                    int mCoef = matrix[i - 1, j - 1] + GetMatrixCoeff(s1[i - 1], s2[j - 1], BlosumScoringMatrix);

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

            int maxnode = -100;
            int maxnodenum = -1;
            for (int i = 0; i <= s1l; i++)
            {
                if (matrix[i, middle] > maxnode) { maxnode = matrix[i, middle]; maxnodenum = i; }
            }

            int a = middle - 1;
            int aa = maxnodenum - 1;

            int mm = middle + 1;
            int mmm = maxnodenum + 1;

            int mmmm = middle + 2;
            int mmmmm = maxnodenum + 2;

            string result = "(" + maxnodenum + ", " + middle + ") (" + mmm + ", " + mm + ")";

            //result = "(" + mm + ", " + mmm + ") (" + mmmm + ", " + mmmmm + ")";

            OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

        }

        public static void FittingAlignment(string s1, string s2)
        {
            int indelPenalty = -1;

            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            //for (int i = 0; i <= s1l; i++) matrix[i, 0] = indelPenalty * i;
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
                    int mCoef = matrix[i - 1, j - 1] + GetFittingCoeff(s1[i - 1], s2[j - 1]);

                    matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                }
            }

            int imax = 0;
            int jmax = 0;
            int maxelem = -1000;

            //for (int i = 0; i <= s1l; i++)
            //{
            //    for (int j = 0; j <= s2l; j++)
            //    {
            //        //if (i == s1l)
            //            Console.Write(matrix[i, j].ToString().PadLeft(4));
            //    }
            //    Console.WriteLine();
            //}

            //for (int j = 0; j < s2l; j++)
            //{
            //    if (matrix[s1l, j] >= maxelem)
            //    {
            //        imax = s1l;
            //        jmax = j;
            //        maxelem = matrix[s1l, j];
            //    }
            //}

            for (int i = 0; i < s1l; i++)
            {
                if (matrix[i, s2l] >= maxelem)
                {
                    imax = i;
                    jmax = s2l;
                    maxelem = matrix[i, s2l];
                }
            }

            //Result = Result + s2[jmax];
            //Result2 = Result2 + s1[imax];

            OUTPUTLCSALIGN(backtrack, s2, s1, imax, jmax);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

            int score = 0;

            for (int i = 0; i < aligned1.Length; i++)
            {
                if (aligned1[i] == aligned2[i])
                {
                    score++;
                }
                else
                {
                    score--;
                }
            }

            //aligned1 = aligned1.Replace("-", "");
            //aligned2 = aligned2.Replace("-", "");

        }

        public static void OverlapAlignment(string s1, string s2)
        {
            int indelPenalty = -2;

            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            //for (int i = 0; i <= s1l; i++) matrix[i, 0] = indelPenalty * i;
            //for (int j = 0; j <= s2l; j++) matrix[0, j] = indelPenalty * j;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    //deletion
                    int delCoef = matrix[i - 1, j] + indelPenalty;
                    //insertion
                    int insCoef = matrix[i, j - 1] + indelPenalty;
                    //match / mismatch
                    int mCoef = matrix[i - 1, j - 1] + GetOverlapCoeff(s1[i - 1], s2[j - 1]);

                    matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                }
            }

            int imax = 0;
            int jmax = 0;
            int maxelem = -1000;

            for (int i = 0; i <= s1l; i++)
            {
                for (int j = 0; j <= s2l; j++)
                {
                    if(i == s1l)
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }

            for (int j = 0; j < s2l; j++)
            {
                if (matrix[s1l, j] >= maxelem)
                {
                    imax = s1l;
                    jmax = j;
                    maxelem = matrix[s1l, j];
                }
            }

            //Result = Result + s2[jmax];
            //Result2 = Result2 + s1[imax];

            OUTPUTLCSALIGN(backtrack, s2, s1, imax, jmax);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

            int score = 0;

            for (int i = 0; i < aligned1.Length; i++)
            {
                if (aligned1[i] == aligned2[i])
                {
                    score++;
                }
                else
                {
                    score = score - 2;
                }
            }

            //aligned1 = aligned1.Replace("-", "");
            //aligned2 = aligned2.Replace("-", "");

        }

        public static void EditDistance(string s1, string s2)
        {
            int indelPenalty = -1;

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
                    int mCoef = matrix[i - 1, j - 1] + GetDistanceCoeff(s1[i - 1], s2[j - 1]);

                    matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                }
            }

            OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

            int n = 0;

            for (int i = 0; i < aligned1.Length; i++ )
            {
                if (aligned1[i] != aligned2[i]) n++;
            }
        }

        public static void LocalAlignment(string s1, string s2)
        {
            int indelPenalty = -5;

            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            for (int i = 0; i <= s1l; i++) matrix[i, 0] = -5 * i;
            for (int j = 0; j <= s2l; j++) matrix[0, j] = -5 * j;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    //deletion
                    int delCoef = matrix[i - 1, j] + indelPenalty;
                    //insertion
                    int insCoef = matrix[i, j - 1] + indelPenalty;
                    //match / mismatch
                    int mCoef = matrix[i - 1, j - 1] + GetMatrixCoeff(s1[i - 1], s2[j - 1], PAMScoringMatrix);

                    matrix[i, j] = Math.Max(Math.Max(Math.Max(delCoef, insCoef), mCoef), 0);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;
                    else if (matrix[i, j] == 0) backtrack[i, j] = -100;

                }
            }

            int matrixmax = 0;
            int imax = 0;
            int jmax = 0;

            //this would get me the value of the max element, but not the i and j of it
            //matrixmax = matrix.Cast<int>().Max();

            //get the max element from the matrix and its i,j coordinates
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++)
                {
                    if (matrix[i, j] > matrixmax)
                    {
                        matrixmax = matrix[i, j];
                        imax = i;
                        jmax = j;
                    }
                }

            OUTPUTLCSALIGNLOCAL(backtrack, s2, s1, imax, jmax);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

            aligned1 = aligned1.Replace("-", "");
            aligned2 = aligned2.Replace("-", "");

        }

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
                    int mCoef = matrix[i - 1, j - 1] + GetMatrixCoeff(s1[i - 1], s2[j - 1], BlosumScoringMatrix);

                    matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                    if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                    else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                    else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                }
            }

            for (int i = 0; i <= s1l; i++)
            {
                for (int j = 0; j <= s2l; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }

            OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);

        }

        public static void GlobalAlignmentForBlog(string s1, string s2)
        {
            int s1l = s1.Length;
            int s2l = s2.Length;

            int[,] matrix = new int[s1l + 1, s2l + 1];
            int[,] backtrack = new int[s1l + 1, s2l + 1];

            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) matrix[i, j] = 0;
            for (int i = 0; i <= s1l; i++) for (int j = 0; j <= s2l; j++) backtrack[i, j] = 0;

            for (int i = 0; i <= s1l; i++) matrix[i, 0] = 0;
            for (int j = 0; j <= s2l; j++) matrix[0, j] = 0;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    matrix[i, j] = Math.Max(Math.Max(matrix[i - 1, j], matrix[i, j - 1]), matrix[i - 1, j - 1] + 1);

                    if (matrix[i, j] == matrix[i - 1, j]) backtrack[i, j] = -1;
                    else if (matrix[i, j] == matrix[i, j - 1]) backtrack[i, j] = -2;
                    else if (matrix[i, j] == matrix[i - 1, j - 1] + 1) backtrack[i, j] = 1;
                }
            }

            OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = ReverseString(Result);
            string aligned2 = ReverseString(Result2);
        }

        public static void LCS(string s1, string s2)
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

            //for (int i = 0; i <= s1l; i++)
            //{
            //    for (int j = 0; j <= s2l; j++)
            //    {
            //        Console.Write(matrix[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("===");
            //for (int i = 0; i <= s1l; i++)
            //{
            //    for (int j = 0; j <= s2l; j++)
            //    {
            //        Console.Write(backtrack[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            OUTPUTLCS(backtrack, s2, s1l, s2l);

            string aligned = ReverseString(Result);
        }

        public static void OUTPUTLCSALIGNLOCAL(int[,] backtrack, string v, string w, int i, int j)
        {
            if (backtrack[i, j] == -100) { return; }
            if (i == 0 || j == 0)
            {
                return;
            }

            if (backtrack[i, j] == -1)
            {
                Result = Result + "-";
                Result2 = Result2 + w[i - 1];
                OUTPUTLCSALIGNLOCAL(backtrack, v, w, i - 1, j);
            }
            else if (backtrack[i, j] == -2)
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + "-";
                OUTPUTLCSALIGNLOCAL(backtrack, v, w, i, j - 1);
            }
            else
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + w[i - 1];
                OUTPUTLCSALIGNLOCAL(backtrack, v, w, i - 1, j - 1);
            }
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

        public static int ManhattanProblem(int[,] RightMatrix, int[,] DownMatrix)
        {
            int n = RightMatrix.GetLength(0) + 1;
            int m = DownMatrix.GetLength(1) + 1;
            int[,] ManhattanMatrix = new int[n, m];

            ManhattanMatrix[0, 0] = 0;

            for (int i = 1; i <= n; i++)
            {
                ManhattanMatrix[i, 0] = ManhattanMatrix[i - 1, 0] + DownMatrix[i - 1, 0];
            }

            for (int j = 1; j <= m; j++)
            {
                ManhattanMatrix[0, j] = ManhattanMatrix[0, j - 1] + RightMatrix[0, j - 1];
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    ManhattanMatrix[i, j] =
                        Math.Max(ManhattanMatrix[i - 1, j] + DownMatrix[i - 1, j], 
                        ManhattanMatrix[i, j - 1] + RightMatrix[i, j - 1]);
                }
            }

            return ManhattanMatrix.Cast<int>().Max();
        }

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

        public static void DPCHANGE(int val, string denoms)
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
        }

        public static int MaxValue(int[,] matrix)
        {
            return matrix.Cast<int>().Min();
        }

        private static Dictionary<int, char> AminoAcidIndexes = new Dictionary<int, char> 
        { { 0, 'A' }, { 1, 'C' }, { 2, 'D' }, { 3, 'E' }, { 4, 'F' }, {5, 'G'}, { 6, 'H' }, 
        { 7, 'I' }, { 8, 'K' }, { 9, 'L' }, { 10, 'M' }, { 11, 'N' }, { 12, 'P' }, 
        { 13, 'Q' }, { 14, 'R' }, { 15, 'S' }, { 16, 'T' }, { 17, 'V' }, { 18, 'W' }, { 19, 'Y' } };

        private static int[,] PAMScoringMatrix = new int[,] {
        { 2, -2,  0,  0, -3,  1, -1, -1, -1, -2, -1,  0,  1,  0, -2,  1,  1,  0, -6, -3},
        {-2, 12, -5, -5, -4, -3, -3, -2, -5, -6, -5, -4, -3, -5, -4,  0, -2, -2, -8,  0},
        { 0, -5,  4,  3, -6,  1,  1, -2,  0, -4, -3,  2, -1,  2, -1,  0,  0, -2, -7, -4},
        { 0, -5,  3,  4, -5,  0,  1, -2,  0, -3, -2,  1, -1,  2, -1,  0,  0, -2, -7, -4},
        {-3, -4, -6, -5,  9, -5, -2,  1, -5,  2,  0, -3, -5, -5, -4, -3, -3, -1,  0,  7},
        { 1, -3,  1,  0, -5,  5, -2, -3, -2, -4, -3,  0,  0, -1, -3,  1,  0, -1, -7, -5},
        {-1, -3,  1,  1, -2, -2,  6, -2,  0, -2, -2,  2,  0,  3,  2, -1, -1, -2, -3,  0},
        {-1, -2, -2, -2,  1, -3, -2,  5, -2,  2,  2, -2, -2, -2, -2, -1,  0,  4, -5, -1},
        {-1, -5,  0,  0, -5, -2,  0, -2,  5, -3,  0,  1, -1,  1,  3,  0,  0, -2, -3, -4},
        {-2, -6, -4, -3,  2, -4, -2,  2, -3,  6,  4, -3, -3, -2, -3, -3, -2,  2, -2, -1},
        {-1, -5, -3, -2,  0, -3, -2,  2,  0,  4,  6, -2, -2, -1,  0, -2, -1,  2, -4, -2},
        { 0, -4,  2,  1, -3,  0,  2, -2,  1, -3, -2,  2,  0,  1,  0,  1,  0, -2, -4, -2},
        { 1, -3, -1, -1, -5,  0,  0, -2, -1, -3, -2,  0,  6,  0,  0,  1,  0, -1, -6, -5},
        { 0, -5,  2,  2, -5, -1,  3, -2,  1, -2, -1,  1,  0,  4,  1, -1, -1, -2, -5, -4},
        {-2, -4, -1, -1, -4, -3,  2, -2,  3, -3,  0,  0,  0,  1,  6,  0, -1, -2,  2, -4},
        { 1,  0,  0,  0, -3,  1, -1, -1,  0, -3, -2,  1,  1, -1,  0,  2,  1, -1, -2, -3},
        { 1, -2,  0,  0, -3,  0, -1,  0,  0, -2, -1,  0,  0, -1, -1,  1,  3,  0, -5, -3},
        { 0, -2, -2, -2, -1, -1, -2,  4, -2,  2,  2, -2, -1, -2, -2, -1,  0,  4, -6, -2},
        {-6, -8, -7, -7,  0, -7, -3, -5, -3, -2, -4, -4, -6, -5,  2, -2, -5, -6, 17,  0},
        {-3,  0, -4, -4,  7, -5,  0, -1, -4, -1, -2, -2, -5, -4, -4, -3, -3, -2,  0, 10}
        };

        private static int[,] DistanceScoringMatrix = new int[,] {
        {0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1,  1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  1, 0, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0}
        };

        public static int[,] BlosumScoringMatrix = new int[,] {
        { 4,  0, -2, -1, -2,  0, -2, -1, -1, -1, -1, -2, -1, -1, -1,  1,  0,  0, -3, -2},
        { 0,  9, -3, -4, -2, -3, -3, -1, -3, -1, -1, -3, -3, -3, -3, -1, -1, -1, -2, -2},
        {-2, -3,  6,  2, -3, -1, -1, -3, -1, -4, -3,  1, -1,  0, -2,  0, -1, -3, -4, -3},
        {-1, -4,  2,  5, -3, -2,  0, -3,  1, -3, -2,  0, -1,  2,  0,  0, -1, -2, -3, -2},
        {-2, -2, -3, -3,  6, -3, -1,  0, -3,  0,  0, -3, -4, -3, -3, -2, -2, -1,  1,  3},
        { 0, -3, -1, -2, -3,  6, -2, -4, -2, -4, -3,  0, -2, -2, -2,  0, -2, -3, -2, -3},
        {-2, -3, -1,  0, -1, -2,  8, -3, -1, -3, -2,  1, -2,  0,  0, -1, -2, -3, -2,  2},
        {-1, -1, -3, -3,  0, -4, -3,  4, -3,  2,  1, -3, -3, -3, -3, -2, -1,  3, -3, -1},
        {-1, -3, -1,  1, -3, -2, -1, -3,  5, -2, -1,  0, -1,  1,  2,  0, -1, -2, -3, -2},
        {-1, -1, -4, -3,  0, -4, -3,  2, -2,  4,  2, -3, -3, -2, -2, -2, -1,  1, -2, -1},
        {-1, -1, -3, -2,  0, -3, -2,  1, -1,  2,  5, -2, -2,  0, -1, -1, -1,  1, -1, -1},
        {-2, -3,  1,  0, -3,  0,  1, -3,  0, -3, -2,  6, -2,  0,  0,  1,  0, -3, -4, -2},
        {-1, -3, -1, -1, -4, -2, -2, -3, -1, -3, -2, -2,  7, -1, -2, -1, -1, -2, -4, -3},
        {-1, -3,  0,  2, -3, -2,  0, -3,  1, -2,  0,  0, -1,  5,  1,  0, -1, -2, -2, -1},
        {-1, -3, -2,  0, -3, -2,  0, -3,  2, -2, -1,  0, -2,  1,  5, -1, -1, -3, -3, -2},
        { 1, -1,  0,  0, -2,  0, -1, -2,  0, -2, -1,  1, -1,  0, -1,  4,  1, -2, -3, -2},
        { 0, -1, -1, -1, -2, -2, -2, -1, -1, -1, -1,  0, -1, -1, -1,  1,  5,  0, -2, -2},
        { 0, -1, -3, -2, -1, -3, -3,  3, -2,  1,  1, -3, -2, -2, -3, -2,  0,  4, -3, -1},
        {-3, -2, -4, -3,  1, -2, -2, -3, -3, -2, -1, -4, -4, -2, -3, -3, -2, -3, 11,  2},
        {-2, -2, -3, -2,  3, -3,  2, -1, -2, -1, -1, -2, -3, -1, -2, -2, -2, -1,  2,  7}
        };

        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

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

            List<KeyValuePair<int, KeyValuePair<int, int>>> updatedgraph = AssembleGenom.CloneGraph2(sortedgraph);
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

    }
}
