using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public abstract class CPianta : IEquatable<CPianta>, IComparable<CPianta>
    {
        protected string Nome { get; set; }
        protected string Specie { get; set; }
        protected int Eta { get; set; }
        protected bool Foglie { get; set; }
        protected CHabitat Habitat { get; set; } = null;

        public CPianta(string nome, string specie, int eta, bool foglie)
        {
            Nome = nome;
            Specie = specie;
            Eta = eta;
            Foglie = foglie;
        }

        public virtual string Descrizione()
        {
            string fog = Foglie ? "Si" : "No";
            return $"Nome: {Nome},  Specie: {Specie},   Eta: {Eta} anni,    Foglie: {fog}";
        }

        public bool Equals(CPianta p)
        {
            if (p == null) return false;
            
            if (Nome.ToLower().Equals(p.Nome.ToLower()) && Specie.ToLower().Equals(p.Specie.ToLower()))
            {
                return true;
            }
            return false;
        }

        public int CompareTo(CPianta p)
        {
            if (p == null)
            {
                return 1;
            }
            int c = Specie.ToLower().CompareTo(p.Specie.ToLower());
            if (c != 0) return c;
            c = Nome.ToLower().CompareTo(p.Nome.ToLower());
            if (c != 0) return c;
            return Eta.CompareTo(p.Eta);
            
        } 

        public abstract bool ControlloCodizioniAmbientali(CStatoAmbientale statoAmbientale);
    }
}
