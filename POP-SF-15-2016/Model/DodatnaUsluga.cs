using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private double cena { get; set; }
        private bool obrisan { get; set; }

        public DodatnaUsluga(int id)
        {
            this.id = id;
        }

        public DodatnaUsluga(int id, string naziv, double cena, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.cena = cena;
            this.obrisan = obrisan;
        }

        public int Id
        {
            get
            {
                return id;
            }set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public double Cena
        {
            get
            {
                return cena;
            }set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public bool Obrisan
        {
            get
            {
                return obrisan;
            }set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
