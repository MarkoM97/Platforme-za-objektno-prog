using POP_SF_15_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace POP_SF_15_2016.UI
{
    /// <summary>
    /// Interaction logic for RacunIzmenaProzor.xaml
    /// </summary>
    public partial class RacunIzmenaProzor : Window
    {
        Racun racun;
        public enum Stanje { DODAVANJE, IZMENA }
        public enum Pristup { ADMINISTRATOR, PRODAVAC }
        Stanje stanje;
        ICollectionView viewNamestaj;
        ICollectionView viewDodatne;
        ObservableCollection<DodatnaUsluga> dodateUsluge = new ObservableCollection<DodatnaUsluga>();
        ObservableCollection<Stavka> dodateStavke = new ObservableCollection<Stavka>();
        ICollectionView viewNamestajDodati;
        ICollectionView viewDodatneDodate;
        //ObservableCollection<DodatnaUsluga> naruceneUsluge = new ObservableCollection<DodatnaUsluga>();
        //ObservableCollection<Tuple<Namestaj, int>> naruceniNamestaj = new ObservableCollection<Tuple<Namestaj, int>>();
        public RacunIzmenaProzor(Racun racun, Stanje stanje = Stanje.DODAVANJE, Pristup pristup = Pristup.ADMINISTRATOR)
        {
            InitializeComponent();

            this.racun = racun;
            this.stanje = stanje;

            cbProdavac.ItemsSource = Aplikacija.filtriraniKorisnici();
            cbProdavac.DataContext = racun;

            tbUkupna.DataContext = racun;
            dpDatumProdaje.DataContext = racun;

            tbKupac.DataContext = racun;

            viewNamestaj = CollectionViewSource.GetDefaultView(Aplikacija.filtriranNamestaj());
            dgPostojaciNamestaj.ItemsSource = viewNamestaj;
            dgPostojaciNamestaj.IsSynchronizedWithCurrentItem = true;
            dgPostojaciNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewDodatne = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Usluge);
            dgPostojaceDodatne.ItemsSource = viewDodatne;
            dgPostojaceDodatne.IsSynchronizedWithCurrentItem = true;
            dgPostojaceDodatne.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewNamestajDodati = CollectionViewSource.GetDefaultView(dodateStavke);
            dgNaruceniNamestaj.ItemsSource = viewNamestajDodati;
            dgNaruceniNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNaruceniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            viewDodatneDodate = CollectionViewSource.GetDefaultView(dodateUsluge);
            dgNaruceneDodatne.ItemsSource = viewDodatneDodate;
            dgNaruceneDodatne.IsSynchronizedWithCurrentItem = true;
            dgNaruceneDodatne.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (stanje == Stanje.IZMENA)
            {

                viewNamestajDodati = CollectionViewSource.GetDefaultView(racun.Stavke);
                dgNaruceniNamestaj.ItemsSource = viewNamestajDodati;
                dgNaruceniNamestaj.IsSynchronizedWithCurrentItem = true;
                dgNaruceniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


                viewDodatneDodate = CollectionViewSource.GetDefaultView(racun.Usluge);
                dgNaruceneDodatne.ItemsSource = viewDodatneDodate;
                dgNaruceneDodatne.IsSynchronizedWithCurrentItem = true;
                dgNaruceneDodatne.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


                tbUkupna.DataContext = racun;
                cbProdavac.IsEnabled = false;
                tbKupac.IsEnabled = false;
                dpDatumProdaje.IsEnabled = false;
                cbKolicina.Visibility = Visibility.Hidden;
                lbKolicina.Visibility = Visibility.Hidden;
                btnDodajNamestaj.Visibility = Visibility.Hidden;
                btnIzbaciNamestaj.Visibility = Visibility.Hidden;
                btnDodajUslugu.Visibility = Visibility.Hidden;
                btnIzbaciUslugu.Visibility = Visibility.Hidden;
                btnSacuvaj.Visibility = Visibility.Hidden;
                dgPostojaciNamestaj.Margin = new Thickness(300, 72, 0, 0);
                dgNaruceniNamestaj.Margin = new Thickness(-160, 72, 0, 0);
                dgPostojaceDodatne.Margin = new Thickness(290, 47, 0, 0);
                dgNaruceneDodatne.Margin = new Thickness(-150, 47, 0, 0);

            }


            for (int i = 1; i < 11; i++)
            {
                cbKolicina.Items.Add(i);
            }
            cbKolicina.SelectedItem = 1;


            if (pristup == Pristup.PRODAVAC)
            {
                cbProdavac.Visibility = Visibility.Hidden;
                dpDatumProdaje.Visibility = Visibility.Hidden;
            }
        }

        private void btnDodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = viewDodatne.CurrentItem as DodatnaUsluga;

            foreach (var x in dodateUsluge)
            {
                if (x.Id.Equals(selektovanaUsluga.Id))
                {
                    return;
                }
            }
            racun.UkupnaCena += selektovanaUsluga.Cena;
            // DodatnaUsluga.AddForRacun(racun, selektovanaUsluga);
            //dgNaruceneDodatne.ItemsSource = racun.Usluge;
            dodateUsluge.Add(selektovanaUsluga);
            //racun.UkupnaCena += selektovanaUsluga.Cena;
            //tbUkupna.Text = racun.UkupnaCena.ToString();


        }

        private void btnIzbaciUslugu_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = dgNaruceneDodatne.SelectedItem as DodatnaUsluga;
            dodateUsluge.Remove(selektovanaUsluga);
            racun.UkupnaCena -= selektovanaUsluga.Cena;
            //DodatnaUsluga.DeleteForRacun(racun, selektovanaUsluga);
            //dgNaruceneDodatne.ItemsSource = racun.Usluge;
            //racun.UkupnaCena -= selektovanaUsluga.Cena;
            //tbUkupna.Text = racun.UkupnaCena.ToString();
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {

            Namestaj selektovaniNamestaj = viewNamestaj.CurrentItem as Namestaj;
            int kolicina = int.Parse(cbKolicina.SelectedItem.ToString());

            if (kolicina > selektovaniNamestaj.Kolicina)
            {
                Warning.Visibility = Visibility.Visible;
            }


            else
            {
                double cenaJedneStavke = 0;
                double popust = 0;
                Warning.Visibility = Visibility.Hidden;
                selektovaniNamestaj.Kolicina -= kolicina;
                //Namestaj.Update(selektovaniNamestaj);

                foreach (var x in dodateStavke)
                {
                    if (x.Namestaj.Id.Equals(selektovaniNamestaj.Id))
                    {
                        x.BrojKomada += kolicina;
                        //Stavka.UpdateForRacun(racun, x);
                        //dgNaruceniNamestaj.ItemsSource = racun.Stavke;
                        //tbUkupna.Text = racun.UkupnaCena.ToString();
                        if (x.Namestaj.Akcija.Naziv != "")
                        {
                            popust = (((x.Namestaj.Akcija).Popust / 100) * x.Namestaj.JedinicnaCena);
                            double nakonSnizenja = Math.Round((x.Namestaj.JedinicnaCena - popust), 2);
                            cenaJedneStavke = nakonSnizenja * kolicina;
                        } else
                        {
                            cenaJedneStavke = x.Namestaj.JedinicnaCena * kolicina;
                        }
                        racun.UkupnaCena += cenaJedneStavke;
                        return;
                    }

                }
                Stavka newStavka = new Stavka(selektovaniNamestaj, kolicina);
                dodateStavke.Add(newStavka);
                if (selektovaniNamestaj.Akcija.Naziv != "")
                {
                    popust = (((selektovaniNamestaj.Akcija).Popust / 100) * selektovaniNamestaj.JedinicnaCena);
                    double nakonSnizenja = Math.Round((selektovaniNamestaj.JedinicnaCena - popust), 2);
                    cenaJedneStavke = nakonSnizenja * kolicina;
                }
                else
                {
                    cenaJedneStavke = selektovaniNamestaj.JedinicnaCena * kolicina;
                }
                racun.UkupnaCena += cenaJedneStavke;



                //Stavka.AddForRacun(racun, newStavka);
                //dgNaruceniNamestaj.ItemsSource = racun.Stavke;
                // racun.UkupnaCena += newStavka.Namestaj.JedinicnaCena * newStavka.BrojKomada;
                //tbUkupna.Text = racun.UkupnaCena.ToString();
                return;
            }
        }

        private void btnIzbaciNamestaj_Click(object sender, RoutedEventArgs e)
        {
            int Kolicina = int.Parse(cbKolicina.SelectedItem.ToString());
            Stavka stavka = dgNaruceniNamestaj.Items.CurrentItem as Stavka;
            try
            {
                if (Kolicina > stavka.BrojKomada)
                {
                    Warning2.Visibility = Visibility.Visible;
                }
                else
                {
                    double cenaJedneStavke = 0;
                    double popust = 0;
                    Warning2.Visibility = Visibility.Hidden;

                    if (stavka.Namestaj.Akcija.Naziv != "")
                    {
                        popust = (((stavka.Namestaj.Akcija).Popust / 100) * stavka.Namestaj.JedinicnaCena);
                        double nakonSnizenja = Math.Round((stavka.Namestaj.JedinicnaCena - popust), 2);
                        cenaJedneStavke = nakonSnizenja * stavka.BrojKomada;
                    }
                    else
                    {
                        cenaJedneStavke = stavka.Namestaj.JedinicnaCena * stavka.BrojKomada;
                        Console.WriteLine(cenaJedneStavke);
                    }

                    racun.UkupnaCena -= cenaJedneStavke;
                    foreach (var namestaj in Aplikacija.Instance.Namestaj)
                    {
                        if (namestaj == stavka.Namestaj)
                        {
                            stavka.BrojKomada -= Kolicina;
                            namestaj.Kolicina += Kolicina;
                        }
                    }


                    //Stavka.UpdateForRacun(racun, stavka);
                    //dgNaruceniNamestaj.ItemsSource = racun.Stavke;
                    if (stavka.BrojKomada == 0)
                    {
                        dodateStavke.Remove(stavka);
                    }
                    //racun.UkupnaCena -= stavka.Namestaj.JedinicnaCena * Kolicina;
                    //tbUkupna.Text = racun.UkupnaCena.ToString();


                }

            }
            catch (NullReferenceException)
            {
                viewNamestajDodati.Refresh();
                Console.WriteLine("Exception cought");
            }
            

            
        
        
            

        
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(stanje == Stanje.DODAVANJE)
            {
                racun.UkupnaCena += 150;
                Racun.Create(racun);
                foreach (var x in dodateStavke)
                {
                    Namestaj.Update(x.Namestaj);
                    Stavka.AddForRacun(racun, x);
                }
                foreach(var x in dodateUsluge)
                {
                    DodatnaUsluga.AddForRacun(racun, x);
                }
            }
            Model.Racun.Update(racun);
            this.Close();
        }

        private void dgPostojaceDodatne_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgNaruceneDodatne_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgNaruceniNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            if ((string)e.Column.Header == "Key")
            {
                e.Column.Header = "Naziv Namestaja";
            }
        }

        private void dgPostojaciNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan" || x == "Sifra" || x == "AkcijaNaziv" || x == "TipNamestaja" || x == "TipNamestajaNaziv")
            {
                e.Cancel = true;
            }
        }

      
    }
}
