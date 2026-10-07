namespace esGestioneMacchinari
{
    public enum TipoRuspa
    {
        Tipo1 = 300,
        Tipo2 = 500,
        Tipo3 = 700,
        Tipo4 = 1000,
        Tipo5 = 1500,
        Tipo6 = 2000
    }

    internal class CRuspe : CMacchinariPesanti, IAssegnabile
    {
        public TipoRuspa Tipo { get; set; }

        public CRuspe(string targa, string modello, int annoProduzione, double volumeSerbatoio, bool statoMacchinario, TipoRuspa tipo)
            : base(targa, modello, annoProduzione, volumeSerbatoio, statoMacchinario)
        {
            this.Tipo = tipo;
        }

        public override string Descrizione()
        {
            string statement = this.StatoMacchinario ? "libero" : "Occupato";
            return $"Ruspe - {this.Modello} - Anno: {this.AnnoProduzione} - Targa: {this.Targa} - Stato: {statement} - Dimensione benna: {(int)this.Tipo}";
        }

        public void CambioBenna(TipoRuspa nuovoTipo)
        {
            this.Tipo = nuovoTipo;
        }
    }
}
