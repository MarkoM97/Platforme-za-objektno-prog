using POP_SF_15_2016.Model;
using POP_SF_15_2016.UI;
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

namespace POP_SF_15_2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Klik na namestaj");
            NamestajProzor np = new NamestajProzor();
            np.ShowDialog();
        }

        private void btnTipovi_Click(object sender, RoutedEventArgs e)
        {
            TipNamestajaProzor tnp = new TipNamestajaProzor();
            tnp.ShowDialog();
        }

        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            AkcijaProzor ap = new AkcijaProzor();
            ap.ShowDialog();
        }

        private void btnRacuni_Click(object sender, RoutedEventArgs e)
        {
            RacunProzor rp = new RacunProzor();
            rp.ShowDialog();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisnikProzor kp = new KorisnikProzor();
            kp.ShowDialog();
        }
    }
}
