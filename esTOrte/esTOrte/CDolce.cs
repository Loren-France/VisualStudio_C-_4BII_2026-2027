using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal abstract class CDolce
    {
        public string Nome { get; set; }
        public int Punteggio { get; set; }

        public CDolce(string nome, int punteggio)
        {
            Nome = nome;
            Punteggio = punteggio;
        }

        public abstract string Stampa();

        public void Raffinatura()
        {
            int rand = new Random().Next(3, 8);
            this.Punteggio += rand;

            if (this.Punteggio > 10)
            {
                this.Punteggio = 10;
            }
            return;
        }
    }
}
