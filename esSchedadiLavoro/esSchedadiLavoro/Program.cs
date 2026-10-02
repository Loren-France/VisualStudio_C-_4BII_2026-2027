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
            List<ISwitchable> dispositivi = new List<ISwitchable>();

            CLampadina lampadina1 = new CLampadina("Lampadina 1", "Stanza 1", 50);
            CTermostato termostato1 = new CTermostato("Termostato 1", "Stanza 1", 22.5);
            CAllarme allarme = new CAllarme();

            dispositivi.Add(lampadina1);
            dispositivi.Add(termostato1);
            dispositivi.Add(allarme);

            Console.WriteLine("\nAccensione dei dispositivi smart: \n");
            foreach (ISwitchable dispositivo in dispositivi)
            {
                dispositivo.Accendi();
                Console.WriteLine(dispositivo.MostraDettagli());
            }

            Console.WriteLine("\nSpegnimento dei dispositivi smart: \n");

            foreach (ISwitchable dispositivo in dispositivi)
            {
                dispositivo.Spegni();
                Console.WriteLine(dispositivo.MostraDettagli());
            }
        }
    }
}
