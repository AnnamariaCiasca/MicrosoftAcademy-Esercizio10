using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    class Manager
    {


        static List<Conto> conti = new List<Conto>();


        internal static void CreaConto() {


            Console.WriteLine("\nInserisci nome e cognome dell'intestatario:");
            string intestatario = Console.ReadLine().ToUpper();

            string numeroDiConto = GeneratoreNumeroConto();
            Console.WriteLine("\nTi è stato assegnato il seguente Numero di Conto: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{numeroDiConto} ");
            Console.ForegroundColor = ConsoleColor.White;
            decimal saldo;

            Console.WriteLine("\nInserisci la cifra da depositare sul nuovo conto: ");
            while (!decimal.TryParse(Console.ReadLine(), out saldo) || saldo < 0)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }

            Conto conto = new Conto(numeroDiConto, intestatario, saldo);
            conti.Add(conto);
            MostraConti();
        }


        private static string GeneratoreNumeroConto()
        {
            string numConto = string.Empty;
            Conto contoDaTrovare = GetByNumConto(numConto);
            Conto conto = new Conto();
            do
            {
                var random = new Random();
            
                for (int i = 0; i < 10; i++)
                {
                    numConto = String.Concat(numConto, random.Next(10).ToString());
                }

               
                if (contoDaTrovare == null)
                {
                    conto.NumeroDiConto = numConto;
                    return numConto;

                }
                else
                {
                    Console.WriteLine("\nEsiste già un conto con questo Numero");
                    return null;
                }
            } while (contoDaTrovare != null);
        }
    private static Conto GetByNumConto(string numConto)
    {
        foreach (Conto conto in conti)
        {
            if (conto.NumeroDiConto == numConto)
            {
                return conto;
            }

        }
        return null;
    }

    public static void MostraConti(List<Conto> conti)
        { 

            if (conti.Count > 0)
            {
                Console.WriteLine("\nEcco l'elenco dei conti presenti in banca: \n");
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Conto conto in conti)
                {
                    Console.WriteLine($"{count})  \tNumero di Conto: {conto.NumeroDiConto} \tIntestatario: {conto.Intestatario} ");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Nessun conto presente");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MostraConti()
        {
            MostraConti(conti);
        }


        internal static void EffettuaPrelievo()
        {
            Conto conto = new Conto();

            MostraConti();
            conto = ScegliConto();
          
            Console.WriteLine("\nIl Saldo disponibile sul conto scelto è il seguente: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" {conto.Saldo} euro");
            Console.ForegroundColor = ConsoleColor.White;
          
            conti.Remove(conto);

            decimal importo = 0;
            
                Console.WriteLine("\nInserisci l'importo da prelevare: \n");
                while (!decimal.TryParse(Console.ReadLine(), out importo) || importo < 0 || importo > conto.Saldo) 
                {
                    Console.WriteLine("\nInserire valore corretto!");
                if (importo > conto.Saldo)
                {
                    Console.WriteLine("La cifra inserita è superiore a quella presente in banca!\n");
                }
            }

            conto.Saldo = conto.Saldo - importo;

            Console.WriteLine($"\nIl nuovo saldo sul conto {conto.NumeroDiConto} intestao a {conto.Intestatario} è:\n{conto.Saldo} euro.");
           
            conti.Add(conto);
            
            }
            

        private static Conto ScegliConto()
        {
            int codice = -1;
            bool esiste = false;
            do
            {

                Console.WriteLine("\nInserisci il codice del conto con cui effettuare l'operazione richiesta:\n ");
                while (!int.TryParse(Console.ReadLine(), out codice) || codice < 0 || codice > conti.Count) 
                {
                    Console.WriteLine("\nInserire valore corretto!");
                }
                esiste = true;
                
                return conti.ElementAt(codice - 1);

            } while (!esiste);
        }

        internal static void EffettuaVersamento()
        {
            Conto conto = new Conto();

            MostraConti();
            conto = ScegliConto();
            conti.Remove(conto);

            decimal importo = 0;

            Console.WriteLine("Inserisci l'importo da versare: \n");
            while (!decimal.TryParse(Console.ReadLine(), out importo) || importo < 0)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }

            conto.Saldo += importo;

            Console.WriteLine($"\nIl nuovo saldo sul conto {conto.NumeroDiConto} intestao a {conto.Intestatario} è:\n{conto.Saldo} euro.");

            conti.Add(conto);
        }

        internal static void VisualizzaSaldo()
        {
            MostraConti();
            Conto conto = new Conto();
            conto = ScegliConto();
            Console.WriteLine($"\nIl saldo sul conto {conto.NumeroDiConto} intestato a {conto.Intestatario} è: {conto.Saldo} euro.");
        }

        internal static void EliminaConto()
        {
            MostraConti();

            Conto contoDaEliminare = ScegliConto();

            conti.Remove(contoDaEliminare);
        }
    }
}
