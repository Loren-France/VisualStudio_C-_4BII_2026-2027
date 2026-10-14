using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esTOrte
{
    internal class CCrostata : CDolce
    {
        private bool Glassata = false;
        public int TempoCottura { get; set; }

        public CCrostata(string nome, int punteggio, int tempoCottura, bool glassata) : base(nome, punteggio)
        {
            TempoCottura = tempoCottura;
            Glassata = glassata;
        }
        public override string Stampa()
        {
            return $"Nome: {Nome}, Tipologia: Crostata, Punteggio: {Punteggio}, Tempo di cottura: {TempoCottura}, Glassata: {(Glassata ? "Sì" : "No")}";
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

        public string Glassatura()
        {
            if (!Glassata)
            {
                Glassata = true;
                this.Punteggio += 2;
                if (this.Punteggio > 10)
                {
                    this.Punteggio = 10;
                }
                return "La crostata è stata glassata con successo!";
            }
            else
            {
                return "La crostata è già glassata!";
            }
        }
    }
}
