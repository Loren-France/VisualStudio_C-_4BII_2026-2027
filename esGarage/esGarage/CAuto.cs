using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGarage
{
    public enum TipoAlimentazione
    {
        Benzina,
        Diesel,
        GPL,
        Elettrico
    }
    internal class CAuto : CVeicolo
    {
        private int numeroPorte;
        private TipoAlimentazione tipoAlimentazione;

        public CAuto(string marca, int anno, int cilindrata, int numeroPorte, TipoAlimentazione tipoAlimentazione) : base(marca, anno, cilindrata)
        {
            this.numeroPorte = numeroPorte;
            this.tipoAlimentazione = tipoAlimentazione;
        }

        public override string InfoVeicolo()
        {
            return base.InfoVeicolo() + $", Numero Porte: {numeroPorte}, Tipo Alimentazione: {tipoAlimentazione}";
        }

    }
}
