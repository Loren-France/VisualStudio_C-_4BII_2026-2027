using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esContenutiMultimediali
{
    internal interface IRiproducibile
    {
        string Weaker(int mod);
        string Louder(int mod);
        string Play();
    }
}
