namespace esUEFA
{
    internal class Program
    {
        static RepositoryPartite ListaPartite = new RepositoryPartite();
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMMA GESTIONE UEFA MICRONATIONS");

            ListaPartite.Carica();

            int action = 1;

            while (action != 0)
            {
                Console.WriteLine("1.Visualizza le partite in ordine naturale");
                Console.WriteLine("2.Visualizza le partite ordinate secondo uno dei criteri, a scelta dell’utente");
                Console.WriteLine("3.Inserisci una partita(gironi o eliminazione; i rigori vengono chiesti solo in caso di pareggio)");
                Console.WriteLine("4.Mostra la classifica dei gironi");
                Console.WriteLine("5.Cerca le partite di una squadra");
                Console.WriteLine("6.Elimina una partita");
                Console.WriteLine("0. Esci");
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Seleziona un'opzione (0-6): ");
                }
                while (!int.TryParse(Console.ReadLine(), out action) || action < 0 || action > 6);

                Console.WriteLine();

                switch (action)
                {
                    case 1:
                        VisualizzaPartite();
                        break;

                    case 2:
                        VisualizzaPartiteOrdinate();
                        break;

                    case 3:
                        InserisciPartita();
                        ListaPartite.Salva();
                        break;

                    case 4:
                        MostraClassifica();
                        break;

                    case 5:
                        CercaPartiteSquadra();
                        break;

                    case 6:
                        EliminaPartita();
                        ListaPartite.Salva();
                        break;

                    case 0:
                        Console.WriteLine("Chiusura programma...");
                        break;
                }
            }
        }

        static void VisualizzaPartite()
        {
            IReadOnlyList<CPartita> partite = ListaPartite.GetElenco();

            if (partite.Count == 0)
            {
                Console.WriteLine("Nessuna partita registrata.");
                return;
            }

            foreach (var partita in partite)
            {
                Console.WriteLine(partita.Descrizione());
                Console.WriteLine();
            }
        }

        static void VisualizzaPartiteOrdinate()
        {
            string criterio = "naturale";

            IReadOnlyList<CPartita> partite = ListaPartite.GetElenco();
            if (partite.Count == 0)
            {
                Console.WriteLine("Nessuna partita registrata.");
                return;
            }
            do
            {
                Console.WriteLine("Inserisci il criterio di ordinamento (naturale, gol, scarto, casaAZ, casaZA): ");
                criterio = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(criterio));

            try
            {
                CPartita.Criterio = criterio;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return;
            }

            List<CPartita> partiteOrdinate = new List<CPartita>(partite);

            partiteOrdinate.Sort();

            foreach (var partita in partiteOrdinate)
            {
                Console.WriteLine(partita.Descrizione());
                Console.WriteLine();
            }
        }

        static void InserisciPartita()
        {
            try
            {
                int tipoPartita;

                do
                {
                    Console.WriteLine("Tipo di partita:");
                    Console.WriteLine("1. Girone");
                    Console.WriteLine("2. Eliminazione");
                    Console.WriteLine("Seleziona un'opzione (1-2): ");
                }
                while (!int.TryParse(Console.ReadLine(), out tipoPartita) || (tipoPartita != 1 && tipoPartita != 2));

                int giornata;

                do
                {
                    Console.WriteLine("Inserisci la giornata:");
                }
                while (!int.TryParse(Console.ReadLine(), out giornata) || giornata < 1);

                string squadraCasa;

                do
                {
                    Console.WriteLine("Inserisci il nome della squadra di casa:");
                    squadraCasa = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(squadraCasa));

                string squadraOspite;

                do
                {
                    Console.WriteLine("Inserisci il nome della squadra ospite:");
                    squadraOspite = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(squadraOspite)
                       || squadraOspite.ToLower() == squadraCasa.ToLower());

                int golCasa;

                do
                {
                    Console.WriteLine("Inserisci il numero di gol della squadra di casa:");
                }
                while (!int.TryParse(Console.ReadLine(), out golCasa)
                       || golCasa < 0);

                int golOspite;

                do
                {
                    Console.WriteLine("Inserisci il numero di gol della squadra ospite:");
                }
                while (!int.TryParse(Console.ReadLine(), out golOspite)
                       || golOspite < 0);

                if (tipoPartita == 1)
                {
                    Console.WriteLine("Partita del girone inserita correttamente.");

                    CPartitaGirone girone = new CPartitaGirone(giornata, squadraCasa, squadraOspite, golCasa, golOspite);
                    ListaPartite.Aggiungi(girone);
                }
                else
                {
                    int? rigoriCasa = null;
                    int? rigoriOspite = null;

                    if (golCasa == golOspite)
                    {
                        int tempCasa;

                        do
                        {
                            Console.WriteLine("Inserisci i rigori della squadra di casa:");
                        }
                        while (!int.TryParse(Console.ReadLine(), out tempCasa)
                               || tempCasa < 0);

                        rigoriCasa = tempCasa;

                        int tempOspite;

                        do
                        {
                            Console.WriteLine("Inserisci i rigori della squadra ospite:");
                        }
                        while (!int.TryParse(Console.ReadLine(), out tempOspite)
                               || tempOspite < 0
                               || tempOspite == tempCasa);

                        rigoriOspite = tempOspite;
                    }

                    Console.WriteLine("Partita ad eliminazione inserita correttamente.");

                    CPartitaEliminazione eliminatoria = new CPartitaEliminazione(giornata, squadraCasa, squadraOspite, golCasa, golOspite, rigoriCasa, rigoriOspite);
                    ListaPartite.Aggiungi(eliminatoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        static void MostraClassifica()
        {
            IReadOnlyList<CPartita> partite = ListaPartite.GetElenco();

            if (partite.Count == 0)
            {
                Console.WriteLine("Nessuna partita registrata.");
                return;
            }

            List<CStatisticheSquadra> classifica = new List<CStatisticheSquadra>();

            foreach (CPartita partita in partite)
            {
                if (!(partita is CPartitaGirone))
                    continue;

                CStatisticheSquadra statsCasa = null;
                CStatisticheSquadra statsOspite = null;

                foreach (CStatisticheSquadra stats in classifica)
                {
                    if (stats.Squadra.ToLower() == partita.SquadraCasa.ToLower())
                        statsCasa = stats;

                    if (stats.Squadra.ToLower() == partita.SquadraOspite.ToLower())
                        statsOspite = stats;
                }

                if (statsCasa == null)
                {
                    statsCasa = new CStatisticheSquadra(partita.SquadraCasa);
                    classifica.Add(statsCasa);
                }

                if (statsOspite == null)
                {
                    statsOspite = new CStatisticheSquadra(partita.SquadraOspite);
                    classifica.Add(statsOspite);
                }

                statsCasa.PartiteGiocate++;
                statsOspite.PartiteGiocate++;

                statsCasa.GolFatti += partita.GolCasa;
                statsCasa.GolSubiti += partita.GolOspite;

                statsOspite.GolFatti += partita.GolOspite;
                statsOspite.GolSubiti += partita.GolCasa;

                int puntiCasa = partita.PuntiPer(partita.SquadraCasa);
                int puntiOspite = partita.PuntiPer(partita.SquadraOspite);

                statsCasa.Punti += puntiCasa;
                statsOspite.Punti += puntiOspite;

                if (puntiCasa == 3)
                {
                    statsCasa.Vittorie++;
                    statsOspite.Sconfitte++;
                }
                else if (puntiCasa == 1)
                {
                    statsCasa.Pareggi++;
                    statsOspite.Pareggi++;
                }
                else
                {
                    statsCasa.Sconfitte++;
                    statsOspite.Vittorie++;
                }
            }

            classifica.Sort();

            Console.WriteLine();
            Console.WriteLine("Stampa della classifica dei gironi:");

            foreach (CStatisticheSquadra stats in classifica)
            {
                Console.WriteLine(stats.Descrizione());
            }
        }

        static void CercaPartiteSquadra()
        {
            IReadOnlyList<CPartita> partite = ListaPartite.GetElenco();

            if (partite.Count == 0)
            {
                Console.WriteLine("Nessuna partita registrata.");
                return;
            }

            string squadra;

            do
            {
                Console.WriteLine("Inserisci il nome della squadra da cercare:");
                squadra = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(squadra));

            bool trovata = false;

            Console.WriteLine();
            Console.WriteLine($"Partite trovate per {squadra}:");
            Console.WriteLine();

            foreach (CPartita partita in partite)
            {
                if (partita.SquadraCasa.ToLower() == squadra.ToLower() || partita.SquadraOspite.ToLower() == squadra.ToLower())
                {
                    Console.WriteLine(partita.Descrizione());
                    Console.WriteLine();
                    trovata = true;
                }
            }

            if (!trovata)
            {
                Console.WriteLine("Nessuna partita trovata per questa squadra.");
            }
        }

        static void EliminaPartita()
        {
            IReadOnlyList<CPartita> partite = ListaPartite.GetElenco();

            if (partite.Count == 0)
            {
                Console.WriteLine("Nessuna partita registrata.");
                return;
            }

            Console.WriteLine("Partite registrate:");

            for (int i = 0; i < partite.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {partite[i].Descrizione()}");
            }

            int scelta;

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Seleziona la partita da eliminare (1-{partite.Count}):");
            }
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > partite.Count);

            CPartita partitaDaEliminare = partite[scelta - 1];

            ListaPartite.Rimuovi(partitaDaEliminare);

            Console.WriteLine("Partita eliminata correttamente.");
        }

    }
}

