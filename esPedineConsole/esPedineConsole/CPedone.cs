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
            this.Nome = nome;
        }

        public override void Azione(object? sender, EventArgs e)
        {
            string FileName = "output.txt";
            string message = $"Il Pedone {this.Nome} si sta preparando.\n";

            File.AppendAllText(FileName, message);

            base.Comunica(message);
        }

        public void Cattura()
        {
            string FileName = "output.txt";
            string message = $"Il Pedone {this.Nome} è stato catturato.\n";
            File.AppendAllText(FileName, message);
        }
    }
}
