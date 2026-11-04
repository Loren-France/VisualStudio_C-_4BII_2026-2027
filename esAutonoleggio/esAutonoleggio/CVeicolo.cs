using System;
using System.Collections.Generic;
using System.Text;

namespace esAutonoleggio
{
    internal abstract class CVeicolo
    {
        public string Targa { get; }
        public string Modello { get; }
        public string Tipo { get; }
        public double TariffaGiornaliera { get; }

        protected CVeicolo(string targa, string modello, string tipo, double tariffaGiornaliera)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.Tipo = tipo;
            this.TariffaGiornaliera = tariffaGiornaliera;
        }

        public virtual double CalcolaCosto(int giorni)
        {
            return giorni * TariffaGiornaliera;
        }

        public override string ToString()
        {
            return $"{Tipo} - {Modello} ({Targa}) - {TariffaGiornaliera}€/giorno";
        }
    }
}
