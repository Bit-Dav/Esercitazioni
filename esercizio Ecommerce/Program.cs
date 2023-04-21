using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Prodotto prodotto = new Prodotto("Computer", 1500m, "Computer ultima generazione", "Asus", 12);
            Prodotto prodotto1 = new Prodotto("Tastiera", 200m, "Tastiera meccanica", "Logitech", 5);
            Prodotto prodotto2 = new Prodotto("Frigorifero", 800m, "Computer ultima generazione", "Samsung", 2);
            Prodotto prodotto3 = new Prodotto("Lavatrice", 600m, "Lavatrice smart 10kg", "Ariston", 3);

            Ecommerce.ListaTotaleProdotti.Add(prodotto);
            Ecommerce.ListaTotaleProdotti.Add(prodotto1);
            Ecommerce.ListaTotaleProdotti.Add(prodotto2);
            Ecommerce.ListaTotaleProdotti.Add(prodotto3);


            Indirizzo indirizzo = new Indirizzo("Napoli", "Via Federico II, 32", 30010);
            Indirizzo indirizzo1 = new Indirizzo("Palermo", "Piazza Italia, 36", 10110);
            Indirizzo indirizzo2 = new Indirizzo("Roma", "Via Aldo Moro, 22", 32020);

            DatiSpedizione spedizione = new DatiSpedizione("Amazon", 3333332);
            DatiSpedizione spedizione1 = new DatiSpedizione("BRT", 4555555);
            DatiSpedizione spedizione2 = new DatiSpedizione("GLS", 2212334);
            DatiSpedizione spedizione3 = new DatiSpedizione("SDA", 555553);

            Pagamento bonifico = new Pagamento("Bonifico");
            Pagamento carta = new Pagamento("Carta");
            Pagamento contanti = new Pagamento("Contanti");


            Ordine ordine = new Ordine(1, new DateTime(2023,04,21), new List<Prodotto>() { prodotto, prodotto3 },  new List<DatiSpedizione>() { spedizione2}, bonifico);
            Ordine ordine2 = new Ordine(2, new DateTime(2023,03,11), new List<Prodotto>() { prodotto1 },  new List<DatiSpedizione>() { spedizione1, spedizione3}, carta);
            Ordine ordine3 = new Ordine(3, new DateTime(2022,02,22), new List<Prodotto>() { prodotto2, prodotto2 },  new List<DatiSpedizione>() { spedizione, spedizione2}, contanti);
            Ordine ordine4 = new Ordine(4, new DateTime(2022,08,3), new List<Prodotto>() { prodotto, prodotto3, prodotto2 },  new List<DatiSpedizione>() { spedizione}, contanti);


            Utente utente = new Utente(1, "Paolo", "Marcucci", new List<Indirizzo>() { indirizzo1, indirizzo2 }, new List<Pagamento>() { contanti, carta, bonifico }, new List<Ordine>() { ordine3 });
            Utente utente1 = new Utente(2, "Mario", "Bianchi", new List<Indirizzo>() { indirizzo }, new List<Pagamento>() { bonifico, carta }, new List<Ordine>() { ordine });
            Utente utente2 = new Utente(3, "Daniele", "Marrone", new List<Indirizzo>() { indirizzo2, indirizzo1, indirizzo }, new List<Pagamento>() { carta}, new List<Ordine>() { ordine2, ordine4 });

            Ecommerce.ListaUtenti.Add(utente);
            Ecommerce.ListaUtenti.Add(utente1);
            Ecommerce.ListaUtenti.Add(utente2);

            Ecommerce ecommerce = new Ecommerce();
            ecommerce.Menu();
        }
    }
}
