namespace Franceschetto_AccademiaBotanica
{
    internal class CPiantaTropicale : CPianta
    {
        public double Umidità { get; set; }

        public CPiantaTropicale(string nome, int età, bool foglie, double umidità) : base(nome, età, foglie)
        {
            this.Umidità = umidità;
        }

        public override string Descrizione()
        {
            return $"Nome: {this.Nome}, Specie: Pianta tropicale, Età: {this.Età}, Foglie: {(Foglie ? "Sì" : "No")}, Umidità: {this.Umidità}%,  Nessun periodo segnalato di spoglio della pianta";
        }

        public override bool CondizioniAdeguate(CStatoAmbientale statoAmbientale)
        {
            if (statoAmbientale.SensoreUmidità < Umidità)
            {
                return false;
            }
            return true;
        }
    }
}
