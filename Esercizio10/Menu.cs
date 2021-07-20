using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    class Menu
    {

      
        public static void Start()
        {
            char continua;

            do
            {
                int scelta = 0;
         
                Console.WriteLine("***********************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digita 1 per Creare un nuovo conto");
                Console.WriteLine("Digita 2 per Effettuare un prelievo");
                Console.WriteLine("Digita 3 per Effettuare un versamento");
                Console.WriteLine("Digita 4 per Visualizzare il saldo");
                Console.WriteLine("Digita 5 per Eliminare un conto");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("***********************************************");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 5)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1: 
                        Manager.CreaConto();
                        break;

                    case 2:
                        Manager.EffettuaPrelievo();
                        break;

                    case 3:
                        Manager.EffettuaVersamento();
                        break;
                    
                    case 4:
                        Manager.VisualizzaSaldo();
                        break;

                    case 5:
                        Manager.EliminaConto();
                        break;

                    default:
                        break;

                }





                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nVuoi continuare? Se sì, digita s");
                continua = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");


            } while (continua == 's' || continua == 'S');
        }
    }
}



