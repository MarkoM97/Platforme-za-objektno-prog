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

        public int prodavacId {get;set;}
        private Korisnik prodavac { get; set; }
        [XmlIgnore]
        public Korisnik Prodavac{
            get {
                return Model.Korisnik.getID(prodavacId);
            } set {

                prodavac = value;
                prodavacId = prodavac.Id;
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


        /*[XmlIgnore]
        private string usluge;
        
        public string uslugeString {
            get {
                Console.WriteLine();
                
                return "5";

            } set {

            }
        }*/
        [XmlIgnore]
        public string ispisniString { get; set; }
        public int idDodatneUsluge { get; set; }
        private List<DodatnaUsluga> dodatneUsluge = new List<DodatnaUsluga>();
        [XmlIgnore]
        public List<DodatnaUsluga> DodatneUsluge {
            get {
                dodatneUsluge.Add(Model.DodatnaUsluga.getId(idDodatneUsluge));
                ispisniString += Model.DodatnaUsluga.getId(idDodatneUsluge).Naziv;
                return dodatneUsluge;
                 
            } set {
                dodatneUsluge = value;
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
