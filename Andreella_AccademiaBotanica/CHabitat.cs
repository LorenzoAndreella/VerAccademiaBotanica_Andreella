using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CHabitat
    {
        protected string Nome { get; set; }
        public CStatoAmbientale StatoAttuale { get; set; }
        public List<CPianta> Piante { get; }

        public CHabitat(string nome)
        {
            Nome = nome;
            Piante = new List<CPianta>();
        }

        public string AggiungiPianta(CPianta p)
        {
            if (p.ControlloCodizioniAmbientali(StatoAttuale))
            {
                Piante.Add(p);
                return "Pianta aggiunta correttamente nell'habita " + Nome;
            }
            return "Pianta non adatta";
        }

        public string RimuoviPianta(int indice)
        {
            Piante.RemoveAt(indice);
            return "Pianta romossa correttamente nell'habitat " + Nome;
        }

        public string ControlloGenerale()
        {
            string st = "Controllo Generale piante habitat: " + Nome;
            int adeguate = 0;
            int[] tipi = { 0, 0, 0 };
            foreach (var p in Piante)
            {
                st += "\n\n" + p.Descrizione();
                st += "\n Condizioni: ";
                if (p.ControlloCodizioniAmbientali(StatoAttuale))
                {
                    st += "ADEGUATE";
                    adeguate++;
                } else
                {
                    st += "NON ADEGUATE";
                }
                if (p is CTropicale)
                {
                    tipi[0]++;
                } else if (p is CMediterranea)
                {
                    tipi[1]++;
                } else
                {
                    tipi[2]++;
                }
                
            }
            st += "\n\nNumero piante: " + Piante.Count;
            st += "\nPiante in condizioni adeguate: " + adeguate;
            st += "\nTropicali: " + tipi[0];
            st += "\nMediterranee: " + tipi[1];
            st += "\nTemperate: " + tipi[2];
            
            return st;

        }
    }
}
