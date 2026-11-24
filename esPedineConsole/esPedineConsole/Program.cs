using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;
using System.Collections.ObjectModel;

namespace esPedineConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CGestione gestione = new CGestione();

            gestione.Inizializza();

            gestione.EseguiPasso();

            gestione.EseguiPasso();

            gestione.EseguiTutto();

            foreach (string s in gestione.Registro)
            {
                Console.WriteLine(s);
            }

        }
    }
}
