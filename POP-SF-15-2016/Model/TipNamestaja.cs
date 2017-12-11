using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_15_2016.Model
{
    public class TipNamestaja : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private bool obrisan { get; set; }

        public TipNamestaja(int id) {
            this.id = id;
        }

        public TipNamestaja(int id, string naziv, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.obrisan = obrisan;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public bool Obrisan
        {
            get
            {
                return obrisan;
            }set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public override string ToString()
        {
            return naziv;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
