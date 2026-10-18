using System;

namespace Franceschetto_AccademiaBotanica
{
    internal abstract class CPianta : IEquatable<CPianta>, IComparable<CPianta>
    {
        public string Nome { get; set; }
        public int Età { get; set; }
        public bool Foglie { get; set; }

        public CPianta(string nome, int età, bool foglie)
        {
            this.Nome = nome;
            this.Età = età;
            this.Foglie = foglie;
        }

        public abstract string Descrizione();

        public abstract bool CondizioniAdeguate(CStatoAmbientale statoAmbientale);

        public bool Equals(CPianta other)
        {
            if (other == null) return false;

            if (this.Nome != other.Nome || this.GetType() != other.GetType()) return false;

            return true;
        }

        public int CompareTo(CPianta other)
        {
            if (other == null) return 1;

            string thisTypeName = this.GetType().ToString();

            string otherTypeName = other.GetType().ToString();

            if (thisTypeName == otherTypeName)
            {
                if (this.Nome.ToLower() == other.Nome.ToLower())
                {
                    return this.Età.CompareTo(other.Età);
                }
                else
                {
                    return this.Nome.CompareTo(other.Nome);
                }
            }
            else
            {
                return thisTypeName.CompareTo(otherTypeName);
            }
        }
    }
}
