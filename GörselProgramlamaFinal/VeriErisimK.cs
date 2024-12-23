using GörselProgramlamaFinal.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörselProgramlamaFinal
{
    internal class VeriErisimK
    {
        private OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database7.accdb;Persist Security Info=False;");



        public bool UyeVarMi(int id)
        {
            string query = "SELECT COUNT(*) FROM Uyeler WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);
            {
                cmd.Parameters.AddWithValue("@ID", id);
                connect.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                connect.Close();
                return count > 0;

            }

        }

        public void UyeEkle(Uye uye)
        {
            string query = "INSERT INTO [Uyeler] ([AdSoyad], [Telefon], [Email], [Adres], [KayıtTarihi], [GüncelBorc], [Aile]) VALUES (@AdSoyad, @Telefon, @Email, @Adres, @KayıtTarihi, @GüncelBorc, @Aile)";
            OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.Parameters.Add("@AdSoyad", OleDbType.VarChar).Value = uye.AdSoyad;
            cmd.Parameters.Add("@Telefon", OleDbType.VarChar).Value = uye.Telefon;
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = uye.Email;
            cmd.Parameters.Add("@Adres", OleDbType.VarChar).Value = uye.Adres;
            cmd.Parameters.Add("@KayıtTarihi", OleDbType.Date).Value = uye.KayıtTarihi;
            cmd.Parameters.Add("@GüncelBorc", OleDbType.Currency).Value = uye.GüncelBorc;
            cmd.Parameters.Add("@Aile", OleDbType.VarChar).Value = uye.Aile;


            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void UyeSil(int uyeID)
        {
            string query = "DELETE FROM Uyeler WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.Parameters.AddWithValue("@ID", uyeID);

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public List<Uye> UyeListele()
        {
            List<Uye> uyeler = new List<Uye>();
            string query = "SELECT * FROM Uyeler"; 
            OleDbCommand cmd = new OleDbCommand(query, connect);

            try
            {
                connect.Open();  
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        Uye uye = new Uye
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            AdSoyad = reader["AdSoyad"].ToString(),
                            Telefon = reader["Telefon"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adres = reader["Adres"].ToString(),
                            KayıtTarihi = Convert.ToDateTime(reader["KayıtTarihi"]),
                            GüncelBorc = Convert.ToDecimal(reader["GüncelBorc"]),
                            Aile = reader["Aile"].ToString()
                        };
                        uyeler.Add(uye);
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanında üye bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                connect.Close(); 
            }

            return uyeler;
        }

        public void UyeGuncelle(Uye uye)
        {
            
                string query = "UPDATE Uyeler SET AdSoyad = @AdSoyad, Telefon = @Telefon, Email = @Email, " +
                               "Adres = @Adres, KayıtTarihi = @KayıtTarihi, GüncelBorc = @GüncelBorc, " +
                               "Aile = @Aile WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.Parameters.Add("@AdSoyad", OleDbType.VarChar).Value = uye.AdSoyad;
            cmd.Parameters.Add("@Telefon", OleDbType.VarChar).Value = uye.Telefon;
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = uye.Email;
            cmd.Parameters.Add("@Adres", OleDbType.VarChar).Value = uye.Adres;
            cmd.Parameters.Add("@KayıtTarihi", OleDbType.Date).Value = uye.KayıtTarihi;
            cmd.Parameters.Add("@GüncelBorc", OleDbType.Currency).Value = uye.GüncelBorc;
            cmd.Parameters.Add("@Aile", OleDbType.VarChar).Value = uye.Aile;
            cmd.Parameters.AddWithValue("@ID", uye.ID); 

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            
        }

        public Uye UyeIDileGetir(int ID)
        {
            Uye uye = null;
            string query = "SELECT * FROM Uyeler WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.Parameters.AddWithValue("@ID", ID);

            connect.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) 
            {
                uye = new Uye
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    AdSoyad = reader["AdSoyad"].ToString(),
                    Telefon = reader["Telefon"].ToString(),
                    Email = reader["Email"].ToString(),
                    Adres = reader["Adres"].ToString(),
                    KayıtTarihi = Convert.ToDateTime(reader["KayıtTarihi"]),
                    GüncelBorc = Convert.ToDecimal(reader["GüncelBorc"]),
                    Aile = reader["Aile"].ToString()
                };
            }

            connect.Close();
            return uye;
        }

        public Uye UyeTumBilgileriniGetir(int ID)
        {
            Uye uye = null;
            string query = "SELECT * FROM Uyeler WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);

            cmd.Parameters.AddWithValue("@ID", ID);

            connect.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                uye = new Uye
                {
                    AdSoyad = reader["AdSoyad"].ToString(),
                    GüncelBorc = Convert.ToDecimal(reader["GüncelBorc"]),
                    Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) ? null : reader["Telefon"].ToString(),
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader["Email"].ToString(),
                    Adres = reader.IsDBNull(reader.GetOrdinal("Adres")) ? null : reader["Adres"].ToString(),
                    Aile = reader.IsDBNull(reader.GetOrdinal("Aile")) ? null : reader["Aile"].ToString()
                };
            }

            connect.Close();
            return uye;
        }


        public Uye UyeBilgileriniGetir(int ID)
        {
            Uye uye = null;
            string query = "SELECT * FROM Uyeler WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);

            cmd.Parameters.AddWithValue("@ID", ID);

            connect.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                uye = new Uye
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    AdSoyad = reader["AdSoyad"].ToString(),
                    GüncelBorc = Convert.ToDecimal(reader["GüncelBorc"])
                };
            }

            connect.Close();
            return uye;
        }

        public void AidatOde(int ID, decimal odemeMiktari)
        {
            string query = "UPDATE Uyeler SET GüncelBorc = GüncelBorc - @OdemeMiktari WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);

            cmd.Parameters.AddWithValue("@OdemeMiktari", odemeMiktari);
            cmd.Parameters.AddWithValue("@ID", ID);

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public List<Uye> BorclariListele()
        {
            List<Uye> uyeler = new List<Uye>();
            string query = "SELECT AdSoyad, Telefon, GüncelBorc FROM Uyeler";

            using (OleDbCommand cmd = new OleDbCommand(query, connect))
            {
                connect.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye uye = new Uye
                    {
                        AdSoyad = reader["AdSoyad"].ToString(),
                        Telefon = reader["Telefon"].ToString(),
                        GüncelBorc = Convert.ToDecimal(reader["GüncelBorc"])
                    };
                    uyeler.Add(uye);
                }
                connect.Close();
            }

            return uyeler;
        }

        public List<string> UyeEmailListele()
        {
            List<string> emailListesi = new List<string>();
            string query = "SELECT Email FROM Uyeler";  
            OleDbCommand cmd = new OleDbCommand(query, connect);

            connect.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                emailListesi.Add(reader["Email"].ToString());  
            }

            connect.Close();
            return emailListesi;  
        }

        public void AidatGuncelle(int uyeID, decimal aidat)
        {
            string query = "UPDATE Uyeler SET GüncelBorc = GüncelBorc + @Aidat WHERE ID = @ID";
            OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.Parameters.AddWithValue("@Aidat", aidat);
            cmd.Parameters.AddWithValue("@ID", uyeID);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }


    }
}


