using System;

namespace esGestioneMacchinari
{
    internal class CBetoniere : CMacchinariPesanti, IAssegnabile
    {
        public double CapacitàMax { get; set; }
        public double CapacitàAttuale { get; set; }

        public CBetoniere(string targa, string modello, int annoProduzione, double volumeSerbatoio, bool statoMacchinario, double capaxitàMax, double capaxitàAttuale)
            : base(targa, modello, annoProduzione, volumeSerbatoio, statoMacchinario)
        {
            this.CapacitàMax = capaxitàMax;
            this.CapacitàAttuale = capaxitàAttuale;
        }

        public override string Descrizione()
        {
            string statement = this.StatoMacchinario ? "libero" : "Occupato";
            return $"Betoniera - {this.Modello} - Anno: {this.AnnoProduzione} - Targa: {this.Targa} - Stato: {this.StatoMacchinario} - Capacità: {this.CapacitàAttuale} / {this.CapacitàMax}";
        }

        public void CaricaCemento(double quantità)
        {
            if (quantità < 0)
            {
                throw new ArgumentException("La quantità da caricare non può essere negativa.");
            }
            if (this.CapacitàAttuale + quantità > this.CapacitàMax)
            {
                throw new InvalidOperationException("La betoniera non può superare la capacità massima.");
            }
            this.CapacitàAttuale += quantità;
        }

        public void VersaCemento(double quantità)
        {
            if (quantità < 0)
            {
                throw new ArgumentException("La quantità da versare non può essere negativa.");
            }
            if (this.CapacitàAttuale - quantità < 0)
            {
                throw new InvalidOperationException("La betoniera non può avere una capacità negativa.");
            }
            this.CapacitàAttuale -= quantità;
        }
    }
}
