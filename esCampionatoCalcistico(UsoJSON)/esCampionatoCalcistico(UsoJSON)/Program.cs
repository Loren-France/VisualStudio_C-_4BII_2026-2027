using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace esCampionatoCalcistico_UsoJSON_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMMA GESTIONE CAMPIONATO CALCISTICO");

            Console.WriteLine("Programma che sfrutta un json per la gestione del campionato.");

            int action = 1;

            while (action != 0)
            {
                do
                {
                    Console.WriteLine("Scegli un'azione:");
                    Console.WriteLine("1. Inserisci una nuova partita");
                    Console.WriteLine("2. Visualizza le partite");
                    Console.WriteLine("0. Esci");
                } while (!int.TryParse(Console.ReadLine(), out action) || (action != 0 && action != 1 && action != 2));

                switch (action)
                {
                    case 1:
                        InserisciPartita();
                        break;
                    case 2:
                        VisualizzaPartite();
                        break;
                    case 0:
                        Console.WriteLine("\nUscita dal programma...");
                        break;
                }
            }
            return;
        }

        static void InserisciPartita()
        {
            Console.WriteLine("Inserisci i nome dei giocatori della squadra di casa:");

            List<string> squadraCasa = new List<string>();

            string nomeGiocatori;

            for (int i = 0; i < 11; i++)
            {
                do
                {
                    Console.WriteLine($"Inserisci il nome del giocatore {i + 1}: ");
                    nomeGiocatori = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nomeGiocatori));

                squadraCasa.Add(nomeGiocatori);
            }
            Console.WriteLine("Inserisci i nome dei giocatori della squadra ospite:");

            List<string> squadraOspite = new List<string>();

            for (int i = 0; i < 11; i++)
            {
                do
                {
                    Console.WriteLine($"Inserisci il nome del giocatore {i + 1}: ");
                    nomeGiocatori = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nomeGiocatori));

                squadraOspite.Add(nomeGiocatori);
            }

            int golCasa;

            do
            {
                Console.WriteLine("Inserisci il numero di gol segnati dalla squadra di casa: ");
            } while (!int.TryParse(Console.ReadLine(), out golCasa) || golCasa < 0);

            int golOspite;

            do
            {
                Console.WriteLine("Inserisci il numero di gol segnati dalla squadra ospite: ");
            } while (!int.TryParse(Console.ReadLine(), out golOspite) || golOspite < 0);

            CPartita partita = new CPartita(squadraCasa, squadraOspite, golCasa, golOspite);

            Console.WriteLine(partita.ToString());

            Console.WriteLine("\nSalvataggio dei dati in formato JSON...");

            string fileName = "ResocontoPartite.json";
            string jsonString = JsonSerializer.Serialize(partita);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine("Dati salvati con successo in formato JSON.\n");
        }

        static void VisualizzaPartite()
        {
            string fileName = "ResocontoPartite.json";

            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                CPartita partite = JsonSerializer.Deserialize<CPartita>(jsonString); // Ricorda di mettere tipo tra parentesi angolari <CPartita> per specificare il tipo di oggetto da deserializzare
                Console.WriteLine("\nResoconto della partita:");
                Console.WriteLine(partite.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("Nessuna partita registrata.");
            }
        }
    }
}
