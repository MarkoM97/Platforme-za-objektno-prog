using POP_SF_15_2016.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NamestajIzmenaProzor.xaml
    /// </summary>
    public partial class NamestajIzmenaProzor : Window
    {
        Namestaj namestaj;
        public enum Stanje { DODAVANJE, IZMENA};
        Stanje stanje; 
        public NamestajIzmenaProzor(Namestaj namestaj, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();
            this.namestaj = namestaj;
            this.stanje = stanje;

            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            tbSifra.DataContext = namestaj;

            
            cbAkcija.ItemsSource = Aplikacija.Instance.Akcije;
            cbAkcija.DataContext = namestaj;
            cbTip.ItemsSource = Aplikacija.Instance.Tipovi;
            cbTip.DataContext = namestaj;

        }

        private void btnSacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {
            if (stanje == Stanje.DODAVANJE)
            {
                Model.Namestaj.Create(namestaj);
            }
            Model.Namestaj.Update(namestaj);
            this.Close();
            
        }

        private void chbAkcija_Checked(object sender, RoutedEventArgs e)
        {
            cbAkcija.IsEnabled = false;
            cbAkcija.SelectedItem = null;
            namestaj.Akcija = new Akcija();
        }

        private void chbAkcija_Unchecked(object sender, RoutedEventArgs e)
        {
            cbAkcija.IsEnabled = true;
            cbAkcija.SelectedIndex = 0;
        }
    }
}
