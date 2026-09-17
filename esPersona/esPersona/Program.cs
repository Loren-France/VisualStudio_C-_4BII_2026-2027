using System;
using System.Collections.Generic;

namespace esPersona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroPersone = 0;

            Console.WriteLine("PROGRAMMA PERSONE, STUDENTI E DOCENTI");

            do
            {
                Console.WriteLine("Inserire numero di persone da creare: ");
            }
            while (!int.TryParse(Console.ReadLine(), out numeroPersone) || numeroPersone <= 0);

            ElencoPersone elenco = new ElencoPersone(numeroPersone);

            for (int i = 0; i < numeroPersone; i++)
            {
                Console.WriteLine("Creazione persona numero " + (i + 1));
                Persona container = CreaPersona();
                if (container != null)
                {
                    elenco.Aggiungi(container);
                }
                else
                {
                    Console.WriteLine("Errore nella creazione della persona. Riprova.");
                    i--;
                }
            }

            Console.WriteLine("\n Elenco persone create: \n");
            Console.WriteLine(elenco.Print() + "\n");

            Console.WriteLine("Numero di studenti: " + elenco.ContaStudenti() + "\n");

            Console.WriteLine("Docenti con stipendio maggiore di 2000 euro: \n");

            Console.WriteLine(elenco.StampaDocentiConStipendioAlto(2000));

        }

        static Persona CreaPersona()
        {
            int tipoPersona = 0;
            string codiceFiscale = "", nome = "", cognome = "";
            Persona person = new Persona();

            do
            {
                Console.WriteLine("Inserire tipo di persona ( 1 = Persona, 2 = Studente, 3 = Docente ): ");
            }
            while (!int.TryParse(Console.ReadLine(), out tipoPersona) || tipoPersona < 1 || tipoPersona > 3);


            Console.WriteLine("Inserire codice fiscale: ");

            try
            {
                codiceFiscale = Console.ReadLine();
                person.FiscalCode = codiceFiscale;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la lettura del codice fiscale: " + ex.Message);
                return null;
            }

            Console.WriteLine("Inserire nome: ");

            try
            {
                nome = Console.ReadLine();
                person.Name = nome;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la lettura del nome: " + ex.Message);
                return null;
            }

            Console.WriteLine("Inserire cognome: ");

            try
            {
                cognome = Console.ReadLine();
                person.Surname = cognome;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la lettura del cognome: " + ex.Message);
                return null;
            }

            switch (tipoPersona)
            {
                case 1:

                    return person;
                case 2:

                    int matricola = 0;
                    string universita = "";

                    Console.WriteLine("Inserire matricola: ");

                    try
                    {
                        matricola = int.Parse(Console.ReadLine());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore durante la lettura della matricola: " + ex.Message);
                        return null;
                    }

                    Console.WriteLine("Inserire università: ");

                    try
                    {
                        universita = Console.ReadLine();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore durante la lettura dell'università: " + ex.Message);
                        return null;
                    }

                    person = new Studente(codiceFiscale, nome, cognome, matricola, universita);

                    return person;
                case 3:

                    double salario = 0;
                    string materia = "";

                    Console.WriteLine("Inserire nome materia insegnata: ");

                    try
                    {
                        materia = Console.ReadLine();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore durante la lettura della materia: " + ex.Message);
                        return null;
                    }

                    Console.WriteLine("Inserire salario: ");

                    try
                    {
                        salario = double.Parse(Console.ReadLine());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore durante la lettura del salario: " + ex.Message);
                        return null;
                    }

                    person = new Docente(codiceFiscale, nome, cognome, materia, salario);

                    return person;
                default:

                    return null;
            }
        }
    }
}
