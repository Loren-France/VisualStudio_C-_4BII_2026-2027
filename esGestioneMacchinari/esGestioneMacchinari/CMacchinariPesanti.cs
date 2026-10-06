namespace esGestioneMacchinari
{
    internal abstract class CMacchinariPesanti : IAssegnabile
    {
        protected string Targa, Modello;
        protected int AnnoProduzione;
        protected double VolumeSerbatoio;
        protected bool StatoMacchinario;

        public CMacchinariPesanti(string targa, string modello, int annoProduzione, double volumeSerbatoio, bool statoMacchinario)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.AnnoProduzione = annoProduzione;
            this.VolumeSerbatoio = volumeSerbatoio;
            this.StatoMacchinario = statoMacchinario;
        }

        public string Model
        {
            get { return this.Modello; }
            set { this.Modello = value; }
        }

        public string LicensePlate
        {
            get { return this.Targa; }
            set { this.Targa = value; }
        }

        public abstract string Descrizione();

        public void AssegnaMacchinario()
        {
            this.StatoMacchinario = false;
        }

        public void LiberaMacchinario()
        {
            this.StatoMacchinario = true;
        }
    }
}
