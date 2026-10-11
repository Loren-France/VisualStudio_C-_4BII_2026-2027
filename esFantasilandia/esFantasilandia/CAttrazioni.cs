using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal abstract class CAttrazioni : IFixable
    {
        public string Nome { get; set; }
        public int CapacitaMax { get; set; }
        private bool Stato;
        private int TempoRiparazione;
        public int CostoRiparazione;

        public CAttrazioni (string nome, int capacitaMax, bool stato, int tempoRiparazione, int costoRiparazione)
        {
            this.Nome = nome;
            this.CapacitaMax = capacitaMax;
            this.Stato = stato;
            this.TempoRiparazione = tempoRiparazione;
            this.CostoRiparazione = costoRiparazione;
        }

        public bool IsGuasto
        {
            get { return !Stato; }
            set { Stato = !value; }
        }

        public abstract int Costo();
        public abstract bool VerificaVisitatore(CVisitatore visitatore);
        public virtual int Vendi(CVisitatore visitatore)
        {
            if (VerificaVisitatore(visitatore))
            {
                return Costo();
            }
            return 0;
        }

        public string Ripara()
        {
            string builder = "";

            if (IsGuasto)
            {
                builder += $"Riparazione in corso per l'attrazione {Nome}. Tempo stimato: {TempoRiparazione} minuti. Costo stimato: {CostoRiparazione} euro.";
                IsGuasto = false;
                builder += $"L'attrazione {Nome} è stata riparata con successo.";
            }
            else
            {
                builder += $"L'attrazione {Nome} non necessita di riparazioni.";
            }

            return builder;
        }

        public string SegnalaGuasto()
        {
            if (!IsGuasto)
            {
                IsGuasto = true;
                return $"L'attrazione {Nome} è stata segnalata come guasta.";
            }
            else
            {
                return $"L'attrazione {Nome} è già segnalata come guasta.";
            }
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Capacità Massima: {CapacitaMax}, Stato: {(Stato ? "Funzionante" : "Guasto")}, Tempo Riparazione: {TempoRiparazione} minuti, Costo Riparazione: {CostoRiparazione} euro.";
        }
    }
}
