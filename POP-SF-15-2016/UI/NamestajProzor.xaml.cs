using POP_SF_15_2016.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace POP_SF_15_2016.UI
{
    public partial class NamestajProzor : Window
    {
        CollectionViewSource cvs;
        ICollectionView view;
        public NamestajProzor()
        {
            InitializeComponent();


            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instance.Namestaj;

            cvs.Filter += new FilterEventHandler(skloniBezTipa);
            view = cvs.View;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbKriterijumPretrage.Items.Add("Naziv");
            cbKriterijumPretrage.Items.Add("Sifra");
            cbKriterijumPretrage.Items.Add("Akcija");
            cbKriterijumPretrage.Items.Add("Tip");
            cbKriterijumPretrage.SelectedIndex = 0;

            cbSortiranje.Items.Add("Naziv");
            cbSortiranje.Items.Add("Sifra");
            cbSortiranje.Items.Add("Akcija");
            cbSortiranje.Items.Add("Tip");
            /*view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Namestaj);
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        */
        }

        private void skloniBezTipa(object sender, FilterEventArgs e)
        {
            Namestaj namestaj = e.Item as Namestaj;
            e.Accepted = namestaj.TipNamestaja.Obrisan != true && namestaj.Obrisan != true;
        }

        private void pretraga(object sender, FilterEventArgs e)
        {
            string x = cbKriterijumPretrage.SelectedItem.ToString();
            string s = tbPretraga.Text;
            Namestaj namestaj = e.Item as Namestaj;
            switch (x)
            {
                case "Naziv":
                    e.Accepted = namestaj.Naziv.ToString().Contains(s) && namestaj.Obrisan != true && namestaj.TipNamestaja.Obrisan != true ;
                    break;
                case "Sifra":
                    e.Accepted = namestaj.Sifra.ToString().Contains(s) && namestaj.Obrisan != true && namestaj.TipNamestaja.Obrisan != true;
                    break;
                case "Akcija":
                    if (namestaj.Akcija != null) e.Accepted = namestaj.Akcija.Naziv.ToString().Contains(s) && namestaj.Obrisan != true && namestaj.TipNamestaja.Obrisan != true;
                    break;
                case "Tip":
                    e.Accepted = namestaj.TipNamestaja.Naziv.ToString().Contains(s) && namestaj.Obrisan != true && namestaj.TipNamestaja.Obrisan != true;
                    break;
                default:
                    break;
            }

        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Id" || x == "Obrisan" || x == "AkcijaNaziv" || x == "TipNamestajaNaziv")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj noviNamestaj = new Namestaj();
            NamestajIzmenaProzor nip = new NamestajIzmenaProzor(noviNamestaj);
            nip.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = view.CurrentItem as Namestaj;
            if (selektovaniNamestaj != null)
            {
                Namestaj old = (Namestaj)selektovaniNamestaj.Clone();
                NamestajIzmenaProzor nip = new NamestajIzmenaProzor(selektovaniNamestaj, NamestajIzmenaProzor.Stanje.IZMENA);
                if(nip.ShowDialog() != true)
                {
                    int index = Aplikacija.Instance.Namestaj.IndexOf(selektovaniNamestaj);
                    Aplikacija.Instance.Namestaj[index] = old;
                    
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namestaj selektovaniNamestaj = view.CurrentItem as Namestaj;
                Model.Namestaj.Delete(selektovaniNamestaj);
                view.Refresh();
                
            }
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretraga);
        }

        private void rbBezFiltera_Checked(object sender, RoutedEventArgs e)
        {
            cbSortiranje.SelectedItem = null;
        }

        private void rbOpadajuce_Checked(object sender, RoutedEventArgs e)
        {
            string kriterijumSortiranja = cbSortiranje.Text;
            cvs.SortDescriptions.Clear();
            if (kriterijumSortiranja == "Akcija")
            {
                cvs.SortDescriptions.Add(new SortDescription("AkcijaNaziv", ListSortDirection.Descending));
            }
            else if (kriterijumSortiranja == "Tip")
            {
                cvs.SortDescriptions.Add(new SortDescription("TipNamestajaNaziv", ListSortDirection.Descending));
            }
            else
            {
                cvs.SortDescriptions.Add(new SortDescription(kriterijumSortiranja, ListSortDirection.Descending));
            }

        }

        private void rbRastuce_Checked(object sender, RoutedEventArgs e)
        {
            string kriterijumSortiranja = cbSortiranje.Text;
            cvs.SortDescriptions.Clear();
            if (kriterijumSortiranja == "Akcija")
            {
                cvs.SortDescriptions.Add(new SortDescription("AkcijaNaziv", ListSortDirection.Ascending));
            } else if (kriterijumSortiranja == "Tip")
            {
                cvs.SortDescriptions.Add(new SortDescription("TipNamestajaNaziv", ListSortDirection.Ascending));
            } else {
                cvs.SortDescriptions.Add(new SortDescription(kriterijumSortiranja, ListSortDirection.Ascending));
            }

        }
    }
}
