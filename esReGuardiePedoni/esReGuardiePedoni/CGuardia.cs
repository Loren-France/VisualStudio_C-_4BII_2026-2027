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
        }

        public override string Azione()
        {
            string FileName = "output.txt";
            string message = $"La Guardia {this.Nome} sta difenfendo.";

            File.WriteAllText(FileName, message);

            return message;
        }

        public void Cattura()
        {
            string FileName = "output.txt";
            string message = $"La Guardia {this.Nome} è stata catturata.";
            File.WriteAllText(FileName, message);
        }
    }
}
