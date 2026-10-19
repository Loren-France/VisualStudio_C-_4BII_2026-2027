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

            Console.WriteLine("Inserisci i nome dei giocatori della squadra di casa:");

            List<string> squadraCasa = new List<string>();

            string nomeGiocatori;

            for (int i = 0; i < 11; i++)
            {
                do
                {
                    Console.WriteLine($"Inserisci il nome del giocatore {i + 1}: ");
                    nomeGiocatori = Console.ReadLine();
                }while (string.IsNullOrWhiteSpace(nomeGiocatori));

                squadraCasa.Add(nomeGiocatori);

            }


        }
    }
}
