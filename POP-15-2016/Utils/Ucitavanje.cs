using POP_15_2016.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016.Utils
{
    public class Ucitavanje
    {
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

        public static void sacuvajNamestaj(string fileName)
        {
            using (var stram = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Namestaj>));
                xmls.Serialize(stram, Program.namestaj);
            }
        }

        internal static List<ProdajaNemestaja> ucitajProdaje(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<ProdajaNemestaja>));
                return (List<ProdajaNemestaja>)xmls.Deserialize(stream);
            }
        }

        public static List<Namestaj> ucitajNamestaj(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Namestaj>));
                return (List<Namestaj>)xmls.Deserialize(stream);
            }
        }
    }
}
