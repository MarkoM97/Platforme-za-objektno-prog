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

        public int korisnikId {get;set;}
        private Korisnik prodavac { get; set; }
        [XmlIgnore]
        public Korisnik Prodavac{
            get {
                return Model.Korisnik.getID(korisnikId);
            } set {

                prodavac = value;
                korisnikId = prodavac.Id;
                OnPropertyChanged("Prodavac");
            } 
}

        public int namestajId;
        private Namestaj prodatiNamestaj { get; set; }
        [XmlIgnore]
        public Namestaj ProdatiNamestaj {
            get {
                return Model.Namestaj.getID(namestajId);
            } set {
                prodatiNamestaj = value;
                namestajId = prodatiNamestaj.Id;
                OnPropertyChanged("ProdatiNamestaj");
            }
        }

        private int brojKomada{ get; set; }
        public int BrojKomada { get { return brojKomada; } set { brojKomada= value; OnPropertyChanged("BrojKomada"); } }

        [XmlElement(DataType = "dateTime", ElementName = "datumProdaje")]
        private DateTime datumProdaje { get; set; }
        public DateTime DatumProdaje { get { return datumProdaje; } set { datumProdaje= value; OnPropertyChanged("DatumProdaje"); } }

        public List<int> dodateUslugeIds { get; set; }
        private List<DodatnaUsluga> dodatneUsluge { get; set; }
        [XmlIgnore]
        public List<DodatnaUsluga> DodatneUsluge {
            get {
                return Model.DodatnaUsluga.getIds(dodateUslugeIds);
            } set {
                dodatneUsluge = value;
                foreach(var d in dodatneUsluge)
                {
                    dodateUslugeIds.Add(d.Id);
                }
                OnPropertyChanged("DodatneUsluge");
            }
        }

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
