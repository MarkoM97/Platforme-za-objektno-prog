using POP_15_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016
{
    class Program
    {
        static List<Namestaj> namestaj { get; set; } = new List<Namestaj>();
        static void Main(string[] args)
        {

            Salon s = new Model.Salon()
            {
                Id = 1,
                naziv = "Forma FTNa",
                adresa = "Trg Dositeja OBradovica 6",
                brojZiroRacuna = "840-006848618-48",
                email = "salonFtn@gmail.com",
                maticniBroj = 486464648,
                PIB = 358483443,
                adresaSajta = "www.salonFtn.com",
                telefon = "021/448-551",

            };

            TipNamestaja sofa = new Model.TipNamestaja()
            {
                Id = 1,
                naziv = "DnevniBoravak"

            };


            namestaj.Add(new Namestaj()
        {
            Id = 1,
            jedinicnaCena = 28,
            naziv = "Sofa",
            kolicina = 5,
            akcija = null,
            sifra = "Sgasg",
            tipNamestaja = sofa
        });
            
            Console.WriteLine($"Dobrodosli u salon namestaja {s.naziv}");
            ispisiGlavniMeni();
            Console.ReadLine();


            
            
        }
        public static void ispisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===GLAVNI MENI===");
                Console.WriteLine("1 - Rad sa namestajem");
                Console.WriteLine("2 - Rad sa tipom namestaja");
                Console.WriteLine("0 - Izlaz iz aplikacije");
            } while (izbor < 0 || izbor > 2);

            izbor = int.Parse(Console.ReadLine());

            switch(izbor)
            {
                case 1:
                    ispisiNamestajMeni();
                    break;
                case 2:
                    ispisiTipMeni();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void ispisiTipMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===RAD SA NAMESTAJEM");
                Console.WriteLine("1 - ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

            } while (izbor < 0 || izbor > 4);
        }

        private static void ispisiNamestajMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===Namestaj===");
                Console.WriteLine("1 - Listing namestaja");
                Console.WriteLine("2 - Dodaj novi namestaj");
                Console.WriteLine("3 - Izmeni postojeci namestaj");
                Console.WriteLine("4 - Obrisi postojeci");
                Console.WriteLine("0 - Povraka na glavni meni");
            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    ispisiSavNamestaj();
                    break;
                case 2:
                    dodavanjeNemstaja();
                    break;
                case 3:
                    izmenaNemestaja();
                    break;
                case 4:
                    brisanjeNamestaja();
                    break;
                case 0:
                    ispisiGlavniMeni();
                    break;
                default:
                    break;


            }
        }

        private static void brisanjeNamestaja()
        {
            throw new NotImplementedException();
        }

        private static void izmenaNemestaja()
        {
            throw new NotImplementedException();
        }

        private static void dodavanjeNemstaja()
        {
            throw new NotImplementedException();
        }

        private static void ispisiSavNamestaj()
        {
            int index = 0;
            Console.WriteLine("=== Listing namestaja ===");
            foreach(var namestaj in namestaj)
            {
                Console.WriteLine($"{index++}.Naziv namestaja: {namestaj.naziv} Cena:{namestaj.jedinicnaCena} Tip namestaja: {namestaj.tipNamestaja.naziv}");

            }
            ispisiNamestajMeni();
        }
    }
}
