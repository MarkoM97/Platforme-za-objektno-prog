using POP_15_2016_GUI.Model;
using POP_SF_15_2016_GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_15_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
        public MainWindow()
        {
            InitializeComponent();
            
            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            ListBoxNamestaja.Items.Clear();
            foreach (var namestaj in postojeciNamestaj)
            {
                if (namestaj.obrisan == false)
                {
                    ListBoxNamestaja.Items.Add(namestaj);
                }
            }

            ListBoxNamestaja.SelectedIndex = 0;
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Id = Projekat.instanca.Namestaj.Count + 1,
                naziv = "",
                akcija = 0,
                kolicina = 0,
                jedinicnaCena = 0,
                sifra = "",
                tipNamestaja = 0

                
            };
            

            var NamestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            NamestajProzor.Show();
            this.Close();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = (Namestaj)ListBoxNamestaja.SelectedItem;

            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
            this.Close();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = (Namestaj)ListBoxNamestaja.SelectedItem;
            selektovaniNamestaj.obrisan = true;
            Projekat.instanca.Namestaj = postojeciNamestaj;
            OsveziPrikaz();
        }
    }
}
