using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W1D3_ContoCorrente
{
    internal class Program
    {

        private void MostraMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Apri conto");
            Console.WriteLine("2. Effettua versamento");
            Console.WriteLine("3. Effettua prelievo");
            Console.WriteLine("4. Visualizza elenco conti");
            Console.WriteLine("5. Esci");
            Console.Write("Scelta: ");
        }
        static void Main(string[] args)
        {

            {
                Program program = new Program();
                List<ContoCorrente> conti = new List<ContoCorrente>();
                ContoCorrente conto = null;

                while (true)
                {
                    program.MostraMenu();
                    int scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            Console.Write("Nome: ");
                            string Nome = Console.ReadLine();
                            Console.Write("Cognome: ");
                            string Cognome = Console.ReadLine();
                            Console.Write("Importo iniziale: ");
                            decimal importoIniziale = Convert.ToDecimal(Console.ReadLine());

                            // Controlla se il conto è già presente
                            if (conti.Exists(c => c.Titolare == Nome + " " + Cognome))
                            {
                                Console.WriteLine("Titolare già presente.");
                            }
                            else
                            {
                                conto = new ContoCorrente();
                                conto.AperturaConto(Nome, Cognome, importoIniziale);
                                conti.Add(conto);
                            }
                            break;

                        case 2:
                            if (conto != null)
                            {
                                Console.Write("Importo versamento: ");
                                decimal importoVersamento = Convert.ToDecimal(Console.ReadLine());
                                conto.Versamento(importoVersamento);
                            }
                            else
                            {
                                Console.WriteLine("Apri un conto prima di effettuare un versamento.");
                            }
                            break;

                        case 3:
                            if (conto != null)
                            {
                                Console.Write("Importo prelievo: ");
                                decimal importoPrelievo = Convert.ToDecimal(Console.ReadLine());
                                conto.Prelievo(importoPrelievo);
                            }
                            else
                            {
                                Console.WriteLine("Apri un conto prima di effettuare un prelievo.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Elenco conti:");
                            foreach (ContoCorrente contoCorrente in conti)
                            {
                                Console.WriteLine(contoCorrente.IBAN);
                            }
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Scelta non valida.");
                            break;
                    }
                }
                Console.ReadLine();

            }
        }
    }
}