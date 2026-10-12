using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal class CCrostata : CDolce
    {
        public CCrostata(string nome, int punteggio) : base(nome, punteggio)
        {
        }
        public override string Stampa()
        {
            return $"Nome: {Nome}, Tipologia: Crostata, Punteggio: {Punteggio}";
        }

        public void ProvadiCroccantezza()
        {
            this.Punteggio -= 4;
            
            if (this.Punteggio < 0)
            {
                this.Punteggio = 0;
            }
            return;
        }
    }
}
