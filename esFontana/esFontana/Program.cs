namespace esFontana
{
    internal class Program
    {
        static List<CFontana> fontane = new List<CFontana>();
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMMA SU GESTIONE DI PIAZZE E FONTANE");

            int action = 0;

            do
            {
                Console.WriteLine("Azioni disponibili:");
                Console.WriteLine("1. Crea fontana");
                Console.WriteLine("2. Crea piazza");
                Console.WriteLine("3. Visualizza piazze");
                Console.WriteLine("4. Modifica piazza");
                Console.WriteLine("5. Aggiungi manutenzione fontana");
                Console.WriteLine("6. Rimuovi manutenzione fontana");
                Console.WriteLine("7. Esci");

                Console.WriteLine("Inserisci il numero dell'azione da eseguire: ");
            }
            while (!int.TryParse(Console.ReadLine(), out action) || action < 1 || action > 7);

            switch (action)
            {
                case 1:
                    CreaFontana();
                    break;
                case 2:
                    CreaPiazza(false);
                    break;
                case 3:
                    VisualizzaPiazze();
                    break;
                case 4:
                    ModificaPiazza();
                    break;
                case 5:
                    AggiungiManutenzione();
                    break;
                case 6:
                    RimuoviManutenzione();
                    break;
                case 7:
                    Console.WriteLine("Uscita dal programma.");
                    break;
                default:
                    Console.WriteLine("Azione non valida.");
                    break;
            }
        }

        static void CreaFontana()
        {
            bool fontana = true;

            CreaPiazza(fontana);

            Console.WriteLine("Fontana creata con successo!");

            return;
        }

        static CFontana CreaPiazza(bool isFontana)
        {
            string nome, autore, temp;
            float cAcqua, diametro;
            string città, nomePiazza;
            bool stato;

            do
            {
                Console.WriteLine("Inserisci il nome della fontana: ");
                nome = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome));

            do
            {
                Console.WriteLine("Inserisci l'autore della piazza: ");
                autore = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(autore) || string.IsNullOrWhiteSpace(autore));

            do
            {
                Console.WriteLine("Inserisci il nome della piazza: ");
                nomePiazza = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nomePiazza) || string.IsNullOrWhiteSpace(nomePiazza));

            do
            {
                Console.WriteLine("Inserisci la quantità d'acqua della fontana: ");
            }
            while (!float.TryParse(Console.ReadLine(), out cAcqua) || cAcqua < 0);

            do
            {
                Console.WriteLine("La fontana è attiva? (y/n): ");
                temp = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp) || temp != "y" && temp != "n");

            if (temp == "y")
            {
                stato = true;
            }
            else
            {
                stato = false;
            }

            if (isFontana)
            {
                CFontana fontana = new CFontana(nome, autore, cAcqua, stato);
                fontane.Add(fontana);
                return fontana;
            }

            do
            {
                Console.WriteLine("Inserisci il diametro della piazza: ");
            }
            while (!float.TryParse(Console.ReadLine(), out diametro) || diametro <= 0);

            do
            {
                Console.WriteLine("Inserisci la città della piazza: ");
                città = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(città) || string.IsNullOrWhiteSpace(città));

            CPiazza nuova = new CPiazza(nome, autore, cAcqua, stato, diametro, città, nomePiazza);

            fontane.Add(nuova);

            Console.WriteLine("Piazza creata con successo!");

            return nuova;
        }

        static void VisualizzaPiazze()
        {
            Console.WriteLine("Elenco delle piazze create: \n");
            foreach (var piazza in fontane)
            {
                if (piazza is CPiazza cp)
                {
                    Console.WriteLine(cp.InfoPiazza());
                }
            }
            return;
        }

        static void ModificaPiazza()
        {
            string nomePiazza;
            int indicePiazza = -1;

            do
            {
                Console.WriteLine("Inserisci il nome della piazza da modificare: ");
                nomePiazza = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nomePiazza) || string.IsNullOrWhiteSpace(nomePiazza));

            for (int i = 0; i < fontane.Count; i++)
            {
                if (fontane[i] is CPiazza cp && cp.Name == nomePiazza)
                {
                    Console.WriteLine("Piazza trovata. Creare la nuova piazza con cui modificare la piazza esistente: ");
                    indicePiazza = i;
                    break;
                }
            }

            if (indicePiazza == -1)
            {
                Console.WriteLine("Piazza non trovata.");
                return;
            }

            CFontana nuovaPiazza = CreaPiazza(false);
            if (nuovaPiazza is CPiazza cpNuova)
            {
                fontane.Remove(cpNuova);
                fontane[indicePiazza] = cpNuova;
                Console.WriteLine("Piazza modificata con successo!");
            }
            else
            {
                Console.WriteLine("Errore: la creazione della nuova piazza non ha restituito una CPiazza.");
            }

            return;
        }

        static void AggiungiManutenzione()
        {
            string nomeFontana, manutenzione;
            CFontana fontanaDaModificare = null;
            do
            {
                Console.WriteLine("Inserisci il nome della fontana a cui aggiungere la manutenzione: ");
                nomeFontana = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nomeFontana) || string.IsNullOrWhiteSpace(nomeFontana));
            foreach (var fontana in fontane)
            {
                if (fontana is CFontana cf && cf.Name == nomeFontana)
                {
                    fontanaDaModificare = fontana;

                    fontane.Remove(fontanaDaModificare);

                    do
                    {
                        Console.WriteLine("Inserisci la manutenzione da aggiungere: ");
                        manutenzione = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(manutenzione) || string.IsNullOrWhiteSpace(manutenzione));

                    fontanaDaModificare.AggiungiManutenzione(manutenzione);

                    fontane.Add(fontanaDaModificare);

                    break;
                }
            }
            if (fontanaDaModificare == null)
            {
                Console.WriteLine("Fontana non trovata.");
            }
            else
            {
                Console.WriteLine("Manutenzione aggiunta con successo!");
            }

            return;
        }

        static void RimuoviManutenzione()
        {
            string nomeFontana, manutenzione;
            CFontana fontanaDaModificare = null;
            do
            {
                Console.WriteLine("Inserisci il nome della fontana da cui rimuovere la manutenzione: ");
                nomeFontana = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nomeFontana) || string.IsNullOrWhiteSpace(nomeFontana));
            foreach (var fontana in fontane)
            {
                if (fontana is CFontana cf && cf.Name == nomeFontana)
                {
                    fontanaDaModificare = fontana;

                    fontane.Remove(fontanaDaModificare);

                    do
                    {
                        Console.WriteLine("Inserisci la manutenzione da rimuovere: ");
                        manutenzione = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(manutenzione) || string.IsNullOrWhiteSpace(manutenzione));

                    fontanaDaModificare.EliminaManutenzione(manutenzione);

                    fontane.Add(fontanaDaModificare);

                    break;
                }
            }
            if (fontanaDaModificare == null)
            {
                Console.WriteLine("Fontana non trovata.");
            }
            else
            {
                Console.WriteLine("Manutenzione rimossa con successo!");
            }

            return;
        }
    }
}