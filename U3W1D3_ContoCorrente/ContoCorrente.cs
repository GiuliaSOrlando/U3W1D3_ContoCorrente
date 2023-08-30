using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W1D3_ContoCorrente
{
    internal class ContoCorrente
    {
        public string Titolare { get; set; }
        public string IBAN { get; set; }
        public DateTime DataApertura { get; set; }

        public decimal Saldo { get; set; }

        public bool Aperto { get; set; }

        //Metodi

        private string GeneraNumeroConto()
        {
            Random random = new Random();
            int random1 = random.Next(10000, 100000);
            int random2 = random.Next(10000, 100000);
            string numeroConto = "IT" + random1.ToString() + "0000" + random2.ToString();
            return numeroConto;
        }
        public void AperturaConto(string nome, string cognome, decimal importoIniziale)
        {
            if (!Aperto && importoIniziale >= 1000)
            {
                Titolare = nome + " " + cognome;
                IBAN = GeneraNumeroConto();
                Saldo = importoIniziale;
                DataApertura = DateTime.Now;
                Aperto = true;

                Console.WriteLine("Conto aperto con successo. IBAN: " + IBAN + " - Saldo iniziale: " + Saldo);
            }
            else
            {
                Console.WriteLine("Impossibile aprire il conto.");
            }


        }

        public void Versamento(decimal importo)
        {
            if (Aperto && importo > 0)
            {
                Saldo += importo;
                Console.WriteLine($"Versamento di {importo} € effettuato. Saldo attuale: {Saldo} €");
            }
            else
            {
                Console.WriteLine("Impossibile effettuare il versamento.");
            }
        }
        public void Prelievo(decimal importo)
        {
            if (Aperto && Saldo > 0)
            {
                Saldo -= importo;
                Console.WriteLine($"Prelievo di {importo} € effettuato. Saldo attuale: {Saldo} €");
            }
        
            else
            {
                Console.WriteLine("Impossibile effettuare il prelievo");
            }
        }
    }
}