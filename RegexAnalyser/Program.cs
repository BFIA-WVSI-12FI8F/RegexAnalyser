using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexAnalyser
{
    static class Program
    {
        public static readonly string PROJECT_NAME = "BFIA_WVSI 12FI8F RegexAnalyser";
        public static DatabaseAPI DB_API;


        [STAThread]
        static void Main()
        {
            DB_API = new DatabaseAPI((string)new AppSettingsReader().GetValue("SQL_CONNECTION_STRING", typeof(string)));
            if (!DB_API.ValidateConnectionString())
            {
                MessageBox.Show("Invalid SQL Credentials supplied or no Connection to SQL Server possible due to Connection Problems.", PROJECT_NAME);
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
