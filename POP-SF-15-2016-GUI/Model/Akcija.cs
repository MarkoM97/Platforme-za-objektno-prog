using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class Akcija
    {
        public int id { get; set; }
        public string naziv { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", ElementName = "pocetakAkcije")]
        public DateTime pocetakAkcije { get; set; }
        public int trajanjeAkcije { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", ElementName = "zavrsetakAkcije")]
        public DateTime zavrsetakAkcije { get; set; }
        public double popust { get; set; }
        public bool obrisan { get; set; }


        public static Akcija GetID(int ID)
        {
            foreach (var Akcija in Projekat.instanca.Akcija)
            {
                Console.WriteLine(Akcija.id);
                if (Akcija.id.Equals(ID))
                {
                    return Akcija;
                }
            }
            return null;
        }


        public override string ToString()
        {
            return naziv;
        }

        public Akcija() { id = 0; naziv = ""; }
    }
}
