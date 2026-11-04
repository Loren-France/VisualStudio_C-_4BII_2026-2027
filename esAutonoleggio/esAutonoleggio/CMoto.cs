using System;
using System.Collections.Generic;
using System.Text;

namespace esAutonoleggio
{
    internal class CMoto : CVeicolo
    {
        const double tf = 30;
        public CMoto(string targa, string modello) : base(targa, modello, "Moto", tf)
        {
        }

        public override double CalcolaCosto(int giorni)
        {
            double costoBase = base.CalcolaCosto(giorni);
            if (giorni >= 7)
            {
                costoBase = costoBase - (costoBase * 20 / 100);
            }
            return costoBase;
        }
    }
}
