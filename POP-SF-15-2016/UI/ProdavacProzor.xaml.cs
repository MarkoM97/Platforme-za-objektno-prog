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
    /// Interaction logic for ProdavacProzor.xaml
    /// </summary>
    public partial class ProdavacProzor : Window
    {
        public ProdavacProzor()
        {
            InitializeComponent();
        }

        private void btnGenerisiRacun_Click(object sender, RoutedEventArgs e)
        {
            Racun racun = new Racun();
            Racun.Create(racun);
            RacunIzmenaProzor rip = new RacunIzmenaProzor(racun, RacunIzmenaProzor.Stanje.DODAVANJE , RacunIzmenaProzor.Pristup.PRODAVAC);
            rip.ShowDialog();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }
    }
}
