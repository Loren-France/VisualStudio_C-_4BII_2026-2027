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
            Console.WriteLine("===========================================");
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
                Console.WriteLine();
                Console.WriteLine("Azioni disponibili:");
                Console.WriteLine("1. Esegui un elemento (1-5)");
                Console.WriteLine("2. Stampa le informazioni del lettore multimediale");
                Console.WriteLine("3. Aumenta il volume/luminosità di un elemento");
                Console.WriteLine("4. Diminuisci il volume/luminosità di un elemento");
                Console.WriteLine("5. Visualizza film con durata inferiore a riferimento");
                Console.WriteLine("6. Ordina gli elementi multimediali per titolo");
                Console.WriteLine("7. Controlla se 2 filmati sono uguali");
                Console.WriteLine("0. Esci");

                do
                {
                    Console.WriteLine("Scegli un'azione (0-7):");
                } while (!int.TryParse(Console.ReadLine(), out action) || action < 0 || action > 7);

                switch (action)
                {
                    case 1:
                        EseguiElemento();
                        break;
                    case 2:
                        VisualizzaElementi();
                        break;
                    case 3:
                        AumentaParametri();
                        break;
                    case 4:
                        DiminuisciParametri();
                        break;
                    case 5:
                        VisualizzaDurataMinore();
                        break;
                    case 6:
                        OrdinaPerTitolo();
                        break;
                    case 7:
                        ConfrontaFilmati();
                        break;
                    case 0:
                        Console.WriteLine("Uscita dal programma...");
                        break;
                }
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

        static void EseguiElemento()
        {
            int index;
            do
            {
                Console.WriteLine("Inserisci il numero dell'elemento multimediale da eseguire (1-5):");
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > 5);
            CElementoMultimediale elemento = LettoreMultimediale[index - 1];
            if (elemento == null)
            {
                Console.WriteLine("Nessun elemento presente in quella posizione.");
                return;
            }
            Console.WriteLine(elemento.ToString());
            if (elemento is CRegistrazioneAudio audio)
            {
                Console.WriteLine(audio.Play());
            }
            else if (elemento is CImmagine immagine)
            {
                Console.WriteLine(immagine.Show());
            }
            else if (elemento is CFilmato filmato)
            {
                Console.WriteLine(filmato.Play());
            }
        }

        static void VisualizzaElementi()
        {
            Console.WriteLine("Contenuti multimediali nel lettore:");
            for (int i = 0; i < LettoreMultimediale.Length; i++)
            {
                var item = LettoreMultimediale[i];
                Console.WriteLine(item != null ? $"{i + 1}. {item.ToString()}" : $"{i + 1}. <vuoto>");
            }
        }

        static void AumentaParametri()
        {
            int index;
            do
            {
                Console.WriteLine("Inserisci il numero dell'elemento multimediale da modificare (1-5):");
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > 5);
            CElementoMultimediale elemento = LettoreMultimediale[index - 1];
            if (elemento is CRegistrazioneAudio audio)
            {
                int incremento;
                do
                {
                    Console.WriteLine("Inserisci di quanto aumentare il volume:");
                } while (!int.TryParse(Console.ReadLine(), out incremento) || incremento < 0 || incremento > 20);
                Console.WriteLine(audio.Louder(incremento));
            }
            else if (elemento is CImmagine immagine)
            {
                int incremento;
                do
                {
                    Console.WriteLine("Inserisci di quanto aumentare la luminosità:");
                } while (!int.TryParse(Console.ReadLine(), out incremento) || incremento < 0 || incremento > 10);
                Console.WriteLine(immagine.Brighter(incremento));
            }
            else if (elemento is CFilmato filmato)
            {
                int incrementoVolume, incrementoLuminosità;
                do
                {
                    Console.WriteLine("Inserisci di quanto aumentare il volume:");
                } while (!int.TryParse(Console.ReadLine(), out incrementoVolume) || incrementoVolume < 0 || incrementoVolume > 20);
                Console.WriteLine(filmato.Louder(incrementoVolume));
                do
                {
                    Console.WriteLine("Inserisci di quanto aumentare la luminosità:");
                } while (!int.TryParse(Console.ReadLine(), out incrementoLuminosità) || incrementoLuminosità < 0 || incrementoLuminosità > 10);
                Console.WriteLine(filmato.Brighter(incrementoLuminosità));
            }
        }

        static void DiminuisciParametri()
        {
            int index;
            do
            {
                Console.WriteLine("Inserisci il numero dell'elemento multimediale da modificare (1-5):");
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > 5);
            CElementoMultimediale elemento = LettoreMultimediale[index - 1];
            if (elemento is CRegistrazioneAudio audio)
            {
                int decremento;
                do
                {
                    Console.WriteLine("Inserisci di quanto diminuire il volume:");
                } while (!int.TryParse(Console.ReadLine(), out decremento) || decremento < 0 || decremento > 20);
                Console.WriteLine(audio.Weaker(decremento));
            }
            else if (elemento is CImmagine immagine)
            {
                int decremento;
                do
                {
                    Console.WriteLine("Inserisci di quanto diminuire la luminosità:");
                } while (!int.TryParse(Console.ReadLine(), out decremento) || decremento < 0 || decremento > 10);
                Console.WriteLine(immagine.Darker(decremento));
            }
            else if (elemento is CFilmato filmato)
            {
                int decrementoVolume, decrementoLuminosità;
                do
                {
                    Console.WriteLine("Inserisci di quanto diminuire il volume:");
                } while (!int.TryParse(Console.ReadLine(), out decrementoVolume) || decrementoVolume < 0 || decrementoVolume > 20);
                Console.WriteLine(filmato.Weaker(decrementoVolume));
                do
                {
                    Console.WriteLine("Inserisci di quanto diminuire la luminosità:");
                } while (!int.TryParse(Console.ReadLine(), out decrementoLuminosità) || decrementoLuminosità < 0 || decrementoLuminosità > 10);
                Console.WriteLine(filmato.Darker(decrementoLuminosità));
            }
        }

        static void VisualizzaDurataMinore()
        {
            int durataRiferimento;
            CFilmato riferimento;

            do
            {
                Console.WriteLine("Inserisci numero del filmato di riferimento (in secondi) per confrontare la durata:");
            } while (!int.TryParse(Console.ReadLine(), out durataRiferimento) || durataRiferimento <= 0);

            if (LettoreMultimediale[durataRiferimento - 1] is CFilmato filmatoRiferimento)
            {
                riferimento = filmatoRiferimento;
            }
            else
            {
                Console.WriteLine("L'elemento selezionato non è un filmato. Utilizzo della durata di riferimento inserita.");
                riferimento = null;
                return;
            }


            Console.WriteLine($"Filmati con durata inferiore a {durataRiferimento} secondi:");
            foreach (CElementoMultimediale elemento in LettoreMultimediale)
            {
                if (elemento is CFilmato filmato && filmato.Durata < durataRiferimento)
                {
                    Console.WriteLine(filmato.ToString());
                }
            }
        }

        static void OrdinaPerTitolo()
        {
            LettoreMultimediale = LettoreMultimediale.OrderBy(x => x?.Nome).ToArray();
            Console.WriteLine("Elementi multimediali ordinati per titolo:");
            VisualizzaElementi();
        }

        static void ConfrontaFilmati()
        {
            int index1, index2;
            do
            {
                Console.WriteLine("Inserisci il numero del primo filmato da confrontare (1-5):");
            } while (!int.TryParse(Console.ReadLine(), out index1) || index1 < 1 || index1 > 5);
            do
            {
                Console.WriteLine("Inserisci il numero del secondo filmato da confrontare (1-5):");
            } while (!int.TryParse(Console.ReadLine(), out index2) || index2 < 1 || index2 > 5);
            CElementoMultimediale elemento1 = LettoreMultimediale[index1 - 1];
            CElementoMultimediale elemento2 = LettoreMultimediale[index2 - 1];
            if (elemento1 is CFilmato filmato1 && elemento2 is CFilmato filmato2)
            {
                if (filmato1.Equals(filmato2))
                {
                    Console.WriteLine("I due filmati sono uguali.");
                }
                else
                {
                    Console.WriteLine("I due filmati non sono uguali.");
                }
            }
            else
            {
                Console.WriteLine("Uno o entrambi gli elementi selezionati non sono filmati.");
            }
        }
    }
}
