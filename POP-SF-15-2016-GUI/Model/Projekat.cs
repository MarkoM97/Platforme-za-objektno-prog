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
        public List<TipNamestaja> tipNamestaja = new List<TipNamestaja>();

        public List<Namestaj> Namestaj
        {
            get {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("Namestaj");
                return this.namestaj;
            }
            set {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("Namestaj", this.namestaj);
            }
        }

        /*public List<Korisnik> Korisnici
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
        }*/

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


    }
}
