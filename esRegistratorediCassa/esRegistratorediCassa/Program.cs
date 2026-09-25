using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRegistratore registratore = new CRegistratore();

            Console.WriteLine("PROGRAMMA DEL REGISTRATORE DI CASSA");

            string nome, cognome;
            bool tesseraFedelta;

            do
            {
                Console.WriteLine("Inserisci il nome del cliente:");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome));

            do
            {
                Console.WriteLine("Inserisci il cognome del cliente:");
                cognome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(cognome) || string.IsNullOrEmpty(cognome));

            string input = "";
            Console.WriteLine("Il cliente ha la tessera di fedeltà? (y/n):");
            do
            {
                input = Console.ReadLine();
            } while (input != "y" && input != "n");

            if (input == "y")
            {
                tesseraFedelta = true;
            }
            else
            {
                tesseraFedelta = false;
            }

            Console.WriteLine($"Creazione cliente...");

            CClienti cliente = new CClienti(nome, cognome, tesseraFedelta);
            registratore.EmettiScontrino();

            Console.WriteLine("Aggiungi 3 articoli alimentari:");

            long codiceBarre = 0;
            string descrizione = "";
            int prezzo = 0;

            for (int i = 0; i < 3; i++)
            {
                int anno = 0;

                Console.WriteLine($"\nArticolo alimentare {i + 1}: \n");

                InitializeArticolo(out codiceBarre, out descrizione, out prezzo);

                do
                {
                    Console.WriteLine("Inserisci l'anno di scadenza dell'articolo (numero intero):");
                }
                while (!int.TryParse(Console.ReadLine(), out anno) || anno <= 0 || anno < DateTime.Now.Year);

                CArticoloAlimentare articolo = new CArticoloAlimentare(codiceBarre, descrizione, prezzo, anno);

                if (tesseraFedelta)
                {
                    articolo.Sconta();
                }

                cliente.AggiungiArticolo(articolo);
                registratore.RichiamoAggiunta(articolo);
            }

            Console.WriteLine("Aggiungi 2 articoli non alimentari: ");

            for (int i = 0; i < 2; i++)
            {
                string temp;
                Materiale materiale;

                Console.WriteLine($"\nArticolo non alimentare {i + 1}: \n");

                InitializeArticolo(out codiceBarre, out descrizione, out prezzo);

                do
                {
                    Console.WriteLine("Inserisci il materiale dell'articolo:");
                    temp = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(temp) || (temp != "plastica" && temp != "carta" && temp != "vetro" && temp != "metallo" && temp != "legno"));

                if (temp == "plastica") materiale = Materiale.Plastica;
                else if (temp == "carta") materiale = Materiale.Carta;
                else if (temp == "vetro") materiale = Materiale.Vetro;
                else if (temp == "metallo") materiale = Materiale.Metallo;
                else materiale = Materiale.Legno;

                CArticoloNonAlimentare articolo = new CArticoloNonAlimentare(codiceBarre, descrizione, prezzo, materiale);

                if (tesseraFedelta)
                {
                    articolo.Sconta();
                }

                cliente.AggiungiArticolo(articolo);
                registratore.RichiamoAggiunta(articolo);
            }

            Console.WriteLine(cliente.StampaScontrino());

            long barcode = 1;

            while (barcode != 0)
            {
                do
                {
                    Console.WriteLine("Inserisci il codice a barre dell'articolo (Inserire 0 per continuare):");
                }
                while (!long.TryParse(Console.ReadLine(), out barcode) || barcode != 0 && (barcode < 0 || barcode.ToString().Length != 13));

                if (barcode == 0)
                {
                    break;
                }

                foreach (CArticolo articolo in cliente.ArticoliAcquistati)
                {
                    if (articolo.CodiceBarre == barcode)
                    {
                        Console.WriteLine($"Articolo comprato dal cliente: {cliente.Nome} {cliente.Cognome}");
                    }
                }
            }

            int azione = 0;
            do
            {
                Console.WriteLine("Scegli l'azione da eseguire: 1) Rimuovi scontrino 2) Stampa scontrini 3) Esci");
            }
            while (!int.TryParse(Console.ReadLine(), out azione) || azione < 1 || azione > 3);

            switch (azione)
            {
                case 1:
                    registratore.CancellaScontrino();
                    Console.WriteLine("L'ultimo scontrino è stato rimosso.");
                    break;
                case 2:
                    Console.WriteLine("Elenco degli scontrini emessi:");
                    Console.WriteLine(registratore.ListScontrini());
                    break;
                case 3:
                    Console.WriteLine("Uscita dal programma...");
                    break;
                default:
                    Console.WriteLine("Azione non valida.");
                    break;
            }
        }

        static void InitializeArticolo(out long codiceBarre, out string descrizione, out int prezzo)
        {
            do
            {
                Console.WriteLine("Inserisci il codice a barre dell'articolo:");
            }
            while (!long.TryParse(Console.ReadLine(), out codiceBarre) || codiceBarre <= 0 || codiceBarre.ToString().Length != 13);
            Console.WriteLine("Inserisci la descrizione dell'articolo:");
            do
            {
                descrizione = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(descrizione) || string.IsNullOrEmpty(descrizione));
            do
            {
                Console.WriteLine("Inserisci il prezzo dell'articolo (numero intero):");
            }
            while (!int.TryParse(Console.ReadLine(), out prezzo) || prezzo <= 0);
        }
    }
}