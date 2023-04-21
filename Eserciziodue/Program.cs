using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Eserciziodue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci l' età: ");
            int eta = Convert.ToInt16( Console.ReadLine());

            Cliente bambino = new Cliente(eta);
            decimal importo = bambino.ImportoBiglietto();

            if(importo == 0)
                Console.WriteLine("Il biglietto è gratuito");
            else
                Console.WriteLine($"L'importo del biglietto ammonta a: {importo} euro");

            Console.ReadLine();
        }
    }
}
