using POP_SF_15_2016.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public enum Stanje { DODAVANJE, IZMENA}
        Stanje stanje;
        ICollectionView viewNamestaj;
        ICollectionView viewDodatne;
        //ObservableCollection<DodatnaUsluga> naruceneUsluge = new ObservableCollection<DodatnaUsluga>();
        //ObservableCollection<Tuple<Namestaj, int>> naruceniNamestaj = new ObservableCollection<Tuple<Namestaj, int>>();
        public RacunIzmenaProzor(Racun racun, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.racun = racun;
            this.stanje = stanje;

            cbProdavac.ItemsSource = Aplikacija.Instance.Korisnici;
            cbProdavac.DataContext = racun;

            dpDatumProdaje.DataContext = racun;

            tbKupac.DataContext = racun;

            viewNamestaj = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Namestaj);
            dgPostojaciNamestaj.ItemsSource = viewNamestaj;
            dgPostojaciNamestaj.IsSynchronizedWithCurrentItem = true;
            dgPostojaciNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewDodatne = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Usluge);
            dgPostojaceDodatne.ItemsSource = viewDodatne;
            dgPostojaceDodatne.IsSynchronizedWithCurrentItem = true;
            dgPostojaceDodatne.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgNaruceniNamestaj.ItemsSource = CollectionViewSource.GetDefaultView(racun.Namestaji);
            dgNaruceniNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNaruceniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgNaruceneDodatne.ItemsSource = CollectionViewSource.GetDefaultView(racun.Usluge);
            dgNaruceneDodatne.IsSynchronizedWithCurrentItem = true;
            dgNaruceneDodatne.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            for(int i=1; i<11;i++)
            {
                cbKolicina.Items.Add(i);
            }
            cbKolicina.SelectedItem = 1;
        }

        private void btnDodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = viewDodatne.CurrentItem as DodatnaUsluga;
            Console.WriteLine("Pre dodavanja");
            foreach(var x in racun.Usluge)
            {
                Console.WriteLine(x.Naziv);
            }
            racun.Usluge.Add(selektovanaUsluga);
            Console.WriteLine("Posle dodavanja");
            foreach (var x in racun.Usluge)
            {
                Console.WriteLine(x.Naziv);
            }
        }

        private void btnIzbaciUslugu_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = dgNaruceneDodatne.SelectedItem as DodatnaUsluga;
            racun.Usluge.Remove(selektovanaUsluga);

        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            foreach (var x in racun.Namestaji)
            {
                Console.WriteLine(x);
            }
            Namestaj selektovaniNamestaj = viewNamestaj.CurrentItem as Namestaj;
            int kolicina = int.Parse(cbKolicina.SelectedItem.ToString());
            if (kolicina > selektovaniNamestaj.Kolicina)
            {
                Warning.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
                try
                {
                    racun.Namestaji[selektovaniNamestaj] = racun.Namestaji[selektovaniNamestaj] + kolicina;
                }catch(Exception ex) when (ex is KeyNotFoundException || ex is NullReferenceException)
                {
                    racun.Namestaji.Add(selektovaniNamestaj, kolicina);
                }
                selektovaniNamestaj.Kolicina = selektovaniNamestaj.Kolicina - kolicina;
                dgNaruceniNamestaj.Items.Refresh();
            }
        }

        private void btnIzbaciNamestaj_Click(object sender, RoutedEventArgs e)
        {
            int tempKolicina = int.Parse(cbKolicina.SelectedItem.ToString());
            var x = dgNaruceniNamestaj.Items.CurrentItem as KeyValuePair<Namestaj, int>?;
            Namestaj nam = x.Value.Key;
            if(tempKolicina > nam.Kolicina)
            {
                Warning2.Visibility = Visibility.Visible;
            } else
            {
                Warning2.Visibility = Visibility.Hidden;
                foreach (var z in Aplikacija.Instance.Namestaj)
                {
                    if (z == nam)
                    {
                        z.Kolicina += tempKolicina;
                    }
                }
                racun.Namestaji.Remove(x.Value.Key);
                dgNaruceniNamestaj.Items.Refresh();
            }
            
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.Racuni.Add(racun);
            }
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

            if ((string)e.Column.Header == "Value")
            {
                e.Column.Header = "Broj komada";
            }
        }

        private void dgPostojaciNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
