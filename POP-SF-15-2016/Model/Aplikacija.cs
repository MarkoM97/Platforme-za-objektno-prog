using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class Aplikacija
    {
        public int ulogovaniKorisnikId { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<TipNamestaja> Tipovi { get; set; }
        public ObservableCollection<Racun> Racuni { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<DodatnaUsluga> Usluge { get; set; }

        private static Aplikacija instance = new Aplikacija();

        public static Aplikacija Instance
        {
            get
            {
                return instance;
            }
        }

        private Aplikacija()
        {
            //Problem: Poziv getById funkcije iz Racuna za namestaj ne radi tacnije sputava ucitavanje namestaja. Pitati za razlog. Da li je to zbog regije?
            Tipovi = TipNamestaja.GetAll();
            Akcije = Model.Akcija.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            Korisnici = Model.Korisnik.GetAll();
            Usluge = Model.DodatnaUsluga.GetAll();
            Racuni = Model.Racun.GetAll();
            
        }
    }
}
