using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esContenutiMultimediali
{
    internal class CRegistrazioneAudio : CElementoMultimediale, IRiproducibile
    {
        private int Volume;

        public int Durata { get; set; }

        public CRegistrazioneAudio (string nome, int volume, int durata) : base (nome)
        {
            this.Volume = volume;
            this.Durata = durata;
        }

        public int SelectVolume
        {
            get
            {
                if (SelectVolume >= 0)
                {
                    return SelectVolume;
                }
                else
                {
                    throw new ArgumentException("Il valore del Volume non può esssere negativo.");
                }
            }
            set
            {
                SelectVolume = value;
            }
        }

        public override string ToString()
        {
            return $"File audio, Nome: {this.Nome}, Volume: {this.Volume}, Durata: {this.Durata}";
        }

        public string Weaker (int w)
        {
            Volume -= w;
            return $"Il Volume della registrazione {this.Nome} è diminuito di {w}";
        }

        public string Louder(int l)
        {
            Volume += l;
            return $"Il Volume della registrazione {this.Nome} è aumentato di {l}";
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
                builder += "\n";
            }

            return builder;
        }
    }
}
