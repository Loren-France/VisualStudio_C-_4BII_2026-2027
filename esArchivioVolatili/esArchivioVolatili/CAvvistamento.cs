using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esArchivioVolatili
{
    internal class CAvvistamento
    {
        private DateTime Data;
        private string Luogo;
        private string Note;

        public CAvvistamento(DateTime data, string luogo, string note)
        {
            this.Data = data;
            this.Luogo = luogo;
            this.Note = note;
        }

        public string StampaAvvistamento()
        {
            return $"Data: {Data.ToString()}, Luogo: {Luogo}, Note: {Note}";
        }
    }
}
