using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    public class DodatnaUsluga
    {
        public int Id{ get; set; }

        public string Naziv { get; set; }
        public bool Obrisan{ get; set; }
        public int Cena { get; set; }
    }
}
