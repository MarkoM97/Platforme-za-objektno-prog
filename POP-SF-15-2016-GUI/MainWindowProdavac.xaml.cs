using POP_15_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POP_SF_15_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindowProdavac.xaml
    /// </summary>
    public partial class MainWindowProdavac : Window
    {
        List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
        ObservableCollection<Namestaj> pNamestaj = new ObservableCollection<Namestaj>(Projekat.instanca.Namestaj);

        public MainWindowProdavac()
        {
            InitializeComponent();
            lvvPostojeci.ItemsSource = pNamestaj;

        }

        private void UbaciButton(object sender, RoutedEventArgs e)
        {
            Namestaj n = (Namestaj)lvvPostojeci.SelectedItem;
            lvvNaruceni.Items.Add(n);
        }

        private void GenerisiRacun(object sender, RoutedEventArgs e)
        {
            List<Namestaj> ubaceni = new List<Namestaj>();
            foreach(var x in lvvNaruceni.Items)
            {
                ubaceni.Add((Namestaj)x);
            }
        }
    }
}
