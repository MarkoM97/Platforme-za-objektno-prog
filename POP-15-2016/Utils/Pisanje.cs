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
    public class Pisanje
    {
        public static void sacuvajNamestaj(string fileName)
        {
            using (var stram = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Namestaj>));
                xmls.Serialize(stram, Program.namestaj);
            }
        }

        public static void sacuvajKorisnike(string fileName)
        {
            using (var stram = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Korisnik>));
                xmls.Serialize(stram, Program.korisnici);
            }
        }

        public static void sacuvajProdaje(string fileName)
        {
            using (var stram = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<ProdajaNemestaja>));
                xmls.Serialize(stram, Program.prodati);
            }
        }
    }
}
