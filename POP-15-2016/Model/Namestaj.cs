using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
