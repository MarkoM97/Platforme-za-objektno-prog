using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class Korisnik: INotifyPropertyChanged
    {
        private int id { get; set; }
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string ime { get; set; }
        public string Ime { get { return ime; } set { ime = value; OnPropertyChanged("Ime"); } }

        private string korisnickoIme { get; set; }
        public string KorisnickoIme { get { return korisnickoIme; } set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); } }

        private string prezime { get; set; }
        public string Prezime { get { return prezime; } set { prezime = value; OnPropertyChanged("Prezime"); } }

        private string lozinka { get; set; }
        public string Lozinka { get { return lozinka; } set { lozinka = value; OnPropertyChanged("Lozinka"); } }

        private bool tipKorisnika { get; set; }
        public bool TipKorisnika { get { return tipKorisnika; } set { tipKorisnika = value; OnPropertyChanged("TipKorisnika"); } }

        private double cena { get; set; }
        public double Cena { get { return cena; } set { cena = value; OnPropertyChanged("Cena"); } }

        

        public static Korisnik getTip(int ID)
        {
            foreach(Korisnik kor in Projekat.instanca.korisnici)
            {
                if(ID.Equals(kor.tipKorisnika))
                {
                    return kor;
                }
            }
            return null;
        }

        public static Korisnik getID(int ID)
        {
            foreach (Korisnik kor in Projekat.instanca.korisnici)
            {
                if (ID.Equals(kor.id))
                {
                    return kor;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return ime;
        }
    }
}
