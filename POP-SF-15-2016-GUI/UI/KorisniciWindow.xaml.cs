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
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class KorisniciWindow : Window
    {
        private Korisnik korisnik;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public KorisniciWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(korisnik, operacija);
        }

        private void InicijalizujVrednosti(Korisnik korisnik, Operacija operacija) {
            this.operacija = operacija;
            this.korisnik = korisnik;
            tbIme.Text = korisnik.Ime;
            tbPrezime.Text = korisnik.Prezime.ToString();
            tbKorisnickoIme.Text = korisnik.KorisnickoIme.ToString();
            tbLozinka.Text = korisnik.Lozinka.ToString();
            tbTipKorisnika.Text = korisnik.TipKorisnika.ToString();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<Korisnik> postojeciKorisnici = Projekat.instanca.Korisnik;
            if (tbIme.Text.Equals("") || tbPrezime.Text.Equals("") || tbTipKorisnika.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviKorisnik = new Korisnik()
                    {
                        Id = Projekat.instanca.Korisnik.Count + 1,
                        Ime = tbIme.Text,
                        Prezime = tbPrezime.Text,
                        KorisnickoIme= tbKorisnickoIme.Text,
                        Lozinka = tbLozinka.Text,
                        TipKorisnika= Convert.ToBoolean(tbTipKorisnika.Text),
                    };
                    postojeciKorisnici.Add(noviKorisnik);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciKorisnici)
                    {
                        if (n.Id == korisnik.Id)
                        {
                            n.Ime = tbIme.Text;
                            n.Prezime = tbPrezime.Text;
                            n.KorisnickoIme = tbKorisnickoIme.Text;
                            n.Lozinka = tbLozinka.Text;
                            n.TipKorisnika = Convert.ToBoolean(tbTipKorisnika.Text);
                        }
                    }
                    break;
            }

            Projekat.instanca.Korisnik = postojeciKorisnici;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }
    }

}
