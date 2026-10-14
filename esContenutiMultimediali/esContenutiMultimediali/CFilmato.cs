using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace esContenutiMultimediali
{
    internal class CFilmato : CElementoMultimediale, IRiproducibile, ILuminosità, IComparable<CFilmato>
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
                if (SelectVolume >= 0 || SelectVolume <= 20)
                {
                    return Luminosità;
                }
                else
                {
                    throw new Exception("Il valore del Volume non rispetta i limiti, il valore deve essere compreso tra 0 e 20.");
                }
            }
            set
            {
                SelectVolume = value;
            }
        }

        public int Light
        {
            get
            {
                if (Luminosità >= 0 || Luminosità <= 10)
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
                Light = value;
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

        public int CompareTo(CFilmato f)
        {
            if (f == null) return 1;

            if (this.Durata < f.Durata) return -1;
            if (this.Durata > f.Durata) return 1;

            return 0;
        }

        public string Weaker(int w)
        {
            Volume -= w;
            return $"Il Volume del filmato {this.Nome} è diminuito di {w}";
        }

        public string Louder(int l)
        {
            Volume -= l;
            return $"Il Volume del filmato {this.Nome} è diminuito di {l}";
        }
        public string Darker(int d)
        {
            Luminosità -= d;
            return $"Luminosità del filmato {this.Nome} diminuita di {d}";
        }
        public string Brighter(int b)
        {
            Luminosità += b;
            return $"Luminosità del filmato {this.Nome} aumentata di {b}";
        }
    }
}
