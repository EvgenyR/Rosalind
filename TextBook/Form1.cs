﻿using System;
using System.Collections.Generic;
using System.Text;
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
            List<string> input = Helper.ParseTextFileToStrings();

            string transform = input[0];
            string[] patterns = input[1].Split(' ');

            //string transform = "GGCGCCGC$TAGTCACACACGCCGTA";
            //string[] patterns = "ACC CCG CAG".Split(' ');
            
            string original = Locate.ReverseBurrowsWheeler(transform);
            StringBuilder result = new StringBuilder();

            List<char> firstC = new List<char>();
            for (int i = 0; i < original.Length; i++) firstC.Add(original[i]);
            firstC.Sort();
            string firstS = string.Empty;
            for (int i = 0; i < original.Length; i++) firstS = firstS + firstC[i];


            foreach (string pattern in patterns)
            {
                int res = Locate.BetterBWMATCHING(firstS, transform, pattern);
                result.Append(res.ToString());
                result.Append(" ");
            }

            string s = result.ToString();

            Helper.WriteStringsToTextFile(new List<string> {s});

            //CompareSequences.GlobalAlignment(
            //    "LSLSITWVALIVQFLDSENCYPLDHLFPWDIAASDTALHAQIDAVYWHDVSGIGGIKWCFDYDSFEQTFFVEMWPVKTTRFYECTKDIWISTYMWQGACYCRHLFPQCQDHMQFKWATVIDMPNYRMMINYQSLFNSSRQRFCESMGPMSSSSKKEKVVRGQRANKRGAKWKYNSEQSFAKETFANVMTWVRAWHLVFQYKKLDYWPNHGPGQRAWHYDCGTEIDQADCYKDHCAESDTNDMANKNTICTNAGNHFNGDMQKDCRETALKIEPSTYYKQLIEQNMPSYHKMFKKVTRKEGYCKLGNHNAMARIYAVVLTLMEETELQFMTIGTPAGCCSLIIMEPHVSYVYNGSMEVIFNQTFGPQDWMGGAHWDHWITRWVWYCAKDMWMMLMIISPCEYDQTVPMAMTVLEDEIVWWTMLFDADGNWKPTRMRCPCDMWGTGRLLYWCDPMCEKCMRMVTFMIIEIFTVNVYKRICNLANAVKWPSTRNTDMPYPMGWMDSIFNYGIECRNTLVGKKPIGRKTSLFPAIMYIVWSGDYPSRMVPIWGNTYMRDMVSDYFTEEICNTDCGDDFYEQIAYFSAIHHEQMLHCVGMSMHKWKIDCSLRSWPTVMDIVSSFTKEYFCMTEIIKFRPTFPGRPRANLGHDLIYDWVIPWMPMLWQEYMVGANMRFIRILFMSLICNSPMQCKTSNLRHYYWPRFKNMAPQVQDDHMQKLKEWSKPWFQLEIYSHRVFSAVIVNNVKWKFDPKGKNFGWEFEHMPNVHYKIFKMTLRQYKDKAQTFLTNAGCYSQKAKQQYPCKVKNLTRVDHHPEFWSDAGFFPLMCHQWKPTMTLAITYLYDCGMRPCYKAVDRVSCIRYNNTRSNCAPKTPPYSIHHYYSSQCRDHGVAWTAQIDRGCMYCTDFHCFVQVRLCMYSELGGIVAMALVVITYYDHYSIGYYQQYMKPMWSFAPPHESWGRIDNPEGEYNMMVGQFNYSGEFPVRHWTRYEADDHQINYSGRIPIKKMHLITQTEMVESWESSMETFAQQWMLTSANERMAWALWPRRNMKRIKNECDISTTLKAEHMSEFMAVMWTREIEELYNTSHLWVIQGLRNLPGACCGLCTYGALRQGPRLSNNGLYPPHLYAMKMDITNHFKANGFEAAIMSRDYEFKSYAEGVIDSWAKEEKISWTTAYMCVIPIYSCIPNNCEWSMVWTQDRQMFLDTSQVTPTDSQDGYPMKVYWPFEPICYHAWMDLCHSCHGDRKKHTGRYCQGMRALKTKQNAIDICFHPVRENEMQSLVFWKSMHCYHRRAHWRCQIDTSWGTARRKMKCDMRICTTPQAFTTFQNIFKIFFAKICVVKTVDSKACERAWENCDVLPFVAGGRDWRETDAIKMIESNTGGNVSHQIFALWSAKLYRWSLMAIFEEGIHGNTRVGYMIMHPAKRYCNFRIPAVFADYTVPFATTNNGFRYDWGDAFDNGNWYGDCETASMVKATARHWVHQMNFWFNMSGDGPAYNGWSSSWCTEAIEVKVLNDSRCYNIRFQGMRMRPASWHLIPYQRWYYRIRADLRVLWVQHAQENVGFACDWVHAKPQRYHMFPYNWRIQVDDWQFFVHDMQPFLMYSVNARIPNEMWVGYEWNDDEPLISAYETPRSRCGIFECPNMSDMTMYFCLYISPFFVLSVHCVLIDSWAKDWTQYVCCQCQMFPFCQPLSITMYQFMCTTPNAVSAWRADMELTIMTQVWFDQMSLPFYCEWCGWWIGCPGGQALNAGNKFGDPLYQISAMGIEHPGMASKVGHEIILRCMNWMRVQIYFICKNYLFPYGSFGNDWTVVHAMLIVIDIAMPHMCWAMTGVICSMNWFLAFMCYHQHENMSWKPTHNMHIMTRTDFNCSNNQTVPSGHPAITFLHSHMDVHEQMLGPIWEKRTPKRVVLCQMKVHGFKCQTVMGSDHLISYEHPEFGYQNNGTGQMNAEGTVQCLQLQENGRIPYIWPPRQLHGLYQDFSLCIQQCSMASWKNDYFLTFPCMMQWNMVISGSTKYKLLARFVCLHVHFHKAKPCYPVWYTGNFGGLLNGVVFLSMFREMHNDRRRALGEWTRNSQRNGRACLNLKEHLLASFIDTDGGEFRDGEKMFFCTFHYHIEEKVFGNWMQHYGTPVVNALAQNTDSVEPANCARAICAFQWQTFGSPKWIIDWFDPIVVVQQRVAECCEKHVEPFQSRSRHHDYERGTKCHFRCEHPWVNTYDKKEKMPMPNINMYWMKNKQMPDVCDVEDMCRVMYQFTSERKEFLGMCRVHFMTPDMDGDPHCQPPAFWLKAITHGYANWWSRADSILQEQWDTARFFYAVDWKCYQQSILSKRSDTPDTYSGWPNRIFDNFWPHRECFCFIYLVYIHGTWLYPHAWKSWTTHGMTRQICIDAHNWKNCVCDITVVYLSIEPELVFQRKGIRCVTWQDFYVTNEWGVGAPENPYRWTCLSGEVAWLSKFKIQNKWLVFRVTMLQVGECGVWTDRLWFIWVSGWNKEYLASKMYEQETTRKWNLVDGNRAQWKSWSVQWFVQKAMMNLTDHVVSQHHWKYLKCLGMYYNCDTYDCGCQQHNFVSWRALWERYHFLVFFLTNPPKYDPRESSTSKNYRMCRMRLQPDMGQKRFNYQKAPICDVHWFWISPTILRPSDVMVTNCLCGNSTQYDVYRVDPCRFTNASEHMAPNFSRWKLDARTKCATDNSGGNWVFAYDGWPTVRLLMMEKKQDPGKDPFNVWIDLERLTKRGFTEGDGYGYSTFPAHTICFTRPAGDPSKSPFGTMWMVRQCHKKFGTDYQDFYMNPELKISGRWWLHLYCIITHMHAIYQPDWQGLTINNPEIDLEMGGISRLGEAMAKLNNIRAPDIEFDANYPYATNGVECSSVSNGELDEDCTCAEHKNNQQMTLLFWDCASSPEGNCQSMIGAAFINGFRYGIMEKAVRCMYCEATWPIYGVSIDNATLNDYKYMKRYTDRWKPGFLLRGGVFFAQITEIGLKPGQAFCSTCRSHHMAPMKVGPLMQAEWAFYCTEFENDDPKVAEICNELFIENLNNYWPLTIMDWWWWWSVVNRGLLEIMDPKHKNNQCRPDPEYSCTYDHGHMLTYRPVVGGQAMNYKLHGNETMMYWWPNCSQAHYCFVIVVQKPHLSCYAINDLFAMNCAPMDYIYFQQQKALMGTALMQCDAPCNEACLYYLLKIGKSMPCIYPFKAEVNGKNSATACGTPCFFAFKLYSVWEIRAVPEITGYRCAYVPQVFPVNGMWKSATSCMGGEQGTAFGQENLHYIMDDPQNWNLEHVEKTFCWTRPAIPIMIRSAFIKKTGPKFLQLGKMTNRGPWWMSLALDLYHQWSCYKSQVPLPLWMMGKNMSWNKITGFCQIHQQSAIFKSNVTRLCSTCRTDFDDPSCWASCWKLCDYQSNISIVWPLVVSDPANDWTERCRGINPHNRGGKTYGWFIGYDQESVGMTAESCWHRIGDCERNMECHCRLEMYFTPNENICHRWFAVVWLPIEIECEDFSHTPYKRIPYFMYGFKQEKNVEWDYFFIIYVDNQTPLAGMHHASITKSSMPMVYIHEYISEIAAEPRCMMHDPNYCTDCKGRILTRLIAQHKAAPDPVLSEWTDDHDALPCNGVSWCLFQWMEMTHVCHRKANECCHHQEPPPPKSRLFLPLPPTLYDCAPYDWDCFPGQVVWLFGHPGMRRQNQGDVTRFSKECTCSPVRKSYAEKWGCLIGFMTDSEFVQHVMEQKIANMWFSHKEGQSEGNRKREHQLEGVKVWINMRQMCQQIPFVCSYPYEPEVAIWIYQEYSAFPYKKRILAEWPREHGKMNRYVFWGEHYFPAMCSDPQHWFHVRQKCTNLFMEKILDWVIFQCSESEWVFSAQEKWEPMAKYAFYWCWWGLCWCIASRHNHWYNQKAECCYEYCKSAGASNESPNGAMNKGSRTYYPPRTSDKYGRFPIHITKWSSFSTSPGFACGWRMWNEAKPTPQPDERYDIIMLKNNRKWYQYDSASEIPTFGNCMMHSVFTYIEFNRYSPTPIINYIMRKRQCSTIAAYGKVMACDFGHYLMHFYFYVYAVNRQSPLAPDSRFCYIICRLLNVETNWLQDSGKWIHISFTWMFKQNQQLCVCCEAGTNGRGCVEGDPIIWNTVIPVPIQDIGNIQCKANDYLRCEWLERAYMWMLNRIERDEWRDVRYRWNQWKTMHCEWTTPPRNDIARRQHNNNQDQRNAQGMGKTHGCDALFALPLHCCWVFFLKDESLFGWTTYLPTMQVMKRADLLFFSQNCPWFCPFTHIIFWAMLDGNNRPPQWLWYLLDPDYMWETLGISPTSWVGEQYKAYYWACPHLPPQFGQDVFNMFQFDRLIYHFKSDSYRQKCTPTFHDTCTEYVERHC",
            //    "LSENCYPLDHLFPWDIAACCYQEIKADTAMHRCVVQIYAVYWHYDSFTFMINEQTFFVEMWPVKTTRFIWITTYAWQGACYCRHLFPQCQDHMQFKCAVIDMPNYRMMINYQSLFFHSRQRFCESMGPDSSTSKKEKVVRGQRANSFETFEEFNVMTAVRAWHLVFQKKLDEVPPRVHGPDQRSDCWRLTTEIDQAQFWDHCAFSRLYLDWGITNDNAGNHFNGTMQKDTIHLNDWIERETAQAKWKIEPSGCYYKQLIEINNSCKSHQCYAECYYASLAGKRQTTMEGYCKLGNHNAMIKRIYAVACNLMEYPLNPLPAGCCSLIIMEPHVSEVAKPNIAMISFQTFGIQDWMGGGHVDHWITRWVWYCAKDLMIISPEPMAMTVLMLADVNLYWVFQLSIIGLMLFDADGREQEFFTPCDDWGAGRLFTKHMRMVTFMRSWWVWQDEIIIFTGNVLSTTEVPEGLANAVKWPSTSNTDMPYPMGWMDFQQVFWMLDIFGITISKPIQLMQSDQRKTSLFPAHPCSKVPGNSHWRCNQKGIVWSGDYPSRMSFKHVYYMRDMVSDAFTEENCHLCKTDCGDDAALLIESATEFGASMDTETHHEQVGMHCHKWWIDIVSSFQKEYFAMTERRPTFPGRPRLIYDYESFHNWTRTVQEYMVGAFIRIRFMNLINNSPNGQCKTSNLRECYYWPRNKFLDAHMAPQVQDDHMQSLKGWALEIYSDFEWFARVFEVAVMVNTDAPIHFDGKGKGEQVCWGHTAEKMFWMTLRQYKDKAQTFLTNAYSQKAQYPCKVKVNDLRRVDPMGTKHIGELMDGFWDPIMFWSDAGFFPLMCHQWKPYLYDCIMRPCYYAVSEDAVDTVSCVICGMTVFIFCMSNCAPKTPPYSIDNHYYSSQCRDHGVAACPQIDRGYMYCTDFHCFVQVSELGGIVAMMNKLVITYYDHYSIGYYQQKMQPMWWYFFFAPPHASWGFIVGQFNYSGEFPVYSGDIPHGPKKMHLITQHALVDFEAEPFECSNPFSQQWMLTSAYHCSTQHERMEWALWPRRNMKRIKYLNDWDHELAEHYIWCIEPEFMAVMWTRALHWEELYNTSHCWVIRCLPGMLCCHEWPPEYMKTYGATTCANHNIQLYPPHYCWADLNSYNFFEAAIMSRDHRKLDYYAEGMAHDMNLCEMCLLAIPIYSCIYNNCEWSDWTQDRQMSLDTSQVTPTDSQDGYPMKVAWDPKWIQMWPMRMWIEPICTEGRHSGHGQRKKHTGRICQGMRALKTKQNAIDICFHPVRDICCMSMKVYHRRANWRKWMPFRETNIFLPKCDMRICTTALYQAFTQNVEQCAHMEFFKIFVECWTWEAAAKICVVKTVDSKACERAPCDFWTTLLPFVAGGRDWRETMAIKMIESNTVKNRKNENSHVIMYRWSLMAIFEHGLHGNTRQLPKYMVQGYMIMHPAKRYCMDIHFFRIPAVFADTNDWMLYVLYHEPDAFWYEDVGGQFQALRATARHWTDQMNFWNNMDDVCHPNHNGWESSRYCKNCLTTFCYWHFEAIEVKVLNDSRYYNIRMRQERQGLVAAPIQVWYYRIRADLRVLWVQHAQLVNVGDKACDNVHAKPQRYHMFPYNWRIQQFFDNTQSTWQFFVHDMQPELMPCMMFNARMPSEMWVGRSEWNDKTRRYPRYEADLIIAEDEHPKSRCFIFEAPNMSDMTMYFCSIRHTLKGFFVLSVHCVLIDSNQYVCCQCQMWFCQNLWVMHALMCTTPNAVLGWFFILAWRWDMELTQTKKNRAMDQMSLPPYLAAMSCYESQICCPGGQAVHCQPTMNNKKRENYTRHMLYQPRFLSAMHAWVGKVILPTDPGVKVGRWDKCGEILLRVQPYFWCINYLFPYGSFGNDWTVVHAMLIHTKDRTFFWMIPAGSYYLETVLCFVTCDQVLAFMCYHPHENMSWKPTHNMHFMTRTDFNELKWDEFFNWQTVVSGHDILWYVITFLHSHMDVHEQLVMQKEHGKRTPKRVVLCQMKVHERMWKRWFKCQTHMGSDYLISYEIDPKNWAKREFGYQNNGTGNLQENRKHRIMWNLKIWPPRQLHGLYQDFSLCIQQCSMVSWPCMMQWNMVISGSTKYKLLARFVCLHVHFQKAKPCRPSRWGRHMPERYTGNFLLNGVVFLSMFCEMHNWAWLPSTLGEWTRNSQRNGRACLNLKEHALASFIDTEDGGEFRDGEKGFFFADGFWAFHYHSEEKVQTWMLKEMQHNGTMLWDFVVNASTDSVEPARAPKNYKKCAWAICAFQWQTLIDKSPKNIDWPIVVVQQRVASCCEKHVELRTIPDDWKVRSRSGTKCHLNIRCEHHFTGWVNTGDFKEKMPNKNQNCSPMKRKQMCRDMYLFTSERKEFCGMFMTPDMDGDPHCQPPAFWLKAITNGYANWWSRWRKDTTRTMYLPSNIFYAVDWDFSEHCCYQQMSNILSKRSDTPDTYSGWPNRIFDNFWPHRECTVKIHGTWLYPHAWKSWAREDSYTGTHGMTRQICILPKHWNCVCDITIVYLSHETELVHQRKGIRAARFNTFWVTNEWGVGAPENPYRWTCLSNHEVAWLSKFKHYINEEPQNKWLVFRVTMLQVGECFGWTDRLYFIWVASTRKWNLVDGKCSFEFKAWNSYQWDCPDRLAHPQQKAMMDHVVSQHLKKLHGSHCTIMRYNCDTHDVNQDGCQQLWEDYLVYEIEDWFLTMPYDPRESSTSMNYRMCRMRLQPDRPNRQAVHWFWISPTILRANDVMVKSHHEDNSTRLEHNVKYDPRVTQPHAMAPNASNWKTWSTWYVTNSWGNWVFAYDGWPTVRLPEMHKKQDPGKDWFNVWAIDTQDLERWWRSQAWTKRGFKEGDGYQIYSTFVNGAHTICFTVRAGDPSKSPGGTMWLQIFVRQCHKKFYQDCYMFKCEQALRMHCPLYCIITHMHAIYQPDWQGLTFHPENNPEIDLEMGGIDEVLHHAYSEAMAKLFASSVSNGLDEDCTCFCSTGMISIEHKNNNAIRRDDCASSLYHSFPTDCNNCNGFRYEATAPIYFRTLKETHIWNAMKRDTDRWKIGFLLRGGVFFAQITEIGLKIQQAFRMHWSKTTCPSHHMAPMKVGRNLMQDMCVKCDEWAFYCTEFENDSNELYIEGFSGQNGMLQNYWNRGLNEEMDPKHKNNGWIECQEDDCRPDYGKTWTVEYSVRTYDHGHMHGPSTKRPYWHQAMNYKLHGNETMMYAMPNCSQAHYCRYDQYDESQYIKMGEDYCAVQKAFAIYLMGTCTHRAEQLMNEACLYKDFKAKVNGKNSATACGTPCFFAFLLYSVYERAVPEITGYRCAYVPGVMGGEQGCAFGQENLQNWNLWHVFCWTIRSAFIKKTGAKFLKMTNRGPWYHQWSCYKSQVPMGKNSPFRVRMSWNDITGFCQIHYQSAIFKSRWFTDFDDPSCWFDCWKDTPCDYQSNISIVWPLVECMPFKRSFYDNNVRFCNDWTEKCRGINRGGKTYMAEGLWWFISVGITAVSCVHRIGDCERNMECHCRLYAYFTPNENICHDDSDSSRWKEHDYCEDFSHTPYKRIPYFMYGFKQEKNVEWDYFFIIYVDNQTPLAGMHHASITKSSLPSVYIHEYIGEIEPRCMMHDFNYHTDCKGRILTKLIAQHPVLFKADQKKILPCNGVSWCLCQWMEMTTHVCFDTEGTCHEKATWNYPECCHHQEPPPPKRHCEWAMYLLPPRVDEEGGYSYDCAPQCFPSSKHVVWNTMIFMHWFFGSPRQMKGDVTRFTWTFPVRKSYAEKWGCLIGFMTDSWNGIKNDFVQAVMEQKIANMWNQWTSCKHNFYRKMMKREHQLEGVKVWINMRQMCQQIPFVCWYPYEEVYEKDSHHWIWIYQKRIHFHHIRQAENKDDKIDIQIEKAAGNRYTDWGEHYFPAMCSKPTCHSSWVKHWFHRQKTTNLFMEDDWTIFYWVFEKWYAQRSSMQSKECWWGDCNANPIASRHNHWYNQKAECCYCYCKSAGASNPNWMSIRKAMNGSRTYYPPRTSCCQEMIERILWKLNHVKPKDPFTPHVKWSSRTDVVDTSTSDGFAYILFWRMWNMKAKPTPQPDERPKDCFRDIIMLKNNRKWYQYRSASEIPSMRYSPTPIINYIMRKRQCVNSMAKDFHGDTLKSYGVDKLLHTDHYLWPAYVYAPMNGTSRKKYYHGHYCLCRLLNVETNWLQDSGKWIHISFTWMWKQVQQPCVCCECHWFTRGCVEGDPIWCTHETRVSGAEPVPINDIRAYHENWRDEWRDFRYRWNQHCEDFGTTPPRGGYDYNARRQCNNNRWGKHGQGQGALPIHCCWVFFLKDQNCFGWPDFKMTYLPLMQVSDVCHAQAYADLLFFSQNCPVTHIIFWAMLDGNNRPPQWAWKWKLLDPDSMWIDMYRMNRTSWVGEQYKAYYWACPHLPPQFGGNNRWVASDVMPNMFCWISEYLQFDRLIYHFKSDSYRQKCTPTFHDTCTEYVNRHC");
            int z = 0;
        }
    }
}
