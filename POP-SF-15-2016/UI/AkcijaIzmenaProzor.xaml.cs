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
    /// Interaction logic for AkcijaIzmenaProzor.xaml
    /// </summary>
    public partial class AkcijaIzmenaProzor : Window
    {
        Akcija akcija;
        public enum Stanje { DODAVANJE , IZMENA}
        Stanje stanje;
        public AkcijaIzmenaProzor(Akcija akcija, Stanje stanje= Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.stanje = stanje;

            tbNaziv.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dpPocetak.DataContext = akcija;
            dpZavršetak.DataContext = akcija;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if(stanje == Stanje.DODAVANJE)
            {
                Model.Akcija.Create(akcija);
            }
            Model.Akcija.Update(akcija);
            this.Close();
        }
    }
}
