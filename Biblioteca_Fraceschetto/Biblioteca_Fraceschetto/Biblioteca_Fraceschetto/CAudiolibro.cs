using System;

namespace Biblioteca_Fraceschetto
{
    internal class CAudiolibro : CLibro
    {
        private static int MaxPrestito = 14;
        public int Durata { get; set; }

        public CAudiolibro(int code, string title, int anno, string author, int durata) : base(code, title, anno, author)
        {
            this.Durata = durata;
        }

        public override string ToString()
        {
            return $"Audiolibro | {base.ToString()} | Durata: {Durata}min";
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
                tot = base.CalcolaPenale() * 2;
            }

            return tot;
        }
    }
}
