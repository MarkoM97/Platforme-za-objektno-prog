using POP_15_2016_GUI.Model;
using System;
using System.Collections;
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

namespace POP_SF_15_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for RacuniWindow.xaml
    /// </summary>
    public partial class RacuniWindow : Window
    {
        private Racun racun;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public RacuniWindow(Racun racun, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(racun, operacija);
        }

        private void InicijalizujVrednosti(Racun racun, Operacija operacija)
        {
            this.operacija = operacija;
            this.racun = racun;
            if (racun.Prodavac != null)
            {
                tbProdavac.Text = racun.Prodavac.ToString();
            } else
            {
                tbProdavac.Text = "";
            }
            if (racun.ProdatiNamestaj != null)
            {
                tbNamestaj.Text = racun.ProdatiNamestaj.ToString();
            } else
            {
                tbNamestaj.Text = "";
            }
            tbBrojKomada.Text = racun.BrojKomada.ToString();
            tbDatumProdaje.Text = racun.DatumProdaje.ToString();
            lbPostojace.ItemsSource = Projekat.instanca.DodatnaUsluga;
            foreach(DodatnaUsluga du in racun.DodatneUsluge)
            {
                lbNarucene.Items.Add(du);
            } 
            tbKupac.Text = racun.ImeKupca.ToString();
            tbUkupnaCena.Text = racun.UkupnaCena.ToString();
            //Ubaciti checkboxove pored svaki dodatne usluge kako ne bi doslo do greske
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<Racun> postojaciRacuni = Projekat.instanca.Racun;
            List<DodatnaUsluga> du = new List<DodatnaUsluga>();
            if (tbProdavac.Text.Equals("") || tbNamestaj.Text.Equals("") || tbBrojKomada.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }  
            foreach(var x in lbNarucene.Items)
            {
                Console.WriteLine();
                du.Add((DodatnaUsluga)x);
            }
            foreach(var z in du)
            {
                Console.WriteLine(z.ToString());
            }
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviRacun = new Racun()
                    {
                        Id = Projekat.instanca.Racun.Count + 1,
                        Prodavac = Korisnik.getName(tbProdavac.Text),
                        ProdatiNamestaj = Namestaj.getName(tbNamestaj.Text),
                        DatumProdaje = Convert.ToDateTime(tbDatumProdaje.Text),
                        DodatneUsluge = du,
                        ImeKupca = tbKupac.Text,
                        UkupnaCena = Convert.ToInt16(tbUkupnaCena.Text)
                    };
                    postojaciRacuni.Add(noviRacun);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojaciRacuni)
                    {
                        if (n.Id == racun.Id)
                        {
                            n.Prodavac = Korisnik.getName(tbProdavac.Text);
                            n.ProdatiNamestaj = Namestaj.getName(tbNamestaj.Text);
                            n.BrojKomada = Convert.ToInt16(tbBrojKomada.Text);
                            n.DatumProdaje = Convert.ToDateTime(tbDatumProdaje.Text);
                            n.DodatneUsluge = du;
                            n.ImeKupca = tbKupac.Text;
                            n.UkupnaCena = Convert.ToInt16(tbUkupnaCena.Text);
                        }
                    }
                    break;
            }

            Projekat.instanca.Racun = postojaciRacuni;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }

        

        private void NaruciUslugu(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga du = (DodatnaUsluga)lbPostojace.SelectedItem;
            lbNarucene.Items.Add(du);
            
        }

        private void IzbaciUslugu(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga du = (DodatnaUsluga)lbNarucene.SelectedItem;
            lbNarucene.Items.Remove(du);
        }
    }
}
