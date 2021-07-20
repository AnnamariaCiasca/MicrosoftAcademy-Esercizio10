
/*Scrivere un programma per la gestione dei conti in una banca.

Un conto è un'entità che ha

•Intestatario

•Numero di conto

•Saldo


L’utente può:

•Creare un nuovo conto

     N.B. Ogni conto deve avere un numero di conto diverso da quelli già esistenti.

•Prelevare da un conto

•Versare su un conto

•Visualizzare il saldo di un conto

•Eliminare un conto
*/


using System;

namespace Esercizio10
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.WriteLine("Benvenuto in banca!");
            Menu.Start();

        }
    }
}
