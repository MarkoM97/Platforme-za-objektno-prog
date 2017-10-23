using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    public class ProdajaNemestaja
    {
        public int Id{ get; set; }
        public int BrojKomadaNamestaja{ get; set; }
        public DateTime DatumProdaje { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }

        public double PDV { get; set; }
        public double  UkupnaCena { get; set; }
        public string  BrojRacuna { get; set; }

    }
}
