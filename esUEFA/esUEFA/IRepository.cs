using System;
using System.Collections.Generic;
using System.Text;

namespace esUEFA
{
    internal interface IRepository<T>
    {
        IReadOnlyList<T> GetElenco();
        bool Aggiungi(T elemento);
        bool Rimuovi(T elemento);
        void Carica();
        void Salva();
    }
}
