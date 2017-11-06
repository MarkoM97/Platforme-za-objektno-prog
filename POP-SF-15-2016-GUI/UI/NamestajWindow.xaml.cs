using POP_15_2016_GUI.Model;
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

namespace POP_SF_15_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InicilizujVrednosti(namestaj, operacija);
            InitializeComponent();

            
        }

        private void InicilizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.operacija = operacija;
            this.namestaj = namestaj;
            tbNaziv.Text = namestaj.naziv;
        }

        private void SacuvajIzmene(Object sender, RoutedEventArgs e)
        {
            List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
            switch(operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        naziv = tbNaziv.Text,
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach(var n in postojeciNamestaj)
                    {
                        if(n.Id == namestaj.Id)
                        {
                            n.naziv = tbNaziv.Text;
                            break;
                        }
                    }
                    break;
            }

            Projekat.instanca.namestaj = postojeciNamestaj;
        }
    }
}
