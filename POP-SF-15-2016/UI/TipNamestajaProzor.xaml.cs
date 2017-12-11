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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {
        ICollectionView view;
        public TipNamestajaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Tipovi);
            dgTip.ItemsSource = view;
            dgTip.IsSynchronizedWithCurrentItem = true;
            dgTip.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgTip_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja noviTip = new TipNamestaja(Aplikacija.Instance.Tipovi.Last().Id + 1);
            TipIzmenaProzor tip = new TipIzmenaProzor(noviTip);
            tip.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja selektovaniNamestaj = view.CurrentItem as TipNamestaja;
            if(selektovaniNamestaj != null)
            {
                TipIzmenaProzor tip = new TipIzmenaProzor(selektovaniNamestaj, TipIzmenaProzor.Stanje.IZMENA);
                tip.ShowDialog();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Da li ste sigurni?" , "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TipNamestaja selektovaniTip = view.CurrentItem as TipNamestaja;
                Aplikacija.Instance.Tipovi.Remove(selektovaniTip);
            }
        }
    }
}
