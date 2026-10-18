using System.Collections.Generic;
using System;

namespace Franceschetto_AccademiaBotanica
{
    internal class CHabitat : CStatoAmbientale, IEquatable<CHabitat>, IComparable<CHabitat>
    {
        public List<CPianta> ListaPiante { get; }
        public string Nome { get; set; }
        public CStatoAmbientale StatoAmbientale { get; set; }

        public CHabitat(string nome, CStatoAmbientale statement) : base()
        {
            this.Nome = nome;
            this.ListaPiante = new List<CPianta>();
            this.StatoAmbientale = new CStatoAmbientale();
        }

        public string DescrizioneHabitat()
        {
            return $"Nome: {this.Nome}, Mese corrente: {this.Mese}, Temperatura: {this.SensoreTemperatura}, Umidità: {this.SensoreUmidità}, Luminosità: {this.SensoreLuminosità}";
        }

        public void AggiungiPianta(CPianta aggiungere)
        {
            ListaPiante.Add(aggiungere);
        }

        public void RimuoviPianta(CPianta rimuovere)
        {
            ListaPiante.Remove(rimuovere);
        }

        public bool Equals(CHabitat other)
        {
            if (other == null) return false;
            if (this.Nome.ToLower() != other.Nome.ToLower())
                return false;
            return true;
        }

        public int CompareTo(CHabitat other)
        {
            if (other == null) return 1;
            return this.Nome.CompareTo(other.Nome);
        }
    }
}
