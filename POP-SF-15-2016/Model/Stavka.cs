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
    public class Stavka : INotifyPropertyChanged
    {
        private int namestajId { get; set; }
        private int brojKomada { get; set; }


        public Stavka()
        {

        }
        public Stavka(Namestaj namestaj, int kolicina)
        {
            this.namestajId = namestaj.Id;
            this.brojKomada = kolicina;
        }

        public Namestaj Namestaj
        {
            get
            {
                return Model.Namestaj.getById(namestajId);
            } set
            {
                namestajId = value.Id;
                OnPropertyChanged("Namestaj");
                OnPropertyChanged("namestajId");
            }
        }

        public int BrojKomada
        {
            get
            {
                return brojKomada;
            }set
            {
                brojKomada = value;
                OnPropertyChanged("BrojKomada");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Database

        public static ObservableCollection<Stavka> GetForRacun(int id)
        {
            ObservableCollection<Stavka> stavke = new ObservableCollection<Stavka>();
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM StavkeRacuna WHERE RacunId=@RacunId";
                cmd.Parameters.AddWithValue("RacunId", id);
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                DataAdapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                DataAdapter.Fill(ds, "StavkeRacuna");

                foreach(DataRow row in ds.Tables["StavkeRacuna"].Rows)
                {
                    Stavka stavka = new Stavka();
                    stavka.namestajId = int.Parse(row["NamestajId"].ToString());
                    stavka.BrojKomada = int.Parse(row["BrojKomada"].ToString());
                    stavke.Add(stavka);
                }
                return stavke;
            }
        }

        public static void UpdateForRacun(Racun r, Stavka s)
        {
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                if (s.BrojKomada == 0)
                {
                    Console.WriteLine("Poziva se delete metoda");
                    cmd.CommandText = "DELETE FROM StavkeRacuna WHERE RacunId=@RacunId AND NamestajId=@NamestajId";
                    cmd.Parameters.AddWithValue("RacunId", r.Id);
                }
                else {
                    Console.WriteLine("Poziva se update metoda");
                    cmd.CommandText = "UPDATE StavkeRacuna SET BrojKomada=@BrojKomada WHERE RacunId=@RacunId AND NamestajId=@NamestajId";
                    cmd.Parameters.AddWithValue("NamestajId", s.namestajId);
                    cmd.Parameters.AddWithValue("BrojKomada", s.brojKomada);
                    cmd.Parameters.AddWithValue("RacunId", r.Id);
                }
                
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddForRacun(Racun r , Stavka s)
        {
            Console.WriteLine("Dosao do add metode racuna");
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                r.Stavke.Add(s);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO StavkeRacuna(RacunId, NamestajId, BrojKomada) VALUES (@RacunId, @NamestajId, @BrojKomada)";
                cmd.Parameters.AddWithValue("RacunId", r.Id);
                cmd.Parameters.AddWithValue("NamestajId", s.Namestaj.Id);
                cmd.Parameters.AddWithValue("BrojKomada", s.BrojKomada);
                cmd.ExecuteNonQuery();
            }
        }



        #endregion

    }
}
