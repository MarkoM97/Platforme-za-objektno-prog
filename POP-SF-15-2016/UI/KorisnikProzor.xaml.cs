using POP_SF_15_2016.Model;
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
        ICollectionView view;
        public KorisnikProzor()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Korisnici);
            dgKorisnik.ItemsSource = view;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
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
            KorisnikIzmenaProzor kip = new KorisnikIzmenaProzor(postojeciKorisnik, KorisnikIzmenaProzor.Stanje.IZMENA);
            kip.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = view.CurrentItem as Korisnik;
            Aplikacija.Instance.Korisnici.Remove(selektovaniKorisnik);
            if (MessageBox.Show("Da li ste sigurni", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Aplikacija.Instance.Korisnici.Remove(selektovaniKorisnik);
            }
        }
    }
}
