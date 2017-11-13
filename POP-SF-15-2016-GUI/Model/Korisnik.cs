using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class Korisnik
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public int tipKorisnika { get; set; }


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
     }
}
