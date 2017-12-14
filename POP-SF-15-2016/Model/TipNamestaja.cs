using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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


        #region Database
        public static ObservableCollection<TipNamestaja> getAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )

                

                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "TipNamestaja"); //Izvrsava se query nad bazom


                foreach(DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tipNamestaja = new TipNamestaja(int.Parse(row["Id"].ToString()));
                    tipNamestaja.Naziv = row["Naziv"].ToString();
                    tipNamestaja.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    tipoviNamestaja.Add(tipNamestaja);

                }
                return tipoviNamestaja;
            }
        }
        #endregion
    }
}
