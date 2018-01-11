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
        private ObservableCollection<Stavka> stavke { get; set; }
        private ObservableCollection<DodatnaUsluga> usluge { get; set; }
        private DateTime datumProdaje { get; set; }
        private string imeKupca { get; set; }
        private double ukupnaCena { get; set; }
        private bool obrisan { get; set; }

        public Racun()
        {
            this.korisnikId = LoginWindow.getUlogovani();
            this.ukupnaCena = 0;
            this.ImeKupca = "";
            //Da ne bi pocinjalo od 0001 godine
            this.DatumProdaje = DateTime.Now;
            stavke = new ObservableCollection<Stavka>();
            usluge = new ObservableCollection<DodatnaUsluga>();
        }

        public Racun(int id, Korisnik korisnik, DateTime datum, string imeKupca, double ukupnaCena, bool obrisan)
        {
            this.id = id;
            this.korisnikId = korisnik.Id;
            stavke = new ObservableCollection<Stavka>();
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
            } set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string stringNamestaja
        {
            get
            {
                string s = "";
                foreach(var x in Stavke)
                {
                    s += x.Namestaj.Naziv; 
                }
                return s;
            }
        }
      



        public ObservableCollection<DodatnaUsluga> Usluge
        {
            get {
                usluge = Model.DodatnaUsluga.GetForRacun(id);
                return usluge;
            } set {

                usluge = value;
                OnPropertyChanged("Usluge");
                OnPropertyChanged("UkupnaCena");
            }
        }

        
        public ObservableCollection<Stavka> Stavke
        {
            get
            {
               
                return Model.Stavka.GetForRacun(id);
            }
            set
            {
                stavke = value;
                OnPropertyChanged("Stavke");
                OnPropertyChanged("UkupnaCena");
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
            } set
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
            } set
            {
                imeKupca = value;
                OnPropertyChanged("ImeKupca");
            }
        }

        public double UkupnaCena
        {
            get
            {
                double ukupnaCenaRacuna = 0;
                if (Usluge != null)
                {
                    foreach (var x in Usluge)
                    {

                        ukupnaCenaRacuna += x.Cena;
                        
                    }
                }
                foreach(var x in Stavke)
                {
                    Console.WriteLine(x.Namestaj.Naziv);
                    Console.WriteLine("Naziv akcije: " + x.Namestaj.Akcija);
                    if(x.Namestaj.Akcija.Id == 0)
                    {
                        double procenatSnizenja = 0;
                        procenatSnizenja = (((x.Namestaj.Akcija).Popust / 100) * x.Namestaj.JedinicnaCena);
                        double nakonSnizenja =  Math.Round((x.Namestaj.JedinicnaCena - procenatSnizenja), 2);
                        ukupnaCenaRacuna = nakonSnizenja * x.BrojKomada;
                    } else
                    {
                        ukupnaCenaRacuna = x.Namestaj.JedinicnaCena * x.BrojKomada;
                    }

                }
                ukupnaCena = ukupnaCenaRacuna;
                return ukupnaCena;
            } set
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
            } set
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
                  
                    var racun = new Racun();
                    racun.Id = int.Parse(row["Id"].ToString());

                    racun.korisnikId = int.Parse(row["KorisnikId"].ToString());

                    racun.ImeKupca = (row["ImeKupca"].ToString());

                    racun.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());

                    racun.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());

                    racun.Obrisan = bool.Parse(row["Obrisan"].ToString());


                    racuni.Add(racun);

                }
                return racuni;
            }
        }


        public static void Update(Racun n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Racun set KorisnikId=@KorisnikId, ImeKupca=@ImeKupca, DatumProdaje=@DatumProdaje, UkupnaCena=@UkupnaCena, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("KorisnikId", n.korisnikId);
                cmd.Parameters.AddWithValue("ImeKupca", n.ImeKupca);
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("UkupnaCena", n.UkupnaCena);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.ExecuteNonQuery();
                foreach (var racun in Aplikacija.Instance.Racuni)
                {
                    if (racun.Id == n.Id)
                    {
                        racun.korisnikId = n.korisnikId;
                        racun.ImeKupca = n.ImeKupca;
                        racun.DatumProdaje = n.DatumProdaje;
                        racun.UkupnaCena = n.UkupnaCena;
                        racun.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }

        }


        public static Racun Create(Racun n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Racun (KorisnikId,ImeKupca, DatumProdaje, UkupnaCena, Obrisan) VALUES(@KorisnikId,@ImeKupca,@DatumProdaje, @UkupnaCena, @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("KorisnikId", n.korisnikId);
                cmd.Parameters.AddWithValue("ImeKupca", n.ImeKupca);
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("UkupnaCena", n.UkupnaCena);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                n.Id = newId;
            }
            Aplikacija.Instance.Racuni.Add(n);
            return n;
        }

        public static void Delete(Racun n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                n.Obrisan = true;
                Aplikacija.Instance.Racuni.Remove(n);
                Update(n);
            }
        }
        #endregion
    }
}
