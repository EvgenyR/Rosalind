﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    //Problems from Week 9, 10: How Do We Locate Disease-Causing Mutations?
    public static class Locate
    {
        //1. Trie Construction Problem

        //9. Burrows-Wheeler Transform Construction Problem
        public static string BurrowsWheelerTransform(string input)
        {
            int len = input.Length;
            //create as list of indexes
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++) list.Add(i);
            //sort somehow
            BurrowsComparer cmp = new BurrowsComparer(Encoding.ASCII.GetBytes(input));
            list.Sort(cmp);
            //output last symbols
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (list[i] == 0) result.Append(input[len - 1]);
                else result.Append(input[list[i] - 1]);
            }
            return result.ToString();
        }

        //10. Inverse Burrows-Wheeler Transform Problem
        public static string ReverseBurrowsWheeler(string input)
        {
            List<KeyValuePair<char, int>> dict = new List<KeyValuePair<char, int>>();

            for (int i = 0; i < input.Length; i++)
            {
                dict.Add(new KeyValuePair<char, int>(input[i], i));
            }

            dict = dict.OrderBy(z => z.Key).ToList();

            int x = dict[0].Value;

            string result = dict[x].Key.ToString();
            for (int i = 1; i < dict.Count; i++)
            {
                x = dict[x].Value;
                result = result + dict[x].Key;
            }

            return result;
        }

        //11. BWMatching problem
        //*** usage start
        //string transform = "TGTAGGGTAACCAAACGTATCGTGTCTCTCAGAGCTGGAGAGTGTCTAGACTATTTTCACATAGATGCGTAGTCAGAGTTTGTGGCGCGCTTAATTTATTCGCCCTCTTTCACCGGGCTTATCAGCACCAATGTCGAAACGAAACACAAATCGTGACGAGTGACATGCACTGTTACGTCCATCAGTCGTTATCATGCTTTCTAATCATTGGGGGCCGGGAGCAAGATAAGACCGTTGAGTCTCATTATATAAGAACGGCGAACTTAATTTGCCGGACGGTCGAACACTTAATCGCAAAATGTGCAGTAGGAAGTCGGACATATGATGAAAGATTATCATGCACGCCGTCCTGCAGTCGGTTCGCTTGAAGTGACTGCGAGTCCAGAGCGTTCGAAGTCGTCCCGAAAAAGGCACGATGTTATT$TATCTTACGAAATTTAGTCTCGAAGTAGGGCGGGGACTAACCCAAGGTACGCAGGCTATTTTACGACATGGGCCATAGACCATGCAAAAACTGAGGATGTAATCATATCCGAAAAGCAGGGCCGAGTCCCCGTAGCGGAGCCGCTTGCGCGCCCTAAGCTGACGACTGTGTAAAAGTTAGTTGAAACTGAGTCCTCGAAAGGGACCGTCAGGCGCGATCGTGAACAAGATTCGGGTTGGTCGTAGGTAGTAATGTCATCTTTCTGCTCGGCCACGGGGGTTAGCACATCGCCCCGCGTTCGGGGAGCTGATTTCACCCTGAGAAGGCAGCTGACCCAGCTGAATGGAAAGGAGTACGTAGCGGATCTGGCTCTCGGTCGGCTAGACAAGAGGACGCGTGGTATGACCGCGCTCGGAGGGGGCACGGAGGTATATTCTGTCTCTCTTAGATGTATTGCGAGGTCTATGATTTACACGGCATTCGCGTTCTTGGCCTCTGGCAGAGTCCTACTGCGTGCTTCTATTCGAGCGACTCAACGTTATAGGTACTATTGGGCGCCAACTACCCATCCTTCATG";
        //string original = Locate.ReverseBurrowsWheeler(transform);
        //List<int> lastToFirst = Locate.FirstToLast(original);

        //string pattern = "GCTCCTTTGA TAGTGGTGGA TTGTCGCAAC CAAAATTAGA CAGAGCGCGT GGGGCCGTGT TCCCTGGTGA CGGAGTTTCT GTGGTATAAT CCGATCGAGT ATGCGGAGCA TGTTCCCTAT CAGCGGATGC CAGATAGTAT GTGGAATCAT GAATGTTAAG CGAAGTACAC CAGATAGTAG AAGAGAGAAG GCGGCAGGTA GGTGAGCTTG TAGTCGCGAC GGTCCGACAA ATATCCAACT TGTGTAACTC CCGCGATGCC GTTTCCATTG CAATGCTCGC CCCGAACAAC TCGCTCCTTT AGAGGAAGAC CTTCCCTCCG ATTCATGTAC CGAACCCTTC GGAGGCGCGG ACGGTATGTG GTACGCTTCT ACAAGACAGT TAAGGTTGCT AACAAAGATA AATCCCGTGG ACTCTGCATT AGGAACCACG GTACTGACGA GCGTGTATTA TGGGGCCCTC CTTGCGTTTG TCTACCGTAG CGCCGCTGGC GACGCAGACA GCGGGCATAC TAATCTCGTA ACAAGAAGAC TCCCAATGAG GACACTGCTA AATCTTATCC GTGTCTCGAT TCCCCACTTA GCTTCTGTCT CTTCGCCGGA AGAATTGAAC GGACAACGGG AAAAGTCAGG CCGGGGAGCC GCGAATGGCA CCCCTCCCGA TATGCCGGCT GAAAAGGGGT ATTAGGCACG TCCGAAGGCT TGAAGATTAA TGTTGGGGAA GACGCGACCC CCATTCAATG AAACTTTGGA AACCGCGGCG CCTCTAGCAA TAGTAAAGAG TATATCTCGA TCATCAGCCA TATAAACAAA CGTCAACGAA GACTTAAGGG GGAGTGACAA TGTAAGCGTA TCAGAATTTC AGCCCATTCT TCCGCTCCAT GGGCGCGGCT CCGCGGCGTT CTAATTTAGA CCGGATCAAA GTTTTGGAAA TCAATTAATT TAGACTCCCC TCACGGCTCC TGATCACGGC CTTATTTTGG TCTCGAGAGT TAGCTATGAT ACGTAGAGGA AGGCTCTTAA AAGCAGTTGA GTACACAACT GCGGCGTTGG GGGGACGGGA ACGTCCGGGG TTGAGGGGCA GTAGGGGGCA TCTCTGATAT GGGGCGCTAA TCTAACCGCG ATAACTTATA CTGGCTTGTG TAGCTGGGTA CTAGAAAGGC GAGGAAGCGC TTCTAGGCGA TTCTCAGGGA GGCAGCATGG CCCGGCGTTA TCGCACTTGG CATTACTTCC AGTATTGTGA GCAATAATTG CGCCACTTCT CACGCACTCG CTTCGCTCCT AGACTTCAAG CGGCGTTGGT CAAGGTTGTT GTATTTCGCC GGATACGAAT GTTCTCTACC GGCCCGTGTG CAAGGTGAAG ATCCCGTTGC ACCGCGGCCG AGTTCTCTAC ACTGACTAAG AAGACATCAA CTGGGGTATT GCTGGTTCGG CAACAGAGCC CTGCACTTGC ATGATAGTTG CCACGGTTTA AGGGGTGAAA GTGGTCCGCA TATTACGAGC GGCGACAAGG GCGACAAATT TGGTTCTCAC TCACTAACGA TGTTACATAC GCCTTCGCTC CGCAGAAGCA TCACTGGGAG AAGTAATACC ACCGGGCTCC GAATGCTGAC TTTACAATCA GGACTCTTAA AGTTGATTTC ATTAAAAACA GGTTGCCCCT AAACGGATAC TTTAACACGT CAGCTAGGTT GAGGTACTGC GACCGCCTTC CCGCTGTAGC ATGTGACTAA TATTGTCGAG CGACTAGGGT CTCGTACCGT TCACTTTCTA GCTACTCCAA TTTAATCGTG TAGTATAACG CAGAGCGTTT GGCTTTGGGT TCTACTACCT AACCAGTCAT CGCGACCCTC CCCCTAGAAG AAACGTCACT AGTTATGGAA ACAGCCCTTT GACCCGTACA TCTCTCGCAA GGCCATTGGC ACATTGTACC CCTCATGTAC AACTCCGTCT ACGTGTGGGA GGGTAGGCGG CGGCCGATCG CATACACGCG CCCTGGTGAA GCCAGGCAGC GAGGTGACAG ACCAATGAAG TCTTACCGCA CGTACCGTAA CCTCTAACCG CTAGGGTACG GTATGCCTCT GCTGTCGCAG TAGGCGACTA TATTACAGAT ACAGTCGCAG GCGCAACTCC AGGGTGCTCG CGCATACACA TACACGCGGG TCCCGGCTTC AACAGGAGCG GGTGGGCAAG ACACCAGAGA GAAATGGACA GAGATGTATT TTGCCAGCAT ACTCATTACA TTACCGCAAG CACTTATTGG TGAGTGAAAA GTGACGAAGC CCGGAAATCC GGGTTAGGAG TGTAAGATAT AGTAGGCAAC TCAGGCGGAC GTACCGCTCG TGACATTCTC TTACGTCAGA TGTATTAGGC CGACCAGGAG GCCCCCTATA TAACGGGTCA ATAAGCCCCC CGGCCGCCGA GGGGCGCGGC TTAACCTGAA CAGGCTCGTG ACATATCCCA ACATAGCGGA CGGCTGAACA GGTCGACACG GTGGCAGGTC TCTTTAATAA CAACGTCCGG GACCACGTGT ACCCGGTTAA GGAGACGGTC TATAAGGCGT AGGTGACAGG AGTTTTGCTT GTTTACACTT CTCCTACTGT CGGGTAAGGT TAACTATTTG AGGAGGTAAC GGACCAATGA ACGTGTTACA TTAAGAGAGA CTCCTTTCAC CCAGAGCTGC TATAACCTAG ACACGCGGGG GCTGGGCCAG AAAGCTAGAA GCAGGGTCTA TAGCGTCCCT ATCTCGCGCG AGACGTCATT CGTGCGACAC ATGACATAAA TAACTTATTT TCAAAGATCC TGCCTTCGCT GGTCGCACTT TTTGACGCCT GTGGAATGCA ATAAACACTC CTAACAGTCG CCGAAGACGC ACGGGATCCG TCTGCCGTGA GCGGTTGCCC TTTGGGTAGG GACACGCCAG ATAGGCCAGT TATGATCCGA AAGGGGTGAA TAGATGTGGT AGGATTGTTC AGCTTTCTTA CTGCTGGTTC CAAGATAGTT TTCGCCGCTG TCACCCGCTG TTTTCTGACT CCGCGTCCGG AACACATGTG TTTAGATGTG AAGTCAGACT ATGTGGTAGG GAGCCTTCGC GTATTAGGCA TGCGTGTATT AGTGTAGCAA GGTTACGTGC TACCGTAGCT GATAAATTAA GTGACAGGGG AGACAGAGGT GAACAGGAGC CATCATCGCG CGTACGTAGT GCTTTGGGTA GCGATCGGAC CGTTTTTCGA CGGTAAGCTG TACGAAGATA TGTCGCAGAA GACGTTAACT ATTTGAGCCT ACATCAAAGA GAACTAATGC ATGTACAAAT TTTATTAACC GATAGTGACT AAGAAGAAAT ACATATACGG CACCAGTCGC CATAGCATGC GGGCCACAAC ACTGCGAGTT TGAATTCATA GGGTCCCTTC GCGCGGCAAT TAATCGATAT AAGTCGCGAA GTTGCGCGCA CTACAGTGCT AGCACCGCAA GGTTGTGCTT ATGGTACGAT AGTAAAGATT CTGGCTGTAA GACCTATTTA AGAACTGCTT TTCCCCCACC TCCTTCGTTA AATAACATGC CACGAACCGT TAGAGGGCTA TGGGCAGACC TAGTCGCCTA CAAAAAATAT TACCCGGGAG GCTTGTTGTC TTTGGTGTAC GACATCAAAG TAACCATTCG AGCCTCGGGA GCTATGATAG CATTATGTGG CTGGAAGAAC TGACATGCGA TGGCTGTAAT GGTTGGTACG AGCCGGTCAG CAGGGAATTT GATACACGGA GGTGGTTCAA CGAGGCTCAA CATCAAAGAT CAACGATGGC TTCCGTAGTA GCGTACAGCG ACACGCCAGA TAGTACTTAA AGCAACGTCC GCCCAGCACC TTTACGTCAG AATAGCCTAG ACTGGTGGAA CCAGAAACAT TATGATGTGA CCTGGTGAAC ATAAAATGCT GCGGACCCAT CTTGTTACAA AGCTTGTCCA CTCGAAGTCC TTACGTCCGA TCGATATAAA GAAAAAATGG CTTTAGATGT TCAAGTCAAG TTGCCCTTGA AGCATGCAGC TGTCAGTGCC CCTTTCTAAA ACGAATTTGC GGCCTCTAGC GGCGTCCGTA CTTATGAAGC ACGCAATACA CGTCCATAAG CGTATGGGTC CACGTTTCAT AGTGTTCTGA ACCCGATGGA AACTACGGCG CATCAACCTC ACAATCAACG GCTAGGGGGA ATGGACCAAA CCTTCAACGG GGGACTACGT ACGGGACAAG CGATCTACCA AAGCGTACAG GGAAGGTCTG AATGAAGCTG ACGCCACTTC ACCCGAGCCG GACCACTAGT GAGAAGACTC TAGTTGGTTG CGTCCGGCTG CGTGTTACAT GTGCGGGTGT GTCAGGGGGC CTTGAGATCA CGGTCAGCAG GGGGACTACG GGCGGCATGT CACGGTAGTC GTAGAGTGAC TAACAAGGAA AGAGAAGACA GTAATACATA ACTTTGGATG GACAACTTTA GTCCGTCTAG GGGCAAGGAG GGGTCGACAC CTTAGAAAAG AGTACCCTGG AGGCGTCTTG TACACCAGAA GTGTAACTCC CAGGTTGGTA TCTCAGGTTG CGCAAGTGTA AGGCACGTCC TTTTAACATC ACGTCTGGTA GACAGCACGG TACACTCAAT TTCGGGCGCG TATTAAGACC CCACTTCTCA CCTCGGTCAG GGCATTCATC CCACCAGCTT ACCGTAGCTT TAGTACCACC TGGGAGTCTG TTGAAGTGTC CTCAATCCTA CCGGGGACTA CCTCCTCATT CCCCCAACGA TGAACCGCGG ATTCAAGGCG GAGATTCTAG AGAGAAATTT ACCAGGAGGC TCCCACATAG CCAAGGGGTA GAGAACGCCT TTCTGCGTTG AAACAAAGAT AGAGAGAAGA GGATCAACTT AGAAAGCAGA TAGGGGGCAA GATGACCACT TGAGGGATCA AACGAGATAG GGGGATCAGC CGTCTATATC AATCTCAGGT CAGAGCTGCT AGCTAAGGGG GTGAGGCAGA CTAACTTATT AGCTTGTCAG ATGTATGAGT CCAACACACG CCTCTTAGTA CGGAGTAGCT TATTTACGTC AAGACGCGAC TACGCCACTT GGGTGGGAGT GTAAAGTCGT GACCGACTTA TAAACGCTCC ATCACGCCGG GCGGGGGTTC TTAGTGTGTT AGGCTCATGG TGGTAGGGGG GTTCGCTCTG TGGGGCGTCT GTAAACATTC TTAGATGTGG TCCCTTCTAA CTACATACGC TTGGTCGCCC TGCCCGCGGA AGGCGTCCGT GGTGAACCGC GGGTAGGAGG ATGACCGGCA ACAAGTTTTG TGTGTTAATC TTGTCCACGT GAAAATAATC ATATCTGCTA GAGGTGCGAG GTAAGGGGGC CGTTATTCGG CTATATTATA ACGCTGAGTA AAAGGGGTGA GTTCACCCGT CGTATTTATT GCCCTTTCTA TCGACACGCC GGTAGGGGGC TGTACCGAAG TAATCCGACC AAGACCACGT TTCGAACCAT GTATTTACGT TCTCATTGAG GATGGATGAA CATTGAGTTC TTAAGCTCAA TGTAACTCCG AGGGGAGCAG TTGGGATGTA ATTCGTAAAA CACGGAACGC ATCGATATAA ACGTCCGGCT TACGAGCTCA TGAGAGATAG TGCTGGGTCC GGGAATGGTG AACTCGCGCT GCCAGAGCTG AACTCTGTAT TAAAGAGGAG TATCCCTGCA ACTTCTCAGG GATTCGTAAA ATAAACAAAG GACTAGGGTA AAGCGCCTTA GTTAGGTCCC TTGGTGGCCC TTTAATAATC CTGGAAGAGA GCCCAGACGA GTTGATCACG CGCACTTGGA TTTGGATGCT ATAGTAAAGG GTTGCCCCTA TGGCGTGTGC TTGGACCAAT TCTAACTTAT CCACGTGCTG CCCCAAGAGA GCGAAGGTAG AATGGACAAC CACACGCTAC GTTCTGGCGG CACACTTAGA GCTCTAGCGC CTCTAACCGC CACTATTAAG ACGTAGAGCC ACAACTTTAG CTCGCGCATA TGATCACCGG GGTTGTCAGC GCAGAAGCAG GACGGAAATT ACAAATGCAT AGGTCTTGCC TTGTTGGGAC CGATATAAAC GAAGGCGCCG AGCGGTCCAG CGAAGTATTT CGTCTCATTG GTCTATTGAG CGCCCCAGCT TTGCGCTGGG ACGCGGGGGT ATATAAGGCG TTTCGTCCCT AGGAGCAATA AACTTACCGT GACCATCAAA ATGCCAGGCT ATCTGATGCA GCGACTAGGG GGGGGCAAGG GGGCTGTAAC TCCAGGAAGA ACTTAGAAAA AGCGAGGGAA GTAGCATTCG TCACGGCAGA AAGATATAAG TCTCTGACAC ATACACATCG TACTCGCATC CGCGGCTTTG CTCACGGCCG ACGTCCATAA TACTCCTATA AGAAGCAGTT CTTTCTTACC ATTTATTGCG CGAAGATATA GCTGTTCGCC ATCCCTCCGT CATATACGGG ACTGGCACTG GATATTTCCG TCGTGAACAA AGTCAGGGGG GGTAGTTGCC AGGGTGCTGA AGCTTCCATT ATCGAGATGC TCCCGTCACC TGATTATCAA GTGACACAAT TATTCATGTA CGTACTATGC CCTATCACTT GTCGCAGAAC GATCGAGTAT ATGCGAAGAG CGAGCAATGC CCTTGACCGT CGGCATGTAT CTACATCGGG TCACCCGTAC CGCGGCGTTG ACCAGCTTGT ACTGTGGTAT GAGACAGCCC GCGCGACAAC TGGGTATAAC AGCAATGCGG TGGGTAGGCG GCTCCTACTT GGACAAATCG CTCTAATACG CGCGCGCGTC GGTGAAATGG TATTGAAAAT CCCTTTCTAA GAGTATTCGT TATTCTCAGC GTAGACCTCC GCGTCCGTAC TTCTGCGACC GTATAATTCT ATAGTTGGTT CGGCGGGACA ATCAGTTATA CGAGCGATTT CGGATTGTGT TGGATGCTGG CCAGCAGAAC CTTCGGGGGC CTCACGGTAG CCGCGCATGT AGGTCTGGAA TCCGGCTGAA GGTGATTCAT AGTCCCTAAC TAAGGCCGTC CCCCGAGGTA TGTCGGGACG ATACGGGTCC AAAAGCCCAG CCGTGTGCGC CAGGGGTCGA CACGTGTTAC TCAAGGAAAG AGGGGGCAAG CGGGGGTTCA GCCGTGGAAC TACGATGACG TCAGGTTGGT CCGCAAGTGT ACCCCTCACA CCAGAAGCTG ATTCTAGGCG GAAGACATCA GACCAGGAGG ACTAGATTAC AGGCGTTTAA TGCTGTTAGA CTGTCGCAGA TCTCTACCGT AAAGCTGCTC GGTCATTCCA TTTCTAAATT TAGAAGAGGG ACCGGTGATT CACTGTCTCC TCCGTGTACG CCCGTACTCA GGTAGGGCGG GTCGAGCCTG TTAGGTTCAG AAGTAGATTC GCGTTGGTGG TTGAGGCGTA ACCCTGCTGG GCGCCACCAG CAGGCGATCT CTAAATTTAC CCCCCATCCG GACAGCCCTT ATTGAGAGGA GGGATTATTC GTTGTGCACG GAAACTATGG ATCCGTAGGC GCTAGAAGCC TGATCCTTCG TGCTCCATCT TTGGCCTTTA CAATCCCGCC GACGTAAGGT AATAGAGCGG GCGTTCTTCA AATAATCTCG CAAGGCGGTA GACCTCGACC AATAATCTCA TTTAGTTGAA ATTACCGTTC AAGTAGGGAC CCCAGTTGGC GGATATAATG CTGTAAGGAA CTGCAAGGCG TGACTTTCCA GGTCTTTGGT TCGTAGAAAA GTATTTATTG CAGATGGTAC TATAATTCTA TGCTGGGTAT CAAATGCAAG TGCCCCTAGA AAAGTCGCCA AAGTGTACCG CAGTAGCTAT CAGTTGATCA TTACATACAC ATGCATCGTT ATTTTGGTAC AACTTTGGAT CTTGGACCAA ATCCCTGGTG CATCTTATGC AGACCACGTG CGATGTTTGT CGAAAAGTAT GACCAAAGGA TCTTCGACAG TCCGGCGATA ACTTATTTTG TACCGGAGTA GCTCTGGAAC CAATACTGCA GTCTTGTAGC ACGTGGCCGG GTACCGTAAT TCAGCCGCTA GGAGGCCTCT GGCTGCACAT AGGTGATCCT CCACTATGCG CTAGCAACGT ATCTCTAAAC CGTACAGGTA TGCTGGTCTA TAGGCGAAAA TCCGGATAAA TGCTTTTGCG TTACGCCAGG TCGAAACACG GGTGACAGGG ACACTGGCTG GCTGGCAACA CTTGATAAGT GCCCCAAATT TCACGGCCGA ATTCCGTTCG AAGGTCTCTA GACTAACACA CAAAGATAGT TTCATTTCAT GAGGCGCTAC CATTGATAGG AGGCGAAAAA TTGTGCTTTT CTTTCTGTCA AAGCACTAAA CCCGATTCCA GGTCCTAGCG AACCGCGATC GGTACGAAGA AAATCAGGAT AAACTGGACT ACGCCGTAGT AGTAGACCTT CGCAACGTTC TTTACGTCCG TGCATTGGGG TTCGCTAGCT TGCGGTGATT GACCCAGAGA GCCCTAGCCA TCGTACCGTA AAAGTCAGGG GTTTTTTTCC CTAAGTTGGT CGTGGCCTAC GGTCCCTTCT CACTATTCAT TATTGCGCCA AGTGGGCTGG GCCACCAGCT AGGTTCAGCG ATAGGTAGCT ATTTGGCATG CAAATTCCGG TAAGCTCACT TGGCCGGTCG CGAAGACGCG CTTGGTACGT GAAGACTTAA TGAGGTGACA AATTCAGACA TAACACACTC TACCTACGCA GGAATTCTAT TGGTATAATT TTGATCACGG ACGTGCTGTC GCTCTCGGTC GATCTTTAAT GGACGTTTTT GATCCTTCGT ATCTGTAAGA CCGACCAGGA CCTTGCATCA AGTCCCAGTG TTGTTTAATG AACTTATTTT GAGATAGGGA CACACCGCGA TGCCGCTGAA TGTGACCACA TCGCGTCCAC GTACTCACTG GGCAAATAGC AACCCGGGTC TGTGTTTTAT CTGGTAGCTG GGCGAAACAT GTGTTAGAAA ACGTCTGACT AAAATAATCT CTATGATTGG GCTGGTCGCA TGCGCCAGTG ATTGAAGGGG AATGGCTTGG TATTAGGCAC GTCTCATTGA AGTTCGCCGC CCCTAGAAGA TACCCCTGAC TTGATTGTCG ATACCGGAGT TCGGGCGCGA AGACGTGGCT CTGAACAGGA ATGAGCAAAG GATTTTAGCC CTTTCACTAC TTTGAGCCTT CGCTCCCTGG CGCATAGACG GCCTCAGGGC CGACCCCAAG AAAAGCCTAT CGCCCAATCG TCTTTTTCCA ACAGGGGTCG TTGGATGCTG GTATAACCTA TGTTGCGTAC TTTCGATTAA CGTATTGTTT TTACCTACCA GCGCCCGATT CGTGTCACTG TACGTCCGAC AGGTGGTAGA GATAAGGGGC GGACTACGTC GCTGCTGGTT CCTCCACAGT AGCGTACAGG GTTGAGCCAG CGTTCGTCGT TGAGCTACAT CGCTGGCTGT ATTGGGGCCG GCTTTGCCCT TGAGTTCTCT CTCCTCGGGG CACTTCTCAG AGTTGGTTGT CTCTATTCCA CGTCCGTACT GTAGGGATAA TTCTGGGACC TGGCAATACC ATTTATAGCC GCCCTAGTGA GACCAATGAA ATGACAGTAT GAGGGCGGCA AAATTTACGT CCACGTACCG GGTATAACCT TGTAATACAT ATCCCAAGGT AGAGACAGCC CAGGCTCACG AATGCGGTTG AAGCTATATA CGCGATCTTT AAATTTGTCC TGGAAGCACG ATTTAGCCCC TCACGGTAGT CGGCAGATAG GGTGGCCCCA AGAAGAGGGC GCGATGCCGG GATATGGCGC ACCGCAAGTG TCGGGAACAA CGGCAAACGG ATCAGCACGA AGTATCATCC CAGATTCGTA CAACTTTAGA CGTTTTTTAG CAGGAGGCCT ATTTGTCACG TCTAGGCGAA CAAGGAGGAA GGGGGCGCGG GGCAAGGAGG GTACTCACGG TTGGTACGAA TAGTTGCTGG CATATGTTGG AGTGTAGAGG TAAATTCAGC ATATAAACAA CTACGTCCAT TTACGGCCAA CCAGTGGGCT AGACCCATAC AGTGGGATTA CTGTGATCCG CTGTCGTTTT ACACCCGAAT TCGTAAAACT AAGCCACGCG GTCGCACTTG CTATATTCTA CATAAAGGGT CAGAGCACAT TACACAACTG CTCTACCGTA AATTAGTTTA CGAAGAGCCA AGCCATCTTA GAGTCTGCTA TCATTCTACG TAGCAGTTCT TTCTAACTTA CAGTATACCG CACAACTGGC GAGCGTCAAT TCGCAGAAGC AATATTTGAA ACTTTCACAG GCATCTCCGC GCAGTTGATC TGTACAAATG CGTATGGTTG CTGTGGTATA CAACGTGCGA CTCGCTACTG GGGCGGCATG TTCCACACTG CTAAGGAACA AATAAAACTA AATGCGTTGC AGCGTATTTA GCGGGTATGG GCGATCTTTA GACGTCGCTT ACGCATACCA TACGGGTCCC TGAGCCTCTC AATTGCCGGC GGCGAAAAAG TTCGTTAAGA TCCATAAGCC TAGTCACCCT CTGAGGTGAC CAGAGTGTCT CAGTCACATA GTCCGACCAG TAATACATAT CCTTCAATGC TCAGTATCAC CTATGATAGT GGCATGTATA TACCGCAAGT CGGGCGCGAC TAAGCGTACA GTTTTTTAGG CCCTACACGA CCAATGAAGC TGGCCCGAAC AAGTAATTAT CCCTCGCCAT CCGATAGCAA TAGATATCAA GGCCGTGTAA TAGTGGGTGG TTAAGGCCGC GAAATTGTCT TGCATAAGAG CAACATCTAT GATATAAGGC TCTAATGTCT AGCGTTCTGC GGGTGAAATG CGTGAGCCGA TTGAAAAGGG ACGAGCTCGT AATTTACGTC TAGCTTTCTT CGCCCTCTTA ATTGAAAATA AGTGACTAAC GAGTAGCTAT GGTATAATTC TACTCTAGTC GTATACCGGA AGCAGTTGAT CGCCAGAGCT CCGTCGTCTT ACGCTTGTTA GAGGGGTCCA TGCATATGTC CTATATTAGG CTAACCGCGA GGCAAATCGG AGCAGTAACC TGGCCATCCA AGAGGTGAAC GCTTTTGCGC ACGCTGACAG CATTGGGGCC TCTAGACAAT CTCTAACATA TCCAACTTGC GCACCTTTGT CAAAGATCCC AGATGTGGTA TGGATCGCAT GTCGTTTTTT ACTACGTCCA GGGACTAGGC GGGAATTTGA GTTGGTGGCC AAAGGTCGGC CTTCTCAGGG GTAGGCGACT AAACCGGCCC ACGGAAATCC GCATACTAGC AGAGGACAGA AAACGGAGAT ACGTCGGAGT ACACCACAGG AATACACAAC CCGCGATCTT CAGTCAAGAT GTGCTGGAAT ATATGGCGGT AAATGGGGCC ACAGGTATTT TATCAGCCAA AACCTAGTTC TATTTAATGT AGTGTCGCGG AGATGTACTA CTCACATTTC TGAGGCTGGG TAATCTCAGG ATTGATGGAT CAGCCCAAAG GTCGAGCAAT AGTGTACCGA ACTTGGACCA CACTTGGACC GTTTACCCCA ATTTCGCGCT ACACAATCGC GGTAGGCGAC GTTCGGGCGC CAGACTTGTC CTGGCTTACT AGCAAAGGGG AGCGCCATTG GGCGCGGCTT TTGAAAATAA TTGAAGGGGC CTTGTGATGA CAGTGCTCCT TGGTCGCACT CTGTAGATTA CGACACGCCA TAGTACTAGA TGTCGTTTTT GGCGTAGTAA TCCACGTGCT TAGTGACTAA TATTACCACA GACTACGTCC GTAGATTACT GGTTCACGGG GCTTGGTCGT TACTCACGGT GATTCCGGGG GAGGATCTGC TACTCACGGC TGGTGAACCG CGACGTAGAA CGGTACCTTC ATCGCACGCT CGCGACAACT CTAGTTCGCC TGTGCTTTTG TGCCATTGGG CAAAACCAGG GCAAGTGTAC GCAACGTCCG GGTGATATCT AGCCCGTGCG GCACTGCGTG TAGAACAAAC ACGGGTCCCT TAAAACTTTG GCCATATGCT GGCCATGGCT TCAACTTGTT CGTCGGGTAA CAGATACTAA ACTGAACGTG AAGCCGCCCG CGTAGACGGC TACTACACGG GGTATTTACG GTGGGTAGTA CGTAATCGAT ACACACTTAG GTCATAGAAA GACCCTCTAA AATCAAGGCC CTGCGTGTAT AGATTCTAGG AGTGAGGTGG AGACGCGACC TTAAGCTTAT TATATGACGG GCGCCAGTGG AAAGTTATCC CCACCAGGGG AAACGGGTTA GCCATATAAG GAGAAGACAT TGACGGTTAC GTCCATAAGC GCCGTGTAAG ACTACGAGGT CAATCCACAC TTTTGCGCCA ATGTACCCCA GGGCCACGAG AGAAGGGACC GGGTCGGTTG CTATGCATTA TCTTTACCTC TAACCTAGTT AAGATCCCTG TCACCGTGTA TATGAATGCC GGTGATCCTT TGGCTTTCGG ATCCACACTC GCAGATAGTA CGTCAGACTG GCTGTCGTTT ATGCAGAGAG AGCTGCTGGT CCACGTGTTA GTAATAACGG CCCTCTAACC GAAGAGGGCG TCGATAACAT TAGGGCTACC AGTTAAGCAG CACGGCCGAT ACACACGAGG CAATGAAGCT CTCGGGGTGA ACAACAGATT TACCGAAGAC AAAGGCGCGA AATGCGGAAC GGGAGTCCAT AACCGAAAGC CTGGTGAACC CAGCGTTCGT TTCTACTGAG GCGGCATGTA TTTTAAAATT CCATAAGCTT TGTTGAGGAA GATCCTCTCC GCAAGGTTTC ACCGGAGTAG ATTGCCAGAT CTCAGGTATT CAATGCCTCT TTCTCTACCG CTGCCATACT AGCTGTAGTA GGGTTCACCC AGTACAAGAA TACCAGGTCA GAGACCTCCT TCCATCCGCC GGTTGTAATT GTCCGGCTGA GAATCATCAA CCACAAACTT GGTCGGTAGG CGTCCTAGTT CTTTTACCAT AAAGCAACCT CGCACACCTC TTGAGGAACT CATCTTGTTG AACGATACAT GAGGAACCAA GTCGAGTCGT AAGAATCCTA CCATGTGGGG ACTCCGTCTC GAGACTCAAG TAGTTTAAAG GTGAAATGGA GCCGATCGCG AAAAGCTGCA CACACTACTC ATGAAGCTGT CGATCGCGCG GATCCCTGGT TCCTATAACT TAACTGATCA CCCATTCGAC TAGCCACGAG TACAGATCAC TAGTGCCGGA ACTAACATAG TTGTCCTTCC GAAAAGTCAG TGTGGTAGGG CAATATCCCG GCTAGTGAAC CGCTCCTTTG CAGAAGAATT GTAAGCGTAC CCTATCGCGT CGATTTTTCA GTTGGGGAAT GGACTATTAC GCAAAGAATC CGCCACGTCG TGTCCTTTAA AGGGGGCGCG AGTTGATCAC GGAAGAGATT AGAGACCAGA GCTTATTCCT TCCCGGTAAC TAGGCACGTC ATGTCGGAAC GCCTTGAACG CTCTGTCGTT CTCAGGTTGG GGCGGGTACT CAAGAGACAG GCACTTGGAC TCGCGCGCGT GTTAGGGCAC CGGACAAGTG CATGTACAAA GCTTGTGTAA AGTCAGGAAC ATAAGCTTGT GCCCCAAGAG CGAGTAATTC TCGGAACGTC GGAGCGCCCA TACCGGTGAA GCGCGCGTCG CGTCCGGGGA AACAACGCCA TTTTTTAGGT CTTTTTTGAC ACCTGACGTG TTTAGGTGAT CCTGGAAGCA ATGTTGCTTA TCGTTAAGAG CTGATGGTGC GGTTGCGATA AACGAATGCT TTGCACAGGC GGGGGTTCAC TCCGGGGACT AGATAGTATT CGCGCGTCGA CCTGGCTACC ATCCTATCCT TTCATAGGCC TCTGACGCGA GCGAAAAAGA TTATTTTGGT CTCTGCCACA TCAATTACCC AACCCTTCAA GACTGTAGAT CATCGGGCAC TTGATGGGGG CTCCTCCCTT GTGTTACATA TATGGCACAA AGTCACAATG CAGCCTTTGA CAACGGATTA GTTTATTCTT GTAGAAGCGC GTCCCTTCTA CTTGGTTGCG AACGCTTACT AACGCTTACC CACTAGGCCA AAGTCTTTTA CGCTCGGCTG TGTTATTTCT CCTAGTTCGC AGAAAAGTCA AGCTATGATA TTTATAAGGA ACCACGTCAA GTACCGAAGA ATAAATTCTA AAATAATCTC GCGTCGAGCA GCACCACATA AGGGTACGCC ACCTTCGTCC TCGAGCAATG CGGAAAAGCA CAGTGGGCTG TTGTGTAACT TGGGGCCGTG GCTGAACAGG GGTGTATTAT AGTTAAAATA CTAGGGCAGA GACTATGGGC ACCTGCGATT CCGATGCACG TGGACAACAG GTACAGGTAT AAACCGGTTA TTTTTCCGTA TATGTGTGTC TTATGCATCA CGGCTTTGGG GTGAACCGCG TATAGATCGG TTAGGGAACA GTCTGTCAGA ATAACCTAGT AATATTGCGT TAAAACTCCC GGTTCGGGCG TGACTAACAC ATTCTACTGA ACCCGTACAA CCGGAGTAGC GCTTGTCCAC CACTCTAGGC TGGTTCGGGC CCTTTAAGAA GCGGACGAGT TGGCACTGCG TGTTTCACAT GGGGTCGACA GGCAACGCGT GCGATTGTAG ATGACTCAGA AGAATCGACG CACGCGGGGG TGTTCCGCGA AACTGGCACT TGTTGGCCCT GGATCTGCAA AGCCCTTTCT CTGTAATACA GCACGGCTGA AAATGAACAT AGGTTGGTAC TATTTATTGC GTGACGGGGT CAAAGCCGTC GCCTATTCCT ACAGAGTATT ACCCCTATAA CGTAAAACTT CCGCTGGCTG TTACTATCGA GTAAGCAGGT GAAGCTGTCG GTCTGGAAGA TCAGTGACGG GGGGTTTGCA TCAGGGGGCG CTGTATCGTG AGGTGAACTC TACGTCCATA GTAGCGTAGT AAAAGGTCCC GTCTGAGCCT CCGTTATGTT CGATCCGTGA ACATGTATCA AGCGACCTAC GAAGATATAA CTGGACGAGT CGCCACCAGC CGGTTGCCCC GGCGCCACGG TTATTGCGCC CACCCGTACT CCGCCACTCA CACTGTTCGA ATAATTCTAC AAGATAGTGA AGCCCTATCG ATTCGTATCA TAATAATCTC CCCGCTGTCA ATCGGGCACT CCGTGCGTAA ATCGCAGAGC GGTCTTCTTG TCTACTGAGG AGCGGCTCAA CGCGTCGAGC GTGGTGGATG GCGCGGCTTT AGCTTGTGTA TCAGGGAATT GACCGATGCC TTAGCTTTGA ATGTATACCG GGTTCTACTC GCGTACAGGT CCTGAATAGA GAGACTTATT AGCCTGGCTA ATGCGGTTGC GTACAAATGC CTATTCGAAA TGTACAGAGT CTATTCATGT AGGAGCGTAT CTGGGTATAA GAAGAGATTC GCCAGTGGGC TCTAGTCCCC GGGCACTATT TGTAGAAACA GACACAAACT GTCGACACGC ACGAGGGTTT TTCTTACCGC CGACCGTGAG AACTACGGGA GGCACTGCGT CAAATGCATT CCTACCCGTT GGCCCCAAGA TGTCGAATTG GGCCAACCAA GGCCAACCAC TCTCACAATA GCTAGCCGCG TTGACGGAGA GCGACCCTCT GTGGTAGGGG GCGCGATAAT CGTACTCACG GGCCGATCGC ACGGCCGATC GGCGCCGTCG ACGCGGGTAC TGCTGGTTCG AAAAGGGGTG GACAATTCTA GTCGCAGAAG TGCCGCAATA CTCCGAGAGT TATACCGGAG GTGATCCTTC CAATCTGTCT CGTCCGACCA TCACTCCTGT ACATACACGC GGGTGCGACC CATAAGAAAG CGCGTATACA GGGTACGCCA ATCGTAACAG CCCTTTCGCA TATGATAGTT ACGTACCATT CTAACAAGAT TGACAGGGGT CCACATGCCG GGGCTGGTCG CCAGGAGGCC CGCACCTGCT TGACCCGAAT AAAATCGGAC CCTTCACGCG CCTTCGCTCC GAGGAAGGTC GGGGTGTAGC TACCGTAATC TGGCGCAAAA AGCCACCTCT AGACAGCCCT CGACCCTCTA GACCGACGAC GGCTGACAAC TGATAGTTGG AGTCAACTAG GGTTGGAACT TCGACCCTAG AACGTGCGAA GGTGGGTGTG CCGCCCGTGA AAAGACGTGG";
        //string[] patterns = pattern.Split(' ');

        //string s = string.Empty;

        //foreach (string p in patterns)
        //{ 
        //    s = s + Locate.BWMATCHING(original, transform, p, lastToFirst) + " ";
        //}
        //*** usage end
        public static string BWMATCHING(string first, string last, string pattern, List<int> lastToFirst)
        {
            string result = string.Empty;
            int top = 0;
            int bottom = last.Length - 1;

            while (top <= bottom)
            {
                if (pattern.Length > 0)
                {
                    char symbol = pattern[pattern.Length - 1];
                    pattern = pattern.Substring(0, pattern.Length - 1);

                    string topToBottom = last.Substring(top, bottom - top + 1);
                    if (topToBottom.Contains(symbol))
                    {
                        int topIndex = top + topToBottom.IndexOf(symbol);
                        int bottomIndex = top + topToBottom.Length - 1 - Helper.Reverse(topToBottom).IndexOf(symbol);
                        top = lastToFirst[topIndex];
                        bottom = lastToFirst[bottomIndex];
                    }
                    else
                    {
                        result = result + " 0";
                        break;
                    }

                }
                else
                {
                    result = result + " " + (bottom - top + 1).ToString();
                    break;
                }
            }
            return result;
        }

        public static List<int> FirstToLast(string s)
        {
            List<char> first = new List<char>();
            for (int i = 0; i < s.Length; i++) first.Add(s[i]);
            first.Sort();

            string t = BurrowsWheelerTransform(s);

            List<char> last = new List<char>();
            for (int i = 0; i < t.Length; i++) last.Add(t[i]);


            List<int> result = new List<int>();
            for (int i = 0; i < last.Count; i++)
            {
                char ch = last[i];

                int ord = BurrowsHelper.OrderOfChar(last, i, ch);
                int ord2 = BurrowsHelper.GetCharPosByOrder(first, ord, ch);

                result.Add(ord2);
            }

            return result;
        }

        //12. Better BWMatching problem
        //*** usage start
        //List<string> input = Helper.ParseTextFileToStrings();

        //string transform = input[0];
        //string[] patterns = input[1].Split(' ');

        ////string transform = "GGCGCCGC$TAGTCACACACGCCGTA";
        ////string[] patterns = "ACC CCG CAG".Split(' ');
            
        //string original = Locate.ReverseBurrowsWheeler(transform);
        //StringBuilder result = new StringBuilder();

        //List<char> firstC = new List<char>();
        //for (int i = 0; i < original.Length; i++) firstC.Add(original[i]);
        //firstC.Sort();
        //string firstS = string.Empty;
        //for (int i = 0; i < original.Length; i++) firstS = firstS + firstC[i];


        //foreach (string pattern in patterns)
        //{
        //    int res = Locate.BetterBWMATCHING(firstS, transform, pattern);
        //    result.Append(res.ToString());
        //    result.Append(" ");
        //}

        //string s = result.ToString();

        //Helper.WriteStringsToTextFile(new List<string> {s});
        //*** usage end
        public static int BetterBWMATCHING(string first, string last, string pattern)
        {
            int top = 0;
            int bottom = last.Length - 1;

            while (top <= bottom)
            {
                if (pattern.Length > 0)
                {
                    char symbol = pattern[pattern.Length - 1];
                    pattern = pattern.Substring(0, pattern.Length - 1);

                    string topToBottom = last.Substring(top, bottom - top + 1);
                    if (topToBottom.Contains(symbol))
                    {
                        //topIndex ← position of symbol with rank Countsymbol(top, LastColumn) + 1 in LastColumn
                        //bottomIndex ← position of symbol with rank Countsymbol(bottom + 1, LastColumn) in LastColumn
                        //top ← LastToFirst(topIndex)
                        //bottom ← LastToFirst(bottomIndex)

                        top = BurrowsHelper.FirstOccurrenceOfSymbol(symbol, first) + BurrowsHelper.CountSymbol(symbol, top, last);
                        bottom = BurrowsHelper.FirstOccurrenceOfSymbol(symbol, first) + BurrowsHelper.CountSymbol(symbol, bottom + 1, last) - 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return (bottom - top + 1);
                }
            }
            return 0;
        }

    }

    public class BurrowsComparer : IComparer<int>
    {
        private int len;
        private byte[] bText;

        public BurrowsComparer(byte[] input)
        {
            bText = input;
            len = input.Length;
        }

        public int GetIthPosition(int i, int start)
        {
            if (start + i < len) return start + i;
            else return start + i - len;
        }

        public int Compare(int x, int y)
        {
            int counter = 0;
            while (counter < len)
            {
                int xpos = GetIthPosition(counter, x);
                int ypos = GetIthPosition(counter, y);

                if (bText[xpos] > bText[ypos]) return 1;
                else if (bText[xpos] < bText[ypos]) return -1;
                counter++;
            }
            return 0;
        }
    }
}
