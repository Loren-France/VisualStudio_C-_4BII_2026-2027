using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal class Program
    {
        static List<CDolce> ListaDolci = new List<CDolce>();
        static void Main(string[] args)
        {
            Random r = new Random();

            //Creazione di alcune crostate e torte e aggiunta alla lista di dolci
            CCrostata crostata1 = new CCrostata("Crostata di frutta", r.Next(1, 11), 30, false);
            CCrostata crostata2 = new CCrostata("Crostata al cioccolato", r.Next(1, 11), 45, false);
            CCrostata crostata3 = new CCrostata("Crostata alla marmellata", r.Next(1, 11), 25, false);
            CTorta Torta1 = new CTorta("Torta di mele", r.Next(1, 11), "mele, zucchero, burro");
            CTorta Torta2 = new CTorta("Torta al cioccolato", r.Next(1, 11), "cioccolato, zucchero, burro");
            CTorta Torta3 = new CTorta("Torta alla frutta", r.Next(1, 11), "frutta di stagione, zucchero, burro");

            ListaDolci.Add(crostata1);
            ListaDolci.Add(crostata2);
            ListaDolci.Add(crostata3);
            ListaDolci.Add(Torta1);
            ListaDolci.Add(Torta2);
            ListaDolci.Add(Torta3);

            Console.WriteLine("PROGRAMMA DI GESTIONE DEI DOLCI\n");

            int action = 0;

            while (action != 8)
            {
                Console.WriteLine("Scegli un'azione:");
                Console.WriteLine("1. Visualizza la lista dei dolci e stato");
                Console.WriteLine("2. Sottoponi una crostata a Prova di croccantezza");
                Console.WriteLine("3. Sottoponi una torta a Prova di sofficienza");
                Console.WriteLine("4. Sottoponi un dolce casuale alla raffinazione");
                Console.WriteLine("5. Avvia il Finale di degustazione");
                Console.WriteLine("6. Glassa una crostata");
                Console.WriteLine("7. Aggiungi strato ad una torta");
                Console.WriteLine("8. Esci");

                do
                {
                    Console.Write("Inserisci il numero dell'azione desiderata: ");
                } while (!int.TryParse(Console.ReadLine(), out action) || action < 1 || action > 8);

                Console.WriteLine();

                switch (action)
                {
                    case 1:
                        Console.WriteLine("Lista dei dolci e stato:");
                        foreach (var dolce in ListaDolci)
                        {
                            Console.WriteLine(dolce.Stampa());
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        int CrostataCasuale = r.Next(0, 4);
                        if (ListaDolci[CrostataCasuale] is CCrostata crostata)
                        {
                            crostata.ProvadiCroccantezza();
                            Console.WriteLine($"Crostata {crostata.Nome} sottoposta a Prova di croccantezza.");
                            Console.WriteLine(crostata.Stampa());
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        int TortaCasuale = r.Next(0, 4);
                        if (ListaDolci[TortaCasuale] is CTorta torta)
                        {
                            torta.ProvadiSofficienza();
                            Console.WriteLine($"Torta {torta.Nome} sottoposta a Prova di sofficienza.");
                            Console.WriteLine(torta.Stampa());
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        int DolceCasuale = r.Next(0, ListaDolci.Count);
                        ListaDolci[DolceCasuale].Raffinatura();
                        Console.WriteLine($"Dolce {ListaDolci[DolceCasuale].Nome} sottoposto a raffinazione.");
                        Console.WriteLine(ListaDolci[DolceCasuale].Stampa());
                        Console.WriteLine();
                        break;
                    case 5:
                        FinalediDegustazione();
                        break;
                    case 6:
                        int CrostataDaGlassare = r.Next(0, 4);
                        if (ListaDolci[CrostataDaGlassare] is CCrostata crostataAGlassare)
                        {
                            Console.WriteLine($"Crostata {crostataAGlassare.Nome} sottoposta a glassatura.");
                            Console.WriteLine(crostataAGlassare.Glassatura());
                        }
                        Console.WriteLine();
                        break;
                    case 7:
                        int TortaDaStratificare = r.Next(3, 6);
                        if (ListaDolci[TortaDaStratificare] is CTorta tortaStratificare)
                        {
                            Console.WriteLine($"Torta {tortaStratificare.Nome} sottoposta a stratificazione");
                            Console.WriteLine(tortaStratificare.AggiungiStrato());
                        }
                        // CCrostate crostata = ListaDolci[indice] as CCrostata;
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.WriteLine("Uscita dal programma...");
                        return;
                    default:
                        Console.WriteLine("Azione impossibile.");
                        break;
                }
            }
        }

        static void FinalediDegustazione()
        {
            Console.WriteLine("Avvio del Finale di degustazione...");
            foreach (var dolce in ListaDolci)
            {
                dolce.Raffinatura();
            }
            Console.WriteLine("Tutti i dolci sono stati sottoposti a raffinazione.");
        }
    }
}
