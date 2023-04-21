using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eserciziodue
{
    public class Cliente
    {
        public int eta { get; set; }

        public Cliente(int eta) 
        {

            this.eta = eta;
        }

        public decimal ImportoBiglietto()
        {
            if(eta < 5)
            {
                return 0;
            }
            else if(eta < 10)
            {
                return 1;
            }
            else if (eta >= 11 && eta <= 17)
            {
                return 1.5m;
            }
            else if (eta >= 18 && eta <= 26)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
