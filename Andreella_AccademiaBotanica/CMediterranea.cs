using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CMediterranea : CPianta, IFoglie
    {
        protected int LuminositaMin { get; set; }
        protected int[] MesiPerdita { get; } = { 7,8 };

        public CMediterranea(string nome, string specie, int eta, bool foglie, int lumMin) : base(nome, specie, eta, foglie)
        {
            LuminositaMin = lumMin;
        }
        public override string Descrizione()
        {
            return base.Descrizione() + $",     Tipo: Mediterranea     Luminosita minima: {LuminositaMin} %,    Periodo perdita foglie: Luglio-Agosto";
        }

        public override bool ControlloCodizioniAmbientali(CStatoAmbientale stato)
        {
            if (MesiPerdita.Contains(stato.MeseCorrente))
            {
                return false;
            }
            
            if (stato.Luminosita >= LuminositaMin)
            {
                return true;
            }
            return false;
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
    }
}
