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
    public class Korisnik: INotifyPropertyChanged
    {
        private int id { get; set; }
        private string ime { get; set; }
        private string prezime { get; set; }
        private string korisnickoIme { get; set; }
        private string lozinka { get; set; }
        public enum tipKorisnika { ADMINISTRATOR=0, PRODAVAC=1 }
        tipKorisnika tip;
        private bool obrisan { get; set; }

        public Korisnik()
        {
        }

        public Korisnik(int id, string ime, string prezime, string korisnickoIme, string lozinka, tipKorisnika tip, bool obrisan)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.tip = tip;
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

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            } set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        public string Lozinka
        {
            get
            {
                return lozinka;
            }set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        public tipKorisnika Tip
        {
            get
            {
                return tip;
            } set
            {
                tip = value;
                OnPropertyChanged("Tip");
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
            return ime + prezime;
        }

        public static Korisnik getById(int id)
        {
            foreach(var k in Aplikacija.Instance.Korisnici)
            {
                if(k.Id.Equals(id))
                {
                    return k;
                }
            }
            return null;
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        #region Database
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnici = new ObservableCollection<Korisnik>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )



                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Korisnik"); //Izvrsava se query nad bazom


                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var korisnik = new Korisnik();
                    korisnik.Id = int.Parse(row["Id"].ToString());
                    korisnik.Ime = row["Ime"].ToString();
                    korisnik.Prezime = row["Prezime"].ToString();
                    korisnik.KorisnickoIme = row["KorisnickoIme"].ToString();
                    korisnik.Lozinka = row["Lozinka"].ToString();
                    //Ne potreban else jer je default-na vrednost administrator
                    if (row["TipKorisnika"].ToString().Equals("True"))
                    {
                        korisnik.Tip = tipKorisnika.PRODAVAC;
                    }
                    korisnik.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    korisnici.Add(korisnik);

                }
                return korisnici;
            }
        }


        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Korisnik set Ime=@Ime,Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.Tip);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.ExecuteNonQuery();
                foreach (var korisnik in Aplikacija.Instance.Korisnici)
                {
                    if (korisnik.Id == k.Id)
                    {
                        korisnik.Ime = k.Ime;
                        korisnik.Prezime = k.Prezime;
                        korisnik.KorisnickoIme = k.KorisnickoIme;
                        korisnik.Lozinka = k.Lozinka;
                        korisnik.Tip = k.Tip;
                        korisnik.Obrisan = k.Obrisan;
                        break;
                    }
                }
            }

        }


        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Korisnik (Ime,Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES(@Ime,@Prezime,@KorisnickoIme, @Lozinka , @TipKorisnika, @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.Tip);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                k.Id = newId;
            }
            Aplikacija.Instance.Korisnici.Add(k);
            return k;
        }

        public static void Delete(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                k.Obrisan = true;
                Aplikacija.Instance.Korisnici.Remove(k);
                Update(k);
            }
        }
        #endregion


    }
}
