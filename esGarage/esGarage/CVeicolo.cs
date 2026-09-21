using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esGarage
{
    internal class CVeicolo
    {
        protected static int id;
        protected string marca;
        protected int anno, cilindrata;

        public CVeicolo(string marca, int anno, int cilindrata)
        {
            this.marca = marca;
            this.anno = anno;
            this.cilindrata = cilindrata;
            id++;
        }

        public int Identifier
        {
            get
            {
                return id;
            }
        }
        public virtual string InfoVeicolo()
        {
            return $"ID: {id}, Marca: {marca}, Anno: {anno}, Cilindrata: {cilindrata}";
        }
    }
}
