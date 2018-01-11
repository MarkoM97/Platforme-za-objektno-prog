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
        CollectionViewSource cvs;
        ICollectionView view;
        public TipNamestajaProzor()
        {
            InitializeComponent();

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instance.Tipovi;

            cvs.Filter += new FilterEventHandler(origFilter);
            view = cvs.View;
            dgTip.ItemsSource = view;
            dgTip.IsSynchronizedWithCurrentItem = true;
            dgTip.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            /*view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Tipovi);
            dgTip.ItemsSource = view;
            dgTip.IsSynchronizedWithCurrentItem = true;
            dgTip.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            */
        }

        private void origFilter(object sender, FilterEventArgs e)
        {
            TipNamestaja tip = e.Item as TipNamestaja;
            e.Accepted = tip.Obrisan == false;
        }

        private void dgTip_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja noviTip = new TipNamestaja();
            TipIzmenaProzor tip = new TipIzmenaProzor(noviTip);
            tip.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja selektovaniNamestaj = view.CurrentItem as TipNamestaja;
            if(selektovaniNamestaj != null)
            {
                
                TipNamestaja old = (TipNamestaja)selektovaniNamestaj.Clone();
                TipIzmenaProzor tip = new TipIzmenaProzor(selektovaniNamestaj, TipIzmenaProzor.Stanje.IZMENA);
                if(tip.ShowDialog() != true)
                {
                    int index = Aplikacija.Instance.Tipovi.IndexOf(selektovaniNamestaj);
                    Aplikacija.Instance.Tipovi[index] = old;
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Da li ste sigurni?" , "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TipNamestaja selektovaniTip = view.CurrentItem as TipNamestaja;
                Model.TipNamestaja.Delete(selektovaniTip);
                view.Refresh();
            }
        }

        private void rbSortirajRastuce_Checked(object sender, RoutedEventArgs e)
        {
            cvs.SortDescriptions.Clear();
            cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));
        }

        private void rbSortirajOpadajuce_Checked(object sender, RoutedEventArgs e)
        {
            cvs.SortDescriptions.Clear();
            cvs.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretraga);
        }

        private void pretraga(object sender, FilterEventArgs e)
        {
            string x = tbPretraga.Text.ToString();
            TipNamestaja tip = e.Item as TipNamestaja;
            e.Accepted = tip.Naziv.Contains(x) && tip.Obrisan == false;
        }
    }
}
