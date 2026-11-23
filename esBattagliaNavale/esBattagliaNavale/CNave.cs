using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;

namespace esBattagliaNavale
{

    internal class CNave
    {
        public List<CCasella> caselleNave { get; set; }
        public int Dimensione { get; set; }

        public CNave(int dimensione)
        {
            caselleNave = new List<CCasella>();
            Dimensione = dimensione;
        }

        public bool Affondata()
        {
            foreach (CCasella casel in caselleNave)
            {
                if (!casel.IsColpita)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"Nave da {Dimensione} celle";
        }
    }

}
