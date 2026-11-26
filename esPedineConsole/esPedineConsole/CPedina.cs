using System;
using System.Collections.Generic;
using System.Text;
using esPedineConsole;

namespace esReGuardiePedoni
{
    internal abstract class CPedina
    {
        public string Nome { get; set; }

        public event EventHandler<string>? Messaggio;

        public CPedina(string nome)
        {
            this.Nome = nome;
        }

        protected void Comunica(string frase)
        {
            Messaggio?.Invoke(this, frase);
        }

        public abstract void Azione(object? sender, EventArgs e);

        public virtual void OnCatturaPedina(object? sender, string nome)
        {
            if (this.Nome != nome)
            {
                return;
            }

            if (sender is CGestione gestore)
            {
                gestore.AttaccaRe -= Azione;
                gestore.Cattura -= OnCatturaPedina;
            }
        }
    }
}
