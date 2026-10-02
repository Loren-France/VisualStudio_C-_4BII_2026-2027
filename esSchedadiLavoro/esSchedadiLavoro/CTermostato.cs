using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal class CTermostato : CDispositivoSmart
    {
        double Temperatura;

        public CTermostato(string nome, string stanza, double temperatura) : base(nome, stanza)
        {
            this.Temperatura = temperatura;
        }

        public override string MostraDettagli()
        {
            return $"Termostato: {Nome} / Stanza: {Stanza} / Temperatura: {Temperatura} / Stato: {(IsAcceso ? "Acceso" : "Spento")}";
        }
    }
}