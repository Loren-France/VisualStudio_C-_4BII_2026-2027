using System;
using LorenzoFranceschetto_VerificaQuartiere;

namespace Biblioteca_Fraceschetto
{
    internal class CRivista : CMateriale
    {
        private static int MaxPrestito = 7;
        public int NumeroUscita { get; set; }

        public CRivista(int code, string title, int anno, int num) : base(code, title, anno)
        {
            this.NumeroUscita = num;
        }

        public override string ToString()
        {
            return $"Rivista | {base.ToString()} | Numero uscita: {NumeroUscita}";
        }

        public override double CalcolaPenale()
        {
            double tot;
            int gg = DataRestituzione.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;

            if (gg <= MaxPrestito)
            {
                tot = 0;
            }
            else
            {
                tot = (gg - MaxPrestito) * 0.10;
                if (tot > 2)
                    tot = 2;
            }

            return tot;
        }
    }
}
