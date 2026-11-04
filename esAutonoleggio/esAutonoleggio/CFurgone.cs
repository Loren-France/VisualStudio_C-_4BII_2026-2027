using System;
using System.Collections.Generic;
using System.Text;

namespace esAutonoleggio
{
    internal class CFurgone : CVeicolo
    {
        const double tf = 80;
        public CFurgone(string targa, string modello) : base(targa, modello, "Furgone", tf)
        {
        }

        public override double CalcolaCosto(int giorni)
        {
            double costoBase = base.CalcolaCosto(giorni) + 100; // Aggiungi 100€ al costo base per pulizies
            return costoBase;
        }
    }
}
