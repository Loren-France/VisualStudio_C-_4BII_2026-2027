namespace Franceschetto_AccademiaBotanica
{
    internal class CPiantaMediterranea : CPianta, IFogliame
    {
        public double Luminosità { get; set; }

        public CPiantaMediterranea(string nome, int età, bool foglie, double luminosità) : base(nome, età, foglie)
        {
            this.Luminosità = luminosità;
        }

        public override string Descrizione()
        {
            return $"Nome: {this.Nome}, Specie: Pianta tropicale, Età: {this.Età}, Foglie: {(Foglie ? "Sì" : "No")}, Luminosità: {this.Luminosità}%, Periodo in cui pianta spoglia: Luglio / Agosto";
        }

        public string PerditaFogliame()
        {
            this.Foglie = false;
            return $"La pianta {this.Nome} ha perso le foglie.";
        }

        public string RicrescitaFogliame()
        {
            this.Foglie = true;
            return $"La pianta {this.Nome} ha fatto ricrescere le sue foglie.";
        }

        public override bool CondizioniAdeguate(CStatoAmbientale statoAmbientale)
        {
            if (statoAmbientale.SensoreLuminosità < Luminosità)
            {
                return false;
            }
            return true;
        }
    }
}
