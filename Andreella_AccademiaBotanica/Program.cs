using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

namespace Andreella_AccademiaBotanica
{
    internal class Program
    {
        public static List<CHabitat> habitatVari = new List<CHabitat>();
        public static CHabitat habitatSelezionato = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nell'Accademia di Botanica di Ernesto Floris!");
            int scelta;
            do
            {
                Console.WriteLine("1. Crea habitat");
                Console.WriteLine("2. Seleziona habitat");
                Console.WriteLine("3. Aggiungi pianta");
                Console.WriteLine("4. Rimuovi pianta");
                Console.WriteLine("5. Visualizza piante presenti");
                Console.WriteLine("6. Modifica valori stato attuale");
                Console.WriteLine("7. Esegui controllo generale");
                Console.WriteLine("8. Esci");

                scelta = AggiungiNum("Scegli cosa fare: ", 1, 8);
                if (scelta > 2 && scelta < 8 && habitatSelezionato == null)
                {
                    Console.WriteLine("Prima devi selezionare un habitat");
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        CreaHabitat();
                        break;
                    case 2:
                        ScegliHabitat();
                        break;
                    case 3:
                        AggiungiPianta();
                        break;
                    case 4:
                        RimuoviPianta();
                        break;
                    case 5:
                        VisualizzaPiantePresenti();
                        break;
                    case 6:
                        ModificaValoriStatoAttuale();
                        break;
                    case 7:
                        EseguiControlloGenerale();
                        break;
                    case 8:
                        Console.WriteLine("Uscita dal programma...");
                        return;

                }
            } while (true);
        }

        public static string AggiungiString(string m)
        {
            string st;
            do
            {
                Console.WriteLine(m);
                st = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(st));
            return st;
        }

        public static int AggiungiNum(string m, int min, int max)
        {
            int n;
            do
            {
                Console.WriteLine(m);
            } while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max);
            return n;
        }

        public static bool AggiungiBool(string m, string s1, string s2)
        {
            int n;
            do
            {
                Console.WriteLine(m + "1. " + s1 + " 2. " + s2);
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 2);

            bool r = n == 1 ? true : false;
            return r;
        }

        public static void CreaHabitat()
        {
            CHabitat h = new CHabitat(AggiungiString("Scrivi nome habitat"));
            h.StatoAttuale = new CStatoAmbientale(
                AggiungiNum("Inserisci mese corrente", 1, 12),
                AggiungiNum("Inserisci temperatura", -5, 35),
                AggiungiNum("Inserisci umidita", 0, 100),
                AggiungiNum("Inserisci luminosita", 0, 100));
            habitatVari.Add(h);
            Console.WriteLine("Habitat creato correttamente");
        }

        public static void ScegliHabitat()
        {
            if (habitatVari.Count == 0)
            {
                Console.WriteLine("Nessun habitat presente");
                return;
            }
            habitatSelezionato = habitatVari[AggiungiNum("Scegli habitat inserendo il numero (il primo ha id 0)", 0, habitatVari.Count - 1)];
        }

        public static void AggiungiPianta()
        {
            int sceltaPianta = AggiungiNum("Scegli tipologia di pianta da aggiungere: \n1.Tropicale, 2.Mediterranea, 3. Temperata", 1, 3);
            switch (sceltaPianta)
            {
                case 1:
                    habitatSelezionato.AggiungiPianta(new CTropicale(AggiungiString("Nome "), AggiungiString("Specie "), AggiungiNum("Eta ", 0, 10000), AggiungiBool("Ha le foglie? ", "si", "no"), AggiungiNum("Umidita minima ", 0, 100)));
                    break;
                case 2:
                    habitatSelezionato.AggiungiPianta(new CMediterranea(AggiungiString("Nome "), AggiungiString("Specie"), AggiungiNum("Eta ", 0, 10000), AggiungiBool("Ha le foglie?", "si", "no"), AggiungiNum("Luminosita minima ", 0, 100)));
                    break;
                case 3:
                    habitatSelezionato.AggiungiPianta(new CTemperate(AggiungiString("Nome "), AggiungiString("Specie"), AggiungiNum("Eta ", 0, 10000), AggiungiBool("Ha le foglie?", "si", "no"), AggiungiNum("Temperatura ideale ", -5, 35)));
                    break;
                default:
                    Console.WriteLine("Errore");
                    return;
            }
        }

        public static void RimuoviPianta()
        {
            if (habitatSelezionato.Piante.Count > 0)
            {
                VisualizzaPiantePresenti();
                int rmPianta = AggiungiNum("Inserisci numero pianta da rimuovere", 0, habitatSelezionato.Piante.Count - 1);
                habitatSelezionato.RimuoviPianta(rmPianta);
            }
            else
            {
                Console.WriteLine("Nessuna pianta da rimuovere");
            }
        }
        public static void VisualizzaPiantePresenti()
        {
            if (habitatSelezionato.Piante.Count == 0)
            {
                Console.WriteLine("Non ci sono piante");
                return;
            }
            Console.WriteLine("Elenco piante:");
            for (int i = 0; i < habitatSelezionato.Piante.Count; i++)
            {
                Console.WriteLine(i + ")" + habitatSelezionato.Piante[i].Descrizione());
            }
            
        }
        public static void ModificaValoriStatoAttuale()
        {
            CStatoAmbientale s = habitatSelezionato.StatoAttuale;
            Console.WriteLine("Modifica stato attuale");
            s.MeseCorrente = AggiungiNum("Inserisci mese corrente: ", 1, 12);
            s.Temperatura = AggiungiNum("Inserisci temperatura: ", -5, 35);
            s.Umidita = AggiungiNum("Inserisci umidita: ", 0, 100);
            s.Luminosita = AggiungiNum("Inserisci luminosita: ", 0, 100);

            Console.WriteLine("Stato ambientale aggiornato!");
        }
        public static void EseguiControlloGenerale()
        {
            Console.WriteLine(habitatSelezionato.ControlloGenerale());
        }


    }
}
