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


            if (namestaj.Akcija ==  null)
            {
                cbAkcije.SelectedItem = namestaj.Akcija;
            }else
            {
                cbAkcije.SelectedItem = "";
            }


            foreach (var Tip in Projekat.instanca.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(Tip.Naziv);
            }



            if (namestaj.TipNamestaja != null)
            {
                cbTipNamestaja.SelectedItem = namestaj.TipNamestaja;
            } else
            {
                cbTipNamestaja.SelectedItem = Projekat.instanca.TipNamestaja[0];
            }
            this.operacija = operacija;
            this.namestaj = namestaj;
            tbNaziv.Text = namestaj.Naziv;
            tbCena.Text = namestaj.JedinicnaCena.ToString();
            tbSifra.Text = namestaj.Sifra.ToString();
            tbKolicina.Text = namestaj.Kolicina.ToString(); 
        }

        private void SacuvajIzmene(Object sender, RoutedEventArgs e)
        {
            List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
            Akcija akcijaDodele = new Akcija();
            TipNamestaja tipDodele = new TipNamestaja();

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        Id = Projekat.instanca.Namestaj.Count + 1,
                        Naziv = tbNaziv.Text,
                        JedinicnaCena = Convert.ToDouble(tbCena.Text),
                        Kolicina = Convert.ToInt16(tbKolicina.Text),
                        TipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem,
                        Akcija = (Akcija)cbAkcije.SelectedItem,
                        Sifra = tbSifra.Text
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach(var n in postojeciNamestaj)
                    {
                        if(n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.JedinicnaCena = Convert.ToDouble(tbCena.Text);
                            n.Akcija = namestaj.Akcija;
                            n.Kolicina = Convert.ToInt16(tbKolicina.Text);
                            n.TipNamestaja = namestaj.TipNamestaja;
                            n.Sifra = tbSifra.Text;
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
