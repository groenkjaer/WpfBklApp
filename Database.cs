using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WpfBklApp
{
    static class Database
    {
        private static SqlConnection conn;
        private static int userId = 0;
        private static string status;

        public static int UserId
        {
            get { return userId; }
        }
        public static string Status
        {
            get { return status; }
        }

        public static string OpretNyBruger(string fname, string lname, string email, string kodeord1, string kodeord2, string koen, string alder) //Fillips metode
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString); //setup

            if (kodeord1 == kodeord2)
            {
                try
                {
                    SqlCommand comm = new SqlCommand(string.Format("INSERT INTO Medlemmer (Fornavn, Efternavn, Koen, Alder, [Status], Email, Kodeord) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", fname, lname, koen, alder, "Aktiv", email, kodeord1), conn);
                    conn.Open();

                    if (comm.ExecuteNonQuery() == 1)
                    {
                        conn.Close();
                        return "Du har nu oprettet en bruger";
                    }
                    else
                    {
                        conn.Close();
                        return "Bruger kunne ikke oprettes";
                    }
                }
                catch (Exception e)
                {
                    return "Kunne ikke oprette bruger, venligst kontakt personalet. Fejlkode: " + e.Message;
                }
            }
            else
            {
                return "Kodeord matcher ikke";
            }
        }

        public static string Login(string email, string kodeord) //Fillips metode
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

            try
            {
                SqlCommand comm = new SqlCommand(string.Format("SELECT * FROM Medlemmer WHERE Email = '{0}'", email), conn);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (kodeord == reader["Kodeord"].ToString())
                    {
                        userId = Convert.ToInt32(reader["Medlems_ID"]);
                        string name = reader["Fornavn"].ToString();
                        status = reader["Status"].ToString();
                        conn.Close();
                        return "Velkommen " + name;
                    }
                    else
                    {
                        return "Kodeord er forkert";
                    }
                }
                return "Ukendt email";
            }
            catch (Exception e)
            {
                return "Kunne ikke oprette forbindelse, kontakt en administrator. Fejlkode: " + e.Message;
            }
        }

    }
}
