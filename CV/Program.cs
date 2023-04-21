using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CREAZIONE OGGETTO INFORMAZIONI
            Informazioni info = new Informazioni("Mario", "Rossi", new List<string>() { "+393285555555", "+393211111111" }, new List<string>() { "info@mariorossi.com", "mariorossi@gmail.com"});

            //CREAZIONE OGGETTI STUDI
            Studi studi1 = new Studi("Programmazione", "UniPa", "Sviluppo software", new DateTime(2010, 09, 12), new DateTime(2011, 09, 12));
            Studi studi2 = new Studi("Microsoft c#", "Microsoft Center Milan", "Specializzazione sviluppo software", new DateTime(2011,09,22), new DateTime(2016,11,11));
            Studi studi3 = new Studi("Web development", "Microsoft Center Milan", "Specializzazione sviluppo siti web", new DateTime(2016,09,12), new DateTime(2018,03,15));

            //CREAZIONE OGGETTI ESPERIENZA
            Esperienza esperienza1 = new Esperienza("Libero Professionista","IT Manager", "Sviluppo software bancari di ultima generazione ", new List<string>() { "Sviluppo software gestionali", "Sviluppo software finanziari" }, new DateTime(2016, 09, 12), new DateTime(2017, 08, 11));
            Esperienza esperienza2 = new Esperienza("Libero Professionista","Docenza e formazione", "Docente e Formatore di sviluppo FullStack ", new List<string>() { "Docente", "Formatore" }, new DateTime(2012, 02, 01), new DateTime(2015, 08, 22));

            //CREAZIONE OGGETTI IMPIEGO A CUI ASSEGNO LE ESPERIENZE
            Impiego impiego1 = new Impiego(esperienza1);
            Impiego impiego2 = new Impiego(esperienza2);

            //CREAZIONE OGGETTO CV A CUI ASSEGNO GLI OGGETTI PRECEDENTEMENTE CREATI
            CV cv = new CV(info , new List<Studi>() { studi1, studi2, studi3}, new List<Impiego>() { impiego1, impiego2 });

            cv.listaCV.Add(cv);

            cv.Menu();
        }
    }
}
