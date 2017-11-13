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
    public class Namestaj
    {
        public int Id{ get; set; }
        public string naziv{ get; set; }
        public double jedinicnaCena { get; set; }
        public int akcija { get; set; }
        public int kolicina { get; set; }
        public string sifra { get; set; }
        public bool obrisan { get; set; }
        public int tipNamestaja { get; set;}

        public override string ToString()
        {
            if (akcija != 0)
            {
                return $"Naziv: {naziv} | Cena: {jedinicnaCena} | tip namestaja: {TipNamestaja.GetID(tipNamestaja).Naziv} | Akcija: {Akcija.GetID(akcija).naziv}";
            }else
            {
                return $"Naziv: {naziv} | Cena: {jedinicnaCena} | tip namestaja: {TipNamestaja.GetID(tipNamestaja).Naziv}";
            }
        }
    }

}
