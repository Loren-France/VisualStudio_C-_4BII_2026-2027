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

        public override void OnCatturaPedina(object? sender, string nome)
        {
        }

        public override void Azione(object? sender, EventArgs e)
        {
            string FileName = "output.txt";
            string message = $"Il Re {this.Nome} è sotto attacco.\n";

            File.AppendAllText(FileName, message);

            base.Comunica(message);
        }
    }
}
