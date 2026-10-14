using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esContenutiMultimediali
{
    internal class Program
    {
        static CElementoMultimediale[] LettoreMultimediale = new CElementoMultimediale[5];
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMMA DI GESTIONE ELEMENTI MULTIMEDIALI");
            Console.WriteLine("===========================================");

            Console.WriteLine("Crea 5 contenuti multimediali...");

            for (int i = 0; i < LettoreMultimediale.Length; i++)
            {
                Console.WriteLine($"Contenuto multimediale {i + 1}:");
                CElementoMultimediale NewElement = CreaElementoMultimediale();
                LettoreMultimediale[i] = NewElement;
            }


            int action = 1;

            while (action != 0)
            {
                Console.WriteLine("Azioni disponibili:");
                Console.WriteLine("1. Aggiungi un elemento multimediale");
            }
        }

        static CElementoMultimediale CreaElementoMultimediale()
        {
            string nome;
            Console.WriteLine("Inserisci il nome del contenuto multimediale:");
            do
            {
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Il nome non può essere vuoto. Riprova.");
                }
            } while (string.IsNullOrWhiteSpace(nome));

            int tipo;

            do
            {
                Console.WriteLine("Scegli il tipo di contenuto multimediale da creare:");
                Console.WriteLine("1. Registrazione audio");
                Console.WriteLine("2. Immagine");
                Console.WriteLine("3. Filmato");
                tipo = Convert.ToInt32(Console.ReadLine());
                if (tipo < 1 || tipo > 3)
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }
            } while (tipo < 1 || tipo > 3);

            switch (tipo)
            {
                case 1:

                    int durata, volume;

                    do
                    {
                        Console.WriteLine("Inserisci la durata della registrazione audio (in secondi):");
                    } while (!int.TryParse(Console.ReadLine(), out durata) || durata <= 0);

                    do
                    {
                        Console.WriteLine("Inserisci il volume della registrazione audio (da 0 a 100):");
                    } while (!int.TryParse(Console.ReadLine(), out volume) || volume < 0 || volume > 100);

                    return new CRegistrazioneAudio(nome, durata, volume);

                case 2:

                    int lumos;

                    do
                    {
                        Console.WriteLine("Inserisci il luminosità dell'immagine (da 0 a 10):");
                    } while (!int.TryParse(Console.ReadLine(), out lumos) || lumos < 0 || lumos > 10);

                    return new CImmagine(nome, lumos);
                case 3:

                    int dur, vol, lum;

                    do
                    {
                        Console.WriteLine("Inserisci la durata della registrazione audio (in secondi):");
                    } while (!int.TryParse(Console.ReadLine(), out durata) || durata <= 0);

                    do
                    {
                        Console.WriteLine("Inserisci il volume della registrazione audio (da 0 a 20):");
                    } while (!int.TryParse(Console.ReadLine(), out volume) || volume < 0 || volume > 20);

                    do
                    {
                        Console.WriteLine("Inserisci il luminosità dell'immagine (da 0 a 10):");
                    } while (!int.TryParse(Console.ReadLine(), out lumos) || lumos < 0 || lumos > 10);

                    return new CFilmato(nome, durata, volume, lumos);

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    return CreaElementoMultimediale();
            }
        }
    }
}
