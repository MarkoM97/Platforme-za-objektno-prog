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
        public NamestajWindow(Namestaj namestaj)
        {
            InicilizujVrednosti(namestaj);
            InitializeComponent();

            
        }

        private void InicilizujVrednosti(Namestaj namestaj)
        {
            this.namestaj = namestaj;
            tbNaziv.Text = namestaj.naziv;
        }
    }
}
