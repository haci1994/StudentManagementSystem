using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace StudentManagementSystem
{
    internal class Program
    {
        //Manual telebeler ve qiymetleri elave edilir

        public static List<Telebe> TelebeSiyahisi =
    new List<Telebe>
    {
        new Telebe {
            Melumat = new TelebeSeхsiMelumati {
                Name="Haji", Surname="Mustafazade", BirthDate=new DateTime(1994,6,5),Phone="994512292394"
            },
            Status = TelebeStatusu.Aktiv,
            Ixtisas = IxtisasSahesi.Tibb,
            Qiymetler = new List<FennQiymeti> {
                new FennQiymeti(FennNovu.Anatomiya, 3, 88, Semestr.Birinci),
                new FennQiymeti(FennNovu.Tibbi_Idareetme, 2, 79, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Iqtisadiyyatin_esaslari, 2, 90, Semestr.Ikinci)
            }
        },
        new Telebe {
            Melumat = new TelebeSeхsiMelumati {
                Name="Elmin", Surname="Pashayev", BirthDate=new DateTime(1994,12,23),Phone="994553806060"
            },
            Status = TelebeStatusu.Kesr,
            Ixtisas = IxtisasSahesi.Huquq,
            Qiymetler = new List<FennQiymeti> {
                new FennQiymeti(FennNovu.Azerbaycan_qanunvericiliyi, 3, 68, Semestr.Birinci),
                new FennQiymeti(FennNovu.Biznes_huququ, 2, 75, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Iqtisadiyyatin_esaslari, 1, 60, Semestr.Ikinci)
            }
        },
        new Telebe {
            Melumat = new TelebeSeхsiMelumati {
                Name="Nigar", Surname="Suleymanova", BirthDate=new DateTime(1995,3,18),Phone="994504442222"
            },
            Status = TelebeStatusu.Aktiv,
            Ixtisas = IxtisasSahesi.Maliye,
            Qiymetler = new List<FennQiymeti> {
                new FennQiymeti(FennNovu.Biznesin_teskili, 3, 95, Semestr.Birinci),
                new FennQiymeti(FennNovu.Iqtisadiyyatin_esaslari, 2, 85, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Biznes_huququ, 3, 78, Semestr.YayMektebi),
                new FennQiymeti(FennNovu.Anatomiya, 1, 70, Semestr.Birinci)
            }
        },
        new Telebe {
            Melumat = new TelebeSeхsiMelumati {
                Name="Murad", Surname="Ismayilov", BirthDate=new DateTime(1996,7,1),Phone="994505553333"
            },
            Status = TelebeStatusu.Transfer,
            Ixtisas = IxtisasSahesi.Pedoqoji,
            Qiymetler = new List<FennQiymeti> {
                new FennQiymeti(FennNovu.Tehsil_sisteminin_teskili, 3, 72, Semestr.Birinci),
                new FennQiymeti(FennNovu.Auditoriya_ile_is, 2, 88, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Iqtisadiyyatin_esaslari, 3, 65, Semestr.YayMektebi)
            }
        },
        new Telebe {
            Melumat = new TelebeSeхsiMelumati {
                Name="Lale", Surname="Hesenova", BirthDate=new DateTime(1993,11,9),Phone="994554441111"
            },
            Status = TelebeStatusu.Dondurub,
            Ixtisas = IxtisasSahesi.Tibb,
            Qiymetler = new List<FennQiymeti> {
                new FennQiymeti(FennNovu.Anatomiya, 3, 81, Semestr.Birinci),
                new FennQiymeti(FennNovu.Tibbi_Idareetme, 3, 74, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Azerbaycan_qanunvericiliyi, 2, 77, Semestr.Ikinci),
                new FennQiymeti(FennNovu.Tehsil_sisteminin_teskili, 1, 66, Semestr.YayMektebi),
                new FennQiymeti(FennNovu.Auditoriya_ile_is, 1, 70, Semestr.Ikinci)
            }
        }
    };

        //Loglarin saxlanmasi ucun bosh siyahi yaradilir

        public static List<string> LogList = [];

        static void Main(string[] args)
        {

            //Universitet metodlari ucun class cagirilir
            UniversistetSistemi UniversistetIdare = new UniversistetSistemi();

            do
            {
                //Konsolun menyusu yazilir
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=== UNİVERSİTET TELEBE IDARETEME SİSTEMİ ===");
                Console.WriteLine();
                Console.WriteLine("[1] Telebe elave et");
                Console.WriteLine("[2] Butun telebeleri goster");
                Console.WriteLine("[3] Fenn qiymeti elave et");
                Console.WriteLine("[4] Telebe axtar");
                Console.WriteLine("[5] Statistika goster");
                Console.WriteLine("[6] Cixis");
                Console.WriteLine("[7] Bir telebenin qiymetlerine bax");
                Console.WriteLine("[8] Loglara bax");
                Console.WriteLine("[9] Qiymet deyish");
                Console.WriteLine();
                Console.WriteLine("------------------");

                //Emr qebul edilir ve yoxlanilir
                Console.Write("Seciminiz: ");
                if (int.TryParse(Console.ReadLine(), out int cmnd))
                {
                    if (cmnd < 0 || cmnd > 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Emr nomresi yalniz siyahidaki reqemlerden biri ola biler!");
                        Console.WriteLine("------------------");
                        Console.WriteLine();
                        continue;
                    }

                    //Emre uygun metod cagirilir
                    switch (cmnd)
                    {
                        case 1:
                            Telebe TelebeIdare = new Telebe();
                            TelebeIdare.Add(TelebeSiyahisi, LogList);
                            break;
                        case 2:
                            UniversistetIdare.ButunTelebelereBax(TelebeSiyahisi);
                            break;
                        case 3:
                            var telebe = UniversistetIdare.TelebeAxtar(TelebeSiyahisi);
                            telebe.QiymetElaveEt(telebe.Id, TelebeSiyahisi, LogList);
                            break;
                        case 4:
                            UniversistetIdare.TelebeAxtar(TelebeSiyahisi);
                            break;
                        case 5:
                            UniversistetIdare.Statistika(TelebeSiyahisi);
                            break;
                        case 6:
                            return;
                        case 7:
                            UniversistetIdare.TelebeQiymetlerineBax(TelebeSiyahisi);
                            break;
                        case 8:
                            Console.Clear();
                            foreach (var log in LogList)
                            {
                                Console.WriteLine(log);
                            }
                            break;
                        case 9:
                            UniversistetIdare.QiymetDeyish(TelebeSiyahisi, LogList);
                            break;

                    }



                }

                //Yalnish emrler ucun mesaj gonderilir
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Emrler yalniz reqem kimi daxil edile biler");
                    Console.WriteLine("------------------");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("------------------");
                Console.WriteLine();
            }
            while (true);
        }

    }

    //Enumlar yaradilir
    public enum IxtisasSahesi
    {
        Maliye,
        Tibb,
        Huquq,
        Pedoqoji
    }

    public enum TelebeStatusu
    {
        Aktiv,
        Kesr,
        Dondurub,
        Bitirib,
        Transfer
    }

    public enum FennNovu
    {
        Iqtisadiyyatin_esaslari,
        Biznesin_teskili,
        Anatomiya,
        Tibbi_Idareetme,
        Azerbaycan_qanunvericiliyi,
        Biznes_huququ,
        Tehsil_sisteminin_teskili,
        Auditoriya_ile_is
    }

    //Tapshiriqdan elave enum
    public enum Semestr
    {
        Birinci,
        Ikinci,
        YayMektebi
    }

    //Loglarin cap olunmagi ve log siyahisina artirilmagi ucun metod 
    public class LogAndEvent
    {
        public Action<string, List<string>> LogPrint = (logText, logList) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(logText);
                Console.ForegroundColor = ConsoleColor.White;
                logList.Add(logText);
            };
    }

    //Structlar qurulur
    public struct TelebeSeхsiMelumati
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }

        public TelebeSeхsiMelumati(string name, string surname, DateTime date, string number)
        {
            Name = name;
            Surname = surname;
            BirthDate = date;
            Phone = number;
        }

        public override string ToString()
        {
            return $"Telebe adi ve soyadi: {Name} {Surname}. Dogum tarixi: {BirthDate}. Elaqe nomresi {Phone}";
        }
    }

    public struct FennQiymeti
    {
        public FennNovu Fenn { get; set; }
        public int KreditSayi { get; set; }
        public int Qiymet { get; set; }
        public Semestr Semestr { get; set; }

        public FennQiymeti(FennNovu fenn, int kredit, int qiymet, Semestr semestr)
        {
            Fenn = fenn;
            KreditSayi = kredit;
            Qiymet = qiymet;
            Semestr = semestr;
        }

        public override string ToString()
        {
            return $"Fennin adi: {Enum.GetName(Fenn)}. Kredit sayi: {KreditSayi}. Qiymet: {Qiymet}. Semestr: {Enum.GetName(Semestr)}";
        }

    }

    //Abstract class qurulur
    public abstract class UniversitetUzvu
    {

        public TelebeSeхsiMelumati Melumat = new TelebeSeхsiMelumati();

        public abstract void Add(List<Telebe> telebeSiyahisi, List<string> logList);

        public abstract ValueTuple<int, double, string> GetTelebeStatistikasi(Telebe telebe);

    }


    //Interface yaradilir
    public interface IQiymetIdareetmesi
    {
        public void QiymetElaveEt(int id, List<Telebe> siyahi, List<string> logList);
        public double OrtalamaQiymetHesabla();
    }


    //Telebe classi yaradilir, hem abstarct classdan toreyir, hem de interfaceden protokollari alir
    public class Telebe : UniversitetUzvu, IQiymetIdareetmesi
    {
        //ID konstruktorla avtomatik teyin edilir
        static int _telebeIdIzleme = 0;

        private int _id;
        public int Id => _id;
        public Telebe()
        {
            _id = _telebeIdIzleme++;
        }
        public TelebeStatusu Status { get; set; }
        public IxtisasSahesi Ixtisas { get; set; }
        public List<FennQiymeti> Qiymetler { get; set; } = [];

        //En vacib add metodu yazilir, burada butun inputlarin ucun vacib yoxlamalar aparilir
        public override void Add(List<Telebe> telebeSiyahisi, List<string> logList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Telebe elave etmek ucun melumatlari daxil edin! (legv etmek ucun 'Exit' yazin)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------");

            //Ad daxil edilir ve yoxlanilir, minimum 3 simvol, bosh ola bilmez, reqem ola bilmez           
            string nameInput = "";
            bool nameCheck = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Ad daxil edin: ");

                nameInput = Console.ReadLine();
                nameCheck = false;

                if (nameInput == "Exit") return;

                if (string.IsNullOrEmpty(nameInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Dogru Ad daxil etmediniz!!!");
                    nameCheck = true;
                }

                if (nameInput.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Cox qisa ad daxil etdiniz!");
                    nameCheck = true;
                }

                if (int.TryParse(nameInput, out int a))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Eded ad ola bilmez");
                }

                bool hasNumber = false;

                foreach (char x in nameInput)
                {
                    if (char.IsDigit(x))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Adda reqem istifade etmeyin");
                        hasNumber = true;
                        nameCheck = true;
                        break;
                    }
                }

            }
            while (nameCheck);

            //Soyad daxil edilir, minimum 3 simvol, bosh ola bilmez, reqem ola bilmez
            string surnameInput = "";
            bool surnameCheck = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Soyad daxil edin: ");

                surnameInput = Console.ReadLine();
                surnameCheck = false;

                if (surnameInput == "Exit") return;

                if (string.IsNullOrEmpty(surnameInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Dogru Soyad daxil etmediniz!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    surnameCheck = true;
                }

                if (surnameInput.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cox qisa soyad daxil etdiniz!");
                    Console.ForegroundColor = ConsoleColor.White;
                    surnameCheck = true;
                }

                if (int.TryParse(surnameInput, out int a))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Eded soyad ola bilmez");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                bool hasNumber = false;

                foreach (char x in surnameInput)
                {
                    if (char.IsDigit(x))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Soyadda reqem istifade etmeyin");
                        Console.ForegroundColor = ConsoleColor.White;
                        hasNumber = true;
                        surnameCheck = true;
                        break;
                    }
                }

            }
            while (surnameCheck);

            //Dogum tarixi daxil edilir, tarixden bashqa format qebul etmir (metn ola bilmez, tarixe uygun olmayan reqem toplusu ola bilmez)

            Console.ForegroundColor = ConsoleColor.White;
            DateTime dateInput = DateTime.Now;
            bool dateCheck = false;

            do
            {
                Console.WriteLine();
                Console.Write("Dogum tarixi (gg/aa/iiii): ");

                string tarix = Console.ReadLine();

                if (tarix == "Exit") return;

                if (DateTime.TryParse(tarix, out DateTime birthDate))
                {
                    dateInput = birthDate;
                    dateCheck = false;
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Tarixi duzgun formatda daxil edin (gg/aa/iiii)");
                    Console.ForegroundColor = ConsoleColor.White;
                    dateCheck = true;
                    continue;
                }
            }
            while (dateCheck);

            //Elaqe nomresi daxil edilir (bosh ola bilmez)

            Console.ForegroundColor = ConsoleColor.White;
            string phoneInput = "";
            bool checkNumber = false;

            do
            {
                checkNumber = false;
                Console.WriteLine();
                Console.Write("Elaqe nomresi daxil edin:");
                phoneInput = Console.ReadLine();

                if (phoneInput == "Exit") return;

                if (string.IsNullOrEmpty(phoneInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dogru nomre daxil etmediniz!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    checkNumber = true;
                    continue;
                }
            } while (checkNumber);

            //İxtisas secilir - sadece enum siyahisindan secile biler
            Console.ForegroundColor = ConsoleColor.White;
            IxtisasSahesi ixtisasInput = 0;
            int ixtisasSayi = Enum.GetNames(typeof(IxtisasSahesi)).Length;
            bool ixtisasCheck = false;

            do
            {
                ixtisasCheck = false;
                Console.WriteLine();
                Console.WriteLine("Ixtisas sahesini secin: ");

                for (int i = 0; i < ixtisasSayi; i++)
                {
                    Console.WriteLine($"[{i}] - {Enum.GetNames(typeof(IxtisasSahesi))[i]}");
                }
                Console.WriteLine();

                string ixtisas = Console.ReadLine();

                if (ixtisas == "Exit") return;

                if (int.TryParse(ixtisas, out int a))
                {
                    if (a < 0 || a > ixtisasSayi - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Siyahidan secim edin!");
                        Console.ForegroundColor = ConsoleColor.White;
                        ixtisasCheck = true;
                        continue;
                    }

                    ixtisasInput = (IxtisasSahesi)a;


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Düzgün seçim etmediniz!");
                    Console.ForegroundColor = ConsoleColor.White;
                    ixtisasCheck = true;
                    continue;
                }


            }
            while (ixtisasCheck);

            //Telebe statusu secilir - sadece enum siyahisindan secile biler
            Console.ForegroundColor = ConsoleColor.White;
            TelebeStatusu statusInput = 0;
            int statusSayi = Enum.GetNames(typeof(TelebeStatusu)).Length;
            bool statusCheck = false;

            do
            {
                statusCheck = false;
                Console.WriteLine();
                Console.WriteLine("Telebenin statusunu secin: ");

                for (int i = 0; i < statusSayi; i++)
                {
                    Console.WriteLine($"[{i}] - {Enum.GetNames(typeof(TelebeStatusu))[i]}");
                }
                Console.WriteLine();

                string status = Console.ReadLine();

                if (status == "Exit") return;

                if (int.TryParse(status, out int a))
                {
                    if (a < 0 || a > statusSayi - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Siyahidan secim edin!");
                        Console.ForegroundColor = ConsoleColor.White;
                        statusCheck = true;
                        continue;
                    }
                    else if (nameInput == "Exit")
                    {
                        return;
                    }

                    statusInput = (TelebeStatusu)a;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Düzgün seçim etmediniz!");
                    Console.ForegroundColor = ConsoleColor.White;
                    statusCheck = true;
                    continue;
                }


            }
            while (statusCheck);

            //Melumatlar telebe obyektine daxil edilir
            Melumat.Surname = surnameInput;
            Melumat.Name = nameInput;
            Melumat.BirthDate = dateInput;
            Melumat.Phone = phoneInput;
            Ixtisas = ixtisasInput;
            Status = statusInput;

            //yeni telebe siyahiya artirilir
            telebeSiyahisi.Add(this);

            //log metni hazirlanir
            string logText = $"[{DateTime.Now} - {nameInput} {surnameInput} adli telebel yaradildi. Status: {statusInput}]";

            //log metni cap edilir ve siyahiya artirilir
            Console.Clear();
            LogAndEvent logAndEvent = new LogAndEvent();
            logAndEvent.LogPrint.Invoke(logText, logList);
        }

        //Ortalama qiymet metodu yazilir
        public double OrtalamaQiymetHesabla()
        {
            return Qiymetler.Select(x => x.Qiymet).Average();
        }

        //Qiymet elave etme metodu yazilir, burada da butun inputlar ucun vacib yoxlamalar aparilir
        public void QiymetElaveEt(int id, List<Telebe> siyahi, List<string> logList)
        {
            var telebe = siyahi.FirstOrDefault(t => t.Id == id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{telebe.Melumat.Name} {telebe.Melumat.Surname} adli telebe ucun qiymet elave edirsiniz.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------");

            //Fennin novu daxil edilir - sadece enum siyahisindan
            Console.WriteLine("Fenn novunu daxil edin (secimler asagidaki kimidir):");
            Console.WriteLine();
            int fennSayi = Enum.GetNames(typeof(FennNovu)).Length;

            for (int i = 0; i < fennSayi; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"[{i}] - {Enum.GetNames(typeof(FennNovu))[i]}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Sizin seciminiz: ");
            FennNovu FennId;
            bool FennIdCheck = true;
            do
            {
                if (Enum.TryParse(Console.ReadLine(), out FennNovu fennId))
                {
                    FennId = fennId;
                    FennIdCheck = false;

                    if (fennId < 0 || (int)fennId > fennSayi - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Zehmet olmasa yuxaridaki siyahidan bir fenn secin!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        FennIdCheck = true;
                    }
                }
                else
                {
                    FennIdCheck = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Zehmet olmasa yuxaridaki siyahidan bir fenn secin!");
                    Console.ForegroundColor = ConsoleColor.White;
                    FennId = 0;
                }

            } while (FennIdCheck);

            //Kredit sayi daxil edilir - sadece verilen diapazondan
            Console.WriteLine();
            Console.Write("Kredit sayini daxil edin (1-4): ");
            int kreditSayi;
            bool kreditSayiCheck = true;

            do
            {
                if (int.TryParse(Console.ReadLine(), out int kreditInput))
                {
                    kreditSayi = kreditInput;
                    kreditSayiCheck = false;
                    if (kreditInput < 1 || kreditInput > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Diapazondan kenar kredit sayi daxil etdiniz! Minimum 1, Maximum 4.");
                        Console.ForegroundColor = ConsoleColor.White;
                        kreditSayiCheck = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Kredit sayi reqem olmalidir.");
                    Console.ForegroundColor = ConsoleColor.White;
                    kreditSayi = 0;
                }
            }
            while (kreditSayiCheck);

            //Qiymet daxil edilir - sadece verilen diapazondan
            Console.WriteLine();
            Console.Write("Qiymeti daxil edin (0-100):");
            int qiymet = 0;
            bool qiymetCheck = true;

            do
            {
                if (int.TryParse(Console.ReadLine(), out int qiymetInput))
                {
                    qiymet = qiymetInput;
                    qiymetCheck = false;

                    if (qiymetInput < 0 || qiymetInput > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Diapazondan kenar qiymet daxil etdin!");
                        Console.ForegroundColor = ConsoleColor.White;
                        qiymetCheck = true;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Qiymet eded olmalidir!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (qiymetCheck);

            //Semestr daxil edilir - sadece enum siyahisindan
            Console.WriteLine();
            Console.Write("Hansi semestr? ");
            Semestr semestr = 0;
            bool semestrCheck = true;
            int semestrSayi = Enum.GetNames(typeof(Semestr)).Length;
            Console.WriteLine();
            for (int i = 0; i < semestrSayi; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"[{i}] - {Enum.GetNames(typeof(Semestr))[i]}");
            }

            do
            {
                if (Enum.TryParse(Console.ReadLine(), out Semestr s))
                {
                    semestr = s;
                    semestrCheck = false;

                    if (s < 0 || (int)s > semestrSayi)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Duzgun secim etmediniz!");
                        Console.ForegroundColor = ConsoleColor.White;
                        semestrCheck = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Yanlsih sechim daxil etdiniz!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (semestrCheck);

            //Melumatlar uzre yeni fennQiymeti yaradilir ve verilen telebenin modeline elave edilir.
            var yeniFennQiymeti = new FennQiymeti { Fenn = FennId, KreditSayi = kreditSayi, Qiymet = qiymet, Semestr = semestr };
            siyahi.FirstOrDefault(x => x.Id == id).Qiymetler.Add(yeniFennQiymeti);


            //Logtext yaradilir ve cap edilib siyahiya artirilir
            Console.Clear();
            LogAndEvent logAndEvent = new LogAndEvent();
            string logText = $"[{DateTime.Now} - {FennId} adli Fenn, {kreditSayi} kredit sayi ile {qiymet} qiymet ile {semestr} semestre elave edildi. Telebe: {telebe.Melumat.Name}]";
            logAndEvent.LogPrint.Invoke(logText, logList);
        }

        //Telebe statisiktasi metodu yaradilir  - Tuple istifadesi
        public override (int, double, string) GetTelebeStatistikasi(Telebe telebe)
        {
            double ob = telebe.Qiymetler.Any() ? telebe.Qiymetler.Select(x => x.Qiymet).Average() : 0;

            int fs = telebe.Qiymetler.Any() ? telebe.Qiymetler.Select(x => x.Fenn).Count() : 0;

            string ia = telebe.Ixtisas.ToString();

            return (fs, ob, ia);

        }

        //Telebe modelinin toString metodu override edilir
        public override string ToString()
        {
            return $"Id: {Id}. Melumatlar: {this.Melumat.ToString()} - {Status} - {Ixtisas}";
        }
    }

    //Coxlu telebelerle ish ucun olan metodlar ucun UniversistetSistemi classi yaradilir
    public class UniversistetSistemi
    {
        //Butun telebeleri cap etmek metodu yazilir
        public void ButunTelebelereBax(List<Telebe> telebe)
        {
            Console.Clear();
            Console.WriteLine("TELEBE SIYAHISI");
            //Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",-3}|{"Ad-soyad",-20}|{"Dogum tarixi",-13}|{"Telefon",-14}|{"Status",-8}|{"Ixtisas",-20}");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (var t in telebe)
            {
                Console.WriteLine($"{t.Id,-3}|{t.Melumat.Name + " " + t.Melumat.Surname,-20}|{t.Melumat.BirthDate.ToString("dd-MM-yyyy"),-13}|{t.Melumat.Phone,-14}|{t.Status,-8}|{t.Ixtisas,-20}");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

        }

        //Telebe axtarma metodu yazilir, burada telebe ID-ni daxil edene qeder onun adina, soyadina ve ixtisasina uygun axtarish etmek mumkundur
        public Telebe TelebeAxtar(List<Telebe> siyahi)
        {
            Telebe telebe = null;

            do
            {
                Console.WriteLine("Telebe ID-si, adini veya ixtisasini daxil edin:");
                string search = Console.ReadLine().ToLower();

                if (int.TryParse(search, out int id))
                {
                    telebe = siyahi.FirstOrDefault(x => x.Id == id);

                    if (telebe == null)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{id} ID-li telebe yoxdur!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    var capUcun = new List<Telebe>();
                    capUcun.Add(telebe);
                    Console.ForegroundColor = ConsoleColor.Green;
                    ButunTelebelereBax(capUcun);
                    Console.ForegroundColor = ConsoleColor.White;

                    return telebe;
                }

                var results = siyahi.Where(x => x.Melumat.Name.ToLower().Contains(search) || x.Melumat.Surname.ToLower().Contains(search) || x.Ixtisas.ToString().ToLower().Contains(search)).ToList();
                ButunTelebelereBax(results);
            }
            while (true);
        }

        //Telebe siyahsindan telebe secib onun qiymetlerine baxmaq ucun metod yazilir
        public void TelebeQiymetlerineBax(List<Telebe> siyahi)
        {
            var telebe = TelebeAxtar(siyahi);

            Console.WriteLine($"{"Fenn adi",-35}| {"Kredit sayi",-15}| {"Qiymet",-8}| {"Semestr",-12}");
            foreach (var qiymet in telebe.Qiymetler)
            {
                Console.WriteLine($"{qiymet.Fenn,-35}| {qiymet.KreditSayi,-15}| {qiymet.Qiymet,-8}| {qiymet.Semestr,-12}");
            }
            Console.WriteLine(new string('-', 72));
        }

        //Ortalama bali en yaxshi olan telebeni birbasha gosterir - Tuple istifadesi
        public ValueTuple<string, double, TelebeStatusu> GetEnYaxsiTelebe(List<Telebe> siyahi)
        {
            var list = siyahi.Where(a => a.Qiymetler.Any()).Select(x => new
            {
                Ad = x.Melumat.Name,
                Ortalama = x.Qiymetler.Average(z => z.Qiymet),
                Status = x.Status
            });

            var telebe = list.MaxBy(x => x.Ortalama);

            return (telebe.Ad, telebe.Ortalama, telebe.Status);
        }

        //2 secim uzre statistik melumatlari gosterir (ozu elave menyudur)
        public void Statistika(List<Telebe> siyahi)
        {
            //ALT konsol menyu cap edilir
            do
            {
                Console.WriteLine();
                Console.WriteLine("Baxmaq istediyiniz statistikani secin:");
                Console.WriteLine();
                Console.WriteLine("[1] - Bir telebenin statistikasi");
                Console.WriteLine("[2] - En yaxshi telebeni goster");
                Console.WriteLine("[0] - Cixmaq ucun 'Exit' yaz");

                int command = 0;

                //Emr qebul edilir ve yoxlanilir
                string input = Console.ReadLine();

                if (input == "Exit")
                {
                    Console.Clear();
                    return;
                }

                if (int.TryParse(input, out int result))
                {
                    command = result;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Emr reqem olmalidir!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //Emre uygun metodlar cagilir
                switch (command)
                {
                    case 1:
                        var telebe = TelebeAxtar(siyahi);
                        (int fenn, double orta, string ixtisas) stats = telebe.GetTelebeStatistikasi(telebe);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{telebe.Melumat.Name} adli telebenin ortalama qiymeti: {stats.orta}; fenn sayi: {stats.fenn}; ixtisasi: {stats.ixtisas}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        var bestTelebe = GetEnYaxsiTelebe(siyahi);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"En yaxshi telebemiz: {bestTelebe.Item1}, orta bali: {bestTelebe.Item2}, statusu: {bestTelebe.Item3}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 0:
                        Console.Clear();
                        return;
                }
            }
            while (true);
        }

        //Qiymet deyishme metodu yazilir
        public void QiymetDeyish(List<Telebe> siyahi, List<string> logList)
        {
            Console.WriteLine("Qiymetini deyishmek istediyiniz telebeni secin: ");
            var telebe = TelebeAxtar(siyahi);

            Console.WriteLine($"{"ID",-4}| {"Fenn adi",-35}| {"Kredit sayi",-15}| {"Qiymet",-8}| {"Semestr",-12}");
            for (int i = 0; i < telebe.Qiymetler.Count; i++)
            {
                Console.WriteLine($"{i,-4}| {telebe.Qiymetler[i].Fenn,-35}| {telebe.Qiymetler[i].KreditSayi,-15}| {telebe.Qiymetler[i].Qiymet,-8}| {telebe.Qiymetler[i].Semestr,-12}");
            }
            Console.WriteLine(new string('-', 72));

            Console.WriteLine();

            Console.WriteLine("Qiymetini deyishmek istediyin fennin Id-ni yaz (dayandirmaq ucun [-1] daxil et): ");
            int fennadi = 0;
            bool fennadiCheck = false;

            //Fenn secimi istenilir ve yoxlanilir
            do
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    fennadiCheck = false;

                    if (input == -1) return;

                    if (input < 0 || input > telebe.Qiymetler.Count)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Daxil etdiyin nomrede fenn yoxdur!");
                        Console.ForegroundColor = ConsoleColor.White;                        
                        fennadiCheck = true;
                        continue;
                    }

                    fennadi = input;
                } else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Yalnish secim daxil etdiniz!");
                    Console.ForegroundColor = ConsoleColor.White;
                    fennadiCheck = true;
                    continue;
                }
            } while (fennadiCheck);


            Console.WriteLine($"{telebe.Qiymetler[fennadi].Fenn} fenninin qiymetini deyishirsiniz. Evvelki qiymet - {telebe.Qiymetler[fennadi].Qiymet}");


            Console.Write("Yeni qiymet (dayandirmaq ucun [-1] daxil et): ");

            int kohneQiymet = telebe.Qiymetler[fennadi].Qiymet;
            int giymet = 0;
            bool qiymetCheck = true;

            //Yeni qiymet yoxlanilaraq qebul edilir
            do
            {
                if (int.TryParse(Console.ReadLine(), out int qiymetInput))
                {
                    if (qiymetInput == -1) return;

                    giymet = qiymetInput;
                    qiymetCheck = false;

                    if (qiymetInput < 0 || qiymetInput > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("* Diapazondan kenar qiymet daxil etdin!");
                        Console.ForegroundColor = ConsoleColor.White;
                        qiymetCheck = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* Qiymet eded olmalidir!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (qiymetCheck);

            //Qiymet obyekti struct oldugu ucun bu metodla deyishdirilir
            var temp = telebe.Qiymetler[fennadi];
            temp.Qiymet = giymet;
            telebe.Qiymetler[fennadi] = temp;

            //Log metni yaradilir ve cap edilir ve siyahiya artirilir
            string logText = $"[{DateTime.Now} - {telebe.Melumat.Name} adli telebenin {temp.Fenn} fenni qiymeti {kohneQiymet}-den {giymet}-e deyishdi.]";
            LogAndEvent logAndEvent = new LogAndEvent();
            logAndEvent.LogPrint(logText, logList);
        }
    }
}

