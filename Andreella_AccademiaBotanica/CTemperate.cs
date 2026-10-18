using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CTemperate : CPianta, IFoglie
    {
        protected int TempIdeale { get; set; }
        protected int[] MesiPerdita { get; } = { 11, 12, 1, 2 };

        public CTemperate(string nome, string specie, int eta, bool foglie, int tempIdeale) :base(nome,specie,eta,foglie)
        {
            TempIdeale = tempIdeale;
        }
        public override string Descrizione()
        {
            return base.Descrizione() + $",     Tipo: Temperata     Temperatura ideale: {TempIdeale} gradi,     Periodo perdita foglie: Novembre-Febbraio";
        }
        public string PerdeFoglie()
        {
            if (!Foglie)
            {
                return "Non ha foglie";
            }
            Foglie = false;
            return "Foglie rimosse";
        }

        public string RicresceFoglie()
        {
            if (Foglie)
            {
                return "Ha foglie";
            }
            Foglie = true;
            return "Foglie cresciute";
        }

        public override bool ControlloCodizioniAmbientali(CStatoAmbientale stato)
        {
            if (MesiPerdita.Contains(stato.MeseCorrente))
            {
                return false;
            }
            int tempAttMin = stato.Temperatura - 3;
            int tempAttMax = stato.Temperatura + 3;
            int tempOtt = TempIdeale;
    
            if (tempOtt >= tempAttMin && tempOtt <= tempAttMax)
            {
                return true;
            }
            return false;
        }
    }
}
