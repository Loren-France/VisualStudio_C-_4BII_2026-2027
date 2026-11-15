using System;
using LorenzoFranceschetto_VerificaQuartiere;

namespace Biblioteca_Fraceschetto
{
    internal class CLibro : CMateriale
    {
        private static int MaxPrestito = 30;
        public string Autore { get; set; }

        public CLibro(int code, string title, int anno, string author) : base(code, title, anno)
        {
            this.Autore = author;
        }

        public override string ToString()
        {
            return $"Libro | {base.ToString()} | Autore: {Autore}";
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
                tot = (gg - MaxPrestito) * 0.20;
            }

            return tot;
        }
    }
}
