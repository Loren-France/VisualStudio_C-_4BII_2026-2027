using System;
using System.Collections.Generic;

namespace esFantasilandia
{
    internal class Program
    {
        static List<IFixable> luoghi = new List<IFixable>();
        static List<CAttrazioni> attrazioni = new List<CAttrazioni>();
        static List<IFixable> guasti = new List<IFixable>();
        static void Main(string[] args)
        {
            int Totale = 0;

            Console.WriteLine("PROGRAMMA GESTIONE GIOSTRE FANTASILANDIA");
            Console.WriteLine();

            CVisitatore visitatore1 = new CVisitatore(true, 150, 65, 34, 10);
            CVisitatore visitatore2 = new CVisitatore(false, 120, 45, 10, 5);
            CVisitatore visitatore3 = new CVisitatore(true, 180, 80, 25, 15);
            CVisitatore visitatore4 = new CVisitatore(false, 160, 70, 15, 8);

            List<CVisitatore> visitatori = new List<CVisitatore> { visitatore1, visitatore2, visitatore3, visitatore4 };

            CGiostraBambini giostraBambini = new CGiostraBambini("Giostra Bambini", 20, false, 30, 100, 12, 5);
            CMontagnaRussa montagnaRussa = new CMontagnaRussa("Montagna Russa", 50, true, 60, 200, 18, 10, true);
            CTorreCaduta torreCaduta = new CTorreCaduta("Torre di Caduta", 30, true, 40, 150, 14, 8, true, 100, 20);
            CChiosco chiosco = new CChiosco(false, 20, 50.0, TipologiaCibi.Dolci);
            CBagno bagno = new CBagno(false, 10, 20.0, 9);

            luoghi.Add(giostraBambini);
            luoghi.Add(montagnaRussa);
            luoghi.Add(torreCaduta);
            luoghi.Add(chiosco);
            luoghi.Add(bagno);

            foreach (var luogo in luoghi)
            {
                if (luogo.IsGuasto == true)
                {
                    guasti.Add(luogo);
                }
                else if (luogo is CAttrazioni attrazione)
                {
                    attrazioni.Add(attrazione);
                }
            }

            Console.WriteLine("Elenco attrazioni in manutenzione:");
            foreach (var attrazione in guasti)
            {
                Console.WriteLine(attrazione.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Elenco attrazioni operative:");
            foreach (var attrazione in attrazioni)
            {
                Console.WriteLine(attrazione.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Simulazione: ogni visitatore prova tutte le attrazioni");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < visitatori.Count; i++)
            {
                CVisitatore v = visitatori[i];
                Console.WriteLine($"Visitatore {i + 1} :");
                foreach (var attr in attrazioni)
                {
                    int prezzo = attr.Vendi(v);
                    if (prezzo > 0)
                    {
                        Totale += prezzo;
                        Console.WriteLine($"  Usato: {attr.Nome} - costo {prezzo} euro");
                        if (v.Gettoni >= 0)
                        {
                            Console.WriteLine($"    Gettoni rimanenti: {v.Gettoni}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"  Non può usare: {attr.Nome}");
                    }
                }
                Console.WriteLine($"Incasso totale: {Totale} euro");
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Simulazione della riparazione delle attrazioni guaste:");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            foreach (var guasto in guasti)
            {
                Console.WriteLine($"Riparazione: \n{guasto.SegnalaGuasto()}");
                Console.WriteLine($"Stato dopo riparazione: \n{guasto.Ripara()}");
                Console.WriteLine();
            }

            guasti.Clear();
            attrazioni.Clear();

            foreach (var luogo in luoghi)
            {
                if (luogo.IsGuasto == true)
                {
                    guasti.Add(luogo);
                }
                else if (luogo is CAttrazioni attrazione)
                {
                    attrazioni.Add(attrazione);
                }
            }

            Console.WriteLine("Elenco attrazioni in manutenzione:");
            foreach (var attrazione in guasti)
            {
                Console.WriteLine(attrazione.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Elenco attrazioni operative:");
            foreach (var attrazione in attrazioni)
            {
                Console.WriteLine(attrazione.ToString());
            }
            Console.WriteLine();
        }
    }
}
