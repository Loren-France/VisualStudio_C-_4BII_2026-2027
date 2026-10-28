using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using SkiaSharp;

namespace esFormeGeometriche
{
    internal abstract class CFigura
    {
        public string Nome { get; set; }

        public CFigura(string nome)
        {
            this.Nome = nome;
        }

        public abstract double Area();
        public abstract double Perimetro();

        public string Descrizione()
        {
            return $"Nome: {Nome} | Area: {Area():F2} | Perimetro: {Perimetro():F2}";
        }
    }
}
