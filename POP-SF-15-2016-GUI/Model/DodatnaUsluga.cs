using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class DodatnaUsluga: INotifyPropertyChanged
    {
        private int id{ get; set; }
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string naziv { get; set; }
        public string Naziv { get { return naziv; }  set { naziv = value; OnPropertyChanged("Naziv"); } }

        private bool obrisan{ get; set; }
        public bool Obrisan { get { return obrisan; } set { obrisan = value; OnPropertyChanged("Obrisan"); } }

        private double cena { get; set; }
        public double Cena { get { return cena; } set { cena = value; OnPropertyChanged("Cena"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
