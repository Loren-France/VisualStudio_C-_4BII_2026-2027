using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace esBattagliaNavale
{
    internal class CCampo
    {
        public CCasella[,] caselle = new CCasella[10, 10];

        public List<CNave> navi = new List<CNave>();

        public CCampo()
        {
            InizializzaCaselle();

            InizializzaNavi();
        }

        public void InizializzaCaselle()
        {
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    caselle[i, j] = new CCasella(i, j);
                }
            }
        }

        public void InizializzaNavi()
        {
            navi.Add(new CNave(4));
            navi.Add(new CNave(3));
            navi.Add(new CNave(3));
            navi.Add(new CNave(2));
            navi.Add(new CNave(2));
            navi.Add(new CNave(1));
        }
    }
}
