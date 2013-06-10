using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Numerics;

namespace Rslnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void makeperm(int i)
        {

        }

        private string SetToString(List<int> set)
        {
            string s = "{";
            foreach (int val in set)
            {
                s = s + val + ", ";
            }
            s = s.Substring(0, s.Length - 2);
            return s + "}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> input = Helper.FastaStrings();

            //input = new List<string>{
            //    "ATTAGACCTG",
            //    "CCTGCCGGAA",
            //    "AGACCTGCCG",
            //    "GCCGGAATAC"
            //};

            string result = Helper.ShortestSuperstring(input);

            int zz = 0;

            //int[] catalan = Helper.CatalanNumbers(6);

            //int result = Helper.CatalanNumber(11);

            //IOrderedEnumerable<string> input = Enumerable.Empty<string>().OrderBy(x => 1);

            //List<string> input = new List<string> 
            //{ 
            //    "CACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGCCAAACCCCCCGGTAGAGCTTGCCCCTCGACCACAGGCTAGACCGGGAGCCCTGGTGAAGAGGGTCGAGCTAGTACATTATTCTCACTAACGCCACCTCGCACATGCATGTATCTGTGTAAAGGTTCCGAATGAACACAGCCTATATAATAGTCGACGTGTGTTTGGACGGATCCGAGAGTAAAGTAGGTACTATGTAAACGATTTGCACCCGTTATGGATAATCAGGATTATGAATCCTAGCAGTGGCCTGACCAAGTAAAATAGAGATCATCAAAACAAGGCTATATCGACGGGAATCGAGAGGGGAAGCTCGGAGCTCAGGGAAGATCCACACTCGTGCTACAGGCCTCTCTTAGTGGAGCGTGTACTGATTCCAGACAAATCAACTAGTTGCGGGAAAGCGCTGAGCACTAATCGTGCGCCGAATCGAATAACTCTATCGAACACGATACAGGAGGCGTAGGCTTTGAACCCATTTATCATGCGGGCGGACCGGCAATCATGCTATGTTAGAGAAATTTTAAGCGAACAGCGCAAAATAGGAGATTACTTAAAATGGTAGTGCCAGAAACTGACTGAAGTGGTATTGAGGGCCCGCGCCAAGACAACAGGGTTCATCCAATCGCCGATAGATCAACGTTAGCCGGGTCTATGTAGCATAGACTGTCAATCATGTCCAGGAAGGGACGATCAGTGTGCACTGCAGGTGCCGGACCGAAGAAGTCTGTGCCTCCTCCATACTATCTTAGGCTCATGGTTGCGAATCCCGTAGTTACCGCTTC",
            //    "GATGATCGTCTAACCCCCGAGCAAGAAACCGCAGTAGGTTCTTTTACCGTGACAGCGCGCCCACCGTTCCCTCCCCCAGGCTCAGGGCTTGGAGCACTTTAGCGAGTTGTTCAGCTATTCCCGGATTCAGCTAACTTTATTTCTCCTGTCAGGAGCCACAGCAGCTACTGCAGTTGGTCATTGGTGTGGCCTGTCGCACAAAAGAATGGAGGGCTAACTCGTGATCCATGTTAGTTTGGCCTCGTGTAAGGCACTGCAGTCATCCACCTAGGGTCTGCGGATGATCATTCGATTTATACCGCTGAGGCGGGGTAAAAACGCGCTGTCTTCACTAGGATAGGCCTTACACGACGCTTTAGAACCGTAAATCGGTTGAGTTCGCCCGAACTTGCGACTACGTCAGTACGAGGCCATCCGTTAAGGTCGACGCGGCGGAACATCTAAATAGTGCAGCGATCAATCCGCCTTAAAGCTATGGCGAGGTGGGGCAGTTTGCAAAAAATAAAACTTCACTATCGGCTCTCTTCGGCTCTCTGTTGAGCTGAGGGAACGTTTTCGTTGATAGCAAATCGCAAAAACGGAGGGTTCGGAGCTTGCGAACGCCAGACTCGTATGTCCGGGACTTCGGGTTTTATTGCCCATTCACGCAGTAGTGTCTGTACGTTGACTTATTATGGCGCCGGGGTGGAGAGGCCGTTAGCCATAGTGGAGCTATTTACCTTGGTGAGTACTAATAACAGCGAACTTAACCGTGCTCCGTTGCCGTCGATGTCAGTGATACTACACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGC",
            //    "GTCGACGCGGCGGAACATCTAAATAGTGCAGCGATCAATCCGCCTTAAAGCTATGGCGAGGTGGGGCAGTTTGCAAAAAATAAAACTTCACTATCGGCTCTCTTCGGCTCTCTGTTGAGCTGAGGGAACGTTTTCGTTGATAGCAAATCGCAAAAACGGAGGGTTCGGAGCTTGCGAACGCCAGACTCGTATGTCCGGGACTTCGGGTTTTATTGCCCATTCACGCAGTAGTGTCTGTACGTTGACTTATTATGGCGCCGGGGTGGAGAGGCCGTTAGCCATAGTGGAGCTATTTACCTTGGTGAGTACTAATAACAGCGAACTTAACCGTGCTCCGTTGCCGTCGATGTCAGTGATACTACACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGCCAAACCCCCCGGTAGAGCTTGCCCCTCGACCACAGGCTAGACCGGGAGCCCTGGTGAAGAGGGTCGAGCTAGTACATTATTCTCACTAACGCCACCTCGCACATGCATGTATCTGTGTAAAGGTTCCGAATGAACACAGCCTATATAATAGTCGACGTGTGTTTGGACGGATCCGAGAGTAAAGTAGGTACTATGTAAACGATTTGCACCCGTTATGGATAATCAGGATTATGAATCCTAGCAGTGGCCTGACCAAGTAAAATAGAGATCATCAAAACAAGGCTATATCGACGGGAATCGAGAGGGGAAGCTCGGAGCTCAGGGAAGATCCACACTCGTGCTACAGGCCTCTCTTAGTGGAGCGTGTACTGATTCCAGACAAATCAACTAGTTGCGGGAAAGCGCTGAGCACTAATCGTGCG"

            //};

            //List<string> input = new List<string> 
            //{ 
            //    "ATTAGACCTG",
            //    "CCTGCCGGAA",
            //    "AGACCTGCCG",
            //    "GCCGGAATAC",
            //    "GCATTAGACC"
            //};



            /*
            string one = "CAGGACGCTGAACTTCATAGCTGTTTTGCTATTGTATTTGAGATACACGGTGCTCGTTGAGGTCGACAACCTTTGCCTCGAGCTTGATGGCAATAAGCTTGGGTCTGAAGGTAGGAGTCACCCTGGACGATGGGGACTGCCAGGATCTTTGTCCACGGAAGCTGAGCCGGGGAGATCCTGAGCATCACCCCATTAAGTAACCGTTTACTCTCTCGCGTACGGTCGGCTAGGGCTGTAGAGGTGGGTATCGCATGCTGACTGGCGTACGGCCTCCAATGGACCACTGATAATCTCCGCAGTAAGTTGACCGATCGGCCAGTTACTGCAATGCATTTGCGACTGGGTGGCTGCGCGAACGGAAAAATAAGTGCTGAGCTGGCCTGGTCATACTTGGTAATCTTGTCGAATGATGGCGCCCTGCTAAAATGCGTCATACGAATACCAGGACTTCTCTGCTATATTATCATGAACAGACGCCCGTTACACATAGCTAGATACCTATAAGATCAGTTATAGTGTAGCTATACTGCCTGTCATCTGAAAAACACTACCTATAGGCCCCTCTAGCCATTGCCATGGGTGCGCTTTGTCAAGAGCATGATCATACCGCCTGTTGAGCGCGGCGGCAACATAGGCAGTCAATCGCCATCTTCGCTTATAGGGTGTGGTAGCGGTGTGTACATGTGAAGTCAAAAAAATACTAGTCGTTCCGCCCATGTCAAGGGCCATGTCACGTAGAAGTGAACGGCCATAGGCTCCTCACCTTTGTGATCGATAGGTATATATATGTATGTTTAGCCCTCGCGGGCAGACACTCGGTGCCTGACCATGCAGAAACCAGGGGACTAAGTGGGGATTTCTG";
            string two = "GACCGGTAGAGGGCTAACGATCACAATTGTTGAGGGGCTTATTTAGGTCACGTG";

            int index = 0;

            List<int> indices = new List<int>();
            foreach (char ch in two)
            {
                int value = 0;
                int current = 0;
                string temp = one;
                while(true)
                {
                    value = temp.IndexOf(ch);
                    if(value >= index)
                    {
                        indices.Add(value + current);
                        index = value;
                        break;
                    }
                    else
                    {
                        current = current + value + 1;
                        temp = one.Substring(value + 1, temp.Length - value - 1);
                    }
                }
            }

            string s = string.Empty;
            foreach(int i in indices)
            {
                s = s + (i + 1).ToString() + " ";
            }
            */

            //Helper.SignedPermutations(3);


            //longest increasing subsequence starts
            /*
            string input;

            using (StreamReader reader = new StreamReader(Helper.INPUT_FILE))
            {
                input = reader.ReadToEnd();
            }
            
            Array.Reverse(ints);
            List<int> results2 = Helper.LongesIncreasingSubsequence(ints);

            results.Reverse();
            results2.Reverse();

            string one = string.Empty;
            string two = string.Empty;

            foreach (int value in results)
            {
                one = one + value + " ";
            }

            foreach (int value in results2)
            {
                two = two + value + " ";
            }
            */
            //longest increasing subsequence ends

            //List<string> s = Helper.GetWords(4, new List<string> { "L", "I", "W", "O" }).ToList();

            //using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            //{
            //    foreach (var orf in s)
            //    {
            //        writer.WriteLine(orf);
            //    }
            //}

            //string s = "ATGGTCTACATAGCTGACAAACAGCACGTAGCAATCGGTCGAATCTCGAGAGGCATATGGTCACATGATCGGTCGAGCGTGTTTCAAAGTTTGCGCCTAG";
            //string i1 = "ATCGGTCGAA";
            //string i2 = "ATCGGTCGAGCGTGT";

            //s = s.Replace(i1, "");
            //s = s.Replace(i2, "");

            //s = Helper.DNAtoRNA(s);

            //s = Helper.DNAtoAA(s);

            //string s = textBox1.Text.Trim();

            //List<SubString> result = Helper.AllSubstrings(s, 4, 12);

            //List<SubString> endresult = new List<SubString>();
            //foreach (var str in result)
            //{
            //    string strc = Helper.ReverseComplement(str.substring);
            //    if(str.substring == strc)
            //        endresult.Add(str);
            //}

            //using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            //{
            //    foreach (var orf in endresult)
            //    {
            //        writer.WriteLine(orf.index + " " + orf.lenght);
            //    }
            //}

        }
    }
}
