using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace esPersona
{
    internal class ElencoPersone
    {
        private List<Persona> Persone;
        private int MAX;

        public ElencoPersone()
        {
            Persone = new List<Persona>();
            MAX = 20;
        }

        public void Aggiungi(Persona p)
        {
            if (Persone.Count >= 20)
            {
                return;
            }
            else
            {
                Persone.Add(p);
            }
        }

        public string Print()
        {
            string builder = "";
            foreach (Persona p in Persone)
            {
                builder += p.Print() + "/r/n";
            }
            return builder;
        }

        public int ContaStudenti()
        {
            int counter = 0;
            foreach (Persona p in Persone)
            {
                if (p is Studente)
                {
                    counter++;
                }
            }
            return counter;
        }

        public string StampaDocentiConStipendioAlto(double soglia)
        {
            string builder = "";
            foreach (Persona p in Persone)
            {
                if (p is Docente d && d.Salary > soglia) // (p is Docente && ((Docente)p).Salary > soglia), al posto di questo che va cmq bene , uso uno pseudo operatore AS
                {
                    builder += p.Print() + "/r/n";
                }
            }
            return builder;
        }

        public string StampaTipo()
        {
            string builder = "";
            foreach (Persona p in Persone)
            {
                if (p is Studente)
                {
                    builder += "Studente: " + p.Print() + "/r/n";
                }
                else if (p is Docente)
                {
                    builder += "Docente: " + p.Print() + "/r/n";
                }
                else
                {
                    builder += "Persona: " + p.Print() + "/r/n";
                }
            }
            return builder;
        }
    }
}
