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
            //Ucitavanje iz serialajzera
            Namestaj = new ObservableCollection<Namestaj>();
            //Tipovi = new ObservableCollection<TipNamestaja>();
            Tipovi = TipNamestaja.getAll();
            Akcije = new ObservableCollection<Akcija>();
            Racuni = new ObservableCollection<Racun>();
            Korisnici = new ObservableCollection<Korisnik>();
            Usluge = new ObservableCollection<DodatnaUsluga>();
            popuniPodatke();
        }

        private void popuniPodatke()
        {
            DateTime s = DateTime.Now;
            DateTime.TryParse("2012/03/07", out s);
            TipNamestaja t1 = new TipNamestaja(0, "Radni delovi", false);
            Akcija a1 = new Akcija(0, "Prolecna", s, s, 15, false);
            Namestaj n1 = new Model.Namestaj(0, "Regal", 120, 2, "ss84", a1, t1, false);
            Korisnik k1 = new Korisnik(0, "Marko", "Martonosi", "", "", Korisnik.tipKorisnika.ADMINISTRATOR, false);
            Racun r1 = new Model.Racun(0, k1, s, "Radovan", 500, false);
            DodatnaUsluga d1 = new Model.DodatnaUsluga(0, "Montaza", 250, false);

            r1.namestaji.Add(n1, 1);
            Korisnici.Add(k1);
            Usluge.Add(d1);
            Namestaj.Add(n1);
            Akcije.Add(a1);
            //Akcije.Add(new Akcija());
            Tipovi.Add(t1);
            Racuni.Add(r1);
        }
    }
}
