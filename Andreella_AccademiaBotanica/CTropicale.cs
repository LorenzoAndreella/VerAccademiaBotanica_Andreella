using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CTropicale : CPianta
    {
        protected int UmiditaMin { get; set; }

        public CTropicale(string nome, string specie, int eta, bool foglie, int umiditaMin) : base(nome, specie, eta, foglie)
        {
            UmiditaMin = umiditaMin;
        }
        public override string Descrizione()
        {
            return base.Descrizione() + $",     Tipo: Tropicale     Umidita minima: {UmiditaMin} %";
        }

        public override bool ControlloCodizioniAmbientali(CStatoAmbientale stato)
        {
            if (stato.Umidita >= UmiditaMin)
            {
                return true;
            }
            return false;
        }
    }
}
