using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Model
{
    [Serializable]
    public class Salon
    {
        
        public int Id { get; set; }
        public string naziv { get; set; }

        public string telefon { get; set; }
        public string adresa { get; set; }
        public string email { get; set; }

        public string adresaSajta{ get; set; }

        public int PIB { get; set; }

        public int maticniBroj { get; set; }

        public string brojZiroRacuna { get; set;}

        public bool obrisan { get; set; }

        public void save()
        {

        }
            } 
}
