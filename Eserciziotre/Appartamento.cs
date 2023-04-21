using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eserciziotre
{
    internal class Appartamento
    {
        public double mq { get; set; }
        public string zona { get; set; }

        double prezzo;

        public Appartamento(double mq, string zona)
        {
            this.mq = mq;
            this.zona = zona;
        }

        public double PrezzoImmobile()
        {
            if (zona == "Centro" || zona == "centro")
            {
                prezzo = mq * 1200;

                return prezzo;
            }
            else if (zona == "Zona 1" || zona == "1" )
            {
                prezzo = mq * 1000;

                return prezzo;
            }
            else if (zona == "Zona 2" || zona == "2")
            {
                prezzo = mq * 900;

                return prezzo;
            }
            else if (zona == "Zona 3" || zona == "3")
            {
                prezzo = mq * 750;

                return prezzo;
            }
            else if(zona == "Periferia" || zona == "periferia")
            {
                prezzo = mq * 600;

                return prezzo;
            }
            else
            {
                return 0;
            }
        }

        public double PrezzoConProvvigione()
        {
            return prezzo + (prezzo * 4 / 100);
        }
    }
}
