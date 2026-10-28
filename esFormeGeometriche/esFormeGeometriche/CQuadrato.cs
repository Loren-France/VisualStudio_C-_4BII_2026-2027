using System;
using System.Collections.Generic;
using System.Text;

namespace esFormeGeometriche
{
    internal class CQuadrato : CRettangolo
    {
        public CQuadrato(string nome) : base(nome)
        {
        }

        public override double Area()
        {
            double result = Base * Base;
            return result;
        }

        public override double Perimetro()
        {
            double result = 4 * Base;
            return result;
        }
    }
}
