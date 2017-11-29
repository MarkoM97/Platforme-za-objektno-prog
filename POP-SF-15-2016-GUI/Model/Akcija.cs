using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class Akcija : INotifyPropertyChanged
    {
        private int id { get; set; }
        public int Id {get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string naziv { get; set; }
        public string Naziv { get { return naziv; } set { naziv = value; OnPropertyChanged("Naziv"); } }

        [XmlElement(DataType = "dateTime", ElementName = "pocetakAkcije")]
        private DateTime pocetakAkcije { get; set; }
        public DateTime PocetakAkcije { get { return pocetakAkcije; } set { pocetakAkcije = value; OnPropertyChanged("PocetakAkcije"); } }

        private int trajanjeAkcije { get; set; }
        public int TrajanjeAkcije { get { return trajanjeAkcije; } set { trajanjeAkcije = value;OnPropertyChanged("TrajanjeAkcije"); } }


        [XmlElement(DataType = "dateTime", ElementName = "zavrsetakAkcije")]
        private DateTime zavrsetakAkcije { get; set; }
        public DateTime ZavrsetakAkcije { get { return zavrsetakAkcije; } set { zavrsetakAkcije = value; OnPropertyChanged("ZavrsetakAkcije"); } }

        private double popust { get; set; }
        public double Popust { get { return popust; } set { popust = value; OnPropertyChanged("Popust"); } }

        private bool obrisan { get; set; }
        public bool Obrisan { get { return obrisan; } set { obrisan = value; OnPropertyChanged("Obrisan"); } }



        public static Akcija GetID(int ID)
        {
            foreach (var Akcija in Projekat.instanca.Akcija)
            {
                Console.WriteLine(Akcija.id);
                if (Akcija.id.Equals(ID))
                {
                    return Akcija;
                }
            }
            return null;
        }

        public static Akcija getNaziv(string naziv)
        {
            foreach(var akc in Projekat.instanca.Akcija)
            {
                if(akc.naziv.Equals(naziv))
                {
                    return akc;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return naziv;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
