using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace esReGuardiePedoni
{
    internal class CGuardia : CPedina, ICatturabile
    {
        public CGuardia(string nome) : base(nome)
        {
            this.Nome = nome;
        }

        public override void Azione(object? sender, EventArgs e)
        {
            string FileName = "output.txt";
            string message = $"La Guardia {this.Nome} sta difenfendo.\n";

            File.AppendAllText(FileName, message);

            base.Comunica(message);
        }

        public void Cattura()
        {
            string FileName = "output.txt";
            string message = $"La Guardia {this.Nome} è stata catturata.\n";
            File.AppendAllText(FileName, message);
        }
    }
}
