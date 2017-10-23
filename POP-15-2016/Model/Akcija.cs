using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    class Akcija
    {
        public int id { get; set; }
        public DateTime pocetakAkcije { get;set }
        public DateTime zavrsetakAkcije { get; set; }
        public double popust { get; set; }
        public bool obrisan { get; set; }
    }
}
