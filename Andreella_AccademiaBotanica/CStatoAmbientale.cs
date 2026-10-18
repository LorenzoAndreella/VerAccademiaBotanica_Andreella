using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CStatoAmbientale
    {
        public int MeseCorrente { get; set; }
        public int Temperatura { get; set; }
        public int Umidita { get; set; }
        public int Luminosita { get; set; }

        public CStatoAmbientale(int meseCor, int temp, int umid, int lum)
        {
            MeseCorrente = meseCor;
            Temperatura = temp;
            Umidita = umid;
            Luminosita = lum;
        }


    }
}
