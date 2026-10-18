namespace Franceschetto_AccademiaBotanica
{
    internal class CPiantaTemperata : CPianta, IFogliame
    {
        public double Temperatura { get; set; }

        public CPiantaTemperata(string nome, int età, bool foglie, double temperatura) : base(nome, età, foglie)
        {
            this.Temperatura = temperatura;
        }

        public override string Descrizione()
        {
            return $"Nome: {this.Nome}, Specie: Pianta tropicale, Età: {this.Età}, Foglie: {(Foglie ? "Sì" : "No")}, Temperatura: {this.Temperatura}°C, Periodo in cui pianta spoglia: da Novembre a Febbraio";
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
            if (statoAmbientale.SensoreTemperatura < Temperatura - 3 && statoAmbientale.SensoreTemperatura > Temperatura + 3)
            {
                return false;
            }
            return true;
        }
    }
}
