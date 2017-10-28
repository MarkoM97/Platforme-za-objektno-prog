using POP_15_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POP_15_2016
{
    class Program
    {

        public static Korisnik ulogovaniKorisnik = new Korisnik();
        public static List<Korisnik> korisnici { get; set; } = new List<Korisnik>();
        public static List<Namestaj> namestaj { get; set; } = new List<Namestaj>();
        public static List<TipNamestaja> tip{ get;set; } = new List<TipNamestaja>();
        public static List<DodatnaUsluga> usluge { get; set; } = new List<DodatnaUsluga>();
        public static List<Akcija> akcije { get; set; } = new List<Akcija>();
        public static List<TipKorisnika> tipovi { get; set; } = new List<TipKorisnika>();
        public static List<ProdajaNemestaja> prodati { get; set; } = new List<ProdajaNemestaja>();
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
            tip.Add(sofa);

            DodatnaUsluga usluga = new Model.DodatnaUsluga()
            {
                id = 1,
                naziv = "Montaza",
                cena = 250,
            };
            usluge.Add(usluga);

            TipKorisnika tipAdmin = new Model.TipKorisnika()
            {
                id = 1,
                naziv = "Administrator",
            };
            tipovi.Add(tipAdmin);

            TipKorisnika tipProdavac = new Model.TipKorisnika()
            {
                id = 2,
                naziv = "Prodavac",
            };
            tipovi.Add(tipProdavac);

            Akcija akcija = new Model.Akcija()
            {
                id = 1,
                naziv = "Prolecna",
                pocetakAkcije = DateTime.Parse("10/27/2017"),
                trajanjeAkcije = 15,
                popust = 5.20,
                zavrsetakAkcije = DateTime.Now.AddDays(5),
                



            };
            akcije.Add(akcija);

            Korisnik korisnik = new Model.Korisnik()
            {
                id = 1,
                ime = "Mitar",
                prezime = "Mitrovic",
                korisnickoime = "Mita",
                lozinka = "123",
                tipKorisnika = tipAdmin,

            };
            korisnici.Add(korisnik);

            Korisnik korisnik2 = new Model.Korisnik()
            {
                id = 2,
                ime = "Mitar",
                prezime = "Mitrovic",
                korisnickoime = "Marko",
                lozinka = "123",
                tipKorisnika = tipProdavac,

            };
            korisnici.Add(korisnik2);


            namestaj.Add(new Namestaj()
        {
            Id = 1,
            jedinicnaCena = 28,
            naziv = "RazvlacivaSofa",
            kolicina = 5,
            akcija = null,
            sifra = "Sgasg",
            tipNamestaja = sofa
        });
            
            Console.WriteLine($"Dobrodosli u salon namestaja {s.naziv}");
            //ispisiGlavniMeni();
            ispisiLogin();
            Console.ReadLine();

        
            
            
        }

        public static void ispisiLogin()
        {
            bool proso = false;
            Console.WriteLine("Ulogujte se za dalje koriscenje aplikacije" );
            do
            {
                Console.WriteLine("Unesite svoje korisnicko ime: ");
                string ime = Console.ReadLine();
                Console.WriteLine("Unesite svoju lozinku: ");
                string lozinka = Console.ReadLine();
                foreach (Korisnik korisnik in korisnici)
                {
                    if (korisnik.korisnickoime.Equals(ime) && korisnik.lozinka.Equals(lozinka))
                    {
                        proso = true;

                        if (korisnik.tipKorisnika.naziv.Equals("Administrator"))
                        {
                            
                            ispisiGlavniMeni();
                        } else
                        {
                            ulogovaniKorisnik = korisnik;
                            ispisiMeniProdavac();
                        }
                    }
                }
                Console.WriteLine("Nisu dobri login podaci, pokusajte ponovo.");
            } while (proso == false);
        }

        public static void ispisiProdaje()
        {
            string content = "";
            foreach (ProdajaNemestaja prodaja in prodati) 
            {
                foreach(DodatnaUsluga usluga in prodaja.DodatneUsluge)
                {
                    content += usluga.naziv + ",";
                }
                Console.WriteLine($" Broj racuna : {prodaja.Id }|Prodavac {prodaja.prodavac.ime} |Namestaj {prodaja.prodatiNamestaj.naziv} |Komada {prodaja.BrojKomadaNamestaja} |Dodatne usluge prodaje {content} |Kupac : {prodaja.imeKupca + prodaja.prezimeKupca} |Ukupna cena : {prodaja.UkupnaCena} ");
            }
        }

        public static void ispisiMeniProdavac() 
        {
            int izbor = 0;
            Console.WriteLine("===DOBRODOSLI===");
            do
            {
                Console.WriteLine("1 - Za pregled lagera");
                Console.WriteLine("2 - Evindentiraj prodaju");
                Console.WriteLine("0 - Izlaz iz aplikacije");
            } while (izbor < 0 || izbor > 2);

            izbor = int.Parse(Console.ReadLine());

            switch(izbor)
            {
                case 1:
                    ispisiNamestajNaLageru();
                    break;
                case 2:
                    konstruisiRacun();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        public static void ispisiNamestajNaLageru()
        {
            foreach(Namestaj namestaj in namestaj)
            {
                Console.WriteLine($"Identifikacioni broj namestaja: [{namestaj.Id}] | Naziv namestaja : {namestaj.naziv} | Na lageru dostupno: {namestaj.kolicina} | Na akciji : {namestaj.akcija}");
            }
            ispisiMeniProdavac();
        }



        public static int brojKomadaNaLageru(Namestaj n)
        {
            bool proso = false;
            int brojRaspolozivih = n.kolicina;
            do
            {
                Console.WriteLine("Odaberiti broj komada namestaja: ");
                int izbor = int.Parse(Console.ReadLine());
                if(izbor <= brojRaspolozivih)
                {
                    proso = true;
                    n.kolicina -= izbor;
                    return izbor;
                } else if(izbor > brojRaspolozivih)
                {
                    Console.WriteLine("Nedostupna kolicina na lageru. Izaberite ponovo: ");
                }
            } while (proso == false);

            return 0;
        }

        public static double izracunajUkupnuCenu(int brojProdatih, List<DodatnaUsluga> usluge, Namestaj namestaj)
        {
            double cenaNamestaja = namestaj.jedinicnaCena;
            int brojProdatihNamestaja = brojProdatih;
            double procenatSnizenja = 0;
            double cenaUsluga = 0;
            if(usluge != null)
            {
                foreach(DodatnaUsluga usluga in usluge)
                {
                    cenaUsluga += usluga.cena;
                }
            }
            if (namestaj.akcija != null)
            {
                double popust = namestaj.akcija.popust;
                procenatSnizenja = ((popust / 100) * cenaNamestaja);

            }
            Console.WriteLine(procenatSnizenja);
            Console.WriteLine(cenaUsluga);
            double ukupnaCena = (((cenaNamestaja - procenatSnizenja) * brojProdatihNamestaja) + cenaUsluga) + 2.52;
            return ukupnaCena;

        }

        public static void konstruisiRacun()
        {
            List<DodatnaUsluga> uslugeProdaja = new List<DodatnaUsluga>();
            Namestaj namestaj = autentifikacijaNamestaja();
            int brojProdatihKomada = brojKomadaNaLageru(namestaj);
            DodatnaUsluga usluga = new DodatnaUsluga();
            bool proso = false;
            int indeks = 0;
            do
            {
                indeks++;
                string izbor = "";
                if (indeks == 1)
                {
                    Console.WriteLine("Da li kupac zeli neku od dodatnih usluga? [Y/N]: ");
                }else
                {
                    Console.WriteLine("Da li kupac zeli jos neku od dodatnih usluga [Y/N]: ");
                }
                izbor = Console.ReadLine();
                if (izbor.Equals("y") || izbor.Equals("Y"))
                {
                    proso = false;
                    usluga = autentifikacijaUsluge();
                    uslugeProdaja.Add(usluga);
                }
                else if (izbor.Equals("n") || izbor.Equals("N"))
                {
                    proso = true;
                    usluga = null;
                }
            } while (proso == false);
            Console.WriteLine("Unesite ime kupca: ");
            string imeK = Console.ReadLine();
            Console.WriteLine("Unesite prezime kupca: ");
            string prezimeK = Console.ReadLine();
            double ukupnaCena = izracunajUkupnuCenu(brojProdatihKomada, uslugeProdaja, namestaj);
            prodati.Add(new ProdajaNemestaja()
            {
                Id = prodati.Count + 1,
                prodavac = ulogovaniKorisnik,
                prodatiNamestaj = namestaj,
                BrojKomadaNamestaja = brojProdatihKomada,
                DatumProdaje = DateTime.Now,
                DodatneUsluge = uslugeProdaja,
                imeKupca = imeK,
                prezimeKupca = prezimeK,
                UkupnaCena = ukupnaCena,
            });
            Console.WriteLine("---PRODAJA USPESNO EVIDENTIRANA---");
            ispisiProdaje();
            ispisiMeniProdavac();
        }

        public static void ispisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===GLAVNI MENI===");
                Console.WriteLine("1 - Rad sa namestajem");
                Console.WriteLine("2 - Rad sa tipom namestaja");
                Console.WriteLine("3 - Rad sa akcijama");
                Console.WriteLine("4 - Rad sa dodatnim uslugama salona");
                Console.WriteLine("0 - Izlaz iz aplikacije");
            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());

            switch(izbor)
            {
                case 1:
                    ispisiNamestajMeni();
                    break;
                case 2:
                    ispisiTipNamestajaMeni();
                    break;
                case 3:
                    ispisiAkcijeMeni();
                    break;
                case 4:
                    ispisiDodatneUslugeMeni();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void ispisiDodatneUslugeMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===RAD SA USLUGAMA===");
                Console.WriteLine("1 - Listing svih usluga");
                Console.WriteLine("2 - Dodaj novu uslugu");
                Console.WriteLine("3 - Izmeni postojecu uslugu");
                Console.WriteLine("4 - Obrisi uslugu");
                Console.WriteLine("0 - Povratak na glavni meni");

            } while (izbor < 0 || izbor > 4);
            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    ispisiSveUsluge();
                    break;
                case 2:
                    dodajUslugu();
                    break;
                case 3:
                    izmeniPostojecuUslugu();
                    break;
                case 4:
                    obrisiUslugu();
                    break;
                case 0:
                    ispisiGlavniMeni();
                    break;
                default:
                    break;
            }
        }

        private static void obrisiUslugu()
        {
            bool proso = false;
            DodatnaUsluga du = autentifikacijaUsluge();
            do
            {
                Console.WriteLine("Da li ste sigurni da zelite da obrisete ovu uslugu? [Y/N]:");
                string izbor = Console.ReadLine();
                if (izbor.Equals("y") || izbor.Equals("Y"))
                {
                    du.obrisan = true;
                    proso = true;
                    Console.WriteLine("---Usluga uspesno obrisana---");
                    ispisiDodatneUslugeMeni();
                } else if(izbor.Equals("N") || izbor.Equals("n"))
                {
                    proso = true;
                    Console.WriteLine("---Brisanje otkazano!---");
                    ispisiDodatneUslugeMeni();
                }
            } while (proso == false);
            ispisiDodatneUslugeMeni();



        }

        private static void ispisiSveUsluge()
        {
            int index = 0;
            Console.WriteLine("===LISTING USLUGA===");
            foreach (var usluga in usluge)
            {
                Console.WriteLine($" {index++}. Naziv usluge: {usluga.naziv}");
            }
            ispisiDodatneUslugeMeni();
        }

        private static void dodajUslugu()
        {
            Console.WriteLine("===DODAVANJE USLUGA===");
            Console.WriteLine("Unesite naziv nove usluge: ");
            string naziv = Console.ReadLine();
            Console.WriteLine("Unesite cenu usluge");
            double cena = double.Parse(Console.ReadLine());
            usluge.Add(new DodatnaUsluga()
            {
                id = usluge.Count() + 1,
                naziv = naziv,
                cena = cena,

            });
            ispisiDodatneUslugeMeni();

        }

        private static DodatnaUsluga autentifikacijaUsluge()
        {
            bool proso = false;
            do
            {
                Console.WriteLine("Unesite naziv zeljene usluge za izmenu/brisanje: ");
                string nazivUsluge = Console.ReadLine();
                foreach(var usluga in usluge)
                {
                    if(usluga.naziv.Equals(nazivUsluge))
                    {
                        proso = true;
                        return usluga;
                    }
                }
                Console.WriteLine("Ne postojeca usluga. Pokusajte ponovo: ");
            } while (proso == false);
            return null;
        }

        private static void izmeniPostojecuUslugu()
        {
            int izbor = 0;
            DodatnaUsluga du = autentifikacijaUsluge();
            do
            {
                Console.WriteLine("Koji deo usluge menjate?");
                Console.WriteLine("1 - Naziv");
                Console.WriteLine("2 - Cena");
                Console.WriteLine("0 - Povratak na meni");
            } while (izbor < 0 || izbor > 2);
            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Ukucajte zeljeni naziv: ");
                    du.naziv = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Unesite zeljenu cenu: ");
                    du.cena = double.Parse(Console.ReadLine());
                    break;
                case 0:
                    ispisiDodatneUslugeMeni();
                    break;
                default:
                    break;
            }
            ispisiDodatneUslugeMeni();

        }

        private static void ispisiAkcijeMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===RAD SA AKCIJAMA===");
                Console.WriteLine("1 - Listing svih akcija");
                Console.WriteLine("2 - Dodaj novu akciju");
                Console.WriteLine("3 - Izmeni postojecu akciju");
                Console.WriteLine("4 - Obrisi akciju");
                Console.WriteLine("0 - Povratak na glavni meni");

            } while (izbor < 0 || izbor > 4);
            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    ispisiSveAkcije();
                    break;
                case 2:
                    dodajAkciju();
                    break;
                case 3:
                    izmeniPostojecuAkciju();
                    break;
                case 4:
                    obrisiAkciju();
                    break;
                case 0:
                    ispisiGlavniMeni();
                    break;
                default:
                    break;
            }
        }

        private static void obrisiAkciju()
        {
            bool proso = false;
            Akcija du = autentifikacijaAkcije();
            do
            {
                Console.WriteLine("Da li ste sigurni da zelite da obrisete ovu akciju? [Y/N]:");
                string izbor = Console.ReadLine();
                if (izbor.Equals("y") || izbor.Equals("Y"))
                {
                    du.obrisan = true;
                    proso = true;
                    Console.WriteLine("---Akcija uspesno obrisana---");
                    ispisiAkcijeMeni();
                }
                else if (izbor.Equals("N") || izbor.Equals("n"))
                {
                    proso = true;
                    Console.WriteLine("---Brisanje otkazano!---");
                    ispisiAkcijeMeni();
                }
            } while (proso == false);
            ispisiAkcijeMeni();
        }

        private static void izmeniPostojecuAkciju()
        {
            int izbor = 0;
            Akcija du = autentifikacijaAkcije();
            do
            {
                Console.WriteLine("Koji deo akcije menjate?");
                Console.WriteLine("1 - Naziv");
                Console.WriteLine("2 - Popust");
                Console.WriteLine("3 - Pocetak akcije");
                Console.WriteLine("4 - Trajanje akcije");
                Console.WriteLine("0 - Povratak na meni");
            } while (izbor < 0 || izbor > 2);
            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Ukucajte zeljeni naziv: ");
                    du.naziv = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Unesite zeljenu cenu: ");
                    du.popust = double.Parse(Console.ReadLine());
                    break;
                case 3:
                    DateTime pocetak = proveraValidnostiDatuma();
                    du.pocetakAkcije = pocetak;
                    break;
                case 4:
                    Console.WriteLine("Unesite zeljeni broj dana trajanja akcije: ");
                    du.trajanjeAkcije = int.Parse(Console.ReadLine());
                    du.zavrsetakAkcije = du.pocetakAkcije.AddDays(du.trajanjeAkcije);
                    break;
                case 0:
                    ispisiDodatneUslugeMeni();
                    break;
                default:
                    break;
            }
            ispisiAkcijeMeni();
        }

        private static Akcija autentifikacijaAkcije()
        {
            bool proso = false;
            do
            {
                Console.WriteLine("Unesite naziv zeljene akcije za izmenu/brisanje: ");
                string nazivAkcije = Console.ReadLine();
                foreach (var akcija in akcije)
                {
                    if (akcija.naziv.Equals(nazivAkcije))
                    {
                        proso = true;
                        return akcija;
                    }
                }
                Console.WriteLine("Ne postojeca akcija. Pokusajte ponovo: ");
            } while (proso == false);
            return null;
        }

        private static DateTime proveraValidnostiDatuma()
        {
            bool proso = false;
            Console.WriteLine("Unesite pocetak akcije u formatu [MM/DD/YYYY]: ");
            do
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime izparsiran))
                {
                    proso = true;
                    return izparsiran;
                }
                Console.WriteLine("Nije dobar format datuma.Pokusajte ponovo:");
            } while (proso == false);
            return DateTime.Now;
        }

        private static void dodajAkciju()
        {
            Console.WriteLine("===DODAVANJE AKCIJA===");
            DateTime pocetak = proveraValidnostiDatuma();
            Console.WriteLine("Unesite naziv nove akcije: ");
            string naziv = Console.ReadLine();
            Console.WriteLine("Unesite akcijski popust: ");
            double popust = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite trajanje akcije u danima: ");
            int trajanje = int.Parse(Console.ReadLine());
            akcije.Add(new Akcija()
            {
                id = akcije.Count() + 1,
                naziv = naziv,
                pocetakAkcije = pocetak,
                popust = popust,
                trajanjeAkcije = trajanje,
                zavrsetakAkcije = pocetak.AddDays(trajanje),



            });
            ispisiAkcijeMeni();
        }

        private static void ispisiSveAkcije()
        {
            int index = 0;
            Console.WriteLine("===LISTING AKCIJA===");
            foreach (var akcija in akcije)
            {
                Console.WriteLine($" {index++}. Naziv usluge: {akcija.naziv} Pocetak : {akcija.pocetakAkcije} Zavrsetak akcije: {akcija.zavrsetakAkcije} Obrisana akcija {akcija.obrisan}");
            }
            ispisiAkcijeMeni();
        }

        private static void ispisiTipNamestajaMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===RAD SA TIPOM NAMESTAJA===");
                Console.WriteLine("1 - Listing svih tipova");
                Console.WriteLine("2 - Dodaj novi tip");
                Console.WriteLine("3 - Izmeni postojeci tip");
                Console.WriteLine("4 - Obrisi postojeci tip");
                Console.WriteLine("0 - Povratak na glavni meni");

            } while (izbor < 0 || izbor > 4);
            izbor = int.Parse(Console.ReadLine());

            switch(izbor)
            {
                case 1:
                    ispisiSveTipove();
                    break;
                case 2:
                    dodajTip();
                    break;
                case 3:
                    izmeniPostojeciTip();
                    break;
                case 4:
                    obrisiTip();
                    break;
                case 0:
                    ispisiGlavniMeni();
                    break;
                default:
                    break;
            }
        }

        private static void dodajTip()
        {
            Console.WriteLine("===DODAVANJE TIPA NAMESTAJA===");
            Console.WriteLine("Unesite naziv tipa: ");
            string nazivTipa = Console.ReadLine();
            tip.Add(new TipNamestaja()
            {
                Id = tip.Count() + 1,
                naziv = nazivTipa,

            });
            Console.WriteLine("---TIP USPESNO DODAT!---");
            ispisiTipNamestajaMeni();
        }

        private static void obrisiTip()
        {
            bool proso = false;
            TipNamestaja t = autentifikacijaTipa();
            do
            {
                Console.WriteLine("Da li ste sigurni da zelite da obrisete ovaj tip? [Y/N]");
                string izbor = Console.ReadLine();
                if(izbor == "y" || izbor == "Y")
                {
                    t.Obrisan = true;
                    proso = true;
                    Console.WriteLine("TIP USPESNO OBRISAN!");
                    ispisiTipNamestajaMeni();
                }
                else if(izbor == "N" || izbor == "n")
                {
                    proso = true;
                    Console.WriteLine("BRISANJE TIPA OTKAZANO!");
                    ispisiTipNamestajaMeni();
                }
            } while (proso == false);
        }

        private static TipNamestaja autentifikacijaTipa()
        {
            bool proso = false;
            do
            {
                Console.WriteLine("Unesite tip namestaja zeljen za izmenu/brisanje: ");
                string zeljeniTip = Console.ReadLine();
                foreach(var tipNamestaja in tip)
                {
                    if (tipNamestaja.naziv.Equals(zeljeniTip))
                    {
                        proso = true;
                        return tipNamestaja;
                    }
                }
                Console.WriteLine("Nije poznat tip namestaja. Pokusajte ponovo: ");
            } while (proso == false);
            return null;
        }

        private static void izmeniPostojeciTip()
        {
            TipNamestaja t = autentifikacijaTipa();
            Console.WriteLine("Ukucajte novi naziv tipa namestaja: ");
            string noviNaziv = Console.ReadLine();
            t.naziv = noviNaziv;
            Console.WriteLine("IZMENA USPESNO OBAVLJENA");
            ispisiTipNamestajaMeni();
        }

        private static void ispisiSveTipove()
        {
            int index = 0;
            Console.WriteLine("===LISTING TIPOVA NAMESTAJA===");
            foreach (var tipNamestaja in tip)
            {
                Console.WriteLine($"{index++}. Id tipa: {tipNamestaja.Id}Naziv namestaja: {tipNamestaja.naziv} Obrisan : {tipNamestaja.Obrisan}");

            }
            ispisiTipNamestajaMeni();
        }

        private static void ispisiNamestajMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("===NAMESTAJ===");
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
                    dodavanjeNamestaja();
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
            bool proso = false;
            Namestaj n = autentifikacijaNamestaja();
            do
            {
                Console.WriteLine("Da li ste sigurni da zelite da obrisete namestaj? [Y/N]:");
                string izbor = Console.ReadLine();
                if (izbor.Equals("Y") || izbor.Equals("y"))
                {
                    n.obrisan = true;
                    proso = true;
                    Console.WriteLine("NAMESTAJ USPESNO OBRISAN!");
                    ispisiNamestajMeni();
                }
                else if(izbor.Equals("N") || izbor.Equals("n"))
                {
                    proso = true;
                    Console.WriteLine("BRISANJE NAMESTAJA OTKAZANO!");
                    ispisiNamestajMeni();
                }
            } while (proso == false);
            
        }

        private static Namestaj autentifikacijaNamestaja()
        {
            bool proso = false;
            do
            {
                Console.WriteLine("Naziv namestaja zeljenog za izmenu/brisanje: ");
                string ukucaniNaziv = Console.ReadLine();
                foreach(var n in namestaj)
                {
                    if (n.naziv.Equals(ukucaniNaziv))
                    {
                        proso = true;
                        return n;
                    }
                }
            } while (proso == false);
            return null;
        }

        private static void izmenaNemestaja()
        {
            int izbor = 0;
            Namestaj n = autentifikacijaNamestaja();
            do
            {
                Console.WriteLine("===IZMENA NAMESTAJA===");
                Console.WriteLine("Koji deo namestaja menjate?");
                Console.WriteLine("1 - Naziv");
                Console.WriteLine("2 - Cena");
                Console.WriteLine("3 - Kolicina");
                Console.WriteLine("4 - Sifra");
                Console.WriteLine("5 - Tip namestaja");
            } while (izbor < 0 || izbor > 5);
            izbor = int.Parse(Console.ReadLine());

            switch(izbor)
            {
                case 1:
                    Console.WriteLine("Ukucajte zeljeni naziv: ");
                    n.naziv = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ukucajte zeljenu cenu: ");
                    n.jedinicnaCena = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Unesite zeljenu kolicinu za namestaj: ");
                    n.kolicina = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Unesite novu sifru namestaja: ");
                    n.sifra = Console.ReadLine();
                    break;
                case 5:
                    n.tipNamestaja = dodelaTipaNamestaja();
                    break;
                default:
                    break;

            }
            ispisiNamestajMeni();


        }



        private static TipNamestaja dodelaTipaNamestaja()
        {
            bool proso = false;
            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                string temp = Console.ReadLine();
                foreach (var tipN in tip)
                {
                    if (temp.Equals(tipN.naziv))
                    {
                        proso = true;
                        return tipN;
                    }else
                    {
                        Console.WriteLine("Nije poznat tip namestaja.Pokusajte ponovo:");
                    }
                }
            } while (proso == false);
            return null;
        }
        private static void dodavanjeNamestaja()
        {
            Console.WriteLine("===DODAVANJE NAMESTAJA===");
            Console.WriteLine("Unesite naziv namestaja: ");
            string nazivNamestaja = Console.ReadLine();
            Console.WriteLine("Unesite kolicinu namestaja: ");
            int kolicinaNamestaja = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite cenu namestaja: ");
            double cenaNamestaja = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite sifru namestaja: ");
            string sifraNamestaja = Console.ReadLine();
            TipNamestaja tipNamestajaSadasnji = dodelaTipaNamestaja();
            namestaj.Add(new Namestaj()
            {
                Id = namestaj.Count() + 1,
                naziv = nazivNamestaja,
                kolicina = kolicinaNamestaja,
                jedinicnaCena = cenaNamestaja,
                sifra = sifraNamestaja,
                tipNamestaja = tipNamestajaSadasnji,

            });
            Console.WriteLine("---NAMESTAJ USPESNO DODAT!---");
            ispisiNamestajMeni();

        }

        private static void ispisiSavNamestaj()
        {
            int index = 0;
            Console.WriteLine("===Listing namestaja===");
            foreach(var namestaj in namestaj)
            {
                Console.WriteLine($"{index++}. Id namestaja: {namestaj.Id}Naziv namestaja: {namestaj.naziv} Cena:{namestaj.jedinicnaCena} Tip namestaja: {namestaj.tipNamestaja.naziv} Obrisan : {namestaj.obrisan}");

            }
            ispisiNamestajMeni();
        }
    }
}
