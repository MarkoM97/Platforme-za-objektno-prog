using POP_SF_15_2016.Model;
using POP_SF_15_2016.UI;
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

namespace POP_SF_15_2016
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static int ulogovani = 1;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            foreach(var x in Aplikacija.Instance.Korisnici)
            {
                if(x.KorisnickoIme.Equals(tbKorisnickoIme.Text) && x.Lozinka.Equals(tbLozinka.Password.ToString()))
                {
                    if(x.Tip == Korisnik.tipKorisnika.ADMINISTRATOR)
                    {
                        MainWindow mejn = new MainWindow();
                        mejn.Show();
                    } else
                    {
                        ProdavacProzor pp = new ProdavacProzor();
                        pp.Show();
                    }
                    ulogovani = x.Id;
                    this.Close();
                    return;
                }
                
            }
            MessageBox.Show("Nisu dobri login podaci");
            tbKorisnickoIme.Clear();
            tbLozinka.Clear();
        }

        public static int getUlogovani()
        {
            return ulogovani;
        }
    }
}
