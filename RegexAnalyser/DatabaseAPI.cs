using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RegexAnalyser
{
    public class DatabaseAPI
    {
        private readonly string connectionstring;
        public DatabaseAPI(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }
        /* Returns if a Connection with the ConnectionString to the Database is possible. */
        public bool ValidateConnectionString()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionstring))
                {
                    con.Open();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        /* Retruns the Sum of all Death Cases for a specific federal-state. */
        public string GetAnzahlTodesfallForBundesland(string Bundesland)
        {
            Dictionary<string, List<string>> ret1 = new Dictionary<string, List<string>>();
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT SUM(`AnzahlTodesfall`) AS `AnzahlTodesfall` FROM `covid19` WHERE `Bundesland` = @Bundesland", con))
                {
                    cmd.Parameters.AddWithValue("@Bundesland", Bundesland);
                    cmd.Prepare();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();//Read first line
                        return rdr.GetString("AnzahlTodesfall");
                    }
                }
            }
        }
    }
}