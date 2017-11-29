using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class TipNamestaja: INotifyPropertyChanged
    {
        private int id { get; set; }
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private bool obrisan { get; set; }
        public bool Obrisan { get { return obrisan; } set { obrisan= value; OnPropertyChanged("Obrisan"); } }

        private string naziv { get; set; }
        public string Naziv { get { return naziv; } set { naziv= value; OnPropertyChanged("Naziv"); } }



        public static TipNamestaja GetID(int ID)
        {
            foreach (var TipNamestaja in Projekat.instanca.TipNamestaja)
            {
                if (TipNamestaja.Id.Equals(ID))
                {
                    return TipNamestaja;
                }
            }
            return null;
        }

        public static TipNamestaja getNaziv(string naziv)
        {
            foreach(var tip in Projekat.instanca.TipNamestaja)
            {
                if(tip.Naziv.Equals(naziv))
                {
                    return tip;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return Naziv;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    
}
