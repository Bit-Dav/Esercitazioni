using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_6
{
    public class Menu
    {
        List<Cibo> listaCibi = new List<Cibo>();
        decimal totaleOrdine { get; set; }
        bool ordineConcluso = false;

        public void MainMenu()
        {
            Console.Clear();
            AggiungiCibi();

            Console.WriteLine($"--------------------------------------");
            Console.WriteLine($"\t IL NOSTRO MENU'");
            Console.WriteLine($"--------------------------------------");


            for (int i = 0; i < listaCibi.Count; i++)
            {
                Console.WriteLine($"{i+1}: {listaCibi[i].Nome}\t || {listaCibi[i].Prezzo} euro");
                Console.WriteLine($"--------------------------------------");
            }

            Console.WriteLine("11: Concludi ordine e Stampa conto finale\n\n");

            do
            {
                Console.Write("Inserisi ordinazione: ");
                int op = Convert.ToInt16(Console.ReadLine());

                for (int i = 0; i < listaCibi.Count; i++)
                {
                    if (op == i + 1)
                    {
                        listaCibi[i].Qt += 1;
                    }
                }

                if (op == 11)
                {
                    ordineConcluso = true;
                    StampaOrdine();
                }
            } while (ordineConcluso == false);

            Console.ReadLine();
        }

        public void AggiungiCibi()
        {
            listaCibi.Add(new Cibo("Coca cola 150ml", 2.50m, 0));
            listaCibi.Add(new Cibo("Insalata di pollo", 5.20m, 0));
            listaCibi.Add(new Cibo("Pizza Margherita", 10.00m, 0));
            listaCibi.Add(new Cibo("Pizza 4 formaggi", 12.50m, 0));
            listaCibi.Add(new Cibo("Patatine fritte", 3.50m, 0));
            listaCibi.Add(new Cibo("Insalata di riso", 8.00m, 0));
            listaCibi.Add(new Cibo("Frutta di stagione", 5.00m, 0));
            listaCibi.Add(new Cibo("Pizza diavola", 5.00m, 0));
            listaCibi.Add(new Cibo("Piadina vegetariana", 6.00m, 0));
            listaCibi.Add(new Cibo("Panino hamburger", 7.90m, 0));
        }

        public void StampaOrdine()
        {

            Console.WriteLine("\nIL TUO ORDINE: \n");

            Console.WriteLine($"*********************************************************");
            Console.WriteLine($"-------------------------------------------------");
            foreach (Cibo cibo in listaCibi)
            {
                if (cibo.Qt > 0)
                {
                    Console.WriteLine($" {cibo.Nome}\n prezzo: {cibo.Prezzo} euro\n qt: {cibo.Qt}");
                    Console.WriteLine($"-------------------------------------------------");

                    totaleOrdine += cibo.Qt * cibo.Prezzo;
                }
            }

            totaleOrdine += 3;
            Console.WriteLine($"TOTALE: {totaleOrdine} euro (+3 euro servizio al tavolo incluso)");
            Console.WriteLine($"*********************************************************");

        }
    }

    public class Cibo
    {
        public string Nome { get; set; }

        public decimal Prezzo { get; set; }

        public int Qt { get; set; }

        public Cibo(string nome, decimal prezzo, int qt)
        {
            Nome = nome;
            Prezzo = prezzo;
            Qt = qt;   
        }
    }
}
