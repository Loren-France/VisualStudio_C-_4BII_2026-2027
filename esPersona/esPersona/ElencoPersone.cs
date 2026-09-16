using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace esPersona
{
    internal class ElencoPersone
    {
        private List<Persona> Persone;

        public ElencoPersone()
        {
            Persone = new List<Persona>();
        }

        public void Aggiungi(Persona p)
        {
            Persone.Add(p);
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
                if (p is Docente && ((Docente)p).Salary > soglia)
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
