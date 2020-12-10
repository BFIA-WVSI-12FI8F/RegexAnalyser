using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexAnalyser.RegexImpl
{
    class RegexImpl
    {
        public delegate string typedef_GetAnswer(string sequence);
        public static List<typedef_GetAnswer> RegexImplementations = new List<typedef_GetAnswer>();

        static RegexImpl()
        {
            RegexImplementations.Add(GetAnswer_Impl1);
        }

        public static string GetAnswer(string sequence)
        {
            typedef_GetAnswer res = RegexImplementations.FirstOrDefault(e =>
            {
                string s = e(sequence);
                return !string.IsNullOrEmpty(s);
            });
            if (res != null) return res(sequence);
            return "";
        }

        private static string GetAnswer_Impl1(string sequence)
        {               //Implementation for "Wie viele Corona- Tode hatte Hessen?"
            Regex rx = new Regex(@"Wie viele.*Tod.*hat.* (.*?)\?", RegexOptions.IgnoreCase);
            Match mx = rx.Match(sequence);
            if (!mx.Success || mx.Groups.Count < 1) return "";
            string bundesland = mx.Groups[1].Value;
            string anzahl = Program.DB_API.GetAnzahlTodesfallForBundesland(bundesland);
            return string.Format("Die totale Anzahl an Covid-19 verendeten Patienten betrug in {1} {0} Personen.", anzahl, bundesland);
        }
    }
}
