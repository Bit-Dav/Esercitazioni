using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_quattro
{
    public class ContoCorrente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public decimal Saldo { get; set; }

        public List<Operazione> listaOperazioni;

        public ContoCorrente() { }

        public void MenuConto()
        {
            Console.Clear();

            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"\t\t\t£ BANCA £");
            Console.WriteLine($"------------------------------------------------------");

            if (Nome != null)
                Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");

            if (Nome == null)
                Console.WriteLine("1) Apri conto");
            else
            {
                Console.WriteLine("1) Chiudi conto");
                Console.WriteLine("2) Effettua un versamento");
                Console.WriteLine("3) Effettua un prelievo");
                Console.WriteLine("4) Lista operazioni");
            }

            Console.WriteLine("5) Esci");

            Console.Write("\n\nInserisci numero operazione: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                if (Nome == null)
                    ApriConto();
                else
                    ChiudiConto();
            }
            else if (op == 2)
            {
                Versamento();
            }
            else if (op == 3)
            {
                Prelievo();
            }
            else if(op == 4)
            {
                ListaOperazioni();
            }
            else
            {
                Console.Clear();
            }
        }

        private void ApriConto()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\t\t\t£ BANCA £");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("\t\tAPERTURA CONTO\n");

            Console.Write("Inserisci nome intestatario: ");
            Nome = Console.ReadLine();

            Console.Write("Inserisci cognome intestatario: ");
            Cognome = Console.ReadLine();

            Console.Clear();

            Saldo = 0;
            Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");
            Console.WriteLine("E' necessario effettuare un versamento di 1000 euro all'apertura del conto");
            Console.WriteLine("Procedere con il versamento?");

            Console.WriteLine("1) si");
            Console.WriteLine("2) no");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                Saldo = 1000;
                listaOperazioni = new List<Operazione>();
                Operazione operazione = new Operazione("Versamento", 1000, DateTime.Now, Saldo);
                listaOperazioni.Add(operazione);
                MenuConto();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Impossibile procedere con l'apertura del conto ritorno al menu [PREMI INVIO PER CONTINUARE]");
                Nome = null;
                Cognome = null;
                Console.ReadLine();
                MenuConto();
            }
            Console.ReadLine();
        }

        private void Versamento()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\t\t\t£ BANCA £");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("\t\tVERSAMENTO SU CONTO\n");

            Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");
            Console.Write("Quanto vuoi versare?: ");
            decimal versamento = Convert.ToDecimal(Console.ReadLine());

            if (versamento >= 100)
                Console.WriteLine($"Sei sicuro di voler versare {versamento} euro?  ");
            else
            {
                Console.WriteLine($"Il versamento minimo è di 100 euro [PREMERE INVIO PER CONTINUARE]");
                Console.ReadLine();
                MenuConto();
            }

            Console.WriteLine("1) si");
            Console.WriteLine("2) no");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                Saldo += versamento;
                Operazione operazione = new Operazione("Versamento", versamento, DateTime.Now, Saldo);
                listaOperazioni.Add(operazione);
                MenuConto();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Impossibile procedere con il versamento");
                Console.ReadLine();
            }
        }

        private void Prelievo()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\t\t\t£ BANCA £");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("\t\tPRELIEVO DA CONTO\n");

            Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");

            Console.Write("Quanto vuoi prelevare?: ");
            decimal prelievo = Convert.ToDecimal(Console.ReadLine());

            if (prelievo <= Saldo)
            {
                Console.WriteLine($"Sei sicuro di voler prelevare {prelievo} euro?  ");

                Console.WriteLine("1) si");
                Console.WriteLine("2) no");

                Console.Write("Inserisci: ");
                int op = Convert.ToInt16(Console.ReadLine());

                if (op == 1)
                {
                    Console.Clear();
                    Saldo -= prelievo;
                    Operazione operazione = new Operazione("Prelievo", prelievo, DateTime.Now, Saldo);
                    listaOperazioni.Add(operazione);
                    MenuConto();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Impossibile procedere con l'apertura del conto");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");
                Console.WriteLine($"Impossibile procedere con il prelievo di {prelievo} euro il saldo è insufficiente [PREMERE INVIO PER CONTINUARE]");
                Console.ReadLine();
                MenuConto();
            }
        }

        private void ChiudiConto()
        {
            Console.Clear();
            Console.WriteLine($"Conto: {Nome} {Cognome} \nSaldo: {Saldo} euro\n\n");

            Console.WriteLine("Sei sicuro di voler chiudere il tuo conto?");

            Console.WriteLine("1) si");
            Console.WriteLine("2) no");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                Saldo = 0;
                Nome = null;
                Cognome = null;
                listaOperazioni = null;
                MenuConto();
            }
            else
            {
                Console.Clear();
                MenuConto();
            }
            Console.ReadLine();
        }

        private void ListaOperazioni()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\t\t\t£ BANCA £");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("\t\tLISTA OPERAZIONI\n");

            Console.WriteLine($" Conto: {Nome} {Cognome} \n Saldo: {Saldo} euro\n\n");

            foreach (Operazione operazione in listaOperazioni)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine($"\n Data Operazione: {operazione.Data}\n Tipo operazione: {operazione.Tipo}\n Importo: {operazione.Importo} euro\n Saldo: {operazione.Saldo}");
                Console.WriteLine("-----------------------------------------------------------------------------------------\n");
            }

            Console.WriteLine("Vuoi tornare al menu?");

            Console.WriteLine("1) si");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                MenuConto();
            }
            Console.ReadLine();

        }
    }

    public class Operazione
    {
        public string Tipo { get; set; }
        public decimal Importo { get; set; }

        public DateTime Data { get; set; }

        public decimal Saldo { get; set; }

        public Operazione(string tipo, decimal importo, DateTime data, decimal saldo)
        {
            Tipo = tipo;
            Importo = importo;
            Data = data;
            Saldo = saldo;
        }
    }

}
