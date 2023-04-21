using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_5_login
{
    public class Utente
    {
        public string Username { get; set; }
        public static string username { get; set; }
        public string Password { get; set; }
        public static string password { get; set; }

        public static DateTime oraAccesso;


        public static List<Utente> listaUtenti = new List<Utente>();
        public static List<Login> listaLogin = new List<Login>();

        static bool autenticato = false;

        Utente(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static void Menu()
        {
            Console.Clear();

            Utente u = new Utente("Davide", "1234");
            Utente u1 = new Utente("Marco", "1234");
            Utente u2 = new Utente("Francesco", "1234");
            Utente u3 = new Utente("Mario", "1234");

            listaUtenti.Add(u);
            listaUtenti.Add(u1);
            listaUtenti.Add(u2);
            listaUtenti.Add(u3);

            if (!autenticato)
            {
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Esci");
            }
            else
            {
                Console.WriteLine($"Hai effettuato l'accesso come: {username}\n");

                Console.WriteLine("1) Logout");
                Console.WriteLine("2) Visualizza ora e data login");
                Console.WriteLine("3) Lista accessi");
                Console.WriteLine("4) Esci");
            }

            Console.Write("\n\nInserisci numero operazione: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                if (!autenticato)
                    Login();
                else
                    Logout();
            }
            else if (op == 2)
            {
                if (autenticato)
                    VisualizzaOra();
            }
            else if (op == 3)
            {
                if (autenticato)
                    ListaAccessi();
            }
            else
            {
                
            }
        }

        private static void Login()
        {
            Console.Clear();

            Console.WriteLine("\t\tACCESSO UTENTE\n");

            Console.Write("Inserisci username: ");
            username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            password = Console.ReadLine();

            Console.Write("Conferma la password: ");
            string conferma = Console.ReadLine();

            foreach (Utente user in listaUtenti)
            {
                if(user.Username == username && user.Password == password && user.Password == conferma)
                {
                    Console.WriteLine("Login effettuato con successo");
                    autenticato = true;

                    Login log = new Login(DateTime.Now, username);
                    oraAccesso = DateTime.Now;
                    listaLogin.Add(log);

                    Menu();
                }
            }

            if (!autenticato)
            {
                Console.Clear();
                Console.WriteLine("ATTENZIONE CREDENZIALI NON VALIDE \n");

                Console.WriteLine("Vuoi tornare al menu?");

                Console.WriteLine("1) si");

                Console.Write("Inserisci: ");
                int op = Convert.ToInt16(Console.ReadLine());

                if (op == 1)
                {
                    Console.Clear();
                    Menu();
                }
            }
        }
        
        private static void Logout()
        {
            Console.Clear();
            Console.WriteLine("Sei sicuro di voler effettuare il logout?");

            Console.WriteLine("1) si");
            Console.WriteLine("2) no");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                username = null;
                password = null;
                autenticato = false;
                Menu();
            }
            else
            {
                Console.Clear();
                Menu();
            }
            Console.ReadLine();
        }

        private static void ListaAccessi()
        {
            Console.Clear();
            Console.WriteLine($"Hai effettuato l'accesso come: {username}");

            foreach (Login login in listaLogin)
            {
                if(login.Username == username)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine($"\n Data Accesso: {login.Data}\n ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------\n");
                }
            }

            Console.WriteLine("Vuoi tornare al menu?");

            Console.WriteLine("1) si");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                Menu();
            }
        }

        private static void VisualizzaOra()
        {
            Console.Clear();

            Console.WriteLine($" Hai effettuato il login come {username}\n alle: {oraAccesso}\n\n");

            Console.WriteLine("Vuoi tornare al menu?");

            Console.WriteLine("1) si");

            Console.Write("Inserisci: ");
            int op = Convert.ToInt16(Console.ReadLine());

            if (op == 1)
            {
                Console.Clear();
                Menu();
            }
        }

    }

    public class Login
    {
        public DateTime Data { get; set; }
        public string Username { get; set; }

        public Login(DateTime data, string username)
        {
            Data = data;
            Username = username;
        }
    }
}
