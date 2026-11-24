using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace esReGuardiePedoni
{
    internal class CRe : CPedina
    {
        public CRe() : base()
        {

        }

        public override string Azione()
        {
            string FileName = "output.txt";
            string message = $"Il Re {this.Nome} è sotto attacco.";

            File.AppendAllText(FileName, message);

            return message;
        }
    }
}
