using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_settimanale
{
    internal class CalcoloAliquote
    {
        public static List<Contribuente> listaContribuenti = new List<Contribuente>();
        bool primoAvvio = false;
        bool error = false;

        public void Menu()
        {
            EsempioContribuenti();

            Console.Clear();
            Console.WriteLine("=============== CALCOLO ALIQUOTA ===============\n\n");

            Console.WriteLine("1) Aggiungi contribuente e calcola aliquota");
            Console.WriteLine("2) Lista aliquote calcolate");
            Console.WriteLine("3) Esci");

            Console.Write("\nInserisci numero operazione: ");
            int op = int.Parse( Console.ReadLine());
            

            if(op == 1)
            {
                AggiungiContribuente();
            }
            else if(op == 2)
            {
                StampaListaContribuenti(false);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //METODO PER AGGIUNGERE NUOVO CONTRIBUENTE
        private void AggiungiContribuente()
        {
            Console.Clear();
            Console.WriteLine("=======AGGIUNTA CONTRIBUENTE=======\n\n");

            //DICHIARAZIONE VARIAIBLI INPUT
            string nome;
            string cognome;
            int giorno;
            int mese;
            int anno;
            string codiceFiscale;
            string sesso;
            string residenza;
            decimal reddito;

            //CONTROLLO NOME ESATTO
            do
            {
                Console.Write("Nome contribuente: ");
                nome = Console.ReadLine();

                if (nome == null || nome == "")
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE NOME ERRATO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO COGNOME ESATTO
            do
            {

                Console.Write("Cognome contribuente: ");
                cognome = Console.ReadLine();

                if (cognome == null || cognome == "")
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE COGNOME ERRATO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO GIORNO ESATTO
            do
            {
                Console.Write("Giorno di nascita: ");
                giorno = int.Parse(Console.ReadLine());

                if (giorno > 31 || giorno < 1)
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE GIORNO DI NASCITA ERRATO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO MESE ESATTO
            do
            {
                Console.Write("Mese di nascita: ");
                mese = int.Parse(Console.ReadLine());

                if (mese > 12 || mese < 1)
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE MESE DI NASCITA ERRATO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO ANNO ESATTO
            do
            {
                Console.Write("Anno di nascita: ");
                anno = int.Parse(Console.ReadLine());

                if (anno < 1800 || anno > 2005)
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE ANNO DI NASCITA ERRATO **");
                }
                else
                    error = false;

            } while (error);

            DateTime inputDate = new DateTime(anno, mese, giorno);

            //CONTROLLO CODICE FISCALE ESATTO
            do
            {
                Console.Write("Codice fiscale: ");
                codiceFiscale = Console.ReadLine();

                if (codiceFiscale == null || codiceFiscale == "")
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE CODICE FISCALE ERRATO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO SESSO ESATTO
            do
            {
                Console.Write("Sesso (M/F): ");
                sesso = Console.ReadLine();

                if (sesso != "M" && sesso != "F")
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE SESSO NON CORRETTO **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO RESIDENZA ESATTA
            do
            {
                Console.Write("Comune di residenza: ");
                residenza = Console.ReadLine();

                if (residenza == null || residenza == "")
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE RESIDENZA NON CORRETTA **");
                }
                else
                    error = false;

            } while (error);

            //CONTROLLO REDDITO ESATTO
            do
            {
                Console.Write("Il tuo reddito: ");
                reddito = decimal.Parse(Console.ReadLine());

                if (reddito <= 0)
                {
                    error = true;
                    Console.WriteLine("** ATTENZIONE REDDITO NON CORRETTO **");
                }
                else
                    error = false;


            } while (error);
            

            CalcoloAliquota(nome, cognome, inputDate, codiceFiscale, sesso, residenza, reddito);

            StampaListaContribuenti(true);
        }

        //METODO PER RIMUOVERE UN CONTRIBUENTE
        private void EliminaContribuente()
        {
            Console.WriteLine("\nQuale contribuente vuoi eliminare?");
            Console.Write("\nInserisci id contribuente: ");
            int op = int.Parse(Console.ReadLine());

            if (op - 1 <= listaContribuenti.Count)
                listaContribuenti.RemoveAt(op - 1);
            else
                Console.WriteLine("Contribuente non esistente");

            StampaListaContribuenti(false);
        }

        //METODO PER CALCOLARE ALIQUOTA E INSERIRLA NELLA LIST DI CONTRIBUENTI
        private void CalcoloAliquota(string nome, string cognome, DateTime nascita, string cf, string sesso, string residenza, decimal reddito)
        {
            decimal imposta = 0;
            if(reddito > 0 && reddito <= 15000)
            {
                imposta = reddito * 23 / 100;
            }
            else if (reddito > 15000 && reddito <= 28000)
            {
                decimal eccedente = reddito - 15000;
                imposta = (eccedente * 27 / 100) + 3450;
            }
            else if (reddito > 28000 && reddito <= 55000)
            {
                decimal eccedente = reddito - 28000;
                imposta = (eccedente * 38 / 100) + 6960;
            }
            else if (reddito > 55000 && reddito <= 75000)
            {
                decimal eccedente = reddito - 55000;
                imposta = (eccedente * 41 / 100) + 17220;
            }
            else if(reddito > 75000)
            {
                decimal eccedente = reddito - 75000;
                imposta = (eccedente * 43 / 100) + 25420;
            }

            listaContribuenti.Add(new Contribuente(nome, cognome, nascita, cf, sesso, residenza, reddito, imposta));
        }

        //METODO PER STAMPARE LISTA CONTRIBUENTI
        private void StampaListaContribuenti(bool stampaSingolo)
        {
            
            Console.Clear();
            Console.WriteLine("=======LISTA CONTRIBUENTI=======\n\n");
            Console.WriteLine($"--------------------------------------\n");

            if (stampaSingolo)
            {
                Console.WriteLine($"Contribuente: {listaContribuenti[listaContribuenti.Count - 1].Nome} {listaContribuenti[listaContribuenti.Count - 1].Cognome},\n" +
                $"nato il {listaContribuenti[listaContribuenti.Count - 1].DataNascita.ToShortDateString()} ({listaContribuenti[listaContribuenti.Count - 1].Sesso}),\n" +
                $"residente in {listaContribuenti[listaContribuenti.Count - 1].ComuneResidenza}\n" +
                $"codice fiscale: {listaContribuenti[listaContribuenti.Count - 1].CodiceFiscale}\n\n" +
                $"Reddito dichiarato: {listaContribuenti[listaContribuenti.Count - 1].RedditoAnnuale.ToString("C2")}\n\n" +
                $"IMPOSTA DA VERSARE: {listaContribuenti[listaContribuenti.Count - 1].ImpostaDaVersare.ToString("C2")}");
                Console.WriteLine($"\n--------------------------------------\n");
            }
            else
            {
                int i = 0;
                foreach (Contribuente contribuente in listaContribuenti)
                {
                    Console.WriteLine($"{i+1}) Contribuente: {contribuente.Nome} {contribuente.Cognome},\n" +
                    $"nato il {contribuente.DataNascita.ToShortDateString()} ({contribuente.Sesso}),\n" +
                    $"residente in {contribuente.ComuneResidenza}\n" +
                    $"codice fiscale: {contribuente.CodiceFiscale}\n\n" +
                    $"Reddito dichiarato: {contribuente.RedditoAnnuale.ToString("C2")}\n\n" +
                    $"IMPOSTA DA VERSARE: {contribuente.ImpostaDaVersare.ToString("C2")}");
                    Console.WriteLine($"\n--------------------------------------\n");
                    i++;
                }
            }
            if (!stampaSingolo)
            {
                Console.WriteLine("\n\nCosa vuoi fare?\n\n1) Torna al menu");
                if(listaContribuenti.Count > 0)
                    Console.WriteLine("\n2) Elimina dati contribuente");

                Console.Write("\nInserisci: ");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                    Menu();
                else if (op == 2)
                {
                    if(listaContribuenti.Count > 0)
                        EliminaContribuente();
                }
            }
            else
            {
                Console.WriteLine("\n\nVuoi tornare al menu?\n\n1) si \n2) no");

                Console.Write("\nInserisci: ");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                    Menu();
            }
        }

        //INSERISCE UN CONTRIBUENTE DI ESEMPIO MARIO ROSSI NELLA LISTA
        private void EsempioContribuenti()
        {
            if (!primoAvvio)
            {
                Contribuente contribuente = new Contribuente("Mario", "Rossi", new DateTime(1961, 07, 15), "M", "MRORSI61LIKSNNNS", "Palermo", 17850m);

                CalcoloAliquota(contribuente.Nome, contribuente.Cognome, contribuente.DataNascita, contribuente.Sesso, contribuente.CodiceFiscale, contribuente.ComuneResidenza, contribuente.RedditoAnnuale);

                primoAvvio = true;
            }
        }
    }

    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }
        public decimal ImpostaDaVersare { get; set; }

        public Contribuente(string nome, string cognome, DateTime nascita, string cf, string sesso, string residenza, decimal reddito)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = cf;
            Sesso = sesso;
            DataNascita = nascita;
            ComuneResidenza = residenza;
            RedditoAnnuale = reddito;
        }

        public Contribuente(string nome, string cognome, DateTime nascita, string cf, string sesso, string residenza, decimal reddito, decimal impostaDaVersare)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = cf;
            Sesso = sesso;
            DataNascita = nascita;
            ComuneResidenza = residenza;
            RedditoAnnuale = reddito;
            ImpostaDaVersare = impostaDaVersare;
        }
    }
}
