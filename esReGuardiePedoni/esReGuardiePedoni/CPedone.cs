using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace esReGuardiePedoni
{
    internal class CPedone : CPedina, ICatturabile
    {
        public CPedone(string nome) : base(nome)
        {
        }

        public override string Azione()
        {
            string FileName = "output.txt";
            string message = $"Il Pedone {this.Nome} si sta preparando.";

            File.WriteAllText(FileName, message);

            return message;
        }

        public void Cattura()
        {
            string FileName = "output.txt";
            string message = $"Il Pedone {this.Nome} è stato catturato.";
            File.WriteAllText(FileName, message);
        }
    }
}
