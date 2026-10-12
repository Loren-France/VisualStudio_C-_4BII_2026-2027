using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal class CTorta : CDolce
    {
        public CTorta(string nome, int punteggio) : base(nome, punteggio)
        {
        }
        public override string Stampa()
        {
            return $"Nome: {Nome}, Tipologia: Torta, Punteggio: {Punteggio}";
        }

        public void ProvadiSofficienza()
        {
            this.Punteggio -= 6;

            if (this.Punteggio < 0)
            {
                this.Punteggio = 0;
            }
            return;
        }
    }
}
