using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eserciziotre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci i mq dell' appartamento: ");
            double mq = Convert.ToDouble(Console.ReadLine());

            Console.Write("Inserisci la zona dell' appartamento: ");
            string zona = Console.ReadLine();

            Appartamento appartamento = new Appartamento(mq, zona);

            double prezzo = appartamento.PrezzoImmobile();
            double provvigione = appartamento.PrezzoConProvvigione();

            if (prezzo > 0)
            {
                Console.WriteLine($"Il prezzo dell'immobile ammonta a: {prezzo} euro");

                Console.WriteLine($"Il prezzo dell'immobile con provvigione al 4% ammonta a: {provvigione} euro");
            }
            else
            {
                Console.WriteLine("Zona inserita non corretta");
            }

            Console.ReadLine();
        }
    }
}
