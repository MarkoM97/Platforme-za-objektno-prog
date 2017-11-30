using POP_15_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Windows;


namespace POP_SF_15_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for UslugeWindow.xaml
    /// </summary>
    public partial class UslugeWindow : Window
    {
        private DodatnaUsluga usluga;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public UslugeWindow(DodatnaUsluga usluga, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(usluga, operacija);
        }

        private void InicijalizujVrednosti(DodatnaUsluga dodatna, Operacija operacija)
        {
            this.operacija = operacija;
            this.usluga = dodatna;
            tbNaziv.Text = usluga.Naziv;
            tbCena.Text = usluga.Cena.ToString();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<DodatnaUsluga> postojaceDodatneUsluge= Projekat.instanca.DodatnaUsluga;
            if (tbNaziv.Text.Equals("") || tbCena.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaDodatnaUsluga = new DodatnaUsluga()
                    {
                        Id = Projekat.instanca.TipNamestaja.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = Convert.ToInt16(tbCena.Text)
                    };
                    postojaceDodatneUsluge.Add(novaDodatnaUsluga);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojaceDodatneUsluge)
                    {
                        if (n.Id == usluga.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.Cena = Convert.ToInt16(tbCena.Text);
                        }
                    }
                    break;
            }

            Projekat.instanca.DodatnaUsluga = postojaceDodatneUsluge;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }
    }
}
