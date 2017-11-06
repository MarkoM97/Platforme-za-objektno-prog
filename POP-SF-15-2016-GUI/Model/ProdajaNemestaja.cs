using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class ProdajaNemestaja
    {
        public int Id { get; set; }
        public Korisnik prodavac { get; set; }
        public Namestaj prodatiNamestaj { get; set; }
        public int BrojKomadaNamestaja { get; set; }
        public DateTime DatumProdaje { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public string imeKupca { get; set; }
        public string prezimeKupca { get; set; }
        public double  UkupnaCena { get; set; }

    }
}
