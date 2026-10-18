using System;
using System.Collections.Generic;
using static System.Console;

namespace Franceschetto_AccademiaBotanica
{
    internal class Program
    {
        static List<CHabitat> ListaHabitat = new List<CHabitat>();
        static int HabitatSelezionato = -1;
        static void Main(string[] args)
        {
            WriteLine("PROGRAMMA SULLA GESTIONE E VERIFICA CONDIZIONE PIANTE DI UN'ACCADEMIA BOTANICA, AUTORE: LORENZO FRANCESCHETTO\n");

            int action = 1;

            while (action != 0)
            {
                WriteLine("Azioni disponibili: \n");
                WriteLine("1. Crea un habitat");
                WriteLine("2. Selezionare un habitat");
                WriteLine("3. Aggiungi una pianta all'habitat selezionato");
                WriteLine("4. Rimuovi una painta all'habitat selezionato");
                WriteLine("5. Visualizza le piante presenti nell'habitat selezionato");
                WriteLine("6. Cerca una pianta nell'habitat selezionato");
                WriteLine("7. Modifica valori dei sensori dell'habitat selezionato");
                WriteLine("8. Esegui il controllo generale");
                WriteLine("0. Esci dal programma");

                do
                {
                    Write("Inserisci il numero corrispondente all'azione da eseguire (0-8): ");
                } while (!int.TryParse(Console.ReadLine(), out action) || action < 0 || action > 8);

                switch (action)
                {
                    case 1:
                        CreazioneHabitat();
                        break;
                    case 2:
                        SelezionaHabitat();
                        break;
                    case 3:
                        CreaPianta();
                        break;
                    case 4:
                        RimuoviPianta();
                        break;
                    case 5:
                        VisualizzaPiante();
                        break;
                    case 6:
                        CercaPianta();
                        break;
                    case 7:
                        ModificaSensori();
                        break;
                    case 8:
                        ControlloGenerale();
                        break;
                    case 0:
                        WriteLine("Uscita dal programma...");
                        break;
                }
            }
            return;
        }

