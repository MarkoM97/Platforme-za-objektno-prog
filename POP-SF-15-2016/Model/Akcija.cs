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
using System.Windows.Controls;

namespace POP_SF_15_2016.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private DateTime pocetakAkcije { get; set; }
        private DateTime zavrsetakAkcije { get; set; }
        private double popust { get; set; }
        private bool obrisan { get; set; }

        //Dummy akcija
        public Akcija() { }
        
        public Akcija(int id) {
            this.id = id;
            this.pocetakAkcije = DateTime.Now;
            this.zavrsetakAkcije = DateTime.Now;
        }

        public Akcija(int id, string naziv, DateTime pocetakAkcije, DateTime zavrsetakAkcije, double popust, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.pocetakAkcije = pocetakAkcije;
            this.zavrsetakAkcije = zavrsetakAkcije;
            this.popust = popust;
            this.obrisan = obrisan;
        }


        public int Id {
            get {
                return id;
            } set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv {
            get {
                return naziv;
            } set {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        //[XmlElement(DataType = "dateTime", ElementName = "pocetakAkcije")]

        public DateTime PocetakAkcije {
            get {
                return pocetakAkcije;
            } set {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }

        public DateTime ZavrsetakAkcije {
            get {
                return zavrsetakAkcije;
            } set {
                zavrsetakAkcije = value;
                OnPropertyChanged("ZavrsetakAkcije");
            }
        }
        
        public double Popust {
            get {
                return popust;
            } set {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public bool Obrisan {
            get {
                return obrisan;
            } set {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public override string ToString()
        {
            return Naziv;
        }

        public static Akcija getById(int id)
        {
            foreach(Akcija akcija in Aplikacija.Instance.Akcije)
            {
                if(akcija.Id.Equals(id))
                {
                    return akcija;
                }
            }
            return null;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        #region Database
        public static ObservableCollection<Akcija> GetAll()
        {
            var akcije = new ObservableCollection<Akcija>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )



                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Akcija"); //Izvrsava se query nad bazom


                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var akcija = new Akcija();
                    akcija.Id = int.Parse(row["Id"].ToString());
                    akcija.Naziv = row["Naziv"].ToString();
                    akcija.PocetakAkcije = DateTime.Parse(row["PocetakAkcije"].ToString());
                    akcija.ZavrsetakAkcije = DateTime.Parse(row["ZavrsetakAkcije"].ToString());
                    akcija.Popust = int.Parse(row["Popust"].ToString());
                    akcija.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    akcije.Add(akcija);

                }
                return akcije;
            }
        }


        public static void Update(Akcija n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Akcija set Naziv=@Naziv,PocetakAkcije=@PocetakAkcije, ZavrsetakAkcije=@ZavrsetakAkcije, Popust=@Popust, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("PocetakAkcije", n.PocetakAkcije);
                cmd.Parameters.AddWithValue("ZavrsetakAkcije", n.ZavrsetakAkcije);
                cmd.Parameters.AddWithValue("Popust", n.Popust);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.ExecuteNonQuery();
                foreach (var namestaj in Aplikacija.Instance.Akcije)
                {
                    if (namestaj.Id == n.Id)
                    {
                        namestaj.Naziv = n.Naziv;
                        namestaj.PocetakAkcije = n.PocetakAkcije;
                        namestaj.ZavrsetakAkcije= n.ZavrsetakAkcije;
                        namestaj.Popust = n.Popust;
                        namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }

        }


        public static Akcija Create(Akcija n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Akcija (Naziv,PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES(@Naziv,@PocetakAkcije,@ZavrsetakAkcije, @Popust , @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("PocetakAkcije", n.PocetakAkcije);
                cmd.Parameters.AddWithValue("ZavrsetakAkcije", n.ZavrsetakAkcije);
                cmd.Parameters.AddWithValue("Popust", n.Popust);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                n.Id = newId;
            }
            Aplikacija.Instance.Akcije.Add(n);
            return n;
        }

        public static void Delete(Akcija n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                n.Obrisan = true;
                Aplikacija.Instance.Akcije.Remove(n);
                Update(n);
            }
        }
        #endregion
    }

}

