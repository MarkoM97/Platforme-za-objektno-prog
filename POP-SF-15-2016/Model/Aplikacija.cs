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
            Console.WriteLine("Proso");
            Akcije = Model.Akcija.GetAll();
            Console.WriteLine("Proso");
            Namestaj = Model.Namestaj.GetAll();
            Console.WriteLine("Proso");
            Korisnici = Model.Korisnik.GetAll();
            Console.WriteLine("Proso");
            Usluge = Model.DodatnaUsluga.GetAll();
            Console.WriteLine("Proso");
            Racuni = Model.Racun.GetAll();
            Console.WriteLine("Proso");
        }

        public static ObservableCollection<Akcija> filtriraneAkcije()
        {
            ObservableCollection<Akcija> storage = new ObservableCollection<Akcija>();
            foreach (var x in Instance.Akcije)
            {
                if (x.Obrisan == false && x.Naziv != "" && x.ZavrsetakAkcije > DateTime.Now)
                {
                    storage.Add(x);
                }
            }
            return storage;
        }

        public static ObservableCollection<Namestaj> filtriranNamestaj()
        {
            ObservableCollection<Namestaj> storage = new ObservableCollection<Namestaj>();
            foreach (var x in Instance.Namestaj)
            {
                if (x.Obrisan == false && x.TipNamestaja.Obrisan == false)
                {
                    storage.Add(x);
                }
            }
            return storage;
        }

        public static ObservableCollection<TipNamestaja> filtriraniTipovi()
        {
            ObservableCollection<TipNamestaja> storage = new ObservableCollection<TipNamestaja>();
            foreach(var x in Instance.Tipovi)
            {
                if(x.Obrisan == false)
                {
                    storage.Add(x);
                }
            }
            return storage;
        }

        public static ObservableCollection<Korisnik> filtriraniKorisnici()
        {
            ObservableCollection<Korisnik> storage = new ObservableCollection<Korisnik>();
            foreach(var x in Instance.Korisnici)
            {
                if(x.Obrisan == false)
                {
                    storage.Add(x);
                }
            }
            return storage;
        }
    }
}
