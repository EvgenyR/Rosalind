﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace TextBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = Locate.BurrowsWheelerTransform("GTGGATTAATGGGGGGTACATCGCCTCTGAGCTAATCAGCACTGCTCAGCGATTTAGCAATGCAGCTCTTCGCCTATTAAGGACCAATGAGCGGTAGAACATTAACCTTTACGTAGCGAGTACCAGGGCTGCTGTCAGTACGCCTAGCGTACTCAACGGCTCAACCAGGACCGGCCCTGATGAGACCACGGTTGATCAGTTCAGAGCATCAGTAGAGTAATCGCTTAGGGACTCCTATGGGCCCGTTCACCCCTCCTTCTGAATAGTCTTACCAGCCGTTACATTGGGTTAGTCGGCACTTAATATAGCATTACGACGTACAGTAGGACAACGTGGTGCTCCAGATTGTTCCAACTATTACAGCCGAACATCAGCCGAAGGCGAGCGTCAACCCTCCACAAACTTATTAAATATGCTTAAGTTTCACGCATAGTTCAAATGACCATAAGCGTTAATCGGCCTTAGAGAGAAGTCTCGTCTCCACCCACAAAAACCTAAAGCTCATGGTCCTATCCTCCAACCTGACGTCTACTTCCGACCCCTTCGACTCTCATAGGCAACGTACAATCCGGGAGGTTCGAATAGTATTAACTTGTACAGGATTGTACATCAGAGGTCCGGCAGACTCTGGGTGGGTCTGTTGACTTCCTTTTTTCGGGACGTTCATATCTGACTGGGTGCAAGTAAATATCAAAAAACGTAATTGTCTGTGGTGGTTCCGTTTACTTATTAATCGCGGAGTTAATCGAAATGAGTGTCGTCGGTAGAGGGTCGTTGATACGAGCATGGACCTCGCCAACCGTGCCACCAGCGTTGCTCCAATTCCATAGTGCCTGGAATCAAGCTAGAAATTACCAGTTAACATCTATTCGTATACTTGTATACGCATGAGGCAGTGAGACACACATCCATTGCAATGGATCGCTTGCGAAGCCGTCTCTCTTACCATAGCATCAGTTAAGCTAATCGCTCTTGAGTTCGATAGCGCATAAGTTACATACCAAACAACTACATCACTTAACCCCAACCAGGGAGACAGTGCGTCTACGGCTCTAATTGGCCGGTATACGTAATCCTGTGTTGACTTGACCTCTTTGGTGGATGTGGAGCCCGTGTGAGGAGAACGTTGGTCGTTATATCTTTGGAGCCTAAATCAAAAAGCACTACGCTCATAGTTCGTAGTCTTCGACTATCTGAAGGATGCACTTTAGGCTACCCCTTGCCGGTGAGCGCCCAGTGCGCGCTTTAACTGCGATCGGATAAGGACTGAGAGACCACAGGTCCTGACCCCGGATAGGTCGGTCTGGGAACCGCTCCTTAAAATAAAGCCCAAAAAGATTTTTGCGGTCACCGCTAGATCCAGGTAGACTGAAGTATCCACGCCACGCCCCCGGAGGTCTTTCTATTCGACACACCCAGGTACAAACCAAAACGATGTACAGGATACGGAAATTCCGCGTCAGAGGGTATAACACAGAACTTAAAACCCGTCGCCAAACGATGTACAACTCGATTCGAGATACACCTAGAAGTATCTCCGCGGCCGGGTCGCATAATCGCTTCTCCCTAGGCTCCAATCGTTCCGAAGGAAGCGGCGTGTCATTGCGCGAGAGGTCTTGAAGCTGTAGCAGTTTGTCGAACGATAGCAGCGCATGTATAAAACCTGCTGATCTTGCAACAGGGAGATGATCCTCTCGCTGGTTACAGCAGGCGGGAAAACCTGCTGTGTTGCAGCCCGACTTCGGGTGCTCGATTAAAAATGAGGTCGGACCTGCGAAAGGGTGTGCATAGTACCCGTAATCATGGTGTGTACGACTGGATTGAGTATTCCCATTAGACAATGACATCTCCTGACCTCGAAGAGAGAAGGTAACAGAGGTCTTACATTAGTACTGCCACGCCTTTGTTCCACTAAGCAGAATTGCGTGCCCTTCCCAAGGTCGCAAGGCGCCTAGGTTTGATTCACGAGAATAGTAATGCGGTTAGACAGTCGTTGAGTCTGCCCGGAAATATGCCAAAAAGCGATCTCTAACTGGTCCGGTGATCCTGCCGCTGCTAGCAGATCCTCGGTTGAGAGCACTAACCGGGTTTGCGTGTGATTCTTCAACGAGCGAGAGATGCGGTAGTGTTTCTAATTGTACGTGTAAAATAGGTCATGCTTTTCCGCGGACGAGCCGCAGGTAGTAAAGCCAGATTGGGTCAACGAACATACTCTGGCCTGGCCATATTCTGTCGTAAGGCTTCGGACGCCACCCAACTGTTTCTACGTTGGTAGAATCGCTATGCTGCTAAGGTCAGGGCTGCGCAATTTAAAAGAAAATCCGGGAATGGAACTCGGCGAACTGAAATGCATAGGTGTTCTCGGAGTGACTGCGGAGGGGTTTCCGCGAAAGCATGGACGCGACTTCGCATTGATTGCCTTGTAAGATAAATCCGCTCACACTAATCGTTTCTTGATGAAATGCCGAAACTGTGAACCGACCAGAGGTATTGGCGACGCAGTACCCGACGGTTATCATGGGATCTTGGGTTAGCGTATCCAAGCGGGATTTTTGCTCAGACTTATGGATGTCGGTTCGGTTGAAGATTATGCAACAGGTTAGAGATCTGGGCTGATGCTCGCGCCATAGGATCGTAGGAAAGGACTGACGTTTACTGCCAATTGTTTCATCAACGTCAGATAGTCTTTACGATCTATGTGGGGTTGGACAATCACATGAGTAGAGCGGCTAAGCAACAGGAAACATTCTTTTTTAGTGGGGTTGTAGAGCTAGACGGCGCTATGAGCCAGAGCTTAATAAATTATTTCTGGGTGAATAAAATAGATGGTTGGACGTACACCAAGCCTAGCTAAAACGATGCGCCATTGCGCAGCGATAGTTACCGAACATGAAGTTTTTACTTCCCTACTTCTACCTTACTCCCGTCCTTGAAAACCGATAAAGAAGGGTAGAACCGTGTAGGTTAGGAGGTCACTTGTCGAATATTTGGGCGCTTAGCAAGGCTCGTAAACCCAAAGATGTGAGTCCACAATTTGGTGGATCAATCAGGATCTCTCATTGGACAAGTGGCTGCGACGGAAACGGGAACGGTGGATCCCCTCAAGAGGTCCGGACAGGGCATTTGGTCTGTCTTCCTAAATATGGCGTCACGAGCCCAAAGACTAGTCCTCGCGGCTATTCGTCTCCGCGACGAAGGAGGTGCGACACGTGAATCTAACCCAGCGCAACCAATAGAGTGCCTACCTAGGTAGCAATGGGCTAAGTAGTGCAGGAACGCGGTGGGATGGTCGACCGGCACTATCTGAGACATCTACTTGTCACGTATTTCCAGAGTGGCCCCGGAGAAGCAGGATTGACGGGACCGTATTGGACGTATCGATATAATCGGCCCCCAATTCGCCATCTGTTCTGGAGCTCAATCGGTGCGTCGTCAAAGAACACCGGCAAACTGGTCGTAAGCGGTGCACCAGACAGTACCAATCAAGGCGTCAAGCTCCATTATAAGTGGGCCTAGAGAGGTATGGGCTGCGACGATTCCCCGGCTATTCTTCTACATTACAGGCATTATTAGGATCAAGCTCTGGATGCTAGTAGACCCATGCCTCCCGCCTTTTGTCGGGGTCGGAACGGTTAACCATGGCTCTGCGCTGCACCACGCGGTTATTTCGTCAGAGCGTGCGGTAAGAACCGCACCAAGCTCAACGTATCACCGGGTTATTTCGTGCTAGGTGAATGATAACCTTCATACTCTCATGAGAATTCGCCTAGTTTACTACTCTGAAGGTGACATCGCAAAGTCTGACGGGGCTGTACATGCACACTGGCACAAATCCCTCTGGAATATGATCATTTGACTAGAATGGTGCATCTTGGGTTGGTGCGCCAGACGGCGGATTCAAGCGAGCGGTTGAACGGTAGAACGTGACGTGGCGCACTACTATTTTTACATTGAGCTCATTAGATTCCACCTCAATTTCACCAAGGGGAAGTAAGCGATGACCATGGGCAGGTCGTAGCCGCTGGGTGCTTCCCGCAACGCGATGGGGAATGTTCGCTACCCGCTAGACAACCCATGGTCGACAAACTACTAAAACCCACGGCTGCGTCCGAGTGTTTTGCAAGGTTGTGCTGTGGTCCTCCCTAAAAAATCATCGCAACATATGCTGTTCCTCGCGTCTTAACGGAAAGTCACGGGAGGGAAGGAACCTGAGATGTTTTGTCCTCCTCAATCCACCGGCATGTGACGTTGACGAGTCAGGTAGCTATATCAGGGCAACTGCTCGACGAGCATAAGTCTTGTCAACGTGTCGCGACAACCGCCAACCATGAAGATCTAAGCGTTTAGAGTCCTATGATGCCAATGGGGTTTTGATCTGCAAGGGCGCAAATGCACAGAGCTCAAGCCACTCAGGGTATGATCCAGCTCTTTGACACCTTGAAGAGACTCGTCAAGATACCCCACACAATTTAAGCTCGGTTGGATATAGGGTGTTAGGAACATCGCTAGAAACCGCACGGGCGTGAACTATCGGAGTACCACTTCACTCAGCAGAGCAGGCACTCAATTACTTCTGAGCATACCCCACACCTTAAAAGTCGTCTTTAGATGGATCTAATCATATTCCGACTCTCCAGCAGCAGTTTAACAACTTTATCTGGTGATCTAAGCTGTAGGGTCATGCGAAGCGTACTAACCTCCGAGAGTTCGCTTTGTGTTCCAGTGCGGACCGCCTCGATAGAGGACTGGCAACGAACGAACTACAAGATACGTATTTCGACAGGTCTTACACCGATGATGTGAGTATAGGTGGAGACGCCCGCGCGTTTGATTGCTGCCATCATGTCTGCTGCCTATGTCATGGCAAGTCGGTTGAGGTTGACCGTTAACACCGCCGTTTAAGTGGGGATACCCCGCAGGGTAGGGTTCGTTGAGTCCGTATACTGAATGTGACACTTTAGAACCTCGTCAGACTTTCAAGAAGAGAGGAAATGAACCCTTTGGTACTAACAGGGTCGGGCATACGCCGGAAGGTGGTAGGTCTATAACAAATAATTATGGTAGGTGGACGTGTGACCGGAACGTATAAAGCGCGTCCGCATAATCTCGTTTCAGTAACCTAGGGAATAACGTGGACGTTACGAACTACGTGATATGAGTAACTGTTCGTCGTCTAACCATAGACTTCGTACGCCTACACTTAATCCCACGTGGATCATCTTTAGTCCGACTGGAGTCCTGTCGCGGTCATCCGTTATCACGGGCTCCGTCGTATGTTGGCAATAACCAACGGTGCCTTGTAAGCAACGGACCAGCGAGTTGTGAACTTAGACAAGTGGGCAGCAAGAGCGGCGGTTGATCGGAGACTATCACACTTTTCAAACGTATCTCGACGGTGGCCAGGTTCATGGATGCTCTTTCTTGCATTAGTGGCGAGAAATGTCTGACTGGGGACCGGCGCCCAACCGCAAAGCTGATAGACTATGTGATCTCCTCATACCAGTCATAGGTTGGTCGGACTAGTCCGGCTTTCCTGTAACTTACACAGGGACGGTGTCTATGGCCCATTATGTCTATATTGCTCACGGCATTATTGTCATGCACGCACTGAGTGTACGGAGACAATCCTGCACTATAGTACACTTAAAGACTAAGCCGGCGGCGAGCAATGACTTCGCGCCCGTACTCTACTCATATTAAATTGCGGAGCTTGTATAGACGTACAACGAACATCGGCTGATGGATCTTAATGCGATACACGACGAACACCCCAGCGTGTGTGATCTATGGTACATCAGGCTCAGCTAGATGTAAACGTATGTAATGGAGAATGGGCTTGAAGGTTGTTTGGTCACCTTAAACTTCGCCAGTGCTTATCTTACATTATTAGGCCAGTAGGCACGCTAGGCTTCGGCCGCCTCTATCTATAACATACATAGACGTGCACGTGCGGACTCACCGCGAAGAACTCGGTGCCGCAACAGCCATCGTTCGCCGTCTAGATGGCCAGTTAACCCCGGGAGATTAACCGGACATATTTCTTGACGTTGATCTCCGGGTCGCAGGTTCAGCCTATGTGGTCGAGACCTCGTCCATGGTCTAGTTGTGACTTCGTGCAAGGGGCTACAGTGGCAGGGCGTGAATGTCTTTGCCCAATTCAATTAACCCCCTGGCTTTACAATGTCAAGTGTGCGTGACTCAGACCGTCAGCGATGACACGAGTCCGCCCAGCCAGGCTCGTAGAAGTTTTTTGGGTCGTGTTCTATGTATCTCACCACTCACTCATCCTTCCAGGAATGACGGACTGCGGTCGACGGGTTATACTTCCCTAGGGTCACACGTTGGTTATTGGACGAATAAAGTGTCAGGATGAAGTATACCGAAGAACCTAGACATAGTGTAAAGAATGTTAGGACTACGTTAGACATACCCAGCTGGTATGAGTTGCCTAATAATGTTCCAGCTGCGTAGTTATAGAAAATATGCCGGTCCCGGTACGTATAAGCGTCTCCTCTTAAATACGAGCGCATTCACTGCATGGTACTGTCACACTGATCGCGTTGGTGGTCTTATCGTCGCGCTCCCAATTTGGCCCAACATGGACCGGCCGTCCACGATGTTGAGGTTTGCATTGAGTCGTCGAACGAATGTTTAGTTGTGTAAACATCTAATATGCCTATAGAGGAGCCTAGCATCCAAATGGAAGGGTGGTGTGTATGCAGTTTTACCAGCCGCCCGAATGTGGCCGATCTCTCCCGCGTTCTCGTATGGTCGCATGCGCGGCAAACTCTGCATATCTTCCCAGCAGCCTCTGGCATAAGATGCAACGCTGTAGGGGTCTCAATTGCAACTAACCCTTAGGGTGCTCGTTGACGATACATCTCTAAGTCAAAAGCTAGTTACTCGATACACTGTCCACATTATTACAGTGCTATTATACAACCCTAGATTTTACGTCATTACCCGAGCACAATCTAGTGAGAGGCGGACACTCAAGTGCCGTATTTAACCGGGGGGGAAGCAGTGGTGCCCCCGACCACACTTTACGAAACGCAGTCGTGTCCTGAACCAACGAGACCTTCGACTTTTTATGTGGGGGGTTCACAGAGAATTTCACTATGGACGCATGGGAAAGCCAAGCACATATCCCGCTTAATGAGGTTAATAAACGTGTCGATCCCGAAAGCGGTGATAGTCGGCCGCAGCCCTCTTAACCTGATGTACACCGGCATTGAAGTGTGCTAGATCGTTTTATTATTGAACACGCGTCCTAAGACCAGGCTCCGACGAAAGACGCGCTGCCATGCCATGATGTCACCCCATCACCGCGGTACAAGGTCTTCATAGAGGTGAAAACTAGCTGGGGTCACACATAAATCAAACCCCCAGTTAGTGGGGAGCATTGATGGACCGTTCATTTCTGATCACATGATTGTACTACAGGTCACGGGTGTCGCAGCTCTTTAAACGACCTGTATCCGACGCCGGGGGTGCTTGCTTAGAATTATCAGATTTTCACATAACGAGTTGCACACCTTGGACTTATTCTTTCATGAGCTGAGGGTGGGAAATAGTTTAGTCAATGGCTCACACCGTGTGCAAGAGGTAACCTAAAATAGTGGGTTTAGAAATACGCGCAACCAGTTGCATGAACATCCCTTTTAGTTATACATATGAAGCTACAAGACTGACATAGACCTTTAGGCAGAACAGGCTCAGAGCGCCGAGATAAGCCTCAGACTGTATACCCGTACTGCGGCTAGCCCTAGACTAGCCTGGGCAAATCTAGTCGAGAACCCGTTGATCACCGCATCTATCCTGCTCCTACGTGTACCAGCAATTCCCGTGGAAATAGTTAGCCCCCCTGACGCGGCTTAAGACTTTGATACAACGCTTTCCCGATCGTGATTGGCCCCTAGCGTGTCCCCCTTAGAAGCCAGGCGTCTCCGTCTGACGCAGCGATGTAACGAGAGTTCGTGAGTGAGGCGCTAGAAAGTAATGACATCCGATCGTATTTCTGGCCATCACCATGAGAGGGGATCTCTTGCTCCAGTACCATTGCCCCGCGGACTAACCTATATCAGGCTTATGAGAAGTGCTAGAGATACGTGTCTAAGTGCTCGG$");

            //CompareSequences.GlobalAlignment(
            //    "LSLSITWVALIVQFLDSENCYPLDHLFPWDIAASDTALHAQIDAVYWHDVSGIGGIKWCFDYDSFEQTFFVEMWPVKTTRFYECTKDIWISTYMWQGACYCRHLFPQCQDHMQFKWATVIDMPNYRMMINYQSLFNSSRQRFCESMGPMSSSSKKEKVVRGQRANKRGAKWKYNSEQSFAKETFANVMTWVRAWHLVFQYKKLDYWPNHGPGQRAWHYDCGTEIDQADCYKDHCAESDTNDMANKNTICTNAGNHFNGDMQKDCRETALKIEPSTYYKQLIEQNMPSYHKMFKKVTRKEGYCKLGNHNAMARIYAVVLTLMEETELQFMTIGTPAGCCSLIIMEPHVSYVYNGSMEVIFNQTFGPQDWMGGAHWDHWITRWVWYCAKDMWMMLMIISPCEYDQTVPMAMTVLEDEIVWWTMLFDADGNWKPTRMRCPCDMWGTGRLLYWCDPMCEKCMRMVTFMIIEIFTVNVYKRICNLANAVKWPSTRNTDMPYPMGWMDSIFNYGIECRNTLVGKKPIGRKTSLFPAIMYIVWSGDYPSRMVPIWGNTYMRDMVSDYFTEEICNTDCGDDFYEQIAYFSAIHHEQMLHCVGMSMHKWKIDCSLRSWPTVMDIVSSFTKEYFCMTEIIKFRPTFPGRPRANLGHDLIYDWVIPWMPMLWQEYMVGANMRFIRILFMSLICNSPMQCKTSNLRHYYWPRFKNMAPQVQDDHMQKLKEWSKPWFQLEIYSHRVFSAVIVNNVKWKFDPKGKNFGWEFEHMPNVHYKIFKMTLRQYKDKAQTFLTNAGCYSQKAKQQYPCKVKNLTRVDHHPEFWSDAGFFPLMCHQWKPTMTLAITYLYDCGMRPCYKAVDRVSCIRYNNTRSNCAPKTPPYSIHHYYSSQCRDHGVAWTAQIDRGCMYCTDFHCFVQVRLCMYSELGGIVAMALVVITYYDHYSIGYYQQYMKPMWSFAPPHESWGRIDNPEGEYNMMVGQFNYSGEFPVRHWTRYEADDHQINYSGRIPIKKMHLITQTEMVESWESSMETFAQQWMLTSANERMAWALWPRRNMKRIKNECDISTTLKAEHMSEFMAVMWTREIEELYNTSHLWVIQGLRNLPGACCGLCTYGALRQGPRLSNNGLYPPHLYAMKMDITNHFKANGFEAAIMSRDYEFKSYAEGVIDSWAKEEKISWTTAYMCVIPIYSCIPNNCEWSMVWTQDRQMFLDTSQVTPTDSQDGYPMKVYWPFEPICYHAWMDLCHSCHGDRKKHTGRYCQGMRALKTKQNAIDICFHPVRENEMQSLVFWKSMHCYHRRAHWRCQIDTSWGTARRKMKCDMRICTTPQAFTTFQNIFKIFFAKICVVKTVDSKACERAWENCDVLPFVAGGRDWRETDAIKMIESNTGGNVSHQIFALWSAKLYRWSLMAIFEEGIHGNTRVGYMIMHPAKRYCNFRIPAVFADYTVPFATTNNGFRYDWGDAFDNGNWYGDCETASMVKATARHWVHQMNFWFNMSGDGPAYNGWSSSWCTEAIEVKVLNDSRCYNIRFQGMRMRPASWHLIPYQRWYYRIRADLRVLWVQHAQENVGFACDWVHAKPQRYHMFPYNWRIQVDDWQFFVHDMQPFLMYSVNARIPNEMWVGYEWNDDEPLISAYETPRSRCGIFECPNMSDMTMYFCLYISPFFVLSVHCVLIDSWAKDWTQYVCCQCQMFPFCQPLSITMYQFMCTTPNAVSAWRADMELTIMTQVWFDQMSLPFYCEWCGWWIGCPGGQALNAGNKFGDPLYQISAMGIEHPGMASKVGHEIILRCMNWMRVQIYFICKNYLFPYGSFGNDWTVVHAMLIVIDIAMPHMCWAMTGVICSMNWFLAFMCYHQHENMSWKPTHNMHIMTRTDFNCSNNQTVPSGHPAITFLHSHMDVHEQMLGPIWEKRTPKRVVLCQMKVHGFKCQTVMGSDHLISYEHPEFGYQNNGTGQMNAEGTVQCLQLQENGRIPYIWPPRQLHGLYQDFSLCIQQCSMASWKNDYFLTFPCMMQWNMVISGSTKYKLLARFVCLHVHFHKAKPCYPVWYTGNFGGLLNGVVFLSMFREMHNDRRRALGEWTRNSQRNGRACLNLKEHLLASFIDTDGGEFRDGEKMFFCTFHYHIEEKVFGNWMQHYGTPVVNALAQNTDSVEPANCARAICAFQWQTFGSPKWIIDWFDPIVVVQQRVAECCEKHVEPFQSRSRHHDYERGTKCHFRCEHPWVNTYDKKEKMPMPNINMYWMKNKQMPDVCDVEDMCRVMYQFTSERKEFLGMCRVHFMTPDMDGDPHCQPPAFWLKAITHGYANWWSRADSILQEQWDTARFFYAVDWKCYQQSILSKRSDTPDTYSGWPNRIFDNFWPHRECFCFIYLVYIHGTWLYPHAWKSWTTHGMTRQICIDAHNWKNCVCDITVVYLSIEPELVFQRKGIRCVTWQDFYVTNEWGVGAPENPYRWTCLSGEVAWLSKFKIQNKWLVFRVTMLQVGECGVWTDRLWFIWVSGWNKEYLASKMYEQETTRKWNLVDGNRAQWKSWSVQWFVQKAMMNLTDHVVSQHHWKYLKCLGMYYNCDTYDCGCQQHNFVSWRALWERYHFLVFFLTNPPKYDPRESSTSKNYRMCRMRLQPDMGQKRFNYQKAPICDVHWFWISPTILRPSDVMVTNCLCGNSTQYDVYRVDPCRFTNASEHMAPNFSRWKLDARTKCATDNSGGNWVFAYDGWPTVRLLMMEKKQDPGKDPFNVWIDLERLTKRGFTEGDGYGYSTFPAHTICFTRPAGDPSKSPFGTMWMVRQCHKKFGTDYQDFYMNPELKISGRWWLHLYCIITHMHAIYQPDWQGLTINNPEIDLEMGGISRLGEAMAKLNNIRAPDIEFDANYPYATNGVECSSVSNGELDEDCTCAEHKNNQQMTLLFWDCASSPEGNCQSMIGAAFINGFRYGIMEKAVRCMYCEATWPIYGVSIDNATLNDYKYMKRYTDRWKPGFLLRGGVFFAQITEIGLKPGQAFCSTCRSHHMAPMKVGPLMQAEWAFYCTEFENDDPKVAEICNELFIENLNNYWPLTIMDWWWWWSVVNRGLLEIMDPKHKNNQCRPDPEYSCTYDHGHMLTYRPVVGGQAMNYKLHGNETMMYWWPNCSQAHYCFVIVVQKPHLSCYAINDLFAMNCAPMDYIYFQQQKALMGTALMQCDAPCNEACLYYLLKIGKSMPCIYPFKAEVNGKNSATACGTPCFFAFKLYSVWEIRAVPEITGYRCAYVPQVFPVNGMWKSATSCMGGEQGTAFGQENLHYIMDDPQNWNLEHVEKTFCWTRPAIPIMIRSAFIKKTGPKFLQLGKMTNRGPWWMSLALDLYHQWSCYKSQVPLPLWMMGKNMSWNKITGFCQIHQQSAIFKSNVTRLCSTCRTDFDDPSCWASCWKLCDYQSNISIVWPLVVSDPANDWTERCRGINPHNRGGKTYGWFIGYDQESVGMTAESCWHRIGDCERNMECHCRLEMYFTPNENICHRWFAVVWLPIEIECEDFSHTPYKRIPYFMYGFKQEKNVEWDYFFIIYVDNQTPLAGMHHASITKSSMPMVYIHEYISEIAAEPRCMMHDPNYCTDCKGRILTRLIAQHKAAPDPVLSEWTDDHDALPCNGVSWCLFQWMEMTHVCHRKANECCHHQEPPPPKSRLFLPLPPTLYDCAPYDWDCFPGQVVWLFGHPGMRRQNQGDVTRFSKECTCSPVRKSYAEKWGCLIGFMTDSEFVQHVMEQKIANMWFSHKEGQSEGNRKREHQLEGVKVWINMRQMCQQIPFVCSYPYEPEVAIWIYQEYSAFPYKKRILAEWPREHGKMNRYVFWGEHYFPAMCSDPQHWFHVRQKCTNLFMEKILDWVIFQCSESEWVFSAQEKWEPMAKYAFYWCWWGLCWCIASRHNHWYNQKAECCYEYCKSAGASNESPNGAMNKGSRTYYPPRTSDKYGRFPIHITKWSSFSTSPGFACGWRMWNEAKPTPQPDERYDIIMLKNNRKWYQYDSASEIPTFGNCMMHSVFTYIEFNRYSPTPIINYIMRKRQCSTIAAYGKVMACDFGHYLMHFYFYVYAVNRQSPLAPDSRFCYIICRLLNVETNWLQDSGKWIHISFTWMFKQNQQLCVCCEAGTNGRGCVEGDPIIWNTVIPVPIQDIGNIQCKANDYLRCEWLERAYMWMLNRIERDEWRDVRYRWNQWKTMHCEWTTPPRNDIARRQHNNNQDQRNAQGMGKTHGCDALFALPLHCCWVFFLKDESLFGWTTYLPTMQVMKRADLLFFSQNCPWFCPFTHIIFWAMLDGNNRPPQWLWYLLDPDYMWETLGISPTSWVGEQYKAYYWACPHLPPQFGQDVFNMFQFDRLIYHFKSDSYRQKCTPTFHDTCTEYVERHC",
            //    "LSENCYPLDHLFPWDIAACCYQEIKADTAMHRCVVQIYAVYWHYDSFTFMINEQTFFVEMWPVKTTRFIWITTYAWQGACYCRHLFPQCQDHMQFKCAVIDMPNYRMMINYQSLFFHSRQRFCESMGPDSSTSKKEKVVRGQRANSFETFEEFNVMTAVRAWHLVFQKKLDEVPPRVHGPDQRSDCWRLTTEIDQAQFWDHCAFSRLYLDWGITNDNAGNHFNGTMQKDTIHLNDWIERETAQAKWKIEPSGCYYKQLIEINNSCKSHQCYAECYYASLAGKRQTTMEGYCKLGNHNAMIKRIYAVACNLMEYPLNPLPAGCCSLIIMEPHVSEVAKPNIAMISFQTFGIQDWMGGGHVDHWITRWVWYCAKDLMIISPEPMAMTVLMLADVNLYWVFQLSIIGLMLFDADGREQEFFTPCDDWGAGRLFTKHMRMVTFMRSWWVWQDEIIIFTGNVLSTTEVPEGLANAVKWPSTSNTDMPYPMGWMDFQQVFWMLDIFGITISKPIQLMQSDQRKTSLFPAHPCSKVPGNSHWRCNQKGIVWSGDYPSRMSFKHVYYMRDMVSDAFTEENCHLCKTDCGDDAALLIESATEFGASMDTETHHEQVGMHCHKWWIDIVSSFQKEYFAMTERRPTFPGRPRLIYDYESFHNWTRTVQEYMVGAFIRIRFMNLINNSPNGQCKTSNLRECYYWPRNKFLDAHMAPQVQDDHMQSLKGWALEIYSDFEWFARVFEVAVMVNTDAPIHFDGKGKGEQVCWGHTAEKMFWMTLRQYKDKAQTFLTNAYSQKAQYPCKVKVNDLRRVDPMGTKHIGELMDGFWDPIMFWSDAGFFPLMCHQWKPYLYDCIMRPCYYAVSEDAVDTVSCVICGMTVFIFCMSNCAPKTPPYSIDNHYYSSQCRDHGVAACPQIDRGYMYCTDFHCFVQVSELGGIVAMMNKLVITYYDHYSIGYYQQKMQPMWWYFFFAPPHASWGFIVGQFNYSGEFPVYSGDIPHGPKKMHLITQHALVDFEAEPFECSNPFSQQWMLTSAYHCSTQHERMEWALWPRRNMKRIKYLNDWDHELAEHYIWCIEPEFMAVMWTRALHWEELYNTSHCWVIRCLPGMLCCHEWPPEYMKTYGATTCANHNIQLYPPHYCWADLNSYNFFEAAIMSRDHRKLDYYAEGMAHDMNLCEMCLLAIPIYSCIYNNCEWSDWTQDRQMSLDTSQVTPTDSQDGYPMKVAWDPKWIQMWPMRMWIEPICTEGRHSGHGQRKKHTGRICQGMRALKTKQNAIDICFHPVRDICCMSMKVYHRRANWRKWMPFRETNIFLPKCDMRICTTALYQAFTQNVEQCAHMEFFKIFVECWTWEAAAKICVVKTVDSKACERAPCDFWTTLLPFVAGGRDWRETMAIKMIESNTVKNRKNENSHVIMYRWSLMAIFEHGLHGNTRQLPKYMVQGYMIMHPAKRYCMDIHFFRIPAVFADTNDWMLYVLYHEPDAFWYEDVGGQFQALRATARHWTDQMNFWNNMDDVCHPNHNGWESSRYCKNCLTTFCYWHFEAIEVKVLNDSRYYNIRMRQERQGLVAAPIQVWYYRIRADLRVLWVQHAQLVNVGDKACDNVHAKPQRYHMFPYNWRIQQFFDNTQSTWQFFVHDMQPELMPCMMFNARMPSEMWVGRSEWNDKTRRYPRYEADLIIAEDEHPKSRCFIFEAPNMSDMTMYFCSIRHTLKGFFVLSVHCVLIDSNQYVCCQCQMWFCQNLWVMHALMCTTPNAVLGWFFILAWRWDMELTQTKKNRAMDQMSLPPYLAAMSCYESQICCPGGQAVHCQPTMNNKKRENYTRHMLYQPRFLSAMHAWVGKVILPTDPGVKVGRWDKCGEILLRVQPYFWCINYLFPYGSFGNDWTVVHAMLIHTKDRTFFWMIPAGSYYLETVLCFVTCDQVLAFMCYHPHENMSWKPTHNMHFMTRTDFNELKWDEFFNWQTVVSGHDILWYVITFLHSHMDVHEQLVMQKEHGKRTPKRVVLCQMKVHERMWKRWFKCQTHMGSDYLISYEIDPKNWAKREFGYQNNGTGNLQENRKHRIMWNLKIWPPRQLHGLYQDFSLCIQQCSMVSWPCMMQWNMVISGSTKYKLLARFVCLHVHFQKAKPCRPSRWGRHMPERYTGNFLLNGVVFLSMFCEMHNWAWLPSTLGEWTRNSQRNGRACLNLKEHALASFIDTEDGGEFRDGEKGFFFADGFWAFHYHSEEKVQTWMLKEMQHNGTMLWDFVVNASTDSVEPARAPKNYKKCAWAICAFQWQTLIDKSPKNIDWPIVVVQQRVASCCEKHVELRTIPDDWKVRSRSGTKCHLNIRCEHHFTGWVNTGDFKEKMPNKNQNCSPMKRKQMCRDMYLFTSERKEFCGMFMTPDMDGDPHCQPPAFWLKAITNGYANWWSRWRKDTTRTMYLPSNIFYAVDWDFSEHCCYQQMSNILSKRSDTPDTYSGWPNRIFDNFWPHRECTVKIHGTWLYPHAWKSWAREDSYTGTHGMTRQICILPKHWNCVCDITIVYLSHETELVHQRKGIRAARFNTFWVTNEWGVGAPENPYRWTCLSNHEVAWLSKFKHYINEEPQNKWLVFRVTMLQVGECFGWTDRLYFIWVASTRKWNLVDGKCSFEFKAWNSYQWDCPDRLAHPQQKAMMDHVVSQHLKKLHGSHCTIMRYNCDTHDVNQDGCQQLWEDYLVYEIEDWFLTMPYDPRESSTSMNYRMCRMRLQPDRPNRQAVHWFWISPTILRANDVMVKSHHEDNSTRLEHNVKYDPRVTQPHAMAPNASNWKTWSTWYVTNSWGNWVFAYDGWPTVRLPEMHKKQDPGKDWFNVWAIDTQDLERWWRSQAWTKRGFKEGDGYQIYSTFVNGAHTICFTVRAGDPSKSPGGTMWLQIFVRQCHKKFYQDCYMFKCEQALRMHCPLYCIITHMHAIYQPDWQGLTFHPENNPEIDLEMGGIDEVLHHAYSEAMAKLFASSVSNGLDEDCTCFCSTGMISIEHKNNNAIRRDDCASSLYHSFPTDCNNCNGFRYEATAPIYFRTLKETHIWNAMKRDTDRWKIGFLLRGGVFFAQITEIGLKIQQAFRMHWSKTTCPSHHMAPMKVGRNLMQDMCVKCDEWAFYCTEFENDSNELYIEGFSGQNGMLQNYWNRGLNEEMDPKHKNNGWIECQEDDCRPDYGKTWTVEYSVRTYDHGHMHGPSTKRPYWHQAMNYKLHGNETMMYAMPNCSQAHYCRYDQYDESQYIKMGEDYCAVQKAFAIYLMGTCTHRAEQLMNEACLYKDFKAKVNGKNSATACGTPCFFAFLLYSVYERAVPEITGYRCAYVPGVMGGEQGCAFGQENLQNWNLWHVFCWTIRSAFIKKTGAKFLKMTNRGPWYHQWSCYKSQVPMGKNSPFRVRMSWNDITGFCQIHYQSAIFKSRWFTDFDDPSCWFDCWKDTPCDYQSNISIVWPLVECMPFKRSFYDNNVRFCNDWTEKCRGINRGGKTYMAEGLWWFISVGITAVSCVHRIGDCERNMECHCRLYAYFTPNENICHDDSDSSRWKEHDYCEDFSHTPYKRIPYFMYGFKQEKNVEWDYFFIIYVDNQTPLAGMHHASITKSSLPSVYIHEYIGEIEPRCMMHDFNYHTDCKGRILTKLIAQHPVLFKADQKKILPCNGVSWCLCQWMEMTTHVCFDTEGTCHEKATWNYPECCHHQEPPPPKRHCEWAMYLLPPRVDEEGGYSYDCAPQCFPSSKHVVWNTMIFMHWFFGSPRQMKGDVTRFTWTFPVRKSYAEKWGCLIGFMTDSWNGIKNDFVQAVMEQKIANMWNQWTSCKHNFYRKMMKREHQLEGVKVWINMRQMCQQIPFVCWYPYEEVYEKDSHHWIWIYQKRIHFHHIRQAENKDDKIDIQIEKAAGNRYTDWGEHYFPAMCSKPTCHSSWVKHWFHRQKTTNLFMEDDWTIFYWVFEKWYAQRSSMQSKECWWGDCNANPIASRHNHWYNQKAECCYCYCKSAGASNPNWMSIRKAMNGSRTYYPPRTSCCQEMIERILWKLNHVKPKDPFTPHVKWSSRTDVVDTSTSDGFAYILFWRMWNMKAKPTPQPDERPKDCFRDIIMLKNNRKWYQYRSASEIPSMRYSPTPIINYIMRKRQCVNSMAKDFHGDTLKSYGVDKLLHTDHYLWPAYVYAPMNGTSRKKYYHGHYCLCRLLNVETNWLQDSGKWIHISFTWMWKQVQQPCVCCECHWFTRGCVEGDPIWCTHETRVSGAEPVPINDIRAYHENWRDEWRDFRYRWNQHCEDFGTTPPRGGYDYNARRQCNNNRWGKHGQGQGALPIHCCWVFFLKDQNCFGWPDFKMTYLPLMQVSDVCHAQAYADLLFFSQNCPVTHIIFWAMLDGNNRPPQWAWKWKLLDPDSMWIDMYRMNRTSWVGEQYKAYYWACPHLPPQFGGNNRWVASDVMPNMFCWISEYLQFDRLIYHFKSDSYRQKCTPTFHDTCTEYVNRHC");
            int z = 0;
        }
    }
}
