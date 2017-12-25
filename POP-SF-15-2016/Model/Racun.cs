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
    public class Racun : INotifyPropertyChanged
    {
        private int id { get; set; }
        private int korisnikId { get; set; }
        public Dictionary<Namestaj, int> namestaji { get; set; }
        //ObservableCollection<KeyValuePair<Namestaj, int>> namestaj { get; set; }
        private DateTime datumProdaje { get; set; }
        public ObservableCollection<DodatnaUsluga> usluge { get; set; }
        private string imeKupca { get; set; }
        private double ukupnaCena { get; set; }
        private bool obrisan { get; set; }

        public Racun()
        {
            //Da ne bi pocinjalo od 0001 godine
            this.DatumProdaje = DateTime.Now;
            namestaji = new Dictionary<Namestaj, int>();
            usluge = new ObservableCollection<DodatnaUsluga>();
        }

        public Racun(int id, Korisnik korisnik, DateTime datum, string imeKupca, double ukupnaCena, bool obrisan)
        {
            this.id = id;
            this.korisnikId = korisnik.Id;
            namestaji = new Dictionary<Namestaj, int>();
            //namestaj = new ObservableCollection<KeyValuePair<Namestaj, int>>();
            this.datumProdaje = datum;
            usluge = new ObservableCollection<DodatnaUsluga>();
            this.imeKupca = imeKupca;
            this.ukupnaCena = ukupnaCena;
            this.obrisan = obrisan;
        }

        public int Id
        {
            get
            {
                return id;
            }set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public Korisnik Korisnik
        {
            get
            {
                return Model.Korisnik.getById(korisnikId);
            }
            set
            {
                korisnikId = value.Id;
                OnPropertyChanged("Korisnik");
                OnPropertyChanged("korisnikId");
            }
        }

        public DateTime DatumProdaje
        {
            get
            {
                return datumProdaje;
            }set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        public string ImeKupca
        {
            get
            {
                return imeKupca;
            }set
            {
                imeKupca = value;
                OnPropertyChanged("ImeKupca");
            }
        }

        public double UkupnaCena
        {
            get
            {
                /*if (usluge != null)
                {
                    foreach (var x in usluge)
                    {
                        UkupnaCena += x.Cena;
                    }
                }
                foreach(var x in namestaji)
                {
                    if(x.Key.Akcija != null)
                    {

                    }
                    double popust = namestaj.akcija.popust;
                    procenatSnizenja = ((popust / 100) * cenaNamestaja);

                }
                Console.WriteLine(procenatSnizenja);
                Console.WriteLine(cenaUsluga);
                double ukupnaCena = (((cenaNamestaja - procenatSnizenja) * brojProdatihNamestaja) + cenaUsluga) + 2.52;*/
                return ukupnaCena;
            }set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Database
        public static ObservableCollection<Racun> GetAll()
        {
            var racuni = new ObservableCollection<Racun>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Racun WHERE Obrisan=0";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )



                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Racun"); //Izvrsava se query nad bazom


                foreach (DataRow row in ds.Tables["Racun"].Rows)
                {
                    /*Id INT PRIMARY KEY IDENTITY(1,1),
	                KorisnikId INT,
	                Namestaj VARCHAR(200),
	                DodatneUsluge VARCHAR(100),
	                ImeKupca VARCHAR(50),
	                UkupnaCena NUMERIC(9,2),
	                Obrisan BIT
	                FOREIGN KEY (KorisnikId) REFERENCES Korisnik(Id)*/
                    var racun = new Racun();
                    racun.Id = int.Parse(row["Id"].ToString());
                    racun.Korisnik = Model.Korisnik.getById(int.Parse(row["KorisnikId"].ToString()));
                    var namestajiString = row["Namestaj"].ToString();
                    Console.WriteLine("Namestaji string : " + namestajiString);
                    var dodatneString = row["DodatneUsluge"].ToString();
                    Console.WriteLine("Dodatne usluge string  : " + dodatneString);
                    racun.ImeKupca = (row["ZavrsetakAkcije"].ToString());
                    racun.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                    racun.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    racuni.Add(racun);

                }
                return racuni;
            }
        }


        public static void Update(racun n)
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
                        namestaj.ZavrsetakAkcije = n.ZavrsetakAkcije;
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
