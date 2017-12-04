using POP_15_2016_GUI.Model;
using POP_SF_15_2016_GUI.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;



namespace POP_SF_15_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
        ObservableCollection<Namestaj> pNamestaj = new ObservableCollection<Namestaj>();

        List<Korisnik> postojeciKorisnik = Projekat.instanca.Korisnik;
        ObservableCollection<Korisnik> pKorisnik = new ObservableCollection<Korisnik>(Projekat.instanca.Korisnik);

        ObservableCollection<Racun> pRacun = new ObservableCollection<Racun>(Projekat.instanca.Racun);
        List<Racun> postojeciRacun = Projekat.instanca.Racun;
        

        List<DodatnaUsluga> postojaceUsluge = Projekat.instanca.DodatnaUsluga;
        ObservableCollection<DodatnaUsluga> pDodatna = new ObservableCollection<DodatnaUsluga>(Projekat.instanca.DodatnaUsluga);

        List<Akcija> postojecaAkcija = Projekat.instanca.Akcija;
        ObservableCollection<Akcija> pAkcija = new ObservableCollection<Akcija>(Projekat.instanca.Akcija);

        List<TipNamestaja> postojeciTipovi = Projekat.instanca.TipNamestaja;
        ObservableCollection<TipNamestaja> pTipNamestaja = new ObservableCollection<TipNamestaja>(Projekat.instanca.TipNamestaja);

        //Akcija tempAkcija = new Akcija();
        //TipNamestaja tempTip = new TipNamestaja();
        public MainWindow()
        {
            foreach (var thing in pRacun)
            {
                foreach (var thingy in thing.DodatneUsluge)
                {
                    Console.WriteLine(thingy.Naziv);
                }
            }
            //Za korigovanje .. ispis usluga radi samo zato sto se u ovom pozivu pozove metoda 'Dodatne Usluge', Prepraviti


            InitializeComponent();
            lvUsluge.ItemsSource = pDodatna;
            foreach (var x in postojeciNamestaj)
            {
                if (x.TipNamestaja.Obrisan == false)
                {
                    pNamestaj.Add(x);
                }

                if(x.Akcija.Obrisan == true)
                {
                    x.Akcija = null;
                }
            }
            lvNamestaj.ItemsSource = pNamestaj;
            lvAkcije.ItemsSource = pAkcija;
            lvKorisnici.ItemsSource = pKorisnik;
            lvTipovi.ItemsSource = pTipNamestaja;
            lvRacuni.ItemsSource = pRacun;
            
            
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Id = Projekat.instanca.Namestaj.Count + 1,
                Naziv = "",
                akcijaId = 0,
                Kolicina = 0,
                JedinicnaCena = 0,
                Sifra = "",
                tipNamestajaId = 0
                
            };
            var NamestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            NamestajProzor.Show();
            this.Close();
        }

        private void DodajTip(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Id = Projekat.instanca.TipNamestaja.Count + 1,
                Naziv = ""

            };
            var TipoviProzor = new TipoviWindow(noviTip, TipoviWindow.Operacija.DODAVANJE);
            TipoviProzor.Show();
            this.Close();
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija()
            {
                Id = Projekat.instanca.Akcija.Count + 1,
                Naziv = "",
                PocetakAkcije = DateTime.Now,
                TrajanjeAkcije = 0,
                ZavrsetakAkcije = DateTime.Now,
                Popust = 0,

            };
            var AkcijaProzor = new AkcijeWindow(novaAkcija, AkcijeWindow.Operacija.DODAVANJE);
            AkcijaProzor.Show();
            this.Close();
        }

        private void DodajKorisnika(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
                Id = Projekat.instanca.Korisnik.Count + 1,
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = ""

            };
            var KorisnikProzor = new KorisniciWindow(noviKorisnik, KorisniciWindow.Operacija.DODAVANJE);
            KorisnikProzor.Show();
            this.Close();
        }

        private void DodajRacun(object sender, RoutedEventArgs e)
        {
            var noviRacun = new Racun()
            {
                Id = Projekat.instanca.Racun.Count + 1,
                prodavacId = 0,
                namestajId = 0,
                BrojKomada = 0,
                DatumProdaje = DateTime.Now,
                DodatneUsluge = new List<DodatnaUsluga>(),
                ImeKupca = "",
                UkupnaCena = 0

            };
            var RacunProzor = new RacuniWindow(noviRacun, RacuniWindow.Operacija.DODAVANJE);
            RacunProzor.Show();
            this.Close();
        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Id = Projekat.instanca.DodatnaUsluga.Count + 1,
                Naziv = "",
                Cena = 0,

            };
            var UslugaProzor = new UslugeWindow(novaUsluga, UslugeWindow.Operacija.DODAVANJE);
            UslugaProzor.Show();
            this.Close();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = (Namestaj)lvNamestaj.SelectedItem;

            
            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
            this.Close();
        }

        private void IzmeniTip(object sender, RoutedEventArgs e)
        {
            TipNamestaja selektovanTip= (TipNamestaja)lvTipovi.SelectedItem;


            var tipoviProzor = new TipoviWindow(selektovanTip, TipoviWindow.Operacija.IZMENA);
            tipoviProzor.Show();
            this.Close();
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            Akcija selektovanaAkcija= (Akcija)lvAkcije.SelectedItem;


            var akcijeProzor = new AkcijeWindow(selektovanaAkcija, AkcijeWindow.Operacija.IZMENA);
            akcijeProzor.Show();
            this.Close();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = (Korisnik)lvKorisnici.SelectedItem;


            var korisnikProzor = new KorisniciWindow(selektovaniKorisnik, KorisniciWindow.Operacija.IZMENA);
            korisnikProzor.Show();
            this.Close();
        }

        private void IzmeniRacun(object sender, RoutedEventArgs e)
        {
            Racun selektovaniRacun = (Racun)lvRacuni.SelectedItem;


            var racunProzor = new RacuniWindow(selektovaniRacun, RacuniWindow.Operacija.IZMENA);
            racunProzor.Show();
            this.Close();
        }

        private void IzmeniUslugu(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = (DodatnaUsluga)lvUsluge.SelectedItem;


            var uslugeProzor = new UslugeWindow(selektovanaUsluga, UslugeWindow.Operacija.IZMENA);
            uslugeProzor.Show();
            this.Close();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)

        {
           var izabraniNamestaj = (Namestaj)lvNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabraniNamestaj.Obrisan = true;
                foreach(var thing in postojeciNamestaj)
                {
                    if(izabraniNamestaj.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.Namestaj = postojeciNamestaj;


            }
        }

        private void IzbrisiTip(object sender, RoutedEventArgs e)

        {
            var izabraniTip = (TipNamestaja)lvTipovi.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabraniTip.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabraniTip.Obrisan = true;
                foreach (var thing in postojeciTipovi)
                {
                    if (izabraniTip.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.TipNamestaja = postojeciTipovi;

            }
        }

        private void IzbrisiAkciju(object sender, RoutedEventArgs e)

        {
            var izabranaAkcija = (Akcija)lvAkcije.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabranaAkcija.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabranaAkcija.Obrisan = true;
                foreach (var thing in postojecaAkcija)
                {
                    if (izabranaAkcija.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.Akcija = postojecaAkcija;

            }
        }

        private void IzbrisiKorisnika(object sender, RoutedEventArgs e)

        {
            var izabraniKorisnik = (Korisnik)lvKorisnici.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabraniKorisnik.Ime}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabraniKorisnik.Obrisan = true;
                foreach (var thing in postojeciKorisnik)
                {
                    if (izabraniKorisnik.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.Korisnik = postojeciKorisnik;

            }
        }

        private void IzbrisiRacun(object sender, RoutedEventArgs e)

        {
            var izabraniRacun = (Racun)lvRacuni.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete ovaj racun iz sistema?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabraniRacun.Obrisan = true;
                foreach (var thing in postojeciRacun)
                {
                    if (izabraniRacun.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.Racun= postojeciRacun;

            }
        }

        private void IzbrisiUslugu(object sender, RoutedEventArgs e)

        {
            var izabranaUsluga = (DodatnaUsluga)lvUsluge.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabranaUsluga.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabranaUsluga.Obrisan = true;
                foreach (var thing in postojaceUsluge)
                {
                    if (izabranaUsluga.Id.Equals(thing.Id))
                    {
                        thing.Obrisan = true;
                    }
                }

                Projekat.instanca.DodatnaUsluga = postojaceUsluge;

            }
        }
    }
}
