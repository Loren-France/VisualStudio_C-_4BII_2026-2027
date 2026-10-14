using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace esContenutiMultimediali
{
    internal class CFilmato : CElementoMultimediale, IRiproducibile, ILuminosità, IEquatable<CFilmato>
    {
        private int Volume;
        public int Durata { get; set; }
        private int Luminosità;

        public CFilmato (string nome, int volume, int durata, int luminosità) : base (nome)
        {
            this.Volume = volume;
            this.Durata = durata;
            this.Luminosità = luminosità;
        }

        public int SelectVolume
        {
            get
            {
                if (Volume >= 0 && Volume <= 20)
                {
                    return Volume;
                }
                else
                {
                    throw new Exception("Il valore del Volume non rispetta i limiti, il valore deve essere compreso tra 0 e 20.");
                }
            }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    Volume = value;
                }
                else
                {
                    throw new Exception("Il valore del Volume non rispetta i limiti, il valore deve essere compreso tra 0 e 20.");
                }
            }
        }

        public int Light
        {
            get
            {
                if (Luminosità >= 0 && Luminosità <= 10)
                {
                    return Luminosità;
                }
                else
                {
                    throw new Exception("Il valore di Luminosità non rispetta i limiti, il valore deve essere compreso tra 0 e 10.");
                }
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    Luminosità = value;
                }
                else
                {
                    throw new Exception("Il valore di Luminosità non rispetta i limiti, il valore deve essere compreso tra 0 e 10.");
                }
            }
        }

        public override string ToString()
        {
            return $"File video, Nome: {this.Nome}, Volume: {this.Volume}, Durata. {this.Durata}, Luminosità: {this.Luminosità}";
        }

        public string Play()
        {
            string builder = "";

            for (int i = 0; i < this.Durata; i++)
            {
                builder += this.Nome;
                for (int j = 0; j < this.Volume; j++)
                {
                    builder += "!";
                }
                for (int j = 0; j < this.Luminosità; j++)
                {
                    builder += "*";
                }
                builder += "\n";
            }

            return builder;
        }

        public bool Equals(CFilmato other)
        {
            if (other == null) return false;

            if (this.Nome == other.Nome && this.Volume == other.Volume && this.Durata == other.Durata && this.Luminosità == other.Luminosità)
            {
                return true;
            }
            return false;
        }

        public string Weaker(int w)
        {
            Volume -= w;

            if (Volume < 0)
            {
                Volume = 0;
            }

            return $"Il Volume del filmato {this.Nome} è diminuito di {w}";
        }

        public string Louder(int l)
        {
            Volume += l;

            if (Volume > 20)
            {
                Volume = 20;
            }

            return $"Il Volume del filmato {this.Nome} è aumentato di {l}";
        }
        public string Darker(int d)
        {
            Luminosità -= d;

            if (Luminosità < 0)
            {
                Luminosità = 0;
            }

            return $"Luminosità del filmato {this.Nome} diminuita di {d}";
        }
        public string Brighter(int b)
        {
            Luminosità += b;

            if (Luminosità > 10)
            {
                Luminosità = 10;
            }

            return $"Luminosità del filmato {this.Nome} aumentata di {b}";
        }
    }
}
