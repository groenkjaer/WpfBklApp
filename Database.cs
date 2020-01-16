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

        //public static string Login()
        //{

        //}

    }
}
