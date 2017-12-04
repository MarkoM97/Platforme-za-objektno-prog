using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{

    [Serializable]
    public class Racun: INotifyPropertyChanged
    {
        [XmlElement(ElementName = "Id")]
        private int id { get; set; }
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        [XmlElement(ElementName = "prodavacId")]
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
        [XmlElement(ElementName = "namestajId")]
        public int namestajId { get; set; }
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
        [XmlElement(ElementName ="BrojKomada")]
        private int brojKomada{ get; set; }
        public int BrojKomada { get { return brojKomada; } set { brojKomada= value; OnPropertyChanged("BrojKomada"); } }

        [XmlElement(DataType = "dateTime", ElementName = "datumProdaje")]
        private DateTime datumProdaje { get; set; }
        public DateTime DatumProdaje { get { return datumProdaje; } set { datumProdaje= value; OnPropertyChanged("DatumProdaje"); } }

        [XmlIgnore]
        public string uslugeString { get; set; }
        [XmlArray("dodatneUsluge")]
        [XmlArrayItem("DodatnaUsluga")]
        public List<DodatnaUsluga> dodatneUsluge { get; set; }
        [XmlIgnore]
        public List<DodatnaUsluga> DodatneUsluge
        {
            get
            {
                foreach(var x in dodatneUsluge)
                {
                    uslugeString += x.Naziv + "|";
                }
                return dodatneUsluge;
            }
            set
            {

                dodatneUsluge = value;
                OnPropertyChanged("DodatneUsluge");
            }
        }
        /*[XmlIgnore]
        public string ispisniString { get; set; }
        public List<int> idDodatneUsluge { get; set; }
        private List<DodatnaUsluga> dodatneUsluge = new List<DodatnaUsluga>();
        [XmlIgnore]
        public List<DodatnaUsluga> DodatneUsluge {
            get {
                foreach(var x in idDodatneUsluge)
                {
                    dodatneUsluge.Add(Model.DodatnaUsluga.getId(x));
                    ispisniString += Model.DodatnaUsluga.getId(x).Naziv;
                }
                
                return dodatneUsluge;
                 
            } set {
                dodatneUsluge = value;
                OnPropertyChanged("DodatneUsluge");
            }
        }*/


        [XmlElement(ElementName = "ImeKupca")]
        private string imeKupca { get; set; }
        public string ImeKupca{ get { return imeKupca; } set { imeKupca= value; OnPropertyChanged("ImeKupca"); } }

        [XmlElement(ElementName = "UkupnaCena")]
        private int ukupnaCena { get; set; }
        public int UkupnaCena { get { return ukupnaCena; } set { ukupnaCena= value; OnPropertyChanged("UkupnaCena"); } }

        [XmlElement(ElementName = "Obrisan")]
        private bool obrisan { get; set; }
        public bool Obrisan { get { return obrisan; } set { obrisan = value;OnPropertyChanged("Obrisan"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
