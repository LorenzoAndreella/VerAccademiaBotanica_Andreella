using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreella_AccademiaBotanica
{
    public abstract class CPianta
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

        public abstract bool ControlloCodizioniAmbientali(CStatoAmbientale statoAmbientale);
    }
}
