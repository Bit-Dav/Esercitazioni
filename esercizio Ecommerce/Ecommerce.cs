using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_Ecommerce
{
    public class Ecommerce
    {
        public static List<Utente> ListaUtenti { get; set; } = new List<Utente>();
        public static List<Prodotto> ListaTotaleProdotti { get; set; } = new List<Prodotto>();

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("============== E COMMERCE ==============\n");
            Console.WriteLine("1) Elenco utenti\n" +
                "2) Importo totale ordini effettuati\n" +
                "3) Cerca ordini \n" +
                "4) Cerca prodotto per quantità in giacenza\n");

            Console.Write("Inserisci Comando: ");
            int op = int.Parse(Console.ReadLine());

            if(op == 1)
            {
                ElencoUtenti();
            }
            else if (op == 2)
            {
                StampaOrdini();
            }
            else if (op == 3)
            {
                CercaOrdini();
            }
            else if (op == 4)
            {
                RicercaProdotti();
            }
        }

        private void ElencoUtenti()
        {
            Console.Clear();

            Console.WriteLine("=========== UTENTI ===========\n\n");

            
            foreach (Utente utente in ListaUtenti)
            {
                Console.WriteLine($" ID: {utente.Id}\n " +
                    $"Nome e Cognome: {utente.Nome} {utente.Cognome} \n");

                Console.WriteLine("\nMETODI DI PAGAMENTO: ");

                int i = 0;
                foreach(Pagamento pagamento in utente.ListaMetodiPagamento)
                {
                    i++;
                    Console.WriteLine($" Metodo di pagamento {i}: {pagamento.Tipo}");
                }

                Console.WriteLine("\nINDIRIZZI: ");
                i = 0;
                foreach (Indirizzo indirizzo in utente.ListaIndirizzi)
                {
                    i++;
                    Console.WriteLine($" Indirizzo {i}: {indirizzo.Via}, {indirizzo.Citta} {indirizzo.Cap}");
                }

                Console.WriteLine("\nORDINI: ");

                i = 0;
                Console.WriteLine($" Ordini effettuati: {utente.ListaOrdini.Count}\n");
                foreach(Ordine ordine in utente.ListaOrdini)
                {
                    i++;
                    Console.WriteLine($" ID Ordine {i}: {ordine.Id} effettuato il: {ordine.Data.ToShortDateString()}");
                }

                
                Console.WriteLine("\n----------------------------------------------------------\n");

            }

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }

        }

        private void StampaOrdini()
        {
            Console.Clear();
            Console.WriteLine("=========== ORDINI ===========\n\n");

            decimal totaleOrdini = 0;

            foreach (Utente utente in ListaUtenti)
            {
                Console.WriteLine($"Ordine/i effettuato/i da: {utente.Nome} {utente.Cognome} ({utente.Id})\n");

                foreach (Ordine ordine in utente.ListaOrdini)
                {
                    Console.WriteLine("ORDINE: ");
                    decimal totSingoloOrdine = 0;
                    int j = 0;
                    foreach(Prodotto prodotto in ordine.ListaProdotti)
                    {
                        j++;
                        Console.WriteLine($"Prodotto {j}: {prodotto.Nome} || Prezzo: {prodotto.Prezzo.ToString("C2")}");
                        totSingoloOrdine += prodotto.Prezzo;   
                    }

                    ordine.Totale = totSingoloOrdine;
                    Console.WriteLine($"Totale ordine {ordine.Id}: {totSingoloOrdine.ToString("C2")} pagato tramite: {ordine.MetodoDiPagamento.Tipo}");
                    Console.WriteLine("----------------------------------------------------------\n");


                    totaleOrdini += totSingoloOrdine;
                }
            }
            Console.WriteLine($"\nTotale Ordini: {totaleOrdini.ToString("C2")}");
            

            Console.WriteLine("\n\nVuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }

        private void CercaOrdini()
        {
            Console.Clear();
            Console.WriteLine("=========== RICERCA ORDINI ===========\n\n");

            Console.WriteLine("1) Cerca ordine per importo totale\n" +
                "2) Cerca ordine per ID\n");


            Console.Write("Inserisci: ");
            int op = int.Parse (Console.ReadLine());
            bool ordineTrovato = false;

            if (op == 1) //RICERCA ORDINE PER TOTALE
            {
                Console.Write("Inserisci importo da cui vuoi cominciare a cercare gli ordini: ");
                int importoRicerca = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("=========== RICERCA ORDINI ===========\n\n");

                foreach (Utente utente in ListaUtenti)
                {
                    int i = 0;
                    foreach (Ordine ordine in utente.ListaOrdini)
                    {
                        decimal totSingoloOrdine = 0;
                        foreach (Prodotto prodotto in ordine.ListaProdotti)
                        {
                            totSingoloOrdine += prodotto.Prezzo;
                        }
                        ordine.Totale = totSingoloOrdine;

                        if (ordine.Totale > importoRicerca)
                        {
                            ordineTrovato = true;
                            Console.WriteLine($"ORDINE {ordine.Id} effettuato da {utente.Nome} {utente.Cognome} in data: {ordine.Data.ToShortDateString()}");
                            Console.WriteLine($"Totale ordine {ordine.Id}: {totSingoloOrdine.ToString("C2")} pagato tramite: {ordine.MetodoDiPagamento.Tipo}");
                            Console.WriteLine($"Prodotti ordinati: {ordine.ListaProdotti.Count}");

                            Console.WriteLine("\nSPEDIZIONI: ");
                            foreach (DatiSpedizione spedizione in ordine.ListaSpedizioni)
                            {
                                i++;
                                Console.WriteLine($"Spedizione  {i} per {utente.ListaIndirizzi[0].Via}, {utente.ListaIndirizzi[0].Citta} {utente.ListaIndirizzi[0].Cap} gestita da: {spedizione.NomeCorriere}");
                            }
                            Console.WriteLine("----------------------------------------------------------------------\n");
                        }
                    }
                }

                if (!ordineTrovato)
                {
                    Console.WriteLine($"ORDINE CON TOTALE SUPERIORE A {importoRicerca} NON TROVATO");
                }
            }
            else if(op == 2) //RICERCA ORDINE PER ID
            {
                Console.Write("Inserisci ID dell'ordine di cui vuoi effettuare la ricerca: ");
                int IdRicerca = int.Parse(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("=========== RICERCA ORDINI ===========\n\n");
                foreach (Utente utente in ListaUtenti)
                {
                    foreach (Ordine ordine in utente.ListaOrdini)
                    {
                        int i = 0;
                        if(ordine.Id == IdRicerca)
                        {
                            ordineTrovato = true;
                            Console.WriteLine($"ORDINE {ordine.Id}\n");
                            Console.WriteLine("PRODOTTI: \n");
                            decimal totSingoloOrdine = 0;
                            foreach (Prodotto prodotto in ordine.ListaProdotti)
                            {
                                Console.WriteLine($" Nome: {prodotto.Nome}\n" +
                                    $" Brand: {prodotto.Brand}\n" +
                                    $" Descrizione: {prodotto.Descrizione}\n" +
                                    $" Prezzo: {prodotto.Prezzo.ToString("C2")}");

                                Console.WriteLine("----------------------------------------\n");

                                totSingoloOrdine += prodotto.Prezzo;
                            }

                            Console.WriteLine("SPEDIZIONI: ");
                            foreach (DatiSpedizione spedizione in ordine.ListaSpedizioni)
                            {
                                i++;
                                Console.WriteLine($" Spedizione {i} per {utente.ListaIndirizzi[0].Via}, {utente.ListaIndirizzi[0].Citta} {utente.ListaIndirizzi[0].Cap} gestita da: {spedizione.NomeCorriere} NUMERO TRACCIAMENTO: {spedizione.NumeroSpedizione}");
                            }

                            ordine.Totale = totSingoloOrdine;
                            Console.WriteLine("----------------------------------------------------------\n");

                            Console.WriteLine($" ORDINE {ordine.Id} effettuato da {utente.Nome} {utente.Cognome} in data: {ordine.Data.ToShortDateString()}");
                            Console.WriteLine($" Totale ordine {ordine.Id}: {totSingoloOrdine.ToString("C2")} pagato tramite: {ordine.MetodoDiPagamento.Tipo}");

                            Console.WriteLine("----------------------------------------------------------\n");
                        }
                    }
                }

                if (!ordineTrovato)
                {
                    Console.WriteLine($"ORDINE NON TROVATO CON ID: {IdRicerca}");
                }

            }

            Console.WriteLine("\n\nVuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }

        }

        private void RicercaProdotti()
        {
            Console.Clear();
            Console.WriteLine("=========== RICERCA PRODOTTI ===========\n\n");

            
                Console.Write("Inserisci quantita dei prodotti da ricercare che hanno qt inferiore: ");
                int importoRicerca = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("=========== RICERCA PRODOTTI ===========\n\n");

                
               foreach (Prodotto prodotto in ListaTotaleProdotti)
               {
                    if(prodotto.QuantitaInGiacenza < importoRicerca)
                    {
                        Console.WriteLine($"Nome Prodotto: {prodotto.Nome} || Prezzo: {prodotto.Prezzo.ToString("C2")} || Qt in giacenza: {prodotto.QuantitaInGiacenza}");
                    }
               }

            Console.WriteLine("\n\nVuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }

        }
    }

    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Indirizzo> ListaIndirizzi { get; set; } = new List<Indirizzo>();
        public List<Pagamento> ListaMetodiPagamento { get; set; } = new List<Pagamento>();

        public List<Ordine> ListaOrdini { get; set; } = new List<Ordine>();

        public Utente(int id, string nome, string cognome, List<Indirizzo> indirizzi, List<Pagamento> pagamento, List<Ordine> ordini)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            ListaIndirizzi = indirizzi;
            ListaMetodiPagamento = pagamento;
            ListaOrdini = ordini;
        }

    }

    public class Indirizzo
    {
        public string Citta { get; set; }

        public string Via { get; set; }

        public int Cap { get; set; }

        public Indirizzo(string citta, string via, int cap) 
        {
            Citta = citta;
            Via = via;
            Cap = cap;
        }
    }

    public class Pagamento
    {

        public string Tipo { get; set; }

        public Pagamento(string tipo)
        {
            Tipo = tipo;
        }

    }

    public class Ordine
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public List<Prodotto> ListaProdotti { get; set; } = new List<Prodotto>();

        public List<DatiSpedizione> ListaSpedizioni { get; set; } = new List<DatiSpedizione>();

        public Pagamento MetodoDiPagamento { get; set; }

        public decimal Totale { get; set; }

        public Ordine(int id, DateTime data, List<Prodotto> listaProdotti, List<DatiSpedizione> listaSpedizioni, Pagamento metodo)
        {
            Id = id;
            Data = data;
            ListaProdotti = listaProdotti;
            ListaSpedizioni = listaSpedizioni;
            MetodoDiPagamento = metodo;
        }

    }

    public class Prodotto
    {
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }

        public string Brand { get; set; }

        public int QuantitaInGiacenza { get; set; }

        public Prodotto(string nome, decimal prezzo, string descrizione, string brand, int qt) 
        {
            Nome = nome;
            Prezzo = prezzo;
            Descrizione = descrizione;
            Brand = brand;
            QuantitaInGiacenza = qt;
        }
    }

    public class DatiSpedizione
    {
        public string NomeCorriere;
        public int NumeroSpedizione;

        public DatiSpedizione(string nome, int numeroSpedizione) 
        { 
            NomeCorriere = nome;
            NumeroSpedizione = numeroSpedizione;
        }
    }
}