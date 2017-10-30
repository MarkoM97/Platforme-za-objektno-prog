using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016.Model
{
    [Serializable]
    public class Korisnik
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnickoime { get; set; }
        public string lozinka { get; set; }
        public TipKorisnika tipKorisnika { get; set; }

        public static void sacuvajKorisnike(string fileName)
        {
            using (var stram = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Korisnik>));
                xmls.Serialize(stram, Program.korisnici);
            }
        }

        public static List<Korisnik> ucitajKorisnike(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Korisnik>));
                return (List<Korisnik>)xmls.Deserialize(stream);
            }
        }
    }
}
