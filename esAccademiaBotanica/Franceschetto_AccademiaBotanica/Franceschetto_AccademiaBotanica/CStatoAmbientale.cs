using System.Collections.Generic;
using System;

namespace Franceschetto_AccademiaBotanica
{
    internal class CStatoAmbientale : IEquatable<CStatoAmbientale>
    {
        public int Mese { get; set; }
        public double SensoreTemperatura { get; set; }
        public double SensoreUmidità { get; set; }
        public double SensoreLuminosità { get; set; }

        public CStatoAmbientale()
        {
            this.SensoreTemperatura = 0;
            this.SensoreUmidità = 0;
            this.SensoreLuminosità = 0;
            this.Mese = 0;
        }
        public bool Equals(CStatoAmbientale other)
        {
            if (other == null) return false;
            if (this.Mese != other.Mese || this.SensoreTemperatura != other.SensoreTemperatura || this.SensoreUmidità != other.SensoreUmidità || this.SensoreLuminosità != other.SensoreLuminosità) 
                return false;
            return true;
        }
    }
}
