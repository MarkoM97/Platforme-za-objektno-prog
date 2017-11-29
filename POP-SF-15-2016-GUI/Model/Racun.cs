using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class Racun: INotifyPropertyChanged
    {
        private string id { get; set; }
        public string Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private Korisnik prodavac { get; set; }
        public Korisnik Prodavac { get { return prodavac; } set { prodavac = value; OnPropertyChanged("Prodavac"); } }

        private Namestaj prodatiNamestaj { get; set; }
        public Namestaj ProdatiNamestaj { get { return prodatiNamestaj; } set { prodatiNamestaj= value; OnPropertyChanged("ProdatiNamestaj"); } }

        private int brojKomada{ get; set; }
        public int BrojKomada { get { return brojKomada; } set { brojKomada= value; OnPropertyChanged("BrojKomada"); } }

        [XmlElement(DataType = "dateTime", ElementName = "datumProdaje")]
        private DateTime datumProdaje { get; set; }
        public DateTime DatumProdaje { get { return datumProdaje; } set { datumProdaje= value; OnPropertyChanged("DatumProdaje"); } }

        private List<DodatnaUsluga> dodatneUsluge { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get { return dodatneUsluge; } set { dodatneUsluge= value; OnPropertyChanged("DodatneUsluge"); } }

        private string imeKupca { get; set; }
        public string ImeKupca{ get { return imeKupca; } set { imeKupca= value; OnPropertyChanged("ImeKupca"); } }

        private string prezimeKupca{ get; set; }
        public string PrezimeKupca { get { return prezimeKupca; } set { prezimeKupca= value; OnPropertyChanged("PrezimeKupca"); } }

        private int ukupnaCena { get; set; }
        public int UkupnaCena { get { return ukupnaCena; } set { ukupnaCena= value; OnPropertyChanged("UkupnaCena"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
