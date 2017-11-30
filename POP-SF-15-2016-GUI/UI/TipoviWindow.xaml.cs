using POP_15_2016_GUI.Model;
using System.Collections.Generic;
using System.Windows;

namespace POP_SF_15_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for TipoviWindow.xaml
    /// </summary>
    public partial class TipoviWindow : Window
    {
        
        private TipNamestaja tip;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public TipoviWindow(TipNamestaja tip, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(tip, operacija);
        }

        private void InicijalizujVrednosti(TipNamestaja tip, Operacija operacija)
        {
            this.operacija = operacija;
            this.tip = tip;
            tbNaziv.Text = tip.Naziv;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<TipNamestaja> postojaciTipovi= Projekat.instanca.TipNamestaja;
            if (tbNaziv.Text.Equals(""))
            {
                MessageBox.Show("Podaci nisu dobro uneti, pokusajte ponovo ");
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviTip = new TipNamestaja()
                    {
                        Id = Projekat.instanca.TipNamestaja.Count + 1,
                        Naziv = tbNaziv.Text,
                    };
                    postojaciTipovi.Add(noviTip);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojaciTipovi)
                    {
                        if (n.Id == tip.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                        }
                    }
                    break;
            }

            Projekat.instanca.TipNamestaja = postojaciTipovi;
            MainWindow mejn = new MainWindow();
            mejn.Show();
            this.Close();
        }
    }
}

