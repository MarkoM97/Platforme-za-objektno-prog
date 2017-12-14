using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class Namestaj: INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv {get;set;}
        private double jedinicnaCena { get; set; }
        private int kolicina { get; set; }
        private string sifra { get; set; }
        private Akcija akcija { get; set; }
        private TipNamestaja tip { get; set; }
        private bool obrisan { get; set; }

        //Koristen za dodavnje 
        //Konstruktor za metodu dodavanja namestaja.Stavlja tip automatski na prvi iz liste tipova kako cbTip imao selectedItem i dodeljuje mu se nov id
        public Namestaj(int id) {
            this.id = id;
            this.tip = Aplikacija.Instance.Tipovi[0];
            this.akcija = null;
        }

        //Konstruktor koristen za izmenu
        public Namestaj(int id, string naziv, double jedinicnaCena, int kolicina, string sifra, Akcija akcija, TipNamestaja tip, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.jedinicnaCena = jedinicnaCena;
            this.kolicina = kolicina;
            this.sifra = sifra;
            if (akcija != null) { this.akcija = akcija; } else { this.akcija = null; }; 
            this.tip = tip;
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

        
        public double JedinicnaCena {
            get {
                //Racunanje popusta kod 1 kolicine namestaja
                double procenatSnizenja = 0;
                if (akcija != null)
                {
                    procenatSnizenja = ((akcija.Popust / 100) * jedinicnaCena);
                }
                return jedinicnaCena - procenatSnizenja;
            } set {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }

        
        //public int akcijaId;
        //[XmlIgnore]
        

        
        public int Kolicina {
            get {
                return kolicina;
            } set {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }

        
        public string Sifra {
            get {
                return sifra;
            } set {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }
        public Akcija Akcija
        {
            get
            {
                return akcija; 
                
            }
            set
            {
                akcija = value;
                OnPropertyChanged("Akcija");
                //Da bi promena akcije dinamicki menjala jedinicnu cenu namestaja bez osvezavanja dataGrida.
                OnPropertyChanged("JedinicnaCena");
            }
        }

        public TipNamestaja Tip
        {
            get
            {
                return tip;
            }
            set
            {
                tip = value;
                OnPropertyChanged("TipNamestaja");
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

        //public int tipNamestajaId;
        //[XmlIgnore]
        

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
