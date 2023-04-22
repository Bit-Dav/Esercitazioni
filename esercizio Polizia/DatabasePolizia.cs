using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_Polizia
{
    internal class DatabasePolizia
    {
        public static List<Trasgressore> listaTrasgressori = new List<Trasgressore>();

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("============== DATABASE VERBALI ==============\n");
            Console.WriteLine("1) Totale dei verbali\n" +
                "2) Ricerca verbale con codice fiscale\n" +
                "3) Ricerca trasgressori per citta \n" +
                "4) Ricerca verbale per punti decurtati maggiori di\n" +
                "5) Ricerca verbale per importo maggiore di\n" +
                "6) Calcola saldo punti patente con codice fiscale\n" +
                "7) Esci\n");

            Console.Write("Inserisci Comando: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                TotaleVerbali();
            }
            else if (op == 2)
            {
                RicercaVerbale();
            }
            else if (op == 3)
            {
                RicercaCitta();
            }
            else if (op == 4)
            {
                RicercaPerPunti();
            }
            else if (op == 5)
            {
                RicercaPerImporto();
            }
            else if (op == 6)
            {
                CalcoloPuntiPatente();
            }
            else
            {

            }
        }

        private void TotaleVerbali()
        {
            Console.Clear();
            Console.WriteLine("============== TOTALE VERBALI ==============\n\n");

            int totaleVerbali = 0;
            decimal totaleImportoVerbali = 0;
            foreach(Trasgressore trasgressore in listaTrasgressori)
            {
                foreach(Verbale verbale in trasgressore.ListaVerbali)
                {
                    totaleVerbali += 1;
                    totaleImportoVerbali += verbale.ImportoVerbale;
                }
            }

            Console.WriteLine($"L'importo totale per {totaleVerbali} verbali effettuati è di: {totaleImportoVerbali.ToString("C2")}\n");

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }


        }

        private void RicercaVerbale()
        {
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI ==============\n\n");

            Console.Write("Inserisci il codice fiscale del trasgressore: ");
            string cf = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI ==============\n");

            bool trovato = false;
            foreach (Trasgressore trasgressore in listaTrasgressori)
            {
                if (cf == trasgressore.CodiceFiscale)
                {
                    trovato = true;
                    trasgressore.StampaTrasgressore();
                }
            }

            if (!trovato)
                Console.WriteLine("Codice fiscale non presente nel database");

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }

        private void RicercaCitta()
        {
            Console.Clear();
            Console.WriteLine("============== RICERCA TRASGRESSORI PER CITTA ==============\n\n");

            Console.Write("Inserisci La citta: ");
            string citta = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("============== RICERCA TRASGRESSORI PER CITTA ==============\n");

            bool trovato = false;
            foreach (Trasgressore trasgressore in listaTrasgressori)
            {
                foreach(Verbale verbale in trasgressore.ListaVerbali)
                {
                    if (citta == verbale.CittaViolazione)
                    {
                        trovato = true;
                        trasgressore.StampaTrasgressore();
                    }
                }
                
            }

            if (!trovato)
                Console.WriteLine("Citta non presente nel database");

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }

        private void RicercaPerPunti()
        {
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI PER PUNTI ==============\n\n");

            Console.Write("Inserisci valore: ");
            int punti = int.Parse(Console.ReadLine()) ;
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI PER PUNTI ==============\n");

            bool trovato = false;
            foreach (Trasgressore trasgressore in listaTrasgressori)
            {
                    int totalePunti = 0;
                    foreach (Verbale verbale in trasgressore.ListaVerbali)
                    {
                        foreach (TipoViolazione violazione in verbale.Violazioni)
                        {
                            totalePunti += violazione.DecurtamentoPunti;
                        }

                        if(totalePunti > punti)
                        {
                            trovato = true;
                            trasgressore.StampaTrasgressore();
                        }
                    }
            }

            if (!trovato)
                Console.WriteLine("Non presente");

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }

        private void RicercaPerImporto()
        {
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI PER IMPORTO ==============\n\n");

            Console.Write("Inserisci importo: ");
            decimal importo = Convert.ToDecimal(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("============== RICERCA VERBALI PER IMPORTO ==============\n");

            bool trovato = false;
            foreach (Trasgressore trasgressore in listaTrasgressori)
            {
                foreach (Verbale verbale in trasgressore.ListaVerbali)
                {
                    if (verbale.ImportoVerbale > importo)
                    {
                        trovato = true;
                        trasgressore.StampaTrasgressore();
                    }
                }
            }

            if (!trovato)
                Console.WriteLine("Non presente");

            Console.WriteLine("Vuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }

        private void CalcoloPuntiPatente()
        {
            Console.Clear();
            Console.WriteLine("============== CALCOLO PUNTI PATENTE ==============\n\n");

            Console.Write("Inserisci il codice fiscale del trasgressore: ");
            string cf = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("============== CALCOLO PUNTI PATENTE ==============\n");

            decimal totalePuntiPatente = 20;
            bool trovato = false;
            foreach (Trasgressore trasgressore in listaTrasgressori)
            {
                if(trasgressore.CodiceFiscale == cf)
                {
                    trovato = true;
                    foreach (Verbale verbale in trasgressore.ListaVerbali)
                    {
                        foreach (TipoViolazione violazione in verbale.Violazioni)
                        {
                            totalePuntiPatente -= violazione.DecurtamentoPunti;
                        }
                    }

                    Console.WriteLine($"{trasgressore.Nome} {trasgressore.Cognome} ha {totalePuntiPatente} punti sulla patente");
                }
            }

            if (!trovato)
                Console.WriteLine("\nCodice fiscale non presente nel database");

            Console.WriteLine("\n\nVuoi tornare al menu? \n 1) si \n 2) no\n");
            Console.Write("Inserisci: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
        }
    }

    public class Trasgressore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public int CAP { get; set; }
        public string CodiceFiscale { get; set; }
        public List<Verbale> ListaVerbali { get; set; } = new List<Verbale>();

        public Trasgressore(int id, string nome, string cognome, string indirizzo, string citta, int cap, string cf, List<Verbale> verbali)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            Citta = citta;
            CAP = cap;
            CodiceFiscale = cf;
            ListaVerbali = verbali;
        }

        public void StampaTrasgressore()
        {
            
                    decimal totaleImportoVerbali = 0;
                    int totalePunti = 0;
                    foreach (Verbale verbale in ListaVerbali)
                    {

                        Console.WriteLine($"Nome: {Nome} Cognome: {Cognome}\n" +
                            $"Data violazione: {verbale.DataViolazione.ToShortDateString()}\n" +
                            $"Indirizzo violazione: {verbale.IndizizzoViolazione}\n" +
                            $"Citta violazione: {verbale.CittaViolazione}\n" +
                            $"Agente verbalizzante: {verbale.AgenteVerbalizzante}\n" +
                            $"Trascrizione verbale: {verbale.DataTrascrizioneVerbale.ToShortDateString()}\n" +
                            $"Importo verbale: {verbale.ImportoVerbale.ToString("C2")}\n" +
                            $"Targa veicolo verbale: {verbale.Veicolo.Targa}\n");

                        int i = 0;
                        foreach (TipoViolazione violazione in verbale.Violazioni)
                        {
                            i++;
                            Console.WriteLine($"Violazione {i}: {violazione.Descrizione} || Punti decurtati per violazione: {violazione.DecurtamentoPunti}");
                            totalePunti += violazione.DecurtamentoPunti;
                        }

                             Console.WriteLine("\n------------------------------------------------------------------------------\n");
                             totaleImportoVerbali += verbale.ImportoVerbale;
                    }

                    Console.WriteLine($"I punti totali decurtati al trasgressore sono di: {totalePunti}");
                    Console.WriteLine($"L'importo totale per {ListaVerbali.Count} verbali effettuati è di: {totaleImportoVerbali.ToString("C2")}");
                    Console.WriteLine("\n------------------------------------------------------------------------------\n");

        }

    }

    public class TipoViolazione
    {
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }
        public int DecurtamentoPunti { get; set; }

        public TipoViolazione(int idViolazione, string descrizione, int decurtamentoPunti)
        {
            IdViolazione = idViolazione;
            Descrizione = descrizione;
            DecurtamentoPunti = decurtamentoPunti;
        }
    }

    public class Verbale
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndizizzoViolazione { get; set; }
        public string CittaViolazione { get; set; }
        public string AgenteVerbalizzante { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal ImportoVerbale { get; set; }
        public List<TipoViolazione> Violazioni { get; set; } = new List<TipoViolazione>();
        public Veicolo Veicolo { get; set; }

        public Verbale(int idVerbale, DateTime dataViolazione, string indizizzoViolazione, string cittaViolazione, string agenteVerbalizzante, DateTime dataTrascrizioneVerbale, decimal importoVerbale, Veicolo veicolo, List<TipoViolazione> violazioni)
        {
            IdVerbale = idVerbale;
            DataViolazione = dataViolazione;
            IndizizzoViolazione = indizizzoViolazione;
            CittaViolazione = cittaViolazione;
            AgenteVerbalizzante = agenteVerbalizzante;
            DataTrascrizioneVerbale = dataTrascrizioneVerbale;
            ImportoVerbale = importoVerbale;
            Veicolo = veicolo;
            Violazioni = violazioni;
        }
    }

    public class Veicolo
    {
        public string Targa { get; set; }
        public string NrTelaio { get; set; }
        public string MarcaVeicolo { get; set; }
        public string TipoVeicolo { get; set; }

        public Veicolo(string targa, string nrTelaio, string marcaVeicolo, string tipoVeicolo)
        {
            Targa = targa;
            NrTelaio = nrTelaio;
            MarcaVeicolo = marcaVeicolo;
            TipoVeicolo = tipoVeicolo;
        }
    }

}
