using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace esReGuardiePedoni
{
    internal class CRe : CPedina
    {
        public CRe(string nome) : base(nome)
        {

        }

        public override string Azione()
        {
            string FileName = "output.txt";
            string message = $"Il Re {this.Nome} è sotto attacco.";

            File.WriteAllText(FileName, message);

            return message;
        }
    }
}
