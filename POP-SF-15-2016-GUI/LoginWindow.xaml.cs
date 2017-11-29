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

namespace POP_SF_15_2016_GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {


            //foreach(Korisnik kor in Projekat.instanca.Korisnik)
            //{
                //if(kor.KorisnickoIme.Equals(tbKorisnicko.Text) && kor.Lozinka.Equals(tbLozinka.Text))
                //{
                    MainWindow mejn = new MainWindow();
                    mejn.Show();
                    this.Close();
                    return;
                //}  
            //}
           // MessageBox.Show("Nisu dobri login podaci");
            //tbKorisnicko.Clear();
            //tbLozinka.Clear();

        }
    }
}
