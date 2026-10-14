using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esContenutiMultimediali
{
    internal class CImmagine : CElementoMultimediale, ILuminosità
    {
        private int Luminosità;

        public CImmagine (string nome, int luminosità) : base (nome)
        {
            this.Luminosità = luminosità;
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
            return $"File immagine, Nome: {this.Nome}, Luminosità: {this.Luminosità}";
        }

        public string Darker(int d)
        {
            Luminosità -= d;

            if (Luminosità < 0)
            {
                Luminosità = 0;
            }

            return $"Luminosità dell'immagine {this.Nome} diminuita di {d}";
        }
        public string Brighter(int b)
        {
            Luminosità += b;

            if (Luminosità > 10)
            {
                Luminosità = 10;
            }

            return $"Luminosità dell'immagine {this.Nome} aumentata di {b}";
        }
        public string Show()
        {
            string builder = "";

            builder += this.Nome;
            for (int i = 0; i < this.Luminosità; i++)
            {
                builder += "*";
            }

            return builder;
        }
    }
}
