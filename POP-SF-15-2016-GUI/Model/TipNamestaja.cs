using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class TipNamestaja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Obrisan { get; set; }


        public static TipNamestaja GetID(int ID)
        {
            foreach (var TipNamestaja in Projekat.instanca.TipNamestaja)
            {
                if (TipNamestaja.Id.Equals(ID))
                {
                    return TipNamestaja;
                }
            }
            return null;
        }

        public static TipNamestaja getNaziv(string naziv)
        {
            foreach(var tip in Projekat.instanca.TipNamestaja)
            {
                if(tip.Naziv.Equals(naziv))
                {
                    return tip;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }

    
}
