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
    public class Namestaj
    {
        public int Id{ get; set; }
        public string naziv{ get; set; }
        public double jedinicnaCena { get; set; }
        public Akcija akcija { get; set; }
        public int kolicina { get; set; }
        public string sifra { get; set; }
        public bool obrisan { get; set; }
        public TipNamestaja tipNamestaja { get; set;}
    }

    //public static void sacuvajNamestaj(string fileName)
    //{
    //    using (var stram = new FileStream(fileName, FileMode.Open))
    //    {
    //        XmlSerializer xmls = new XmlSerializer(typeof(List<Namestaj>));
    //        xmls.Serialize(stram, Program.korisnici);
    //    }
    //}

    //public static List<Namestaj> ucitajNamestaj(string fileName)
    //{
    //    using (var stream = new FileStream(fileName, FileMode.Open))
    //    {
    //        XmlSerializer xmls = new XmlSerializer(typeof(List<Namestaj>));
    //        return (List<Namestaj>)xmls.Deserialize(stream);
    //    }
    //}
}
