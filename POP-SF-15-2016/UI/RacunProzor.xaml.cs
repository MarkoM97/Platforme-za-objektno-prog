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
        CollectionViewSource cvs;
        ICollectionView view;
        public RacunProzor()
        {
            InitializeComponent();

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instance.Racuni;

            view = cvs.View;
            dgRacun.ItemsSource = view;
            dgRacun.IsSynchronizedWithCurrentItem = true;
            dgRacun.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cmbKriterijumPretrage.Items.Add("Ime i prezime kupca");
            cmbKriterijumPretrage.Items.Add("Broj racuna");
            cmbKriterijumPretrage.Items.Add("Prodat komad namestaja");
            cmbKriterijumPretrage.Items.Add("Datum prodaje");

            cmbNamestajZaPretragu.ItemsSource = Aplikacija.Instance.Namestaj;
        }

        private void dgRacun_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if (x == "Usluge" || x == "Stavke" || x == "Id" || x == "Obrisan" || x == "stringNamestaja")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Racun racun = new Racun();
            RacunIzmenaProzor rip = new RacunIzmenaProzor(racun);
            rip.ShowDialog();

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Racun selektovaniRacun = view.CurrentItem as Racun;
            if(MessageBox.Show("Da li ste sigurni", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Racun.Delete(selektovaniRacun);
            }
        }

        private void tbTekstPretrage_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretraga);
        }

        private void pretraga(object sender, FilterEventArgs e)
        {
            string x = cmbKriterijumPretrage.SelectedItem.ToString();
            string s = tbTekstPretrage.Text;
            Racun racun = e.Item as Racun;
            switch(x)
            {
                case "Broj racuna":
                    break;
                case "Datum prodaje":
                    e.Accepted = racun.DatumProdaje.ToString().Contains(s);
                    break;
                case "Ime i prezime kupca":
                    e.Accepted = racun.ImeKupca.ToString().Contains(s);
                    break;
                default:
                    break;
            }
        }

        private void cmbKriterijumPretrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbKriterijumPretrage.SelectedItem.ToString().Equals("Prodat komad namestaja"))
            {
                tbTekstPretrage.Text = "";
                tbTekstPretrage.Visibility = Visibility.Hidden;
                cmbNamestajZaPretragu.Visibility = Visibility.Visible;
            } else
            {
                view.Filter = null;
                tbTekstPretrage.Visibility = Visibility.Visible;
                cmbNamestajZaPretragu.Visibility = Visibility.Hidden;
            }
        }

        private void cmbNamestajZaPretragu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretragaNamestaj);
        }

        private void pretragaNamestaj(object sender, FilterEventArgs e)
        {
            Namestaj namestaj = cmbNamestajZaPretragu.SelectedItem as Namestaj;

            Racun racun = e.Item as Racun;
            e.Accepted = racun.stringNamestaja.Contains(namestaj.Naziv);
        }

        private void btnDetaljnije_Click(object sender, RoutedEventArgs e)
        {
            Racun selektovaniRacun = view.CurrentItem as Racun;
            RacunIzmenaProzor rip = new RacunIzmenaProzor(selektovaniRacun, RacunIzmenaProzor.Stanje.IZMENA);
            rip.ShowDialog();
        }
    }
}
