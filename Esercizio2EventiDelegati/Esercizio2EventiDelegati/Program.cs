using System;
using System.Collections.Generic;
using System.Linq;

namespace Esercizio2EventiDelegati
{
    internal class Program
    {
        delegate bool CriterioFiltro(int numero);

        static bool FiltroPari(int numero)
        {
            return numero % 2 == 0;
        }

        static bool FiltroDispari(int numero)
        {
            return numero % 2 != 0;
        }

        static bool FiltroMaggioreDi(int numero, int max)
        {
            return numero > max;
        }

        static List<int> FiltraNumeri(List<int> numeri, CriterioFiltro criterio)
        {
            List<int> numeriFiltrati = new List<int>();
            foreach (int numero in numeri)
            {
                if (criterio(numero))
                {
                    numeriFiltrati.Add(numero);
                }
            }
            return numeriFiltrati;
        }


        static void Main(string[] args)
        {
            List<int> numeri = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int scelta = 0;
            int max = 0;

            do
            {
                Console.WriteLine("Cosa vuoi fare con i numeri?");
                Console.WriteLine("1. Filtra i numeri pari");
                Console.WriteLine("2. Filtra i numeri dispari");
                Console.WriteLine("3. Filtra i numeri maggiori di 5");
                Console.WriteLine("4. Esci");
            }
            while (!int.TryParse(Console.ReadLine(), out scelta));

            switch (scelta)
            {
                case 1:
                    List<int> numeriPari = FiltraNumeri(numeri, FiltroPari);
                    Console.WriteLine("Numeri pari: " + string.Join(", ", numeriPari));
                    break;
                case 2:
                    List<int> numeriDispari = FiltraNumeri(numeri, FiltroDispari);
                    Console.WriteLine("Numeri dispari: " + string.Join(", ", numeriDispari));
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Inserisci un numero maggiore di 0 per filtrare i numeri maggiori di esso:");
                    } while(!int.TryParse(Console.ReadLine(), out max) || max <= 0);

                    List<int> numeriMaggioriTre = FiltraNumeri(numeri,FiltroMaggioreDi(numeri, max));
                    Console.WriteLine("Numeri maggiori di 5: " + string.Join(", ", numeriMaggioriTre));
                    break;
                case 4:
                    Console.WriteLine("Uscita dal programma.");
                    return;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }
}
