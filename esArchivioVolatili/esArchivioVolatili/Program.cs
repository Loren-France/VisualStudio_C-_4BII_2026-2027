using System;
using System.Collections.Generic;

namespace esArchivioVolatili
{
    internal class Program
    {
        public static List<CPennuto> ArchivioVolatili = new List<CPennuto>();

        static void Main(string[] args)
        {

            Console.WriteLine("PROGRAMMA DI GESTIONE DEGLI AVVISTAMENTI VOLATILI");

            int action = 0;

            while (action != 8)
            {
                Console.WriteLine("Scegli un'azione:");
                Console.WriteLine("1. Aggiungi un pennuto");
                Console.WriteLine("2. Visualizza elenco esemplari e relativi avvistamenti");
                Console.WriteLine("3. Elimina un pennuto");
                Console.WriteLine("4. Aggiungi un avvistamento di un pennuto");
                Console.WriteLine("5. Visualizza avvistamenti di un pennuto");
                Console.WriteLine("6. Visualizza i pennuti migratori di una determinata specie");
                Console.WriteLine("7. Visualizza il numero di esemplari per ogni categoria e il numero complessivo di avvistamenti");
                Console.WriteLine("8. Esci");

                do
                {
                    Console.Write("Inserisci il numero dell'azione desiderata: ");
                } while (!int.TryParse(Console.ReadLine(), out action));

                switch (action)
                {
                    case 1:
                        AggiungiPennuto();
                        break;
                    case 2:
                        VisualizzaDatiPennuti();
                        break;
                    case 3:
                        EliminaPennuto();
                        break;
                    case 4:
                        AggiungiAvvistamento();
                        break;
                    case 5:
                        VisualizzaAvvistamenti();
                        break;
                    case 6:
                        VisualizzaPennutiMigratori();
                        break;
                    case 7:
                        VisualizzaNumeroEsemplari();
                        break;
                    case 8:
                        Console.WriteLine("Uscita dal programma.");
                        break;
                    default:
                        Console.WriteLine("Azione non valida. Riprova.");
                        break;
                }
            }
        }

        static void AggiungiPennuto()
        {
            string specie, habitat, tipoAcqua, cantoCaratteristico, dieta;
            double aperturaAlare;
            bool migratore;

            do
            {
                Console.Write("Inserisci la specie del pennuto: ");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));

            do
            {
                Console.Write("Inserisci l'habitat del pennuto: ");
                habitat = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(habitat));

            do
            {
                Console.Write("Inserisci se il pennuto è migratore (true/false): ");
            } while (!bool.TryParse(Console.ReadLine(), out migratore));

            do
            {
                Console.Write("Inserisci l'apertura alare del pennuto: ");
            } while (!double.TryParse(Console.ReadLine(), out aperturaAlare));

            CPennuto nuovoPennuto = new CPennuto(ArchivioVolatili.Count + 1, specie, habitat, migratore, aperturaAlare);

            int typeChoice;

            do
            {
                Console.WriteLine("Scegli il tipo di pennuto:");
                Console.WriteLine("1. Rapace");
                Console.WriteLine("2. Canterino");
                Console.WriteLine("3. Acquatico");
                Console.Write("Inserisci il numero corrispondente al tipo di pennuto: ");
            } while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 1 || typeChoice > 3);

