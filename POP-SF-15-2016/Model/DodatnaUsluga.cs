﻿using System;
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
    public class DodatnaUsluga : ICloneable,INotifyPropertyChanged
    {
        private int id { get; set; }
        private string naziv { get; set; }
        private double cena { get; set; }
        private bool obrisan { get; set; }

        public DodatnaUsluga()
        {
        }

        public DodatnaUsluga(int id, string naziv, double cena, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.cena = cena;
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

        public string Naziv
        {
            get
            {
                return naziv;
            } set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public double Cena
        {
            get
            {
                return cena;
            } set
            {
                cena = value;
                OnPropertyChanged("Cena");
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

        public static DodatnaUsluga getById(int id)
        {
            foreach(var x in Aplikacija.Instance.Usluge)
            {
                if(x.Id.Equals(id))
                {
                    return x;
                }
            }
            return null;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        #region Database
        public static ObservableCollection<DodatnaUsluga> GetForRacun(int id)
        {
            var usluge = new ObservableCollection<DodatnaUsluga>();
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Id IN (SELECT UslugaId FROM UslugeRacuna WHERE RacunId=@RacunId)";
                cmd.Parameters.AddWithValue("RacunId", id);
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sdp.Fill(ds, "DodatnaUsluga");

                foreach(DataRow row in ds.Tables["DodatnaUsluga"].Rows) {
                    var usluga = new DodatnaUsluga();
                    usluga.Id = int.Parse(row["Id"].ToString());
                    usluga.Naziv = row["Naziv"].ToString();
                    usluga.Cena = double.Parse(row["Cena"].ToString());
                    usluga.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluge.Add(usluga);
                }
                return usluge;

            }
        }

        public static void  DeleteForRacun(Racun r, DodatnaUsluga du)
        {
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                r.Usluge.Remove(du);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM UslugeRacuna WHERE RacunId=@RacunId AND UslugaId=@UslugaId";
                cmd.Parameters.AddWithValue("RacunId", r.Id);
                cmd.Parameters.AddWithValue("UslugaId", du.Id);
                cmd.ExecuteNonQuery();

            }
        }

        public static void AddForRacun(Racun r, DodatnaUsluga du)
        {
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                r.Usluge.Add(du);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO UslugeRacuna(RacunId, UslugaId) VALUES (@RacunId, @UslugaId)";
                cmd.Parameters.AddWithValue("RacunId", r.Id);
                cmd.Parameters.AddWithValue("UslugaId", du.Id);
                cmd.ExecuteNonQuery();

            }
        }

        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var usluge = new ObservableCollection<DodatnaUsluga>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )



                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "DodatnaUsluga"); //Izvrsava se query nad bazom


                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var usluga = new DodatnaUsluga();
                    usluga.Id = int.Parse(row["Id"].ToString());
                    usluga.Naziv = row["Naziv"].ToString();
                    usluga.Cena = double.Parse(row["Cena"].ToString());
                    usluga.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluge.Add(usluga);

                }
                return usluge;
            }
        }


        public static void Update(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE DodatnaUsluga set Naziv=@Naziv, Cena=@Cena, Obrisadu=@Obrisan WHERE Id=@Id";
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";
                //cmd.Parameters.AddWithValue("Obrisan", )
                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Popust", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);
                cmd.ExecuteNonQuery();
                foreach (var dodatna in Aplikacija.Instance.Usluge)
                {
                    if (dodatna.Id == du.Id)
                    {
                        dodatna.Naziv = du.Naziv;
                        dodatna.Cena = du.Cena;
                        dodatna.Obrisan = du.Obrisan;
                        break;
                    }
                }
            }

        }


        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv,Cena, Obrisan) VALUES(@Naziv, @Cena , @Obrisan)";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //Izvrsava se query nad bazom

                du.Id = newId;
            }
            Aplikacija.Instance.Usluge.Add(du);
            return du;
        }

        public static void Delete(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                du.Obrisan = true;
                Aplikacija.Instance.Usluge.Remove(du);
                Update(du);
            }
        }

        public object Clone()
        {
            DodatnaUsluga kopija = new DodatnaUsluga();
            kopija.Id = Id;
            kopija.Naziv = Naziv;
            kopija.Obrisan = Obrisan;
            return kopija;
        }
        #endregion
    }
}
