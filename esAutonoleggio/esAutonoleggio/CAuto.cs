using System;
using System.Collections.Generic;
using System.Text;

namespace esAutonoleggio
{
    internal class CAuto : CVeicolo
    {
        const double tf = 50;
        public CAuto(string targa, string modello) : base(targa, modello, "Auto", tf)
        {
        }

        public CAuto(string targa, string modello,string tipo, double tariffaGiornaliera) : base(targa, modello, tipo, tariffaGiornaliera)
        {
        }
    }
}