        static void CreazioneHabitat()
        {
            string name;
            int month;
            double temperature, umidity, luminosity;

            WriteLine("Creazione habitat...");

            do
            {
                Write("Inserisci il nome dell'habitat: ");
                name = ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            do
            {
                Write("Inserisci il mese corrente in formato numerico (1~12): ");
            } while (!int.TryParse(ReadLine(), out month) || month < 1 || month > 12);

            do
            {
                Write("Inserisci il valore del sensore di temperatura (-5~12): ");
            } while (!double.TryParse(ReadLine(), out temperature) || month < -5 || month > 35);

            do
            {
                Write("Inserisci il valore del sensore di luminosità in % (0~100): ");
            } while (!double.TryParse(ReadLine(), out luminosity) || luminosity < 0 || luminosity > 100);

            do
            {
                Write("Inserisci il valore del sensore di umidità in % (0~100): ");
            } while (!double.TryParse(ReadLine(), out umidity) || umidity < 0 || umidity > 100);

            CStatoAmbientale state = new CStatoAmbientale();

            state.Mese = month;
            state.SensoreTemperatura = temperature;
            state.SensoreLuminosità = luminosity;
            state.SensoreUmidità = umidity;

            CHabitat nuovoHabitat = new CHabitat(name, state);

            foreach (CHabitat habitat in ListaHabitat)
            {
                if (habitat.Equals(nuovoHabitat))
                {
                    WriteLine("Errore: Habitat già esistente. Non è possibile aggiungerlo.");
                    return;
                }
            }

            ListaHabitat.Add(nuovoHabitat);
            WriteLine("Nuovo habitat aggiunto correttamente!");
        }

        static void SelezionaHabitat()
        {
            if (ListaHabitat.Count == 0)
            {
                WriteLine("Nessun habitat disponibile. Creane uno prima di selezionarlo.");
                return;
            }

            do
            {
                WriteLine("Inserire il numero dell'habitat da selezionare (1~" + ListaHabitat.Count + "): ");
                VisualizzaHabitat();
            } while (!int.TryParse(ReadLine(), out HabitatSelezionato) || HabitatSelezionato < 1 || HabitatSelezionato > ListaHabitat.Count);

            WriteLine("Habitat selezionato: " + HabitatSelezionato);
            VisualizzaHabitat();
        }

        static void VisualizzaHabitat()
        {
            ListaHabitat.Sort();

            WriteLine("Lista di habitat registrati: ");
            for (int i = 0; i < ListaHabitat.Count; i++)
            {
                WriteLine($"{i + 1}. {ListaHabitat[i].DescrizioneHabitat()}");
            }
            WriteLine();
            WriteLine($"Habitat selezionato: {HabitatSelezionato}");
            WriteLine();
        }

        static void CreaPianta()
        {
            if (ListaHabitat.Count == 0)
            {
                WriteLine("Prima devi creare almeno un habitat.");
                return;
            }

            if (HabitatSelezionato < 1 || HabitatSelezionato > ListaHabitat.Count)
            {
                WriteLine("Nessun habitat selezionato. Selezionane uno prima di aggiungere una pianta.");
                SelezionaHabitat();
                if (HabitatSelezionato < 1 || HabitatSelezionato > ListaHabitat.Count)
                {
                    return;
                }
            }

            string nome;
            int eta;
            bool foglie;
            int tipoPianta;

            WriteLine("Aggiunta nuova pianta...");

            do
            {
                Write("Inserisci il nome della pianta: ");
                nome = ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Write("Inserisci l'età della pianta: ");
            } while (!int.TryParse(ReadLine(), out eta) || eta < 0);

            string rispostaFoglie;
            do
            {
                Write("La pianta ha le foglie? (s/n): ");
                rispostaFoglie = ReadLine();
            } while (string.IsNullOrWhiteSpace(rispostaFoglie) || (rispostaFoglie.ToLower() != "s" && rispostaFoglie.ToLower() != "n"));
            foglie = rispostaFoglie.ToLower() == "s";

            WriteLine("Seleziona il tipo di pianta:");
            WriteLine("1. Tropicale");
            WriteLine("2. Mediterranea");
            WriteLine("3. Temperata");

            do
            {
                Write("Tipo di pianta: ");
            } while (!int.TryParse(ReadLine(), out tipoPianta) || tipoPianta < 1 || tipoPianta > 3);

            CPianta nuovaPianta;

            switch (tipoPianta)
            {
                case 1:
                    {
                        double umidita;
                        do
                        {
                            Write("Inserisci l'umidità ideale della pianta in % (0~100): ");
                        } while (!double.TryParse(ReadLine(), out umidita) || umidita < 0 || umidita > 100);
                        nuovaPianta = new CPiantaTropicale(nome, eta, foglie, umidita);
                        break;
                    }
                case 2:
                    {
                        double luminosita;
                        do
                        {
                            Write("Inserisci la luminosità ideale della pianta in % (0~100): ");
                        } while (!double.TryParse(ReadLine(), out luminosita) || luminosita < 0 || luminosita > 100);
                        nuovaPianta = new CPiantaMediterranea(nome, eta, foglie, luminosita);
                        break;
                    }
                default:
                    {
                        double temperatura;
                        do
                        {
                            Write("Inserisci la temperatura ideale della pianta in °C: ");
                        } while (!double.TryParse(ReadLine(), out temperatura));
                        nuovaPianta = new CPiantaTemperata(nome, eta, foglie, temperatura);
                        break;
                    }
            }

            if (ListaHabitat[HabitatSelezionato - 1].ListaPiante.Contains(nuovaPianta))
            {
                WriteLine("Errore: Pianta già presente nell'habitat selezionato. Non è possibile aggiungerla.");
                return;
            }

            ListaHabitat[HabitatSelezionato - 1].AggiungiPianta(nuovaPianta);
            WriteLine("Pianta aggiunta correttamente all'habitat selezionato!");
        }

        static void RimuoviPianta()
        {
            CHabitat habitat = ListaHabitat[HabitatSelezionato - 1];

            string nome, specie;

            do
            {
                Write("Inserisci il nome della pianta da rimuovere: ");
                nome = ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Write("Inserisci la specie della pianta da rimuovere (tropicale, mediterranea, temperata): ");
                specie = ReadLine().ToLower();
            } while (string.IsNullOrWhiteSpace(specie) || (specie != "tropicale" && specie != "mediterranea" && specie != "temperata"));

            CPianta piantaDaRimuovere;

            if (specie == "tropicale")
            {
                piantaDaRimuovere = new CPiantaTropicale(nome, 0, false, 0);
            }
            else if (specie == "mediterranea")
            {
                piantaDaRimuovere = new CPiantaMediterranea(nome, 0, false, 0);
            }
            else
            {
                piantaDaRimuovere = new CPiantaTemperata(nome, 0, false, 0);
            }

            foreach (CPianta pianta in habitat.ListaPiante)
            {
                if (pianta.Equals(piantaDaRimuovere))
                {
                    habitat.RimuoviPianta(pianta);
                    WriteLine("Pianta rimossa correttamente dall'habitat selezionato!");
                    return;
                }
            }
            WriteLine("Pianta non trovata nell'habitat selezionato.");
        }

        static void VisualizzaPiante()
        {
            CHabitat habitat = ListaHabitat[HabitatSelezionato - 1];

            if (habitat.ListaPiante.Count == 0)
            {
                WriteLine("Nessuna pianta presente nell'habitat selezionato.");
                return;
            }

            foreach (CPianta pianta in habitat.ListaPiante)
            {
                WriteLine(pianta.Descrizione());
            }
        }

        static void ModificaSensori()
        {
            if (ListaHabitat.Count == 0)
            {
                WriteLine("Prima devi creare almeno un habitat.");
                return;
            }

            if (HabitatSelezionato < 1 || HabitatSelezionato > ListaHabitat.Count)
            {
                WriteLine("Nessun habitat selezionato. Selezionane uno prima di modificare i sensori.");
                SelezionaHabitat();
                if (HabitatSelezionato < 1 || HabitatSelezionato > ListaHabitat.Count)
                {
                    return;
                }
            }

            CHabitat habitat = ListaHabitat[HabitatSelezionato - 1];
            int mese;
            double temperatura, umidita, luminosita;

            WriteLine("Modifica sensori dell'habitat selezionato...");

            do
            {
                Write("Inserisci il mese corrente in formato numerico (1~12): ");
            } while (!int.TryParse(ReadLine(), out mese) || mese < 1 || mese > 12);

            do
            {
                Write("Inserisci il valore del sensore di temperatura (-5~35): ");
            } while (!double.TryParse(ReadLine(), out temperatura) || temperatura < -5 || temperatura > 35);

            do
            {
                Write("Inserisci il valore del sensore di luminosità in % (0~100): ");
            } while (!double.TryParse(ReadLine(), out luminosita) || luminosita < 0 || luminosita > 100);

            do
            {
                Write("Inserisci il valore del sensore di umidità in % (0~100): ");
            } while (!double.TryParse(ReadLine(), out umidita) || umidita < 0 || umidita > 100);

            habitat.Mese = mese;
            habitat.SensoreTemperatura = temperatura;
            habitat.SensoreLuminosità = luminosita;
            habitat.SensoreUmidità = umidita;

            WriteLine("Valori dei sensori aggiornati correttamente!");
        }

        static void ControlloGenerale()
        {
            if (ListaHabitat.Count == 0)
            {
                WriteLine("Prima devi creare almeno un habitat.");
                return;
            }
            foreach (CHabitat habitat in ListaHabitat)
            {
                WriteLine($"Controllo delle piante nell'habitat: {habitat.Nome}");
                foreach (CPianta pianta in habitat.ListaPiante)
                {
                    bool condizioniAdeguate = pianta.CondizioniAdeguate(habitat);
                    if (condizioniAdeguate)
                    {
                        WriteLine($"{pianta.Descrizione()}, Condizioni: ADEGUATE");
                    }
                    else
                    {
                        WriteLine($"{pianta.Descrizione()}, Condizioni: NON ADEGUATE");
                    }
                }
                WriteLine();
            }
        }

        static void CercaPianta()
        {
            CHabitat habitat = ListaHabitat[HabitatSelezionato - 1];
            string nome, specie;
            do
            {
                Write("Inserisci il nome della pianta da cercare: ");
                nome = ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            do
            {
                Write("Inserisci la specie della pianta da cercare (tropicale, mediterranea, temperata): ");
                specie = ReadLine().ToLower();
            } while (string.IsNullOrWhiteSpace(specie) || (specie != "tropicale" && specie != "mediterranea" && specie != "temperata"));

            CPianta piantaDaCercare;

            if (specie == "tropicale")
            {
                piantaDaCercare = new CPiantaTropicale(nome, 0, false, 0);
            }
            else if (specie == "mediterranea")
            {
                piantaDaCercare = new CPiantaMediterranea(nome, 0, false, 0);
            }
            else
            {
                piantaDaCercare = new CPiantaTemperata(nome, 0, false, 0);
            }

            foreach (CPianta pianta in habitat.ListaPiante)
            {
                if (pianta.Equals(piantaDaCercare))
                {
                    WriteLine("Pianta trovata: " + pianta.Descrizione());
                    return;
                }
            }

            WriteLine("Pianta non trovata nell'habitat selezionato.");
        }
    }
}
