using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    public enum TipologiaCibi
    {
        Panini,
        Gelati,
        Bevande,
        Snack,
        Pizze,
        Dolci,
        Altro
    }
    internal class CChiosco : IFixable
    {
        private bool Stato;
        private int TempoRiparazione;
        private double CostoRiparazione;
        private TipologiaCibi TipoCibo;

        public bool IsGuasto
        {
            get { return !Stato; }
            set { Stato = !value; }
        }

        public CChiosco(bool stato, int tempoRiparazione, double costoRiparazione, TipologiaCibi tipoCibo) : base()
        {
            this.Stato = stato;
            this.TempoRiparazione = tempoRiparazione;
            this.CostoRiparazione = costoRiparazione;
            this.TipoCibo = tipoCibo;
        }

        public string SegnalaGuasto()
        {
            IsGuasto = true;
            return "Il chiosco è guasto.";
        }

        public string Ripara()
        {
            Stato = true;
            return "Il chiosco è stato riparato.";
        }

        public override string ToString()
        {
            return $"Chiosco di {TipoCibo}, Stato: {(Stato ? "Funzionante" : "Guasto")}, Tempo Riparazione: {TempoRiparazione} minuti, Costo Riparazione: {CostoRiparazione} euro.";
        }
    }
}
