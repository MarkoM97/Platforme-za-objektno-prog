using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016_GUI.Model
{
    [Serializable]
    public class Namestaj : INotifyPropertyChanged
    {


        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string naziv;
        public string Naziv { get { return naziv; } set { naziv = value; OnPropertyChanged("Naziv"); } }

        private double jedinicnaCena;
        public double JedinicnaCena { get { return jedinicnaCena; } set { jedinicnaCena = value; OnPropertyChanged("JedinicnaCena"); } }

        private Akcija akcija;
        public int akcijaId;
        [XmlIgnore]
        public Akcija Akcija {
            get
            {
                return Model.Akcija.GetID(akcijaId);
            }
            set
            {
                akcija = value;
                if (akcija == null)
                {
                    akcija = new Akcija()
                    {
                        Id = 0
                    };
                }
                akcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        private int kolicina;
        public int Kolicina { get { return kolicina; } set { kolicina = value; OnPropertyChanged("Kolicina"); } }

        private string sifra;
        public string Sifra { get { return sifra; } set { sifra = value; OnPropertyChanged("Sifra"); } }

        private bool obrisan;
        public bool Obrisan { get { return obrisan; } set { obrisan = value; OnPropertyChanged("Obrisan"); } }

        public int tipNamestajaId;
        private TipNamestaja tipNamestaja;
        [XmlIgnore]
        public TipNamestaja TipNamestaja {
            get {
                return Model.TipNamestaja.GetID(tipNamestajaId);
            }
            set {
                tipNamestaja = value;
                tipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        /*public override string ToString()
        {
            if (akcija != null)
            {
                return $"Naziv: {Naziv} | Cena: {JedinicnaCena} | tip namestaja: {TipNamestaja.Naziv} | Akcija: {Akcija.Naziv} | Obrisan : {Obrisan}";
            }
            else
            {
                return $"Naziv: {Naziv} | Cena: {JedinicnaCena} | tip namestaja: {TipNamestaja.Naziv} | Obrisan : {Obrisan}";
            }
        }*/

        public override string ToString()
        {
            return naziv;
        }

        public static Namestaj getID(int id)
        {
            foreach(var thing  in Projekat.instanca.Namestaj)
            {
                if (id.Equals(id))
                {
                    return thing;
                }
            }
            return null;
        }
        

        public static Namestaj getName(string name)
        {
            foreach(var t in Projekat.instanca.Namestaj)
            {
                if(t.Naziv.Equals(name))
                {
                    return t;
                }
            }
            return null;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
