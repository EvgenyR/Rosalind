using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rslnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long GigabytesToBytes(double gb)
        {
            return (int)(gb * 1024 * 1024);
        }

        private void DirectorySearch(string dir, List<FileInfo> allFiles)
        {
            allFiles.AddRange(new DirectoryInfo(dir).GetFiles().ToList());
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                //allFiles.AddRange(new DirectoryInfo(subDir).GetFiles().ToList());
                DirectorySearch(subDir, allFiles);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s =
            //    "MKNKFKTQEELVNHLKTVGFVFANSEIYNGLANAWDYGPLGVLLKNNLKNLWWKEFVTKQKDVVGLDSAIILNPLVWKASGHLDNFSDPLIDCKNCKARYRADKLIESFDENIHIAENSSNEEFAKVLNDYEISCPTCKQFNWTEIRHFNLMFKTYQGVIEDAKNVVYLRPETAQGIFVNFKNVQRSMRLHLPFGIAQIGKSFRNEITPGNFIFRTREFEQMEIEFFLKEESAYDIFDKYLNQIENWLVSACGLSLNNLRKHEHPKEELSHYSKKTIDFEYNFLHGFSELYGIAYRTNYDLSVHMNLSKKDLTYFDEQTKEKYVPHVIEPSVGVERLLYAILTEATFIEKLENDDERILMDLKYDLAPYKIAVMPLVNKLKDKAEEIYGKILDLNISATFDNSGSIGKRYRRQDAIGTIYCLTIDFDSLDDQQDPSFTIRERNSMAQKRIKLSELPLYLNQKAHEDFQRQCQK";

            //string pattern = @"N[^P][ST][^P]";

            //var matchs = Regex.Matches(s, pattern);

            int j = 0;

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
