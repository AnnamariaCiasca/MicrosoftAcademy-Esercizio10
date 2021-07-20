using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    class Conto
    {
        public String NumeroDiConto { get; set; }
        public String Intestatario { get; set; }
        public decimal Saldo { get; set; }



        public Conto(String numeroDiConto, String intestatario, decimal saldo)
        {
            this.NumeroDiConto = numeroDiConto;
            this.Intestatario = intestatario;
            this.Saldo = saldo;

        }

        public Conto()
        {
        }

  
    }
}
