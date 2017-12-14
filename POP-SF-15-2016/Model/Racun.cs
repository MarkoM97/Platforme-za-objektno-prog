using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class Racun : INotifyPropertyChanged
    {
        private int id { get; set; }
        private Korisnik korisnik { get; set; }
        public Dictionary<Namestaj, int> namestaji { get; set; }
        //ObservableCollection<KeyValuePair<Namestaj, int>> namestaj { get; set; }
        private DateTime datumProdaje { get; set; }
        public ObservableCollection<DodatnaUsluga> usluge { get; set; }
        private string imeKupca { get; set; }
        private double ukupnaCena { get; set; }
        private bool obrisan { get; set; }

        public Racun(int id)
        {
            this.id = id;
            //Da ne bi pocinjalo od 0001 godine
            this.DatumProdaje = DateTime.Now;
            namestaji = new Dictionary<Namestaj, int>();
            usluge = new ObservableCollection<DodatnaUsluga>();
        }

        public Racun(int id, Korisnik korisnik, DateTime datum, string imeKupca, double ukupnaCena, bool obrisan)
        {
            this.id = id;
            this.korisnik = korisnik;
            namestaji = new Dictionary<Namestaj, int>();
            //namestaj = new ObservableCollection<KeyValuePair<Namestaj, int>>();
            this.datumProdaje = datum;
            usluge = new ObservableCollection<DodatnaUsluga>();
            this.imeKupca = imeKupca;
            this.ukupnaCena = ukupnaCena;
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

        public Korisnik Korisnik
        {
            get
            {
                return korisnik;
            }
            set
            {
                korisnik = value;
                OnPropertyChanged("Korisnik");
            }
        }

        public DateTime DatumProdaje
        {
            get
            {
                return datumProdaje;
            }set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        public string ImeKupca
        {
            get
            {
                return imeKupca;
            }set
            {
                imeKupca = value;
                OnPropertyChanged("ImeKupca");
            }
        }

        public double UkupnaCena
        {
            get
            {
                /*if (usluge != null)
                {
                    foreach (var x in usluge)
                    {
                        UkupnaCena += x.Cena;
                    }
                }
                foreach(var x in namestaji)
                {
                    if(x.Key.Akcija != null)
                    {

                    }
                    double popust = namestaj.akcija.popust;
                    procenatSnizenja = ((popust / 100) * cenaNamestaja);

                }
                Console.WriteLine(procenatSnizenja);
                Console.WriteLine(cenaUsluga);
                double ukupnaCena = (((cenaNamestaja - procenatSnizenja) * brojProdatihNamestaja) + cenaUsluga) + 2.52;*/
                return ukupnaCena;
            }set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
