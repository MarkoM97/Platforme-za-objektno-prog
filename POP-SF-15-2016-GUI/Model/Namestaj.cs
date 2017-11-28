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
        private ObservableCollection<Namestaj> namestaji = new ObservableCollection<Namestaj>();

        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string naziv;
        public string Naziv { get { return naziv; } set { naziv = value; OnPropertyChanged("Naziv"); } }

        private double jedinicnaCena;
        public double JedinicnaCena { get { return jedinicnaCena; } set { jedinicnaCena = value; OnPropertyChanged("JedinicnaCena"); } }

        private Akcija akcija;
        public Akcija Akcija { get { return akcija; } set { akcija = value;OnPropertyChanged("Akcija"); } }

        private int kolicina;
        public int Kolicina { get { return kolicina; } set { kolicina = value; OnPropertyChanged("Kolicina"); } }

        private string sifra;
        public string Sifra { get { return sifra; } set { sifra = value;OnPropertyChanged("Sifra"); } }

        private bool obrisan;
        public bool Obrisan { get { return obrisan; } set { obrisan = value;OnPropertyChanged("Obrisan"); } }

        private TipNamestaja tipNamestaja;
        public TipNamestaja TipNamestaja { get { return tipNamestaja; } set { tipNamestaja = value;OnPropertyChanged("TipNamestaja"); } }

        public override string ToString()
        {
            if (akcija != null)
            {
                return $"Naziv: {Naziv} | Cena: {JedinicnaCena} | tip namestaja: {TipNamestaja.Naziv} | Akcija: {Akcija.naziv} | Obrisan : {Obrisan}";
            }else
            {
                return $"Naziv: {Naziv} | Cena: {JedinicnaCena} | tip namestaja: {TipNamestaja.Naziv} | Obrisan : {Obrisan}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
