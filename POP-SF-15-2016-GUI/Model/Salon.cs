using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class Salon: INotifyPropertyChanged
    {

        private string id { get; set; }
        public string Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string telefon { get; set; }
        public string Telefon { get { return telefon; } set { telefon= value; OnPropertyChanged("Telefon"); } }

        private string adresa { get; set; }
        public string Adresa { get { return adresa; } set { adresa= value; OnPropertyChanged("Adresa"); } }

        private string email { get; set; }
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }

        private string adresaSajta { get; set; }
        public string AdresaSajta { get { return adresaSajta; } set { adresaSajta= value; OnPropertyChanged("AdresaSajta"); } }

        private int pib { get; set; }
        public int PIB { get { return pib; } set { pib= value; OnPropertyChanged("PIB"); } }

        private int maticniBroj { get; set; }
        public int MaticniBroj { get { return maticniBroj; } set { maticniBroj= value; OnPropertyChanged("MaticniBroj"); } }

        private string brojZiroRacuna { get; set; }
        public string BrojZiroRacuna { get { return brojZiroRacuna; } set { brojZiroRacuna= value; OnPropertyChanged("BrojZiroRacuna"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void save()
        {

        }
            } 
}
