
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esAttrazioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti al parco delle attrazioni!\n");

            CAttrazione[] attrazioni = new CAttrazione[6];

            attrazioni[0] = new CConcerto("Concerto di Natale", 50.0, "19:00", 60);
            attrazioni[1] = new CConcerto("Concerto di Capodanno", 60.0, "21:00", 75);
            attrazioni[2] = new CGiostra("Giostra della Fortuna", 5.0, 20, "Avventura");
            attrazioni[3] = new CGiostra("Giostra dei Sogni", 7.0, 15, "Fantasy");
            attrazioni[4] = new CMostraArte("Mostra d'Arte", 10.0, "Leonardo da Vinci", new List<string> { "La Gioconda", "L'Ultima Cena" });
            attrazioni[5] = new CMostraArte("Mostra di Sculture", 15.0, "Marietto", new List<string> { "David", "Moses" });

            Console.WriteLine("Opere dell'autore Marietto: \n");
            for (int i = 0; i < attrazioni.Length; i++)
            {
                if (attrazioni[i] is CMostraArte mostra && mostra.Autor == "Marietto")
                {
                    Console.WriteLine(mostra.Info());
                }
            }

            Console.WriteLine("\nInformazioni sulle attrazioni: \n");
            foreach (CAttrazione attrazione in attrazioni)
            {
                Console.WriteLine(attrazione.Info());
            }

        }
    }
}
