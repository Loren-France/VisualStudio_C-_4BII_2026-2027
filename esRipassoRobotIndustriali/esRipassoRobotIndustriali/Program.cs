
using System;
using System.Collections.Generic;
using esRipassoRobot;
using static System.Console;


namespace esRipassoRobot
{
    internal class Program
    {

        static List<Robot> lista = new List<Robot>();
        static bool control;

        static void Main(string[] args)
        {

            WriteLine("PROGRAMMA DI GESTIONE ROBOT INDUSTRIALE\n");

            int num;

            do
            {
                WriteLine("Azioni disponibili:");
                WriteLine("1. Crea robot");
                WriteLine("2. Visualizza robot");
                WriteLine("3. Filtra robot per potenza");
                WriteLine("4. Ordina per anno di produzione");
                WriteLine("5. Esci");

                WriteLine("Inserisci il numero dell'azione da eseguire: ");

                num = int.Parse(ReadLine());

                if (num == 1)
                {
                    CreaRobot();
                }
                else if (num == 2)
                {
                    VisualizzaRobot();
                }
                else if (num == 3)
                {
                    FiltraPotenza();
                }
                else if (num == 4)
                {
                    OrdinamentoperAnno();
                }
                else if (num == 5)
                {
                    WriteLine("Uscita dal programma.");
                }
                else
                {
                    WriteLine("Errore: inserisci un numero valido tra 1 e 5.");
                }
            }
            while (num != 5);

            return;
        }

        static void CreaRobot()
        {
            int nRobot;
            string model;
            float power;
            int state;
            int year;

            WriteLine("Inserisci il numero di robot da creare: ");

            do
            {
                control = int.TryParse(ReadLine(), out nRobot);

                if (!control || nRobot <= 0 || nRobot > 100)
                {
                    WriteLine("Errore: inserisci un numero intero positivo tra 1 e 100.");
                }

            }
            while (!control || nRobot <= 0 || nRobot > 100);

            for (int i = 0; i < nRobot; i++)
            {

                WriteLine("Inserisci il nome del modello del robot: ");

                do
                {
                    model = ReadLine();
                    if (string.IsNullOrWhiteSpace(model))
                    {
                        WriteLine("Errore: il nome del modello non può essere vuoto.");
                    }
                }
                while (string.IsNullOrWhiteSpace(model));

                WriteLine("Inserisci la potenza del robot: ");

                do
                {
                    control = float.TryParse(ReadLine(), out power);
                    if (!control || power <= 0)
                    {
                        WriteLine("Errore: la potenza deve essere un numero positivo.");
                    }
                }
                while (!control || power <= 0);

                WriteLine("Inserisci lo stato del robot: ");

                do
                {
                    control = int.TryParse(ReadLine(), out state);
                    if (!control || state < 0 || state > 100)
                    {
                        WriteLine("Errore: inserisci un numero intero positivo tra 1 e 100.");
                    }
                }
                while (!control || state < 0 || state > 100);

                WriteLine("Inserisci l'anno di produzione del robot: ");

                do
                {
                    control = int.TryParse(ReadLine(), out year);

                    if (!control || year < 0 || year > DateTime.Now.Year)
                    {
                        WriteLine("Errore: inserisci un numero intero positivo tra 1 e " + DateTime.Now.Year + ".");
                    }
                }
                while (!control || year < 0);

                Robot nuovo = new Robot(model, power, state, year);

                lista.Add(nuovo);

                WriteLine($"Robot {i + 1} creato con successo!");

            }

            return;
        }

        static void VisualizzaRobot()
        {
            if (lista.Count == 0)
            {
                WriteLine("Nessun robot creato.");
            }
            else
            {
                WriteLine("Lista dei robot operativi:");

                foreach (Robot robot in lista)
                {
                    if (robot.State > 0)
                    {
                        WriteLine(robot.Visualizza());
                    }
                }
            }
            return;
        }

        static void FiltraPotenza()
        {
            float pow;

            if (lista.Count == 0)
            {
                WriteLine("Nessun robot creato.");
            }
            else
            {
                WriteLine("Inserisci la potenza minima per filtrare i robot: ");

                do
                {
                    control = float.TryParse(ReadLine(), out pow);
                    if (!control || pow < 0)
                    {
                        WriteLine("Errore: inserisci un numero positivo.");
                    }
                }
                while (!control || pow < 0);

                WriteLine($"Lista dei robot con potenza maggiore o uguale a {pow}:");
                foreach (Robot robot in lista)
                {
                    if (robot.Power >= pow)
                    {
                        WriteLine(robot.Visualizza());
                    }
                }
            }
            return;
        }

        static void OrdinamentoperAnno()
        {
            int l = lista.Count;
            int mostRecent = 0;
            bool ordered = false;

            for (int i = 1; i < l && !ordered; i++)
            {
                Robot key = lista[i];
                if (key.Year > mostRecent)
                {
                    mostRecent = key.Year;
                    ordered = true;
                }
                int j = i - 1;
                while (j >= 0 && lista[j].Year > key.Year)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = key;
            }

            WriteLine("Lista dei robot ordinata per anno di produzione (dal più vecchio al più recente).");
            
            VisualizzaRobot();

            WriteLine($"Il robot più recente è:");

            foreach (Robot robot in lista)
            {
                if (robot.Year == mostRecent)
                {
                    WriteLine(robot.Visualizza());
                }
            }

            return;
        }
    }
}

/* BUBBLE SORT MIGLIORATO CON BOOLEANO SE ORDINATO
void scambia(ref int a, ref int b){
int z;
z = a;
a = b;
b = z;
}
void BubbleSort(int[] v, int dim){
bool ordinato=false;
int i,j;
for (j=0; j<dim-1 && !ordinato; j++) {
ordinato=true;
for (i=dim-1; i>j; i--)
if (v[i]<v[i-1]) {
scambia(ref v[i],ref v[i-1]);
ordinato=false;
}
}
}
*/
