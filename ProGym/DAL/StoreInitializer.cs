using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProGym.Migrations;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProGym.DAL
{
    public class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext,Configuration>
    {

        public static void SeedStoreData(StoreContext context)
        {
            var categories = new List<Category>
            {
            new Category() {CategoryID = 1, CategoryName = "BCAA"},
            new Category() {CategoryID = 2, CategoryName = "KREATYNA"},
            new Category() {CategoryID = 3, CategoryName = "ODŻYWKI BIAŁKOWE"},
            new Category() {CategoryID = 4, CategoryName = "SPALACZE TŁUSZCZU"},
            new Category() {CategoryID = 5, CategoryName = "WITAMINY I MINERAŁY"},
            new Category() {CategoryID = 6, CategoryName = "ZDROWIE I URODA"}
            };

            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();


            var products = new List<Product>
            {
            new Product() {ProductID = 1,
                Name = "GASPARI NUTRITION BCAA 6000 - 180tabs",
                ProducerName = "Gaspari Nutrition",
                Price =89,
                ShortDescription ="Zażywając BCAA 6000 dostarczysz do organizmu bardzo duże dawki aminokwasów rozgałęzionych. " +
                "Dzięki niemu zbudujesz suchą masę mięśniową i znacznie szybciej się zregenerujesz.",
                Description ="4:1:1 to stosunek aminokwasów rozgałęzionych znajdujących się w tym suplemencie. 4000mg leucyny dostarczanej w każdej porcji przyspieszy Twoją biosyntezę i regenerację. " +
                "Wyjątkowy jest również sposób uwalniania aminokwasów zawartych w BCAA 6000. " +
                "Następuje on stopniowo gwarantując Ci ich stały dopływ prowadząc do wzrostu suchej masy.",
                Ingredients = "fosforan dwuwapniowy, kwas stearynowy, celuloza mikrokrystaliczna, stearynian magnezu, kroskarmeloza sodowa, dwutlenek krzemu, karboksymetyloceluloza sodowa, dekstryna. Zawiera soję.",
                Parameters = "Wartości odżywcze	W porcji: Witamina B6 3mg, L-Leucyna 4000mg, L-Walina 1000mg,L-Izoleucyna 1000mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA6000.jpg", CategoryID =1
            },
            new Product() {ProductID = 2,
                Name = "EXTRIFIT BCAA 2:1:1 Pure - 240caps",
                ProducerName = "EXTRIFIT",
                Price =69,
                ShortDescription ="Kompletny zestaw aminokwasów rozgałęzionych BCAA, które mają bardzo silne działanie antykataboliczne. " +
                "Dzięki nim możesz zapomnieć o rozpadzie białek, gdyż w ogóle nie ma prawa to nastąpić.",
                Description ="BCAA Pure 2:1:1 firmy Extrifit jest niezwykle skutecznym suplementem, który oprócz tego, że gwarantuje walkę z katabolizmem to dodatkowo przyczynia się do przyrostu beztłuszczowej masy mięśniowej. " +
                "Mięśnie są prawidłowo odżywione i zregenerowane, " +
                "dzięki czemu znajdują się w nieustannym procesie anabolicznym. Każda osoba regularnie trenująca może być spokojna, gdyż BCAA Pure 2:1:1 gwarantuje znakomite rezultaty już w krótkim czasie!",
                Ingredients = "L-Leucyna, L-Izoleucyna, L-Walina, żelatynowa kapsułka, stearynian magnezu (substancja przeciwzbrylająca)",
                Parameters = "Wartości odżywcze	W porcji: L-Leucyna 1000 mg, L-Izoleucyna 500 mg, Walina 500 mg, Suma BCAA 2000 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA-2-1-1-Pure-240caps.jpg", CategoryID =1
            },
            new Product() {ProductID = 3,
                Name = "IRON HORSE BCAA 2:1:1 - 120caps",
                ProducerName = "IRON HORSE",
                Price =59,
                ShortDescription ="Jeśli chcesz właściwie zadbać o mięśnie, zainwestuj w BCAA 2:1:1 od znanej marki Iron Horse. Zahamuj katabolizm i wzmocnij anabolizm mięśni.",
                Description ="Twoje mięśnie muszą mieć szanse na odbudowanie włókien, odzyskanie siły i dobrej kondycji. Każdy sportowiec traktujący poważnie swoją pasję wie, że po ciężkim, " +
                "intensywnym wysiłku trzeba znaleźć czas na naprawdę solidny odpoczynek. Nie możesz bez przerwy męczyć swojego organizmu ciągłym ruchem, " +
                "bo w pewnym momencie skończy się to ogromnym przemęczeniem. Jeśli chcesz wspomóc swój organizm w regeneracji, wypróbuj BCAA 2:1:1 od marki Iron Horse.",
                Ingredients = "Wolne aminokwasy: 43% L-leucyna, 28,5% L-walina, 28,5% L-izoleucyna, stearynian magnezu, otoczka kapsułki (żelatyna, barwnik E171).",
                Parameters = "Wartości odżywcze	W porcji: Leucyna 2150 mg, Walina 1425 mg, Izoleucyna 1425 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="IRON_HORSE_BCAA-2-1-1-120caps.jpg", CategoryID =1
            },
            new Product() {ProductID = 4,
                Name = "4+ NUTRITION HGP+ - 300g",
                ProducerName = "4+ NUTRITION",
                Price =99,
                ShortDescription ="HGP+ od firmy 4+ Nutrition zwiększa siłę i czystą masę mięśniową. To duża dawka czystego chlorowodorku kreatyny, połączonego z cordycepsem, kozieradką, kwasem foliowym i witaminą B12.",
                Description ="HGP+ wzbogacony został o szereg witamin i minerałów, w skład których wchodzą Kozieradka, Lucerna, Kordyceps. Oprócz doskonałej pompy mięśniowej HGP+ zwiększy naturalną produkcję męskiej substancji syntetyzującej białka mięśniowe. " +
                "Nadaje to sylwetce charakterystycznych, twardych rysów, a także wspomaga redukcję wody podskórnej. Słowem, w opakowaniu HGP+ jest wszystko, czego prawdziwy sportowiec potrzebuje do wzmocnienia siły i wytrzymałości swoich mięśni.",
                Ingredients = "chlorowodorek Kreatyny, maltodekstryna kukurydziana, ekstrakt z nasion Kozieradki (Trigonella foenum-graecum L.), " +
                "Alfa alfa (Medicago sativa) - wyciąg z Lucerny Siewnej, aromaty, Cordyceps (Cordyceps sinensis Sacc.) - ekstrakt standaryz. 7% kwasu cordycepsu, substancja przeciwzbrylająca - " +
                "dwutlenek krzemu, substacja słodząca: sukraloza, barwnik: ekstrakt z papryki, kwas foliowy, witamina B12 (cyjanokobalamina)",
                Parameters = "Wartości odżywcze	W porcji: Chlorowodorek kreatyny 3 g, Kozieradka 500 mg, Lucerna (Alfa-alfa) 250 mg, Cordyceps 50 mg w tym kwas Cordycepsu 3,75 mg, Kwas foliowy 60 mcg,Witamina B12 0,75 mcg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="HGP-300g.jpg", CategoryID =2
            },
            new Product() {ProductID = 5,
                Name = "GASPARI NUTRITION Creatine Monohydrate (Qualitin) - 300g",
                ProducerName = "GASPARI NUTRITION",
                Price =39,
                ShortDescription ="Creatine Monohydrate to najwyższej jakości mikronizowany monohydrat kreatyny. Stosując tę wersję wiesz, że decydujesz się na suplement pozbawiony wypełniaczy. " +
                "Suplement Gaspari to aż 5g monohydratu w porcji – który poprawi siłę i nawodni mięśnie!",
                Description ="Jak kraść to miliony, jak zażywać, to tylko czysty monohydrat kreatyny. Ten od Gaspari Nutrition nie zawiera sztucznych barwników i aromatów, ani zbędnych dodatków. " +
                "Stosując go dostarczasz do organizmu dużą dawkę kreatyny w każdej porcji. Dzięki czemu poczujesz zdumiewający wzrost siły i wytrzymałości.Zażywając ten suplement nawodnisz komórki mięśniowe. " +
                "Zostaną one nabite przez co będą wyglądać znacznie bardziej imponująco! Co bardzo ważne, ochronisz się przed szkodliwym zjawiskiem stresu oksydacyjnego.",
                Ingredients = "100% mikronizowany monohydrat kreatyny (PURE)",
                Parameters = "Wartości odżywcze	W porcji: Mikronizowany Monohydrat Kreatyny	4,54g, Tauryna 0,25g, Witamina B6 0,21g,Witamina B12 0,375 µg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="IRON_HORSE_BCAA-2-1-1-120caps.jpg", CategoryID =2
            },
            new Product() {ProductID = 6,
                Name = "HIRO.LAB Whey Protein Isolate - 1800g",
                ProducerName = "HIRO.LAB",
                Price =239,
                ShortDescription ="Whey Protein Isolate to produkt wyjątkowy na wiele sposobów. Ten wysokiej jakości izolat białka serwatkowego jest lekkostrawny, bardzo smaczny i nie wywołuje przykrych dolegliwości żołądkowych.",
                Description ="Hiro.Lab kolejny raz przeszło samo siebie tworząc swój Whey Protein Isolate. Ta wyjątkowo smaczna odżywka białkowa w składzie ma aż 85% drogocennych protein i znikomą ilość cukru. Dodatkowo wyróżnia ją świetna rozpuszczalność, która sprawia, że nie zostawia nieprzyjemnych grudek. " +
                "Przygotuj ją w swoim shakerze i wypij, a zobaczysz, że inne produkty mogą się przy niej schować. ",
                Ingredients = "izolat białka serwatki (z mleka), stabilizator - guma arabska, emulgator - lecytyny (z soi), emulgator - lecytyny (ze słonecznika), aromat, substancja słodząca - sukraloza. Może zawierać białko jaj oraz orzechy.",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 2,9g, w tym kwasy tłuszczowe nasycone 2g, Węglowodany 2,6g, w tym cukry 2,5g, Białko 85g, Sól <0,3g, Izolat białka serwatki (z mleka) 98g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Whey-Protein-Isolate-1800g.jpg", CategoryID =3
            },
            new Product() {ProductID = 7,
                Name = "HIRO.LAB Instant Whey Protein - 2000g",
                ProducerName = "GASPARI NUTRITION",
                Price =139,
                ShortDescription ="Hiro.Lab wyprodukowało swój Instant Whey Protein w oparciu o najwyższe standardy – GMP, HACCP i Doping Free. Wybierając go decydujesz się na odżywkę w atrakcyjnej cenie o świetnej jakości!",
                Description ="Białko to niezbędny element diety każdego człowieka, bez którego nie ma mowy o prawidłowym funkcjonowaniu organizmu. To właśnie ono stanowi materiał budulcowy, a także wspiera regenerację pomagając odbudować tkanki. Jednak wiele osób w codziennej diecie nie zaspokaja zapotrzebowania organizmu na białko. " +
                "Warto wówczas zacząć zażywać Instant Whey Protein który pomoże Ci dostarczyć białko w wyjątkowo szybki i smaczny sposób!",
                Ingredients = "Koncentrat białka serwatki (z mleka), hydrolizowana skrobia kukurydziana, dekstroza, emulgator - lecytyny (z soi), emulgator – lecytyny (ze słonecznika), aromat, substancja słodząca – sukraloza, substancja zagęszczająca carboxymetyloceluloza." +
                " Może zawierać białko jaj oraz orzechy.",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 2,6g, w tym kwasy tłuszczowe nasycone 3g, Węglowodany 1,6g, w tym cukry 2,2g, Białko 89g, Sól <0,3g, Izolat białka serwatki (z mleka) 98g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Instant-Whey-Protein-2000g.jpg", CategoryID =3
            },
            new Product() {ProductID = 8,
                Name = "GASPARI NUTRITION Proven Whey - 1814g",
                ProducerName = "GASPARI NUTRITION",
                Price =219,
                ShortDescription ="Marzysz o sylwetce kulturysty? Ciężka praca, którą wykonujesz na siłowni może przynieść lepsze efekty, jeśli wspomożesz ją odpowiednią odżywką białkową. Proven Whey od Gaspari Nutrition idealnie nadaje się na Twojego towarzysza podczas treningów.",
                Description ="Proteiny pełnią w organizmie wiele ról i współuczestniczą także w innych procesach zachodzących w ciele. Organizm sportowca potrzebuje więcej białka niż przeciętna osoba, " +
                "dlatego jeśli zależy Ci na muskulaturze, pomyśl o odżywce proteinowej. Proven Whey zawiera aż 25g białka w porcji, dzięki czemu skutecznie wspomożesz rozrost swoich mięśni. " +
                "Średnio powinieneś spożywać łącznie 2,5-3g białka na 1 kg masy ciała na dzień, jeśli chcesz rozbudować masę mięśniową. ",
                Ingredients = "izolat białka serwatki (WPI) (z mleka) 96%, aromaty, substancja zagęszczająca (guma ksantanowa), barwnik (karoteny), substancja słodząca (sukraloza)",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 1,6g, w tym kwasy tłuszczowe nasycone 1,5g, Węglowodany 3,6g, w tym cukry 2,6g, Białko 92g, Sól <0,3g, Izolat białka serwatki (z mleka) 98g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Proven-Whey-1814g.jpg", CategoryID =3
            },
            new Product() {ProductID = 9,
                Name = "GASPARI NUTRITION Myofusion Advanced EU - 500g",
                ProducerName = "GASPARI NUTRITION",
                Price =49,
                ShortDescription ="Rich Gaspari powraca na polski rynek ze swoim kultowym białkiem wielofrakcyjnym MyoFusion! Odpowiednio wydłużony czas trawienia i obniżona zawartość cukrów i tłuszczów. " +
                "Dostajesz aż 5 frakcji – WPC, izolat i hydrolizat białek serwatkowych, koncentrat białek mleka oraz kazeinę!",
                Description ="Zaawansowane MyoFusion jest odżywką pozbawioną Glutenu - całkowicie GLUTEN FREE. Niesamowita ilość protein w porcji - 25 g czystego białka zaledwie przy 2,3 g cukrów. Kultowe Myofusion to jedno z najlepszych białek wielofrakcyjnych dostępnych na rynku. Firma GASPARI NUTRITION stworzyła innowacyjną formułę składającą się z 5 frakcji. " +
                "Koncentrat WPC, izolat i hydrolizat białka serwatkowego, koncentrat mleka oraz kazeina.",
                Ingredients = "Mieszanka białek Myofusion (koncentrat białek serwatkowych (mleko), koncentrat białek mleka, izolat białek serwatkowych (mleko), kazeina micelarna (mleko), hydrolizat białek serwatkowych, (mleko)), " +
                "maltodekstryna, olej słonecznikowy w proszku (olej słonecznikowy o wysokiej zawartości olejów, modyfikowany Skrobia, substancja przeciwzbrylająca (krzemionka)), aromat, barwnik (czerwień buraczana), zagęszczacz (karbometyloceluloza), " +
                "emulgator (lecytyna sojowa), sól, substancja słodząca (sukraloza), trójglicerydy o średniej długości łańcucha, białko mleka, fosforan dipotasowy, fosforan trójwapniowy).",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 1,6g, w tym kwasy tłuszczowe nasycone 1,5g, Węglowodany 3,6g, w tym cukry 2,6g, Białko 92g, Sól <0,3g, Izolat białka serwatki (z mleka) 98g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="IRON_HORSE_BCAA-2-1-1-120caps.jpg", CategoryID =3
            },
            new Product() {ProductID = 10,
                Name = "IRONFLEX WPC EDGE Instant - 2270g",
                ProducerName = "IRONFLEX",
                Price =117,
                ShortDescription ="WPC 80 od IRONFLEX to suplement diety o bardzo dobrym składzie, który dostarczy do organizmu to, czego on potrzebuje. Jest źródłem świetnej jakości białka i pełnego profilu aminokwasowego. ",
                Description ="Suplement diety od IronFlex dostarcza do organizmu potrzebne mu białko. Doskonale sprawdzi się dla osób, które chcą uzupełnić dietę w proteiny, każdą porcję w 70% stanowią właśnie one! " +
                "Jest to produkt szczególnie polecany osobom aktywnym fizycznie, które chcą zwiększyć masę mięśniową, przyspieszyć regenerację i zmniejszyć uczucie zmęczenia.",
                Ingredients = "Koncentrat białek serwatkowych WPC80, substancja zagęszczająca: guma ksantanowa, substancja słodząca: sukraloza i acesulfam K, aromaty, barwniki naturalne: B-karoten, ekstrakt soku z czerwonego buraka, ekstrakt z czarnej marchwi, karmel w proszku, kakao-dla smaku czekoladowego",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 5g, w tym kwasy tłuszczowe nasycone 3,5g, Węglowodany 7,6g, w tym cukry 4,5g, Białko 85g, Sól <1,3g, Izolat białka serwatki (z mleka) 92g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="WPC-EDGE-Instant-2270g.jpg", CategoryID =3
            },
            new Product() {ProductID = 11,
                Name = "4+ NUTRITION Iso+ Probiotics - 900g",
                ProducerName = "4+ NUTRITION",
                Price =149,
                ShortDescription ="ISO+ Probiotics Probiotics to wysokiej jakości odżywka białkowa, która jako jedyna na rynku posiada dodatek probiotyków: Bacillus coagulans i Bacillus subtilis Natto. ",
                Description ="ISO+ Probiotics to aktualnie najlepszy izolat białek serwatkowych na rynku! Włoscy potentaci branży odżywek i suplementów stworzyli WPI o 86% zawartości białka, " +
                "które jest wolne od laktozy, o niskiej zawartości tłuszczów, węglowodanów i cukrów oraz bez dodatków i wypełniaczy. W jednorazowej porcji zawiera aż 26 g najwyższej jakości protein. " +
                "Każde 100 g produktu zawiera 86 g izolatu serwatki. Dokładnie oczyszczony surowiec użyty do produkcji ISO+ Probiotics uznawany jest za najdoskonalsze i najbardziej wartościowe źródło protein w tej kategorii białek dostępne w sprzedaży.",
                Ingredients = "izolat białka serwatki (zawierający emulgator: lecytyna sojowa), aromat, substancja słodząca: sukraloza; Macierz Proβios [nukleotydy 5-monofosforan (5-monofosforan guanozyny, 5-monofosforan inozyny, 5-monofosforan adenozyny)",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 0,6g, w tym kwasy tłuszczowe nasycone 2,5g, Węglowodany 4,6g, w tym cukry 1,6g, Białko 97g, Sól <0,3g, Izolat białka serwatki (z mleka) 93g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Iso-Probiotics-900g.jpg", CategoryID =3
            },
            new Product() {ProductID = 12,
                Name = "EXTRIFIT Protein Caffe Isolate - 31g",
                ProducerName = "EXTRIFIT",
                Price =4.99m,
                ShortDescription ="Protein Caffe Isolate to kolejna odsłona aromatycznej kawy proteinowej od czeskiej marki EXTRIFIT. Wszyscy lubimy doskonałą kawę! A sportowcy kochają proteiny! ",
                Description ="Jeśli trzymasz dietę redukcyjną, Twój wybór produktów, które możesz spożywać, jest bardzo ograniczony. Podczas odchudzania zwykle pije się nawet kilka kaw dziennie. " +
                "Na Twoje oczekiwania odpowiada z dumą Extrifit®, który stworzył połączenie pysznej prawdziwej kawy i najwyższej jakości mikrofiltrowanego krzyżowo 90% izolatu białka serwatkowego CFM " +
                "z zawartością aż 5452 mg BCAA! Jedna porcja to aż 25 gramów czystych protein! Anaboliczna kawa na białkowe śniadanie!",
                Ingredients = "instantyzowany 90% mikrofiltrowany krzyżowo izolat białek serwatkowych (CFM)(z mleka), instantyzowana kawa (zaw. naturalną kofeinę - 2%, stanowi 10% składu produktu), bezwodna kofeina, substancja słodząca - sukraloza, emulgator - lecytyna sojowa.",
                Parameters = "Wartość energetyczna w 31g: 471kJ/1kcal, Tłuszcz 0g, w tym kwasy tłuszczowe nasycone 0g, Węglowodany 2,6g, w tym cukry 0g, Białko 25g, Sól 0g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Protein-Caffe-Isolate-31g.jpg", CategoryID =3
            },
            new Product() {ProductID = 13,
                Name = "OPTIMUM NUTRITION Whey Gold Standard - 2270g",
                ProducerName = "OPTIMUM NUTRITION",
                Price =239,
                ShortDescription ="100% Whey Gold Standard renomowanej firmy OPTIMUM NUTRITION należy do najwyższej jakości odżywek białkowych, opartych całkowicie na koncentracie (WPC), izolacie (WPI) oraz hydrolizowanym izolacie białek serwatkowych.",
                Description ="Whey Gold Standard gwarantuje dostarczenie do organizmu sportowca białek i peptydów najwyższej wartości biologicznej, oraz o najszybszym czasie wchłaniania w układzie pokarmowym człowieka." +
                "Każda porcja dostarcza aż 24 g biologicznie najwyższej wartości białka serwatkowego będącego specjalistyczną mieszaniną frakcji protein produkcji OPTIMUM NUTRITION. ",
                Ingredients = "mieszanka białek - z mleka [izolat białek serwatkowych (emulgator - lecytyna sojowa), koncentrat białek serwatkowych, hydrolizowany izolat białek serwatkowych], aromaty, substancje słodzące (acesulfam K, sukraloza), kompleks enzymów (Amylaza, Proteaza, Celulaza, Beta-D-Galaktoksydaza, Lipaza).",
                Parameters = "Wartość energetyczna w 100g: 1597kJ/377kcal, Tłuszcz 1,6g, w tym kwasy tłuszczowe nasycone 1,5g, Węglowodany 3,8g, w tym cukry 2,6g, Białko 94g, Sól <0,3g, Izolat białka serwatki (z mleka) 96g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Whey-Gold-Standard-2270g.jpg", CategoryID =3
            },
            new Product() {ProductID = 14,
                Name = "OLIMP Whey Protein Complex 100% - 2270g",
                ProducerName = "OLIMP",
                Price =169,
                ShortDescription ="Do produkcji białka od Olimp użyto surowców naprawdę wysokiej jakości, odznaczających się dużą czystością. Wszystko dzięki zastosowaniu nowatorskiej technologii, bogatej wiedzy i wieloletniemu doświadczeniu naukowców z Olimp Labs.",
                Description ="Whey Protein Complex 100% idealnie sprawdzi się jako alternatywa dla śniadania lub innego posiłku. Jeżeli rano zmuszasz się do zjedzenia czegokolwiek to ucieszy Cię wiadomość, że możesz wypić coś pożywnego. W jednej porcji znajdziesz aż 26 gramów białka, niewiele węglowodanów i jeszcze mniej cukrów!",
                Ingredients = "95% preparaty białkowe (ultrafiltrowany koncentrat białek serwatkowych z WPC (z mleka), izolat białek serwatkowych WPI-CFM, karboksymetylocelulozy; substancje słodzące – acesulfam K, sukraloza, cyklaminiany (Z), emulgator – lecytyny (z soi), sól, barwniki: karoteny, koszenila, ryboflawiny, E150c, E 150d, " +
                "E 133, błękit pantenowy V, indygokarmin, chlorofile i chlorofiliny, kurkumina, antocyjany, ekstrakt z papryki, betanina, węgiel roślinny,",
                Parameters = "Wartość energetyczna w 100g: 1697kJ/397kcal, Tłuszcz 2,6g, w tym kwasy tłuszczowe nasycone 2,1g, Węglowodany 5,8g, w tym cukry 3,4g, Białko 92g, Sól <0,3g, Izolat białka serwatki (z mleka) 93g",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="whey_protein.jpg", CategoryID =3
            },
            new Product() {ProductID = 15,
                Name = "MHP X-PEL - 80caps",
                ProducerName = "MHP",
                Price =45.39m,
                ShortDescription ="Xpel od MHP to spalacz tłuszczu, który doskonale sprawdzi się jako środek diuretyczny do pozbycia się wody z organizmu.",
                Description ="W składzie zawiera rośliny, za których pomocą w bezpieczny sposób uwolnisz się od nadmiaru zalegających w organizmie płynów. Zażywając go masz pewność, że stosujesz środek bezpieczny i oparty na naturalnych składnikach. " +
                "Dodatkowo, co ważne, zażywając go masz pewność, że na bieżąco uzupełniasz poziom elektrolitów!",
                Ingredients = "kapsułka (hypromeloza), chlorek amonu, celuloza mikrokrystaliczna, stearynian magnezu i krzemionka.",
                Parameters = "Wartości odżywcze	w 1 porcji (4 caps): Witamina B-6 (jako pirydoksyna HCL) 1 mg, Magnez (Tlenek Magnezu) 100 mg, Wapń (Węglan Wapnia) 200 mg, Potas (Cytrynian Potasu) 90 mg, " +
                "Advanced Herbal Diuretic Matrix(ziołowa mieszanka diuretyczna) 1200 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="X-PEL-80caps.jpg", CategoryID =4
            },
            new Product() {ProductID = 16,
                Name = "3FLOW SOLUTIONS SlimFlow Black - 60caps + Vitamin D3 2000IU PureFlow - 90caps",
                ProducerName = "3FLOW SOLUTIONS",
                Price =49,
                ShortDescription ="Linia SlimFlow renomowanej firmy 3FLOW SOLUTIONS kojarzy się przede wszystkim z bestsellerowym spalaczem tłuszczy dla kobiet, który został doceniony przez tysiące klientek oraz nagrodzony Kobiecą Marką Roku.",
                Description ="Ten fantastyczny spalacz tłuszczu dla mężczyzn SlimFlow Black to kompleks 7 składników aktywnych najwyższej jakości. W jego skład wchodzą: ekstrakt z zielonej herbaty, pieprzyca peruwiańska, buzdyganek naziemny," +
                " witamina B6, kofeina, ekstrakt z czarnego pieprzu oraz chrom. SlimFlow Black skutecznie wspomaga odchudzanie i redukcję tkanki tłuszczowej.",
                Ingredients = "zielona herbata Ekstrakt (Camellia sinensis), pieprzyca Peruwiańska MACA (Lepidium L.), buzdyganek naziemny (Tribulus Terrestris L.), kofeina bezwodna, witamina B6 (chlorowodorek pirydoksyny), pieprz czarny (piper nigrum), " +
                "chrom (pikolinian chromu), celuloza mikrokrystaliczna, barwnik (dwutlenek tytanu).",
                Parameters = "Składniki aktywne 1cap: Ekstrakt z Zielonej Herbaty (Camellia sinensis)(stand. na 50% EGCG) 200 mg,Ekstrakt z Pieprzycy Peruwiańskiej MACA (Lepidium L.)(4:1) 200 mg,Ekstrakt z Buzdyganka Naziemnego(Tribulus Terrestris L.)(4:1) 100 mg,Kofeina Bezwodna 100 mg, " +
                "Witamina B6 (jako Chlorowodorek Pirydoksyny) 9 mg, Ekstrakt z owoców Czarnego Pieprzu (Piper Nigrum)(stand. na 95% Piperyny) 5mg, Chrom (jako Pikolinian Chromu)  100 µg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Vitamin-D3-2000IU-PureFlow-90caps.jpg", CategoryID =4
            },
            new Product() {ProductID = 17,
                Name = "OLIMP Vita-Min Multiple Sport - 60caps",
                ProducerName = "OLIMP",
                Price =29,
                ShortDescription ="Wybierz produkt, który zapewni Ci wiele wartościowych składników odżywczych - Vita-Min Multiple Sport od znanej marki Olimp.",
                Description ="Troszcząc się o zdrowie swojego ciała powinieneś zainwestować w ochronę przed wolnymi rodnikami. Są to cząsteczki, które krążą po ciele niszcząc zdrowe komórki poprzez utlenianie ich. " +
                "Potrafią spowodować niemałe spustoszenie, a nawet wywołać mutację DNA. Na ich ataki narażone są zwłaszcza osoby trenujące sport. Na szczęście produkt Vita-Min Multiple Sport zawiera w sobie cały zestaw wartościowych antyoksydantów – " +
                "czyli substancji walczących z wolnymi rodnikami.",
                Ingredients = "witaminy (mikrokapsułkowany kwas L-askorbinowy (PureWay-C®) - wit.C, octan DL-α-tokoferylu - wit.E, amid kwasu nikotynowego - niacyna, D-biotyna, octan retinylu - wit.A, D-pantotenian wapnia - kwas pantotenowy, chlorowodorek pirydoksyny - wit.B6, cholekalcyferol - wit.D, kwas pteroilomonoglutaminowy - folian, monoazotan tiaminy - wit.B1, ryboflawina - wit.B2, " +
                "cyjanokobalamina - wit.B12), bioflawonoidy cytrusowe, ekstrakt karczocha (Cynara scolymus L.)",
                Parameters = "Składniki aktywne	w 1 kapsułce: Wit. A 1000 µg, Wit. D 10 µg ,Wit. E 24 mg, Wit. C (PureWay-C®) 290 mg, Wit. B1 19,4 mg, Wit. B2 19,6 mg, Niacyna 31 mg, Wit. B6 18,8 mg, Folian 400 µgWit., B12 23 µgBiotyna 100 µg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Vita-Min-Multiple-Sport-60caps.jpg", CategoryID =5
            },
            new Product() {ProductID = 18,
                Name = "IRONFLEX Vitamin Forte - 120tabs",
                ProducerName = "IRONFLEX",
                Price =19,
                ShortDescription ="IronFlex Vitamin Forte jest znakomitej jakości preparatem zawierającym kompleks minerałów i witamin. Wspiera on pracę wszystkich narządów ludzkich i łagodzi stres.",
                Description ="IronFlex Vitamin Forte wspomaga układ nerwowy. Do niepodważalnych zalet tego suplementu zalicza się korzystny wpływ na pracę wszystkich narządów ludzkich, dzięki któremu łatwiej osiągniesz cele treningowe. Dzięki suplementacji IronFlex Vitamin Forte wspomożesz swoją odporność, " +
                "a także poprawisz ogólne samopoczucie, a wiadomo, że gdy będziesz w dobrej kondycji, to Twoje rezultaty treningowe będą lepsze.",
                Ingredients = "Amid kwasu nikotynowego - niacyna, chlorek potasu-potas, chlorowodorek pirydoksyny – witamina B6, cholekalcyferol – witamina D, cyjanokobalamina - witamina B12, D-biotyna - biotyna, D-pantotenian wapnia – kwas pantotenowy,fumaran żelaza (II) - żelazo, kwas L-askorbinowy – witamina C, " +
                "kwas pteroilomonoglutaminowy – kwas foliowy,monoazotan tiaminy – tiamina, octan DL-alfa tokoferylu (50 % alfa-tokoferylu) – witamina E,",
                Parameters = "Składniki aktywne	w 1 kapsułce: Wit. A 1200 µg, Wit. D 12 µg ,Wit. E 26 mg, Wit. C (PureWay-C®) 210 mg, Wit. B1 13,4 mg, Wit. B2 21,6 mg, Niacyna 41 mg, Wit. B6 19,8 mg, Folian 430 µgWit., B12 23 µgBiotyna 130 µg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Vitamin-Forte-120tabs.jpg", CategoryID =5
            },
            new Product() {ProductID = 19,
                Name = "UNIVERSAL Animal Immune Pak - 327 g",
                ProducerName = "UNIVERSAL",
                Price =149,
                ShortDescription ="Suplement Universal zawiera witaminy i minerały wzmacniające odporność oraz wspiera zdrowy sen i regenerację między treningami. ",
                Description ="Animal Immune Pak to przede wszystkim połączenie witamin C i D oraz cynku, które wspólnie pomagają skuteczniej chronić układ immunologiczny przed szkodliwymi bakteriami i wirusami. Immune Pak zawiera też naturalne składniki roślinne i ziołowe. " +
                "Jedna porcja tego proszku to kompletne wsparcie odporności - Animal Immune Pak osłania Cię i wzmacnia Twoją linię obrony, aby nic nie powstrzymało Cię w codziennej walce o wymarzoną sylwetkę. ",
                Ingredients = "Naturalne i sztuczne aromaty, naturalny aromat, kwas cytrynowy, krzemian wapnia, sukraloza, acesulfam potasowy, tlenek cynku, FD&C Yellow#5, FD&C Yellow#6. " +
                "Wykonano w zakładzie GMP przetwarzającym mleko, soję, jajka, orzeszki ziemne, orzechy, ryby, skorupiaki i pszenicę.",
                Parameters = "Witamina C (jako kwas askorobinowy) 1000mg, Witamina D (jako cholekalcyferol) 75mcg (3000IU), Cynk 25mg Kompleks wspierający odporność  7850 mg, L-Glutamina 5000 mg, N-Acetylo-Cysteina 600 mg," +
                "Ekstrakt z liści oliwnych 500 mg, Korzeń Astragalus 500 mg, Ekstrakt z Ashwagandhy (cała roślina) 500 mg, Kwercetyna 300 mg, Korzeń imbiru 250 mg, Ekstrakt z pestek winogron 200 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Animal-Immune-Pak-327.jpg", CategoryID =5
            },
            new Product() {ProductID = 20,
                Name = "GASPARI NUTRITION High Strength Enteric Coated Omega-3 - 60softgels",
                ProducerName = "GASPARI NUTRITION",
                Price =59,
                ShortDescription ="High Strength Enteric Coated Omega-3 od Gaspari Nutrition. Za jego pomocą dostarczysz swojemu organizmowi dokładnie to, czego potrzebuje.",
                Description ="Zdrowe kwasy tłuszczowe są bardzo ważne w diecie każdego, ale to osoby aktywne fizycznie mogą ponieść największe konsekwencje. Podobnie ma to miejsce podczas przesilenia jesienno-zimowego, " +
                "kiedy spada nasza odporność. Zadbaj o siebie stosując suplement diety od Gaspari Nutrition, który jest doskonałym źródłem EPA i DHA.",
                Ingredients = "Inne składniki: żelatyna, gliceryna, woda, kopolimer kwasu metakrylowego i tokoferole. Zawiera ryby (sardele, sardynki, makrele)" +
                "Wykonano w zakładzie GMP przetwarzającym mleko, soję, jajka, orzeszki ziemne, orzechy, ryby, skorupiaki i pszenicę.",
                Parameters = "Wartość energetyczna	25kcal, Kalorie z tłuszczu  35kcal, Tłuszcze 3g, Tłuszcze nasycone 1g, Tłuszcz wielonienasycony 1g, Tłuszcz jednonienasycony 0,5g, " +
                "Cholesterol 25mg, Węglowodany 1g, Białka <1g, Koncentrat oleju rybnego 2400mg, Kwas eikozapentaenowy Omega-3 (EPA) 960mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="Animal-Immune-Pak-327.jpg", CategoryID =6
            }

            };

            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }

        public static void InitializeIdentityForEF(StoreContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@ProGym.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";


            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            //var user = userManager.FindByName(name);
            //if (user == null)
            //{
            //    user = new ApplicationUser { UserName = name, Email = name };
            //    var result = userManager.Create(user, password);
            //    result = userManager.SetLockoutEnabled(user.Id, false);
            //}

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }


}