using POP_SF_15_2016.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF_15_2016.UI
{
    /// <summary>
    /// Interaction logic for KorisnikProzor.xaml
    /// </summary>
    public partial class KorisnikProzor : Window
    {
        CollectionViewSource cvs;
        ICollectionView view;
        public KorisnikProzor()
        {
            InitializeComponent();

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instance.Korisnici;

            view = cvs.View;
            dgKorisnik.ItemsSource = view;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbKriterijumPretrage.Items.Add("Ime");
            cbKriterijumPretrage.Items.Add("Prezime");
            cbKriterijumPretrage.Items.Add("Korisnicko ime");
            cbKriterijumPretrage.Items.Add("Lozinka");
            cbKriterijumPretrage.Items.Add("Tip korisnika");

            cbKriterijumSortiranja.Items.Add("Ime");
            cbKriterijumSortiranja.Items.Add("Prezime");
            cbKriterijumSortiranja.Items.Add("KorisnickoIme");
            cbKriterijumSortiranja.Items.Add("Lozinka");
            cbKriterijumSortiranja.Items.Add("Tip");


        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if(x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            KorisnikIzmenaProzor kip = new KorisnikIzmenaProzor(noviKorisnik);
            kip.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik postojeciKorisnik = view.CurrentItem as Korisnik;
            
            if(postojeciKorisnik != null)
            {
               
                Korisnik old = (Korisnik)postojeciKorisnik.Clone();
                KorisnikIzmenaProzor kip = new KorisnikIzmenaProzor(postojeciKorisnik, KorisnikIzmenaProzor.Stanje.IZMENA);
                if (kip.ShowDialog() != true)
                {
                    int index = Aplikacija.Instance.Korisnici.IndexOf(postojeciKorisnik);
                    Aplikacija.Instance.Korisnici[index] = old;
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = view.CurrentItem as Korisnik;
            if (MessageBox.Show("Da li ste sigurni", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik.Delete(selektovaniKorisnik);
                Aplikacija.Instance.Korisnici.Remove(selektovaniKorisnik);
            }
        }

        private void rbRastuce_Checked(object sender, RoutedEventArgs e)
        {
            string kriterijumSortiranja = cbKriterijumSortiranja.Text.ToString();
            cvs.SortDescriptions.Clear();
            cvs.SortDescriptions.Add(new SortDescription(kriterijumSortiranja, ListSortDirection.Ascending));
        }

        private void rbOpadajuce_Checked(object sender, RoutedEventArgs e)
        {
            string kriterijumSortiranja = cbKriterijumSortiranja.Text.ToString();
            cvs.SortDescriptions.Clear();
            cvs.SortDescriptions.Add(new SortDescription(kriterijumSortiranja, ListSortDirection.Descending));
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretraga);
        }

        private void pretraga(object sender, FilterEventArgs e)
        {
            string kriterijumPretrage = cbKriterijumPretrage.SelectedItem.ToString();
            string x = tbPretraga.Text.ToString();
            Korisnik korisnik = e.Item as Korisnik;
            switch(kriterijumPretrage)
            {
                case "Ime":
                    e.Accepted = korisnik.Ime.Contains(x);
                    break;
                case "Prezime":
                    e.Accepted = korisnik.Prezime.Contains(x);
                    break;
                case "Korisnicko ime":
                    e.Accepted = korisnik.KorisnickoIme.Contains(x);
                    break;
                case "Lozinka":
                    e.Accepted = korisnik.Lozinka.Contains(x);
                    break;
                case "Tip korisnika":
                    e.Accepted = korisnik.Tip.ToString().Contains(x);
                    break;
                default:
                    break;
            }
        }
    }
}
