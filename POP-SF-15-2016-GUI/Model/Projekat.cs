using POP_15_2016.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{
    public class Projekat
    {
        public static Projekat instanca { get; } = new Projekat();
        public List<Namestaj> namestaj = new List<Namestaj>();
        public List<Korisnik> korisnici = new List<Korisnik>();

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

        public List<Korisnik> Korisnici
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
                this.TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("TipNamestaja.xml");
                return this.TipNamestaja;
            }
            set
            {
                this.TipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("TipNamestaja.xml", this.TipNamestaja);
            }
        }


        public Projekat()
        {
        }
    }
}
