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
            InitializeComponent();
            InicilizujVrednosti(namestaj, operacija);
        }

        private void InicilizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            cbAkcije.Items.Add("");
            foreach (var Akcija in Projekat.instanca.Akcija)
            {
                cbAkcije.Items.Add(Akcija.naziv);
            }
            if(namestaj.akcija != 0)
            {
                cbAkcije.SelectedItem = Akcija.GetID(namestaj.akcija).naziv;
            }else
            {
                cbAkcije.SelectedItem = "";
            }
            foreach (var Tip in Projekat.instanca.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(Tip.Naziv);
            }
            if (namestaj.tipNamestaja == 0)
            {
                cbTipNamestaja.SelectedItem = Projekat.instanca.TipNamestaja.ElementAt(0).Naziv;
            } else
            {
                cbTipNamestaja.SelectedItem = TipNamestaja.GetID(namestaj.tipNamestaja).Naziv;
            }
            this.operacija = operacija;
            this.namestaj = namestaj;
            tbNaziv.Text = namestaj.naziv;
            tbCena.Text = namestaj.jedinicnaCena.ToString();
            tbSifra.Text = namestaj.sifra.ToString();
            tbKolicina.Text = namestaj.kolicina.ToString(); 
        }

        private void SacuvajIzmene(Object sender, RoutedEventArgs e)
        {
            List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
            Akcija akcijaDodele = new Akcija();
            TipNamestaja tipDodele = new TipNamestaja();
            foreach (Akcija akcija in Projekat.instanca.Akcija)
            {
                if (akcija.naziv.Equals(cbAkcije.SelectedItem.ToString()))
                {
                    akcijaDodele = akcija;
                }
            }
            foreach (TipNamestaja tip in Projekat.instanca.TipNamestaja)
            {
                if (tip.Naziv.Equals(cbTipNamestaja.SelectedItem.ToString()))
                {
                    tipDodele = tip;
                }
            }
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        Id = Projekat.instanca.Namestaj.Count + 1,
                        naziv = tbNaziv.Text,
                        jedinicnaCena = Convert.ToDouble(tbCena.Text),
                        kolicina = Convert.ToInt16(tbKolicina.Text),
                        tipNamestaja = tipDodele.Id,
                        akcija = akcijaDodele.id,
                        sifra = tbSifra.Text
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach(var n in postojeciNamestaj)
                    {
                        if(n.Id == namestaj.Id)
                        {
                            n.naziv = tbNaziv.Text;
                            n.jedinicnaCena = Convert.ToDouble(tbCena.Text);
                            n.akcija = akcijaDodele.id;
                            n.kolicina = Convert.ToInt16(tbKolicina.Text);
                            n.tipNamestaja = tipDodele.Id;
                            n.sifra = tbSifra.Text;
                        }
                    }
                    break;
            }

            Projekat.instanca.Namestaj = postojeciNamestaj;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }
    }
}
