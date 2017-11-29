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

        public static List<DodatnaUsluga> getIds(List<int> Ids)
        {
            List<DodatnaUsluga> ubacene = new List<DodatnaUsluga>();
            foreach(var dodatna in Projekat.instanca.DodatnaUsluga)
            {
                foreach(var idDodatne in Ids)
                {
                    if (dodatna.Id.Equals(idDodatne))
                    {
                        ubacene.Add(dodatna);
                    }
                }
            }

            return ubacene;
        }

        public static DodatnaUsluga getName(string name)
        {
            foreach (var dodatna in Projekat.instanca.DodatnaUsluga)
            {
                if(dodatna.naziv.Equals(name))
                {
                    return dodatna;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return naziv;
        }
    }
}
