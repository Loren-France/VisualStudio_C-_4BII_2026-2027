using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CBagno : IFixable
    {
        private bool Stato;
        private int TempoRiparazione;
        private double CostoRiparazione;
        private int NumeroBagni;

        public CBagno(bool stato, int tempoRiparazione, double costoRiparazione, int numeroBagni) : base()
        {
            this.Stato = stato;
            this.TempoRiparazione = tempoRiparazione;
            this.CostoRiparazione = costoRiparazione;
            this.NumeroBagni = numeroBagni;
        }

        public bool IsGuasto
        {
            get { return !Stato; }
            set { Stato = !value; }
        }

        public string SegnalaGuasto()
        {
            IsGuasto = true;
            return "Il bagno è guasto.";
        }

        public string Ripara()
        {
            Stato = true;
            return "Il bagno è stato riparato.";
        }

        public override string ToString()
        {
            return $"Bagno con {NumeroBagni} bagni, Stato: {(Stato ? "Funzionante" : "Guasto")}, Tempo Riparazione: {TempoRiparazione} minuti, Costo Riparazione: {CostoRiparazione} euro.";
        }
    }
}