            if (typeChoice == 1)
            {
                do
                {
                    Console.Write("Inserisci la dieta del rapace: ");
                    dieta = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(dieta));

                nuovoPennuto = new CRapace(ArchivioVolatili.Count + 1, specie, habitat, migratore, aperturaAlare, dieta);
                Console.WriteLine($"Nuovo rapace aggiunto con successo!");
            }
            else if (typeChoice == 2)
            {
                do
                {
                    Console.Write("Inserisci il canto caratteristico del canterino: ");
                    cantoCaratteristico = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(cantoCaratteristico));
                nuovoPennuto = new CCanterino(ArchivioVolatili.Count + 1, specie, habitat, migratore, aperturaAlare, cantoCaratteristico);
                Console.WriteLine($"Nuovo canterino aggiunto con successo!");

            }
            else if (typeChoice == 3)
            {
                do
                {
                    Console.Write("Inserisci il tipo di acqua del pennuto: ");
                    tipoAcqua = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(tipoAcqua));

                TipoAcqua type = tipoAcqua.ToLower() == "dolce" ? TipoAcqua.Dolce : TipoAcqua.Salata;

                nuovoPennuto = new CAcquatico(ArchivioVolatili.Count + 1, specie, habitat, migratore, aperturaAlare, type);
                Console.WriteLine($"Nuovo acquatico aggiunto con successo!");
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
                return;
            }
            ArchivioVolatili.Add(nuovoPennuto);
        }

        static void VisualizzaDatiPennuti()
        {
            Console.WriteLine("Elenco dei pennuti registrati:");
            foreach (var pennuto in ArchivioVolatili)
            {
                Console.WriteLine(pennuto.ToString());
            }
        }

        static void EliminaPennuto()
        {
            int codice;
            do
            {
                Console.Write("Inserisci il codice univoco del pennuto da eliminare: ");
            } while (!int.TryParse(Console.ReadLine(), out codice));

            ArchivioVolatili.RemoveAt(codice - 1);
            Console.WriteLine("Pennuto eliminato con successo!");
        }

        static void AggiungiAvvistamento()
        {
            int codice;
            string luogo, note = "Nota assente";
            do
            {
                Console.Write("Inserisci il codice univoco del pennuto a cui aggiungere l'avvistamento: ");
            } while (!int.TryParse(Console.ReadLine(), out codice) || codice < 1 || codice > ArchivioVolatili.Count);

            do
            {
                Console.Write("Inserisci il luogo dell'avvistamento: ");
                luogo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(luogo));

            do
            {
                Console.Write("Inserisci delle note dell'avvistamento: ");
                note = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(note));

            CAvvistamento avvistamento = new CAvvistamento(DateTime.Now, luogo, note);

            ArchivioVolatili[codice - 1].AggiungiAvvistamento(avvistamento);

        }

        static void VisualizzaAvvistamenti()
        {
            int codice;

            do
            {
                Console.Write("Inserisci il codice univoco del pennuto su cui visualizzare gli avvistamenti: ");
            } while (!int.TryParse(Console.ReadLine(), out codice) || codice < 1 || codice > ArchivioVolatili.Count);

            ArchivioVolatili[codice - 1].StampaAvvistamenti();
        }

        static void VisualizzaPennutiMigratori()
        {
            int typeChoice;

            do
            {
                Console.WriteLine("Scegli la specie di pennuto da visualizzare:");
                Console.WriteLine("1. Rapace");
                Console.WriteLine("2. Canterino");
                Console.WriteLine("3. Acquatico");
                Console.Write("Inserisci il numero corrispondente alla specie del pennuto: ");
            } while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 1 || typeChoice > 3);

            string specie = typeChoice == 1 ? "Acquatico" : typeChoice == 2 ? "Canterino" : "Rapace";

            Console.WriteLine($"Elenco dei pennuti migratori della specie {specie}:");

            if (typeChoice == 1)
            {
                foreach (var pennuto in ArchivioVolatili)
                {
                    if (pennuto is CRapace && pennuto.Migratore)
                        Console.WriteLine(pennuto.ToString());
                }
            }
            else if (typeChoice == 2)
            {
                foreach (var pennuto in ArchivioVolatili)
                {
                    if (pennuto is CCanterino && pennuto.Migratore)
                        Console.WriteLine(pennuto.ToString());
                }
            }
            else if (typeChoice == 3)
            {
                foreach (var pennuto in ArchivioVolatili)
                {
                    if (pennuto is CAcquatico && pennuto.Migratore)
                        Console.WriteLine(pennuto.ToString());
                }
            }
        }

        static void VisualizzaNumeroEsemplari()
        {
            int rapaciCount = 0, canteriniCount = 0, acquaticiCount = 0, totalSightings = 0;

            foreach (var pennuto in ArchivioVolatili)
            {
                if (pennuto is CRapace)
                    rapaciCount++;
                else if (pennuto is CCanterino)
                    canteriniCount++;
                else if (pennuto is CAcquatico)
                    acquaticiCount++;
                totalSightings += pennuto.Avvistamenti.Count;
            }

            Console.WriteLine($"Numero di rapaci: {rapaciCount}");
            Console.WriteLine($"Numero di canterini: {canteriniCount}");
            Console.WriteLine($"Numero di acquatici: {acquaticiCount}");
            Console.WriteLine($"Numero complessivo di avvistamenti: {totalSightings}");
        }
    }
}