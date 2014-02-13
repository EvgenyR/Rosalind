using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    public static class GapPenaltyAlignment
    {
        public static int[,] LowerMatrix;
        public static int[,] MiddleMatrix;
        public static int[,] UpperMatrix;

        public static int[,] LowerBacktrackMatrix;
        public static int[,] MiddleBacktrackMatrix;
        public static int[,] UpperBacktrackMatrix;

        public static string Result = string.Empty;
        public static string Result2 = string.Empty;

        public enum CMatrix
        { 
            LOWER = 1,
            MIDDLE = 2,
            UPPER = 3
        }

        public static void GapAlignment(string s1, string s2)
        {
            int gapOpenPenalty = -11;
            int gapExtendPenalty = -1;

            int s1l = s1.Length;
            int s2l = s2.Length;

            LowerMatrix = new int[s1l + 1, s2l + 1];
            MiddleMatrix = new int[s1l + 1, s2l + 1];
            UpperMatrix = new int[s1l + 1, s2l + 1];

            LowerBacktrackMatrix = new int[s1l + 1, s2l + 1];
            MiddleBacktrackMatrix = new int[s1l + 1, s2l + 1];
            UpperBacktrackMatrix = new int[s1l + 1, s2l + 1];

            //Lower
            for (int j = 0; j <= s2l; j++) LowerMatrix[0, j] = -999;
            LowerMatrix[1, 0] = gapOpenPenalty;
            for (int i = 2; i <= s1l; i++) LowerMatrix[i, 0] = LowerMatrix[i - 1, 0] + gapExtendPenalty;
            //for(int i

            //Middle
            MiddleMatrix[0, 0] = 0;
            MiddleMatrix[0, 1] = gapOpenPenalty;
            for (int j = 2; j <= s2l; j++) MiddleMatrix[0, j] = MiddleMatrix[0, j - 1] + gapExtendPenalty;
            MiddleMatrix[1, 0] = gapOpenPenalty;
            for (int i = 2; i <= s1l; i++) MiddleMatrix[i, 0] = MiddleMatrix[i - 1, 0] + gapExtendPenalty;

            //Upper
            for (int i = 0; i <= s1l; i++) UpperMatrix[i, 0] = -999;
            UpperMatrix[0, 1] = gapOpenPenalty;
            for (int j = 2; j <= s2l; j++) UpperMatrix[0, j] = UpperMatrix[0, j - 1] + gapExtendPenalty;

            //Lower Backtrack
            for (int i = 1; i <= s1l; i++) LowerBacktrackMatrix[i, 0] = 1;

            //Upper Backtrack
            for (int j = 1; j <= s2l; j++) UpperBacktrackMatrix[0, j] = 1;

            //Middle Backtrack
            for (int i = 1; i <= s1l; i++) MiddleBacktrackMatrix[i, 0] = 1;
            for (int j = 1; j <= s2l; j++) MiddleBacktrackMatrix[0, j] = 1;

            for (int i = 1; i <= s1l; i++)
            {
                for (int j = 1; j <= s2l; j++)
                {
                    LowerMatrix[i, j] = 
                        Math.Max(LowerMatrix[i - 1, j] + gapExtendPenalty, MiddleMatrix[i - 1, j] + gapOpenPenalty);
                    UpperMatrix[i, j] =
                        Math.Max(UpperMatrix[i, j - 1] + gapExtendPenalty, MiddleMatrix[i, j - 1] + gapOpenPenalty);   
                    MiddleMatrix[i, j] =
                        Math.Max(Math.Max(LowerMatrix[i, j], UpperMatrix[i, j]), 
                        MiddleMatrix[i - 1, j - 1] + CompareSequences.GetMatrixCoeff(s1[i - 1], s2[j - 1], CompareSequences.BlosumScoringMatrix));

                    if (LowerMatrix[i, j] == LowerMatrix[i - 1, j] + gapExtendPenalty) LowerBacktrackMatrix[i, j] = 1; //extension
                    if (LowerMatrix[i, j] == MiddleMatrix[i - 1, j] + gapOpenPenalty) LowerBacktrackMatrix[i, j] = 2; //opening

                    if (UpperMatrix[i, j] == UpperMatrix[i, j - 1] + gapExtendPenalty) UpperBacktrackMatrix[i, j] = 1; //extension
                    if (UpperMatrix[i, j] == MiddleMatrix[i, j - 1] + gapOpenPenalty) UpperBacktrackMatrix[i, j] = 2; //opening

                    if (MiddleMatrix[i, j] == LowerMatrix[i, j]) MiddleBacktrackMatrix[i, j] = 1; //down
                    if (MiddleMatrix[i, j] == UpperMatrix[i, j]) MiddleBacktrackMatrix[i, j] = 2; //right
                    if (MiddleMatrix[i, j] == MiddleMatrix[i - 1, j - 1] + CompareSequences.GetMatrixCoeff(s1[i - 1], s2[j - 1], CompareSequences.BlosumScoringMatrix)) MiddleBacktrackMatrix[i, j] = 3;

                }
            }

            CMatrix matrix = CMatrix.MIDDLE;
            int score = Math.Max(Math.Max(LowerMatrix[s1l, s2l], UpperMatrix[s1l, s2l]), MiddleMatrix[s1l, s2l]);

            if (score == LowerMatrix[s1l, s2l]) matrix = CMatrix.LOWER;
            else if (score == UpperMatrix[s1l, s2l]) matrix = CMatrix.UPPER;
            else if (score == MiddleMatrix[s1l, s2l]) matrix = CMatrix.MIDDLE;




                //for (int i = 1; i <= s1l; i++)
                //{
                //    for (int j = 1; j <= s2l; j++)
                //    {
                //        //deletion
                //        int delCoef = matrix[i - 1, j] + indelPenalty;
                //        //insertion
                //        int insCoef = matrix[i, j - 1] + indelPenalty;
                //        //match / mismatch
                //        int mCoef = matrix[i - 1, j - 1] + GetMatrixCoeff(s1[i - 1], s2[j - 1], BlosumScoringMatrix);

                //        matrix[i, j] = Math.Max(Math.Max(delCoef, insCoef), mCoef);

                //        if (matrix[i, j] == delCoef) backtrack[i, j] = -1; //
                //        else if (matrix[i, j] == insCoef) backtrack[i, j] = -2; //
                //        else if (matrix[i, j] == mCoef) backtrack[i, j] = 1;

                //    }
                //}

            //PrintMatrix(LowerMatrix, "LOWER");
            //PrintMatrix(MiddleMatrix, "MIDDLE");
            //PrintMatrix(UpperMatrix, "UPPER");

            //PrintMatrix(LowerBacktrackMatrix, "LOWER BACKTRACK");
            //PrintMatrix(MiddleBacktrackMatrix, "MIDDLE BACKTRACK");
            //PrintMatrix(UpperBacktrackMatrix, "UPPER BACKTRACK");

            Output(s2, s1, s1l, s2l, matrix);
            

            //OUTPUTLCSALIGN(backtrack, s2, s1, s1l, s2l);

            string aligned1 = CompareSequences.ReverseString(Result);
            string aligned2 = CompareSequences.ReverseString(Result2);

            //int z = 0;
        }

        private static void Output(string v, string w, int i, int j, CMatrix matrix)
        {
            Console.WriteLine("Now in " + matrix.ToString() + " matrix");

            if (i == 0 || j == 0)
                return;
            if (matrix == CMatrix.LOWER)
            {
                Result = Result + "-";
                Result2 = Result2 + w[i - 1];

                Console.WriteLine("String 1 has a gap, string 2 has a letter");

                if (LowerBacktrackMatrix[i, j] == 2) matrix = CMatrix.MIDDLE;
                else if (LowerBacktrackMatrix[i, j] == 1) matrix = CMatrix.LOWER;

                Console.WriteLine("Now in " + matrix.ToString() + " matrix, calling backtrack");

                Output(v, w, i - 1, j, matrix);
            }
            else if (matrix == CMatrix.UPPER)
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + "-";

                Console.WriteLine("String 2 has a gap, string 1 has a letter");

                if (UpperBacktrackMatrix[i, j] == 2) matrix = CMatrix.MIDDLE;
                else if (UpperBacktrackMatrix[i, j] == 1) matrix = CMatrix.UPPER;

                Console.WriteLine("Now in " + matrix.ToString() + " matrix, calling backtrack");

                Output(v, w, i, j - 1, matrix);
                
            }
            else if (matrix == CMatrix.MIDDLE)
            {
                Result = Result + v[j - 1];
                Result2 = Result2 + w[i - 1];

                Console.WriteLine("Both strings has a letter");

                if (MiddleBacktrackMatrix[i - 1, j - 1] == 3) matrix = CMatrix.MIDDLE;
                else if (MiddleBacktrackMatrix[i - 1, j - 1] == 2) matrix = CMatrix.UPPER;
                else if (MiddleBacktrackMatrix[i - 1, j - 1] == 1) matrix = CMatrix.LOWER;

                Console.WriteLine("Now in " + matrix.ToString() + " matrix, calling backtrack");

                Output(v, w, i - 1, j - 1, matrix);
            }
        }


        private static void PrintMatrix(int[,] matrix, string name)
        {
            Console.WriteLine(name);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }       
        }
    }
}
