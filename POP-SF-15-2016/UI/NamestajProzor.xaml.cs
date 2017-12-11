using POP_SF_15_2016.Model;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace POP_SF_15_2016.UI
{
    public partial class NamestajProzor : Window
    {
        ICollectionView view;
        public NamestajProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Namestaj);
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if(x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj noviNamestaj = new Namestaj(Aplikacija.Instance.Namestaj.Last().Id + 1);
            NamestajIzmenaProzor nip = new NamestajIzmenaProzor(noviNamestaj);
            nip.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = view.CurrentItem as Namestaj;
            if(selektovaniNamestaj != null)
            {
                NamestajIzmenaProzor nip = new NamestajIzmenaProzor(selektovaniNamestaj, NamestajIzmenaProzor.Stanje.IZMENA);
                nip.ShowDialog();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namestaj selektovaniNamestaj = view.CurrentItem as Namestaj;
                Aplikacija.Instance.Namestaj.Remove(selektovaniNamestaj);
            }
        }
    }
}
