using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Numerics;
using System.Text.RegularExpressions;

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
            List<string> proteins = new List<string>();

            string line;
            using (StreamReader reader = new StreamReader("C:\\Evgeny\\Development\\Rslnd\\input.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    proteins.Add(line);
                }
            }

            WebClient client = new WebClient();
            Dictionary<string, string> proteinsDict = new Dictionary<string, string>();
            foreach (string id in proteins)
            {
                Stream stream = client.OpenRead("http://www.uniprot.org/uniprot/" + id + ".fasta");

                if (stream != null)
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string protein = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!line.StartsWith(">"))
                            {
                                protein += line;
                            }
                        }

                        proteinsDict.Add(id, protein);
                    }
            }

            const string pattern = @"N[^P][ST][^P]";

            using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            {
                foreach (KeyValuePair<string, string> kvp in proteinsDict)
                {
                    string val = kvp.Value;
                    List<int> matches = new List<int>();
                    int removed = 0;
                    bool done = false;
                    while (done == false)
                    {
                        Match match = Regex.Match(val, pattern);
                        if(match.Success)
                        {
                            int index = val.IndexOf(match.Value);
                            matches.Add(index + removed + 1);
                            removed += index + 1;
                            val = val.Substring(index + 1, val.Length - (index + 1));
                        }
                        else
                        {
                            done = true;
                        }
                    }

                    if(matches.Count > 0)
                    {
                        string indices = string.Empty;
                        writer.WriteLine(kvp.Key);
                        indices = matches.Aggregate(indices, (current, index) => current + index + " ");
                        writer.WriteLine(indices);
                    }
                }
            }

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

            /*
            //start of orf

            string sc = Helper.ReverseComplement(s);

            List<String> source = new List<string>();
            List<String> orfs = new List<string>();

            source.Add(s);
            source.Add(s.Substring(1, s.Length - 1));
            source.Add(s.Substring(2, s.Length - 2));
            source.Add(sc);
            source.Add(sc.Substring(1, sc.Length - 1));
            source.Add(sc.Substring(2, sc.Length - 2));

            foreach (var str in source)
            {
                string orf = Helper.ORF(str);
                if(orf != string.Empty && !orfs.Contains(orf))
                {
                    orfs.Add(orf);

                    while (true)
                    {
                        if(orf.StartsWith("M"))
                        {
                            orf = orf.Substring(1, orf.Length - 1);
                            int indexofm = orf.IndexOf("M");
                            if (indexofm > 0)
                            {
                                string subs = orf.Substring(indexofm, orf.Length - indexofm);
                                orfs.Add(subs);
                                orf = subs;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            {
                foreach (var orf in orfs)
                {
                    writer.WriteLine(orf);
                }
            }*/
            //end of orf
        }
    }
}
