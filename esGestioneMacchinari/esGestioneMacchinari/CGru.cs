using System;


namespace esGestioneMacchinari
{
    internal class CGru : CMacchinariPesanti, IAssegnabile
    {
        public int AltezzaMax { get; set; }
        public int AltezzaLavoro { get; set; }

        public CGru(string targa, string modello, int annoProduzione, double volumeSerbatoio, bool statoMacchinario, int altezzaMax, int altezzaLavoro)
            : base(targa, modello, annoProduzione, volumeSerbatoio, statoMacchinario)
        {
            this.AltezzaMax = altezzaMax;
            this.AltezzaLavoro = altezzaLavoro;
        }

        public override string Descrizione()
        {
            string statement = this.StatoMacchinario ? "libero" : "Occupato";
            return $"Gru - {this.Modello} - Anno: {this.AnnoProduzione} - Targa: {this.Targa} - Stato: {statement} - Altezza: {this.AltezzaLavoro} / {this.AltezzaMax}";
        }
        
        public void AumentaAltezza(int incremento)
        {
            if (incremento < 0)
            {
                throw new ArgumentException("L'incremento non può essere negativo.");
            }
            if (this.AltezzaLavoro + incremento > this.AltezzaMax)
            {
                throw new InvalidOperationException("La gru non può superare l'altezza massima.");
            }
            this.AltezzaLavoro += incremento;
        }

        public void DiminuisciAltezza(int decremento)
        {
            if (decremento < 0)
            {
                throw new ArgumentException("Il decremento non può essere negativo.");
            }
            if (this.AltezzaLavoro - decremento < 0)
            {
                throw new InvalidOperationException("La gru non può avere un'altezza negativa.");
            }
            this.AltezzaLavoro -= decremento;
        } 
    }
}
