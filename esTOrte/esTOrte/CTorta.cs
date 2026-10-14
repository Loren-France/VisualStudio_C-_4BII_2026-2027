using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal class CTorta : CDolce
    {
        public string Ingredienti { get; set; }
        private int NStrati;

        public CTorta(string nome, int punteggio, string ingredienti) : base(nome, punteggio)
        {
            Ingredienti = ingredienti;
            NStrati = 1;
        }
        public override string Stampa()
        {
            return $"Nome: {Nome}, Tipologia: Torta, Punteggio: {Punteggio}, Ingredienti: {Ingredienti}, Numero strati: {NStrati}";
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

        public string AggiungiStrato()
        {
            if (NStrati >= 5)
            {
                return "Non è possibile abbiungere più di 5 strati";
            }
            else
            {
                this.NStrati += 1;

                return "Strato aggiunto correttamente";
            }
        }
    }
}
