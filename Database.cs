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
        private static string maal;
        private static string vaegt;

        public static int UserId
        {
            get { return userId; }
        }
        public static string Status
        {
            get { return status; }
        }
        public static string Maal
        {
            get { return maal; }
            set { maal = value; }
        }
        public static string Vaegt
        {
            get { return vaegt; }
            set { vaegt = value; }
        }

        public static string OpretNyBruger(string fname, string lname, string email, string kodeord1, string kodeord2, string koen, string alder) //Fillip
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

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

        public static string Login(string email, string kodeord) //Fillip
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

        public static string[] TraeningsProgram(int prgId) //Fillip og Isak
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

            try
            {
                SqlCommand comm = new SqlCommand(string.Format("SELECT * FROM Traeningsprogram WHERE Program_ID = '{0}'", prgId), conn);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    string[] result = {reader["Oevelse"].ToString(), reader["Beskrivelse"].ToString(), reader["Muskelgruppe"].ToString(), reader["Belastning"].ToString(), reader["Gentagelser"].ToString(), reader["Pausetid"].ToString(), reader["Set"].ToString()};
                    conn.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            throw new Exception();
        }

        public static int[] HentProgramId() //Fillip
        {
            int antal = HentAntalProgrammer();
            int[] result = new int[antal];
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

            try
            {
                SqlCommand comm = new SqlCommand(string.Format("SELECT Program_ID FROM Traeningsprogram WHERE Medlem = {0}", userId), conn);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < antal; i++)
                    {
                        result[i] = Convert.ToInt32(reader["Program_ID"]);
                        reader.Read();
                    }
                    conn.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            throw new Exception();
        }
        public static int HentAntalProgrammer() //Fillip
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

            try
            {
                SqlCommand comm = new SqlCommand(string.Format("SELECT COUNT (Program_ID) AS Antal FROM Traeningsprogram WHERE Medlem = '{0}'", userId), conn);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    int result = Convert.ToInt32(reader["Antal"]);
                    conn.Close();
                    return result;
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string UploadVaegt() //Fillip
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);

            try
            {
                SqlCommand comm = new SqlCommand(string.Format("INSERT INTO Vaegt(Dato, Maal, Vaegt, Medlem) VALUES(GETDATE(),'{0}', '{1}', '{2}')", maal, vaegt, userId), conn);
                conn.Open();

                if (comm.ExecuteNonQuery() == 1)
                {
                    conn.Close();
                    return "Mål og vægt er gemt";
                }
                else
                {
                    return "Kunne ikke uploade vægt og mål";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
