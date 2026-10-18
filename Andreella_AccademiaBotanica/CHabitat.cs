using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public class CHabitat : IEquatable<CHabitat>, IComparable<CHabitat>
    {
        public string Nome { get; set; }
        public CStatoAmbientale StatoAttuale { get; set; }
        public List<CPianta> Piante { get; }

        public CHabitat(string nome)
        {
            Nome = nome;
            Piante = new List<CPianta>();
        }

        public string AggiungiPianta(CPianta p)
        {
            foreach (CPianta pianta in Piante)
            {
                if (p.Equals(pianta))
                {
                    return "Pianta già presente";
                }
            }
            if (p.ControlloCodizioniAmbientali(StatoAttuale))
            {
                Piante.Add(p);
                return "Pianta aggiunta correttamente nell'habitat " + Nome;
            }
            return "Pianta non adatta";
        }

        public CPianta RicercaPianta(CPianta pianta)
        {
            foreach (var p in Piante)
            {
                if (p.Equals(pianta))
                {
                    return p;
                }
            }
            return null;
        }

        public string RimuoviPianta(CPianta pianta)
        {
            CPianta trovata = RicercaPianta(pianta);
            if (trovata != null)
            {
                Piante.Remove(trovata);
                return "Pianta rimossa correttamente";
            }
            return "Pianta non trovata";
            
        }

        public string ControlloGenerale()
        {
            if (Piante.Count == 0)
            {
                return "Non sono presenti piante";
            }
            string st = "Controllo Generale piante habitat: " + Nome;
            int adeguate = 0;
            int[] tipi = { 0, 0, 0 };
            Piante.Sort();

            foreach (var p in Piante)
            {
                st += "\n\n" + p.Descrizione();
                st += "\n Condizioni: ";
                if (p.ControlloCodizioniAmbientali(StatoAttuale))
                {
                    st += "ADEGUATE";
                    adeguate++;
                }
                else
                {
                    st += "NON ADEGUATE";
                }
                if (p is CTropicale)
                {
                    tipi[0]++;
                }
                else if (p is CMediterranea)
                {
                    tipi[1]++;
                }
                else
                {
                    tipi[2]++;
                }

            }
            st += "\n\nNumero piante: " + Piante.Count;
            st += "\nPiante in condizioni adeguate: " + adeguate;
            st += "\nTropicali: " + tipi[0];
            st += "\nMediterranee: " + tipi[1];
            st += "\nTemperate: " + tipi[2];
            st += "\nPrima pianta: " + Piante[0].Descrizione();
            st += "\nUltima pianta: " + Piante[Piante.Count - 1].Descrizione();
            
            return st;
        }

        public bool Equals(CHabitat h)
        {
            if (h == null) return false;
            return Nome.ToLower().Equals(h.Nome.ToLower());
        }

        public int CompareTo(CHabitat h)
        {
            if (h == null)
            {
                return 1;
            }
            return Nome.ToLower().CompareTo(h.Nome.ToLower());
        }
    }
}
