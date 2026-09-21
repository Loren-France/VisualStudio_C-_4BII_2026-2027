using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGarage
{
    internal class CGarage
    {
        private CVeicolo[] veicoli = new CVeicolo[15];
        private int numeroVeicoli = 0;

        public CGarage()
        {
            for (int i = 0; i < veicoli.Length; i++)
            {
                veicoli[i] = null;
            }
        }

        public void AggiungiVeicolo(CVeicolo veicolo)
        {
            if (numeroVeicoli < veicoli.Length)
            {
                veicoli[numeroVeicoli] = veicolo;
                numeroVeicoli++;
            }
            else
            {
                Console.WriteLine("Garage pieno!");
            }
        }

        public void EstraiVeicolo(int indice)
        {
            if (indice >= 0 && indice < numeroVeicoli)
            {
                veicoli[indice] = null;
                for (int i = indice; i < numeroVeicoli - 1; i++)
                {
                    veicoli[i] = veicoli[i + 1];
                }
                veicoli[numeroVeicoli - 1] = null;
                numeroVeicoli--;
            }
            else
            {
                Console.WriteLine("Indice non valido!");
            }
        }

        public string StampaVeicoli()
        {
            string builder = "";

            for (int i = 0; i < numeroVeicoli; i++)
            {
                builder += veicoli[i].InfoVeicolo() + "\n";
            }

            return builder;
        }

    }

    public class Class1
    {
    }
}
