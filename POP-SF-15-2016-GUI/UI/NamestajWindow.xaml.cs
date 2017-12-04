using POP_15_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Windows;


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
                if (Akcija.Obrisan == false)
                {
                    cbAkcije.Items.Add(Akcija.Naziv);
                }
            }

            if (namestaj.Akcija != null)
            {
                cbAkcije.SelectedItem = namestaj.Akcija.Naziv;
            } else
            {
                cbAkcije.SelectedItem = "";
            }


            foreach (var Tip in Projekat.instanca.TipNamestaja)
            {
                if (Tip.Obrisan == false) {
                    cbTipNamestaja.Items.Add(Tip.Naziv);
                }
            }
            if (namestaj.TipNamestaja != null)
            {
                cbTipNamestaja.SelectedItem = namestaj.TipNamestaja.Naziv;
            }
            else
            {
                cbTipNamestaja.SelectedItem = Projekat.instanca.TipNamestaja[0].Naziv;
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
            if (tbNaziv.Text.Equals("") || tbSifra.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }

            /*if (cbAkcije.SelectedItem.ToString().Equals(""))
            {
                akcijaDodele = new Akcija() { id = Projekat.instanca.Akcija.Count + 1, naziv = "" };
            }
            akcijaDodele = Akcija.getNaziv(cbAkcije.SelectedItem.ToString()); */
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
                        TipNamestaja = TipNamestaja.getNaziv(cbTipNamestaja.SelectedItem.ToString()),
                        Akcija = Akcija.getNaziv(cbAkcije.SelectedItem.ToString()),
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
                            n.Akcija = Akcija.getNaziv(cbAkcije.SelectedItem.ToString());
                            n.Kolicina = Convert.ToInt16(tbKolicina.Text);
                            n.TipNamestaja = TipNamestaja.getNaziv(cbTipNamestaja.SelectedItem.ToString());
                            n.Kolicina = Convert.ToInt16(tbKolicina.Text);
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
