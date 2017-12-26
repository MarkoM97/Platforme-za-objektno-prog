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
    public class Namestaj : ICloneable, INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private double jedinicnaCena { get; set; }


        private int kolicina { get; set; }
        private string sifra { get; set; }
        private int akcijaId { get; set; }
        private int tipNamestajaId { get; set; }
        private bool obrisan { get; set; }

        //Koristen za dodavnje 
        //Konstruktor za metodu dodavanja namestaja.Stavlja tip automatski na prvi iz liste tipova kako cbTip imao selectedItem i dodeljuje mu se nov id
        public Namestaj() {
            this.tipNamestajaId = 1;
        }

        //Konstruktor koristen za izmenu
        public Namestaj(int id, string naziv, double jedinicnaCena, int kolicina, string sifra, Akcija akcija, TipNamestaja tip, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.jedinicnaCena = jedinicnaCena;
            this.kolicina = kolicina;
            this.sifra = sifra;
            if (akcija != null) { this.akcijaId = akcija.Id; } else { this.akcijaId = 0; };
            this.tipNamestajaId = tip.Id;
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

        public double JedinicnaCena {
            get {
                return jedinicnaCena;

            } set {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }

        
        //public int akcijaId;
        //[XmlIgnore]
        

        
        public int Kolicina {
            get {
                return kolicina;
            } set {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }

        
        public string Sifra {
            get {
                return sifra;
            } set {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }
        public Akcija Akcija
        {
            get
            {
                return Akcija.getById(akcijaId); 
                
            }
            set
            {
                if (value != null) { akcijaId = value.Id; } else { akcijaId = 0; };
                OnPropertyChanged("Akcija");
                OnPropertyChanged("akcijaId");
                //Da bi promena akcije dinamicki menjala jedinicnu cenu namestaja bez osvezavanja dataGrida.
                OnPropertyChanged("JedinicnaCena");
                
            }
        }

        public TipNamestaja TipNamestaja
        {
            get
            {
                return TipNamestaja.getById(tipNamestajaId);
            }
            set
            {
                //TipNamestaja = value;
                tipNamestajaId = value.Id;
                OnPropertyChanged("tipNamestajaId");
                OnPropertyChanged("TipNamestaja");
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

        //public int tipNamestajaId;
        //[XmlIgnore]
        

        public override string ToString()
        {
            return naziv;
        }

        public static Namestaj getById(int id)
        {
            Console.WriteLine("Got id" + id);
            foreach(Namestaj n in Aplikacija.Instance.Namestaj)
            {
                Console.WriteLine("Id namestaja : " + n.Id);
                if(n.Id.Equals(id))
                {
                    Console.WriteLine(n.Naziv);
                    return n;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public object Clone()
        {
            Namestaj kopija = new Namestaj();
            kopija.Naziv = Naziv;
            kopija.Sifra = Sifra;
            kopija.TipNamestaja = TipNamestaja;
            kopija.Akcija = Akcija;
            kopija.Id = Id;
            kopija.JedinicnaCena = JedinicnaCena;
            kopija.Obrisan = Obrisan;
            kopija.Kolicina = Kolicina;
            return kopija;
        }

        #region Database
        public static ObservableCollection<Namestaj> GetAll()
        {
            var namestaji = new ObservableCollection<Namestaj>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )



                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Namestaj"); //Izvrsava se query nad bazom


                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var namestaj = new Namestaj();
                    namestaj.Id = int.Parse(row["Id"].ToString());
                    namestaj.Naziv = row["Naziv"].ToString();
                    namestaj.JedinicnaCena = double.Parse(row["JedinicnaCena"].ToString()); 
                    namestaj.Kolicina = int.Parse(row["Kolicina"].ToString());
                    namestaj.Sifra = row["Sifra"].ToString();
                    namestaj.akcijaId = int.Parse(row["AkcijaId"].ToString());
                    namestaj.tipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    namestaj.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    namestaji.Add(namestaj);
                }
                return namestaji;
            }
        }


        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj set Naziv=@Naziv,JedinicnaCena=@JedinicnaCena, Kolicina=@Kolicina, AkcijaId=@AkcijaId, TipNamestajaId=@TipNamestajaId, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("AkcijaId", n.akcijaId);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.tipNamestajaId);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.ExecuteNonQuery();
                foreach (var namestaj in Aplikacija.Instance.Namestaj)
                {
                    if (namestaj.Id == n.Id)
                    {
                        namestaj.Naziv = n.Naziv;
                        namestaj.Sifra = n.Sifra;
                        namestaj.kolicina = n.Kolicina;
                        namestaj.JedinicnaCena = n.JedinicnaCena;
                        namestaj.akcijaId = n.akcijaId;
                        namestaj.tipNamestajaId = n.tipNamestajaId;
                        namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }

        }


        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Namestaj (Naziv,JedinicnaCena, Kolicina, Sifra, AkcijaId, TipNamestajaId,Obrisan) VALUES(@Naziv,@JedinicnaCena,@Kolicina, @Sifra, @AkcijaId, @TipNamestajaId, @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("AkcijaId", n.akcijaId);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.tipNamestajaId);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                n.Id = newId;
            }
            Aplikacija.Instance.Namestaj.Add(n);
            return n;
        }

        public static void Delete(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                n.Obrisan = true;
                Aplikacija.Instance.Namestaj.Remove(n);
                Update(n);
            }
        }

        
        #endregion
    }
}
