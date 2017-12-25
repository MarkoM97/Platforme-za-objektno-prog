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


        public TipNamestaja() { }
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


        public static TipNamestaja getById(int id)
        {
            foreach(TipNamestaja tip in Aplikacija.Instance.Tipovi)
            {
                if(tip.Id.Equals(id))
                {
                    return tip;
                }
            }
            return null;
        }


        #region Database
        public static ObservableCollection<TipNamestaja> GetAll()
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
                    var tipNamestaja = new TipNamestaja();
                    tipNamestaja.Id = int.Parse(row["Id"].ToString());
                    tipNamestaja.Naziv = row["Naziv"].ToString();
                    tipNamestaja.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    tipoviNamestaja.Add(tipNamestaja);

                }
                return tipoviNamestaja;
            }
        }


        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE TipNamestaja set Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);
                cmd.ExecuteNonQuery();
                foreach(var tipNamestaja in Aplikacija.Instance.Tipovi)
                {
                    if(tipNamestaja.Id == tn.Id)
                    {
                        tipNamestaja.Naziv = tn.Naziv;
                        tipNamestaja.Obrisan = tn.Obrisan;
                        break;
                    }
                }
            }

        }


        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES(@Naziv, @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                tn.Id = newId;
            }
            Aplikacija.Instance.Tipovi.Add(tn);
            return tn;
        }

        public static void Delete(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                tn.Obrisan = true;
                Aplikacija.Instance.Tipovi.Remove(tn);
                Update(tn);
            }
        }
        #endregion
    }
}
