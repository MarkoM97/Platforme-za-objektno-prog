using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class Korisnik: INotifyPropertyChanged
    {
        private int id { get; set; }
        private string ime { get; set; }
        private string prezime { get; set; }
        private string korisnickoIme { get; set; }
        private string lozinka { get; set; }
        public enum tipKorisnika { ADMINISTRATOR, PRODAVAC }
        tipKorisnika tip;
        private bool obrisan { get; set; }

        public Korisnik(int id)
        {
            this.id = id;
        }

        public Korisnik(int id, string ime, string prezime, string korisnickoIme, string lozinka, tipKorisnika tip, bool obrisan)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.tip = tip;
            this.obrisan = obrisan;
        }

        public int Id
        {
            get
            {
                return id;
            } set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            } set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        public string Lozinka
        {
            get
            {
                return lozinka;
            }set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        public tipKorisnika Tip
        {
            get
            {
                return tip;
            } set
            {
                tip = value;
                OnPropertyChanged("Tip");
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

        public override string ToString()
        {
            return ime + prezime;
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
