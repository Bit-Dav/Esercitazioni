using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV
{
    public class CV
    {
        public List<CV> listaCV { get; set; } = new List<CV>();
        Informazioni InformazioniPersonali { get; set; }
        List<Studi> StudiEffettuati { get; set; } = new List<Studi>();
        List<Impiego> Impieghi { get; set; } = new List<Impiego>();
        bool altro = false;

        public CV(Informazioni info, List<Studi> studi, List<Impiego> impieghi)
        {
            InformazioniPersonali = info;
            StudiEffettuati = studi;
            Impieghi = impieghi;
        }

        private void StampaDettagliCVSuSchermo(CV cv, bool stampaSingolo)
        {
            Console.WriteLine($"CV di {cv.InformazioniPersonali.Nome} {cv.InformazioniPersonali.Cognome}\n");

            //STAMPA INFORMAZIONI PERSONALI
            Console.WriteLine("++++ INIZIO Informazioni Personali: ++++");
            Console.WriteLine($"Nome: {cv.InformazioniPersonali.Nome}\n" +
                $"Cognome: {cv.InformazioniPersonali.Cognome}");

            foreach (string email in cv.InformazioniPersonali.Email)
            {
                Console.WriteLine($"Email: {email}");
            }

            foreach (string telefono in cv.InformazioniPersonali.Telefono)
            {
                Console.WriteLine($"Telefono: {telefono}");
            }
            Console.WriteLine("++++ FINE Informazioni Personali: ++++\n\n");


            //STAMPA STUDI E FORMAZIONE
            Console.WriteLine("++++ INIZIO Studi e Formazione: ++++\n");

            if(cv.StudiEffettuati.Count == 0)
            {
                Console.WriteLine("NON CI SONO CAMPI STUDIO QUI\n");
            }
            foreach(Studi studio in cv.StudiEffettuati)
            {
                Console.WriteLine($"Istituto: {studio.Istituto}\n" +
                    $"Qualifica: {studio.Qualifica}\n" +
                    $"Tipo: {studio.Tipo}\n" +
                    $"Dal: {studio.Dal.ToShortDateString()} || al: {studio.Al.ToShortDateString()}\n");
            }
            Console.WriteLine("++++ FINE Studi e Formazione: ++++\n\n");


            //STAMPA ESPERIENZE PROFESSIONALI
            Console.WriteLine("++++ INIZIO Esperienze professionali: ++++\n");

            if (cv.StudiEffettuati.Count == 0)
            {
                Console.WriteLine("NON CI SONO CAMPI LAVORO QUI\n");
            }

            foreach (Impiego impiego in cv.Impieghi)
            {
                Console.WriteLine($"Presso: {impiego.Esperienza.Azienda}\n" +
                    $"Tipo di lavoro: {impiego.Esperienza.JobTitle}\n" +
                    $"Descrizione: {impiego.Esperienza.Descrizione}");

                foreach(string compito in impiego.Esperienza.Compiti)
                {
                    Console.WriteLine($"Compito: {compito}");
                }
                Console.WriteLine($"Dal: {impiego.Esperienza.Dal.ToShortDateString()} || al: {impiego.Esperienza.Al.ToShortDateString()}\n");

            }
            Console.WriteLine("++++ FINE Esperienze professionali: ++++");

            if (stampaSingolo)
            {
                Console.WriteLine("Vuoi tornare al menu?\n 1)si \n 2)no");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Menu();
                }
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("===== CV =====\n\n");

            Console.WriteLine("1) Compila il tuo cv\n" +
                "2) Visualizza lista cv caricati\n" +
                "3) Esci");

            Console.Write("\n\nInserisci n. operazione: ");
            int op = int.Parse( Console.ReadLine());

            if(op == 1)
            {
                CompilaCV();
            }
            else if(op == 2)
            {
                StampaListaCV();
            }
            else
            {

            }

        }

        private void CompilaCV()
        {
            //AGGIUNGI INFORMAZIONI
            #region Informazioni
            Console.Clear();
            Console.WriteLine("=====AGGIUNGI LE TUE INFO=====\n\n");
            Console.Write("Inserisci Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci Cognome: ");
            string cognome = Console.ReadLine();
            int op;
            //AGGIUNTA NUMERO DI TELEFONO
            List<string> listTelefono = new List<string>();
            do
            {
                Console.Write("Inserisci numero di telefono: ");
                string telefono = Console.ReadLine();

                listTelefono.Add(telefono);

                Console.WriteLine("Hai altri numeri di telefono da voler aggiungere? 1) si  2) no ");
                op = int.Parse( Console.ReadLine());

                if (op == 1)
                    altro = true;
                else
                    altro = false;
            } while (altro);

            //AGGIUNTA EMAIL
            List<string> listEmail = new List<string>();
            do
            {
                Console.Write("Inserisci email: ");
                string email = Console.ReadLine();

                listEmail.Add(email);

                Console.WriteLine("Hai altre email da voler aggiungere? 1) si  2) no ");
                op = int.Parse(Console.ReadLine());

                if (op == 1)
                    altro = true;
                else
                    altro = false;
            } while (altro);

            Informazioni informazioni = new Informazioni(nome, cognome, listTelefono, listEmail);
            #endregion Informazioni

            //AGGIUNGI STUDI
            #region Studi 
            Console.Clear();
            Console.WriteLine("=====AGGIUNGI I TUOI STUDI=====\n\n");
            Console.Write("Vuoi aggiungere un campo di studi? 1) si 2) no ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
                altro = true;
            else
                altro = false;

            List<Studi> listaStudi = new List<Studi>();

            if (altro)
            {
                
                do
                {
                    Console.Write("\n\nIstituto: ");
                    string istituto = Console.ReadLine();

                    Console.Write("Qualifica: ");
                    string qualifica = Console.ReadLine();

                    Console.Write("Tipo studi: ");
                    string tipo = Console.ReadLine();

                    Console.Write("Data inizio (yyyy/mm/dd): ");
                    DateTime dal = DateTime.Parse(Console.ReadLine());

                    Console.Write("Data fine (yyyy/mm/dd): ");
                    DateTime al = DateTime.Parse(Console.ReadLine());

                    Console.Write("Vuoi aggiungere un altro campo di studi? 1) si 2) no ");
                    op = int.Parse(Console.ReadLine());

                    Studi studio = new Studi(qualifica, istituto, tipo, dal, al);
                    listaStudi.Add(studio);

                    if (op == 1)
                        altro = true;
                    else
                        altro = false;

                } while (altro);
            }
            #endregion Studi

            //AGGIUNGI LAVORI
            #region Lavori
            Console.Clear();
            Console.WriteLine("=====AGGIUNGI I TUOI LAVORI=====\n\n");
            Console.Write("Vuoi aggiungere un campo di lavoro? 1) si 2) no ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
                altro = true;
            else
                altro = false;

            List<Impiego> listaLavori = new List<Impiego>();


            
            if (altro)
            {
                do
                {
                    Console.Write("\n\nAzienda: ");
                    string azienda = Console.ReadLine();

                    Console.Write("Titolo lavoro: ");
                    string jobTitle = Console.ReadLine();

                    Console.Write("Descrizione: ");
                    string desc = Console.ReadLine();

                    List<string> listaCompiti = new List<string>();
                    do
                    {
                        Console.Write("Compiti in azienda: ");
                        string compito = Console.ReadLine();

                        listaCompiti.Add(compito);

                        Console.WriteLine("Hai altri compiti da voler aggiungere? 1) si  2) no ");
                        op = int.Parse(Console.ReadLine());

                        if (op == 1)
                            altro = true;
                        else
                            altro = false;
                    } while (altro);

                    Console.Write("Data inizio (yyyy/mm/dd): ");
                    DateTime dal = DateTime.Parse(Console.ReadLine());

                    Console.Write("Data fine (yyyy/mm/dd): ");
                    DateTime al = DateTime.Parse(Console.ReadLine());

                    Console.Write("Vuoi aggiungere un altro campo di lavori? 1) si 2) no ");
                    op = int.Parse(Console.ReadLine());

                    Esperienza esperienza = new Esperienza(azienda, jobTitle, desc, listaCompiti, dal, al);
                    Impiego impiego = new Impiego(esperienza);

                    listaLavori.Add(impiego);

                    if (op == 1)
                        altro = true;
                    else
                        altro = false;

                } while (altro);
            }
            #endregion Lavori

            CV cv = new CV(informazioni, listaStudi, listaLavori);
            listaCV.Add(cv);

            Console.Clear();
            Console.WriteLine("CREAZIONE CURRICULUM COMPLETATA");

            Console.WriteLine("Vuoi visualizzare il tuo cv ora?\n 1)si \n 2)no");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                StampaDettagliCVSuSchermo(cv, true);
            }
            else if(op == 2)
            {
                Menu();
            }
        }

        private void StampaListaCV()
        {
            Console.Clear();
            Console.WriteLine("===== LISTA CV =====\n\n");
            int i = 1;
            foreach (CV cv in listaCV)
            {
                Console.WriteLine($"===================== CV {i} =====================");
                StampaDettagliCVSuSchermo(cv, false);
                Console.WriteLine("================================================\n\n");
                i++;
            }

            Console.WriteLine("Cosa vuoi fare?\n 1)Torna al menu");
            if(listaCV.Count > 0)
                Console.WriteLine(" 2) Elimina un cv");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Menu();
            }
            else if(op == 2)
            {
                if (listaCV.Count > 0)
                {
                    Console.Write("Quale cv vuoi eliminare? (inserisci numero indice curriculum): ");
                    op = int.Parse(Console.ReadLine());

                    for (i = 0; i <= listaCV.Count; i++)
                    {
                        if (op == i + 1)
                        {
                            listaCV.RemoveAt(i);
                            StampaListaCV();
                            Console.ReadLine();
                        }
                    }
                }

                Menu();
            }
        }
    }

    public class Informazioni
    {
        public string Nome { get; set; }
        public string Cognome { get; set;}
        public List<string> Telefono { get; set; } = new List<string>();
        public List<string> Email { get; set; } = new List<string>();

        public Informazioni(string _nome, string _cognome, List<string> _telefono, List<string> _email)
        {
            Nome = _nome;
            Cognome = _cognome;
            Telefono = _telefono;
            Email = _email;
        }
    }

    public class Studi
    {
        public string Qualifica { get; set; }
        public string Istituto { get; set; }
        public string Tipo { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }

        public Studi(string _qualifica, string _istituto, string _tipo, DateTime _dal, DateTime _al)
        {
            Qualifica = _qualifica;
            Istituto = _istituto;
            Tipo = _tipo;
            Dal = _dal;
            Al = _al;
        }
    }

    public class Impiego
    {
        public Esperienza Esperienza { get; set; }

        public Impiego(Esperienza _esperienza)
        {
           Esperienza = _esperienza;
        }
    }

    public class Esperienza
    {
        public string Azienda { get; set; }
        public string JobTitle { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public string Descrizione { get; set; }
        public List<string> Compiti { get; set; }

        public Esperienza(string _azienda, string _jobTitle, string _descrizione, List<string> _compiti, DateTime _dal, DateTime _al)
        {
            Azienda = _azienda;
            JobTitle = _jobTitle;
            Dal = _dal;
            Al = _al;
            Descrizione = _descrizione;
            Compiti = _compiti;
        }
    }
}
