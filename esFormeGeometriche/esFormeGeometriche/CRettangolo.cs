using System;
using System.Collections.Generic;
using System.Text;

namespace esFormeGeometriche
{
    internal class CRettangolo : CFigura
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public CRettangolo(string nome) : base(nome)
        {
        }

        public override double Area()
        {
            double result = Base * Altezza;
            return result;
        }

        public override double Perimetro()
        {
            double result = 2 * (Base + Altezza);
            return result;
        }
    }
}
