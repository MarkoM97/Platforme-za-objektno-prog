using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    public class Namestaj
    {
        public int Id{ get; set; }

        public string naziv{ get; set; }
        public double jedinicnaCena { get; set; }
        public int kolicina { get; set; }

        public string tipNamestaja { get; set;}
    }
}
