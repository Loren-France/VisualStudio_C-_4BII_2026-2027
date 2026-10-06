

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGestioneMacchinari
{
    internal class Program
    {
        static List<CMacchinariPesanti> parcheggio = new List<CMacchinariPesanti>();
        static CCantiere cantiere = new CCantiere("Cantiere di Mimmo e Geo");

        static void Main(string[] args)
        {
            CGru gru1 = new CGru("AB123CD", "Gru XL", 2020, 200, true, 100, 80);
            CGru gru2 = new CGru("AB124CD", "Gru XXL", 2021, 250, true, 120, 90);
            CBetoniere betoniera1 = new CBetoniere("AB125CD", "Betoniera 500", 2020, 180, true, 500, 300);
            CBetoniere betoniera2 = new CBetoniere("AB126CD", "Betoniera 2000", 2020, 180, true, 500, 300);
            CRuspe ruspa1 = new CRuspe("AB127CD", "Ruspa CAT", 2021, 200, true, TipoRuspa.Tipo3);
            CRuspe ruspa2 = new CRuspe("AB128CD", "Ruspa KOMATSU", 2022, 220, true, TipoRuspa.Tipo4);

            parcheggio.Add(gru1);
            parcheggio.Add(gru2);
            parcheggio.Add(betoniera1);
            parcheggio.Add(betoniera2);
            parcheggio.Add(ruspa1);
            parcheggio.Add(ruspa2);

            Console.WriteLine("PROGRAMMA GESTIONE MACCHINARI");

            Console.WriteLine("Cantiere creato: " + cantiere.Nome);

            int action = 0;

            while (action != 10)
            {
                Console.WriteLine("\nSeleziona un'azione: \n");
                Console.WriteLine("1. Visualizza macchinari presenti nel parcheggio");
                Console.WriteLine("2. Visualizza descrizione completa macchinari");
                Console.WriteLine("3. Assegna macchinario ad un cantiere");
                Console.WriteLine("4. Libera macchinario da un cantiere");
                Console.WriteLine("5. Cambia benna di una ruspa");
                Console.WriteLine("6. Aumenta l'altezza di una gru");
                Console.WriteLine("7. Diminuisci l'altezza di una gru");
                Console.WriteLine("8. Carica cemento su una betoniera");
                Console.WriteLine("9. Versa cemento da una betoniera");
                Console.WriteLine("10. Esci");

                do
                {
                    Console.Write("\nInserisci il numero dell'azione desiderata: ");
                } while (!int.TryParse(Console.ReadLine(), out action));

                switch (action)
                {
                    case 1:
                        VisualizzaParcheggio();
                        break;
                    case 2:
                        VisualizzaMacchiari();
                        break;
                    case 3:
                        AggiungiMacchinario();
                        break;
                    case 4:
                        LiberaMacchinario();
                        break;
                    case 5:
                        CambioBennaRuspa();
                        break;
                    case 6:
                        AumentoAltezza();
                        break;
                    case 7:
                        DiminuzioneAltezza();
                        break;
                    case 8:
                        CaricaCemento();
                        break;
                    case 9:
                        VersaCemento();
                        break;
                    case 10:
                        Console.WriteLine("Uscita dal programma...");
                        return;
                    default:
                        Console.WriteLine("Azione non valida.");
                        break;
                }
            }
        }

        static void VisualizzaParcheggio()
        {
            Console.WriteLine("\nMacchinari presenti nel parcheggio:");
            foreach (var macchinario in parcheggio)
            {
                Console.WriteLine($"[{macchinario.LicensePlate}] {macchinario.Model}");
            }
        }

        static void VisualizzaMacchiari()
        {
            Console.WriteLine("\nDescrizione completa dei macchinari:");
            foreach (var macchinario in parcheggio)
            {
                Console.WriteLine(macchinario.Descrizione());
            }
        }

        static void AggiungiMacchinario()
        {
            string targa = "";

            do
            {
                Console.Write("Inserisci la targa del macchinario da aggiungere: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));

            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa)
                {
                    cantiere.AggiungiMacchinario(macchinario);
                    Console.WriteLine($"Macchinario {macchinario.Model} con targa {macchinario.LicensePlate} aggiunto al cantiere.");
                    return;
                }
            }
        }

        static void LiberaMacchinario()
        {
            string targa = "";
            do
            {
                Console.Write("Inserisci la targa del macchinario da liberare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));

            foreach (var macchinario in cantiere.Macchinari)
            {
                if (macchinario.LicensePlate == targa)
                {
                    macchinario.LiberaMacchinario();
                    Console.WriteLine($"Macchinario {macchinario.Model} con targa {macchinario.LicensePlate} liberato dal cantiere.");
                    return;
                }
            }
        }

        static void CambioBennaRuspa()
        {
            string targa = "";

            do
            {
                Console.Write("Inserisci la targa della ruspa da modificare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));

            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa && macchinario is CRuspe ruspa)
                {
                    Console.WriteLine($"Benna attuale: {ruspa.Tipo}");
                    Console.WriteLine("Seleziona il nuovo tipo di benna:");
                    foreach (var tipo in Enum.GetValues(typeof(TipoRuspa)))
                    {
                        Console.WriteLine($"{(int)tipo} - {tipo}");
                    }
                    int nuovoTipo;
                    do
                    {
                        Console.Write("Inserisci il numero corrispondente al nuovo tipo di benna: ");
                    } while (!int.TryParse(Console.ReadLine(), out nuovoTipo) || !Enum.IsDefined(typeof(TipoRuspa), nuovoTipo));
                    ruspa.CambioBenna((TipoRuspa)nuovoTipo);
                    Console.WriteLine($"Benna della ruspa con targa {ruspa.LicensePlate} cambiata a {ruspa.Tipo}.");
                    return;
                }
            }
            Console.WriteLine("Ruspa non trovata.");
        }

        static void AumentoAltezza()
        {
            string targa = "";
            do
            {
                Console.Write("Inserisci la targa della gru da modificare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));

            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa && macchinario is CGru gru)
                {
                    Console.WriteLine($"Altezza attuale: {gru.AltezzaLavoro} / {gru.AltezzaMax}");
                    int incremento;
                    do
                    {
                        Console.Write("Inserisci l'incremento di altezza: ");
                    } while (!int.TryParse(Console.ReadLine(), out incremento) || incremento <= 0);

                    gru.AumentaAltezza(incremento);

                    Console.WriteLine($"Altezza della gru con targa {gru.LicensePlate} aumentata a {gru.AltezzaLavoro}.");
                    return;
                }
            }
            Console.WriteLine("Gru non trovata.");
        }

        static void DiminuzioneAltezza()
        {
            string targa = "";
            do
            {
                Console.Write("Inserisci la targa della gru da modificare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));
            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa && macchinario is CGru gru)
                {
                    Console.WriteLine($"Altezza attuale: {gru.AltezzaLavoro} / {gru.AltezzaMax}");
                    int decremento;
                    do
                    {
                        Console.Write("Inserisci il decremento di altezza: ");
                    } while (!int.TryParse(Console.ReadLine(), out decremento) || decremento <= 0);
                    if (gru.AltezzaLavoro - decremento < 0)
                    {
                        Console.WriteLine("Errore: l'altezza della gru non può essere negativa.");
                        return;
                    }
                    gru.DiminuisciAltezza(decremento);
                    Console.WriteLine($"Altezza della gru con targa {gru.LicensePlate} diminuita a {gru.AltezzaLavoro}.");
                    return;
                }
            }
            Console.WriteLine("Gru non trovata.");
        }

        static void CaricaCemento()
        {
            string targa = "";
            do
            {
                Console.Write("Inserisci la targa della betoniera da caricare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));
            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa && macchinario is CBetoniere betoniera)
                {
                    Console.WriteLine($"Capacità attuale: {betoniera.CapacitàAttuale} / {betoniera.CapacitàMax}");
                    double quantità;
                    do
                    {
                        Console.Write("Inserisci la quantità di cemento da caricare: ");
                    } while (!double.TryParse(Console.ReadLine(), out quantità) || quantità <= 0);
                    try
                    {
                        betoniera.CaricaCemento(quantità);
                        Console.WriteLine($"Cemento caricato. Capacità attuale della betoniera con targa {betoniera.LicensePlate}: {betoniera.CapacitàAttuale}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                    return;
                }
            }
            Console.WriteLine("Betoniera non trovata.");
        }

        static void VersaCemento()
        {
            string targa = "";
            do
            {
                Console.Write("Inserisci la targa della betoniera da svuotare: ");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa) || string.IsNullOrEmpty(targa));
            foreach (var macchinario in parcheggio)
            {
                if (macchinario.LicensePlate == targa && macchinario is CBetoniere betoniera)
                {
                    Console.WriteLine($"Capacità attuale: {betoniera.CapacitàAttuale} / {betoniera.CapacitàMax}");
                    double quantità;
                    do
                    {
                        Console.Write("Inserisci la quantità di cemento da versare: ");
                    } while (!double.TryParse(Console.ReadLine(), out quantità) || quantità <= 0);
                    try
                    {
                        betoniera.VersaCemento(quantità);
                        Console.WriteLine($"Cemento versato. Capacità attuale della betoniera con targa {betoniera.LicensePlate}: {betoniera.CapacitàAttuale}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                    return;
                }
            }
            Console.WriteLine("Betoniera non trovata.");
        }
    }
}

