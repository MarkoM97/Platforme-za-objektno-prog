using POP_15_2016_GUI.Model;
using POP_SF_15_2016_GUI.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace POP_SF_15_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Namestaj> postojeciNamestaj = Projekat.instanca.Namestaj;
        ObservableCollection<Namestaj> pNamestaj = new ObservableCollection<Namestaj>(Projekat.instanca.Namestaj);
        Akcija tempAkcija = new Akcija();
        TipNamestaja tempTip = new TipNamestaja();
        public MainWindow()
        {
            InitializeComponent();
            lvNamestaj.ItemsSource = pNamestaj;
          
            /*
             * 
             * view = CollectionViewSource.GetDefaultView(Projekat.instance.Namestaj)
             * view.filter = NamestajFilter;
             * dgNamestaj.ItemsSource = view;
             * dgNamestaj.isSynh...
             
             * private bool NamestajFilter(object obj) {
             *  return !((Namestaj)obj.Obrisan);
             * }
             * **/ 
        }

        

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Id = Projekat.instanca.Namestaj.Count + 1,
                Naziv = "",
                Akcija = null,
                Kolicina = 0,
                JedinicnaCena = 0,
                Sifra = "",
                TipNamestaja = null
                
            };

            
            var NamestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            NamestajProzor.Show();
            this.Close();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = (Namestaj)lvNamestaj.SelectedItem;

            
            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
            this.Close();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)

        {
           var izabraniNamestaj = (Namestaj)lvNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                izabraniNamestaj.Obrisan = true;
                
            }
        }
    }
}
