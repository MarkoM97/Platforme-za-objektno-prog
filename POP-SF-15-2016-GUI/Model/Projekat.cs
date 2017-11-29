using POP_15_2016.Utils;
using System.Collections.Generic;


namespace POP_15_2016_GUI.Model
{
    public class Projekat
    {
        public static Projekat instanca { get; } = new Projekat();
        public List<Namestaj> namestaj = new List<Namestaj>();
        public List<Korisnik> korisnici = new List<Korisnik>();
        public List<TipNamestaja> tipNamestaja = new List<TipNamestaja>();
        public List<Akcija> akcija = new List<Akcija>();
        public List<DodatnaUsluga> dodatne = new List<DodatnaUsluga>();
        public List<Racun> racuni = new List<Racun>();

        public List<Namestaj> Namestaj
        {
            get {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("Namestaj.xml");
                return this.namestaj;
            }
            set {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("Namestaj.xml", this.namestaj);
            }
        }

        public List<Racun> Racun
        {
            get
            {
                this.racuni = GenericSerializer.Deserialize<Racun>("Racuni.xml");
                return this.racuni;
            }
            set
            {
                this.racuni = value;
                GenericSerializer.Serialize<Racun>("Racuni.xml", this.racuni);
            }
        }

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                this.dodatne = GenericSerializer.Deserialize<DodatnaUsluga>("DodatneUsluge.xml");
                return this.dodatne;
            }
            set
            {
                this.dodatne = value;
                GenericSerializer.Serialize<DodatnaUsluga>("DodatneUsluge.xml", this.dodatne);
            }
        }

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnici = GenericSerializer.Deserialize<Korisnik>("Korisnik.xml");
                return this.korisnici;
            }
            set
            {
                this.korisnici = value;
                GenericSerializer.Serialize<Korisnik>("Korisnik.xml", this.korisnici);
            }
        }

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("TipNamestaja.xml");
                return this.tipNamestaja;
            }
            set
            {
                this.tipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("TipNamestaja.xml", this.tipNamestaja);
            }
        }

        public List<Akcija> Akcija
        {
            get
            {
                this.akcija = GenericSerializer.Deserialize<Akcija>("Akcija.xml");
                return this.akcija;
            }
            set
            {
                this.akcija = value;
                GenericSerializer.Serialize<Akcija>("Akcija.xml", this.akcija);
            }
        }


    }
}
