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
    /// Interaction logic for TipIzmenaProzor.xaml
    /// </summary>
    public partial class TipIzmenaProzor : Window
    {
        TipNamestaja tip;
        public enum Stanje { DODAVANJE, IZMENA};
        Stanje stanje;
        public TipIzmenaProzor(TipNamestaja tip, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.tip = tip;
            this.stanje = stanje;

            tbNaziv.DataContext = tip;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.Tipovi.Add(tip);
            }
            this.Close();
        }
    }
}
