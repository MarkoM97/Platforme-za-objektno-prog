using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_15_2016.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private DateTime pocetakAkcije { get; set; }
        private DateTime zavrsetakAkcije { get; set; }
        private double popust { get; set; }
        private bool obrisan { get; set; }
        //public DatePicker pocetakAkcijePicker { get; set; }
        //public DatePicker zavrsetakAkcijePicker { get; set; }


        public Akcija(int id) {
            this.id = id;
            this.pocetakAkcije = DateTime.Now;
            this.zavrsetakAkcije = DateTime.Now;
        }

        public Akcija(int id, string naziv, DateTime pocetakAkcije, DateTime zavrsetakAkcije, double popust, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.pocetakAkcije = pocetakAkcije;
            this.zavrsetakAkcije = zavrsetakAkcije;
            this.popust = popust;
            this.obrisan = obrisan;
        }


        public int Id {
            get {
                return id;
            } set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv {
            get {
                return naziv;
            } set {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        //[XmlElement(DataType = "dateTime", ElementName = "pocetakAkcije")]

        public DateTime PocetakAkcije {
            get {
                return pocetakAkcije;
            } set {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }

        public DateTime ZavrsetakAkcije {
            get {
                return zavrsetakAkcije;
            } set {
                zavrsetakAkcije = value;
                OnPropertyChanged("ZavrsetakAkcije");
            }
        }
        
        public double Popust {
            get {
                return popust;
            } set {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public bool Obrisan {
            get {
                return obrisan;
            } set {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
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

