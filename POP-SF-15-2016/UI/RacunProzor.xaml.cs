using POP_SF_15_2016.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_15_2016.UI
{
    /// <summary>
    /// Interaction logic for RacunProzor.xaml
    /// </summary>
    public partial class RacunProzor : Window
    {
        ICollectionView view;
        public RacunProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Racuni);
            dgRacun.ItemsSource = view;
            dgRacun.IsSynchronizedWithCurrentItem = true;
            dgRacun.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgRacun_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "usluge" || x == "namestaji" || x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Racun racun = new Racun(Aplikacija.Instance.Racuni.Last().Id + 1);
            RacunIzmenaProzor rip = new RacunIzmenaProzor(racun);
            rip.ShowDialog();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Racun selektovaniRacun = view.CurrentItem as Racun;
            RacunIzmenaProzor rip = new RacunIzmenaProzor(selektovaniRacun, RacunIzmenaProzor.Stanje.IZMENA);
            rip.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Racun selektovaniRacun = view.CurrentItem as Racun;
            if(MessageBox.Show("Da li ste sigurni", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Aplikacija.Instance.Racuni.Remove(selektovaniRacun);
            }
        }
    }
}
