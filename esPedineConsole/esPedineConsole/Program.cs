using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using esReGuardiePedoni;
using static System.Console;

namespace esPedineConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CGestione gestione = new CGestione();

            try
            {
                gestione.Inizializza();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            ArruolaPedina(new CRe(gestione.NomeRe));

            foreach (string nomeGuardia in gestione.NomiGuardie)
            {
                ArruolaPedina(new CGuardia(nomeGuardia));
            }

            foreach (string nomePedone in gestione.NomiPedoni)
            {
                ArruolaPedina(new CPedone(nomePedone));
            }

            while (!gestione.terminato)
            {
                Console.WriteLine("> " + gestione.AfterCommand);
                if (!gestione.EseguiPasso())
                    Console.WriteLine("Comando non valido");
            }
            Console.WriteLine("Simulazione terminata");

            void ArruolaPedina(CPedina pedina)
            {
                pedina.Messaggio += StampaMessaggio;
                gestione.AttaccaRe += pedina.Azione;
                gestione.Cattura += pedina.OnCatturaPedina;
            }

            static void StampaMessaggio(object? sender, string messaggio)
            {
                Console.WriteLine(messaggio);
            }

        }
    }
}
