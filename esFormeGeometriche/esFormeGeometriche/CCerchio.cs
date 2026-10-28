using System;
using System.Collections.Generic;
using System.Text;

namespace esFormeGeometriche
{
    internal class CCerchio : CFigura
    {
        public double Raggio { get; set; }

        public CCerchio(string nome) : base(nome)
        {
        }

        public override double Area()
        {
            double result = Math.Pow(Raggio, 2) * Math.PI;
            return result;
        }

        public override double Perimetro()
        {
            double result = (2 * Raggio) * Math.PI;
            return result;
        }
    }
}
