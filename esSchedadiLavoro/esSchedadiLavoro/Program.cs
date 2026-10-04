using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CDispositivoSmart> dispositivi = new List<CDispositivoSmart>();
            // Creazione lista di dispositivi smart chiamando però la classe astratta CDispositivoSmart
            List<ISwitchable> test = new List<ISwitchable>();
            // Creazione lista di dispositivi smart chiamando l'interfaccia ISwitchables
            // Ricorda di fare la domanda:
            // "Differenza e quale usare tra interfaccia e classe astratta se devo creare una struttura di base per diversi tipi di oggetti?"

            CLampadina lampadina1 = new CLampadina("Lampadina 1", "Stanza 1", 50);
            CTermostato termostato1 = new CTermostato("Termostato 1", "Stanza 1", 22.5);
            CAllarme allarme = new CAllarme();

            dispositivi.Add(lampadina1);
            dispositivi.Add(termostato1);
            dispositivi.Add(allarme);

            Console.WriteLine("\nAccensione dei dispositivi smart: \n");
            foreach (CDispositivoSmart dispositivo in dispositivi)
            {
                dispositivo.Accendi();
                Console.WriteLine(dispositivo.MostraDettagli());
            }

            Console.WriteLine("\nSpegnimento dei dispositivi smart: \n");

            foreach (CDispositivoSmart dispositivo in dispositivi)
            {
                dispositivo.Spegni();
                Console.WriteLine(dispositivo.MostraDettagli());
            }
        }
    }
}
