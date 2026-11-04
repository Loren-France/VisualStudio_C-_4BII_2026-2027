using System;
using System.Collections.Generic;
using System.Text;

namespace esAutonoleggio
{
    internal class CAutoElettrica : CAuto, IElettrico
    {
        public int AutonomiaKm { get; set; }
        const double tf = 65;
        public CAutoElettrica(string targa, string modello, int autonomiaKm) : base (targa, modello, "Auto Elettrica", tf)
        {
            this.AutonomiaKm = autonomiaKm;
        }

        
    }
}
