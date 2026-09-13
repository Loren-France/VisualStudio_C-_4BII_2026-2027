using System;
using System.Collections.Generic;
using System.Xml.Schema;


namespace esCambioSegno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control;

            Console.WriteLine("PROGRAMMA CAMBIO SEGNO");

            Console.WriteLine("Inserisci quanti numeri vuoi inserire:");

            int n;
            int cont = 0;

            do
            {
                control = int.TryParse(Console.ReadLine(), out n);
                
                if (!control || n <= 0)
                {
                    Console.WriteLine("Errore: inserisci un numero intero positivo.");
                }
            }
            while (!control || n <= 0);

            int[] numeri = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Inserisci il numero {i + 1}:");
                do
                {
                    control = int.TryParse(Console.ReadLine(), out numeri[i]);
                    if (!control)
                    {
                        Console.WriteLine("Errore: inserisci un numero intero.");
                    }
                }
                while (!control);
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (numeri[i] > 0 && numeri[i+1] < 0)
                {
                    cont++;
                }
                else if (numeri[i] < 0 && numeri[i + 1] > 0)
                {
                    cont++;
                }
            }

            Console.WriteLine($"Il numero di cambi di segno è: {cont}");
        }
    }
}
