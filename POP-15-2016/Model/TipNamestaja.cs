using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    [Serializable]
    public class TipNamestaja
    {
        public int Id { get; set; }

        public string naziv { get; set; }

        public bool Obrisan { get; set; }

        public TipNamestaja tipNamestaja { get; set; }
    }
}
