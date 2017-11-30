using POP_15_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Windows;


namespace POP_SF_15_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        private Akcija akcija;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public AkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();
            inicijalizujVrednosti(akcija, operacija);
        }

        private void inicijalizujVrednosti(Akcija akcija, Operacija operacija)
        {
            this.operacija = operacija;
            this.akcija = akcija;
            tbNaziv.Text = akcija.Naziv;
            tbPocetak.Text = akcija.PocetakAkcije.ToString();
            tbTrajanje.Text = akcija.TrajanjeAkcije.ToString();
            tbZavrsetak.Text = akcija.ZavrsetakAkcije.ToString();
            tbPopust.Text = akcija.Popust.ToString();
        }
        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<Akcija> postojeceAkcije = Projekat.instanca.Akcija;
            if (tbNaziv.Text.Equals("") || tbPopust.Text.Equals("") || tbPocetak.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaAkcija = new Akcija()
                    {
                        Id = Projekat.instanca.Akcija.Count + 1,
                        Naziv = tbNaziv.Text,
                        PocetakAkcije = Convert.ToDateTime(tbPocetak.Text),
                        TrajanjeAkcije = Convert.ToInt16(tbTrajanje.Text),
                        ZavrsetakAkcije = Convert.ToDateTime(tbZavrsetak.Text),
                        Popust = Convert.ToInt16(tbPopust.Text),
                    };
                    postojeceAkcije.Add(novaAkcija);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeceAkcije)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.PocetakAkcije = Convert.ToDateTime(tbPocetak.Text);
                            n.TrajanjeAkcije = Convert.ToInt16(tbTrajanje.Text);
                            n.ZavrsetakAkcije = Convert.ToDateTime(tbZavrsetak.Text);
                            n.Popust = Convert.ToInt16(tbPopust.Text);
                        }
                    }
                    break;
            }

            Projekat.instanca.Akcija = postojeceAkcije;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }
    }
}
