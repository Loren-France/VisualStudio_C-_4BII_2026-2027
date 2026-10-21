using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esUEFA
{
    public enum Esito
    {
        VittoriaCasa,
        Pareggio,
        VittoriaOspite
    }

    internal interface IRisultato
    {
        int CalcolaGolTotali();
        int CalcolaScarto();
        Esito CalcolaEsito();
        string? CalcolaVincitore();

    }
}
