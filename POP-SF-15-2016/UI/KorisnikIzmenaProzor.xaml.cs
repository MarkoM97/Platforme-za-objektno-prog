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
    /// Interaction logic for KorisnikIzmenaProzor.xaml
    /// </summary>
    public partial class KorisnikIzmenaProzor : Window
    {
        Korisnik korisnik;
        public enum Stanje { DODAVANJE, IZMENA}
        Stanje stanje;
        public KorisnikIzmenaProzor(Korisnik korisnik, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.stanje = stanje;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisniko.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;

            cbTip.Items.Add(Korisnik.tipKorisnika.ADMINISTRATOR);
            cbTip.Items.Add(Korisnik.tipKorisnika.PRODAVAC);
            cbTip.DataContext = korisnik;


        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if(stanje == Stanje.DODAVANJE)
            {
                Korisnik.Create(korisnik);
            }
            Korisnik.Update(korisnik);
            this.Close();
        }

        private void tbKorisniko_LostFocus(object sender, RoutedEventArgs e)
        {
            string korisnicko = tbKorisniko.Text;
            foreach(var x in Aplikacija.Instance.Korisnici)
            {
                if(x.KorisnickoIme.Equals(korisnicko))
                {
                    tbKorisnickoValidation.Visibility = Visibility.Visible;
                    tbKorisniko.BorderBrush = Brushes.Red;
                } else
                {
                    tbKorisniko.ClearValue(TextBox.BorderBrushProperty);
                }
            }
        }

        private void tbKorisniko_GotFocus(object sender, RoutedEventArgs e)
        {
            tbKorisnickoValidation.Visibility = Visibility.Hidden;
        }
    }
}
