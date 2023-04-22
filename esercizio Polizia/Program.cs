using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_Polizia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TipoViolazione violazione = new TipoViolazione(1, "Guida Senza patente", 3);
            TipoViolazione violazione1 = new TipoViolazione(2, "Violazione divieto di sosta", 2);
            TipoViolazione violazione2 = new TipoViolazione(3, "Eccesso di velocità", 3);
            TipoViolazione violazione3 = new TipoViolazione(4, "Guida in stato di ebbrezza", 5);
            TipoViolazione violazione4 = new TipoViolazione(5, "Uso di cellulare durante la guida", 3);
            TipoViolazione violazione5 = new TipoViolazione(6, "Guida senza cinture di sicurezza", 3);

            Veicolo veicolo = new Veicolo("AA382EO","ERREBVE", "FIAT Panda", "Autoveicolo");
            Veicolo veicolo1 = new Veicolo("GG333QQ","BBE3ER3", "Alfa Romeo Giulia", "Autoveicolo");
            Veicolo veicolo2 = new Veicolo("BE838ER","33333A", "Maserati Levante", "Autoveicolo");
            Veicolo veicolo3 = new Veicolo("FH332LP","FFFFFF", "Audi A3", "Autoveicolo");

            Verbale verbale = new Verbale(1, new DateTime(2023,04,21), "Via dell'Unità", "Napoli", "Maresciallo Mimmo", new DateTime(2023, 04, 21), 1000m, veicolo3, new List<TipoViolazione>() { violazione, violazione2 });
            Verbale verbale1 = new Verbale(2, new DateTime(2023,04,21), "Via Sant Antonio", "Milano", "Paolo Crisali", new DateTime(2023, 04, 19), 200m, veicolo, new List<TipoViolazione>() { violazione1 });
            Verbale verbale2 = new Verbale(3, new DateTime(2023,02,11), "Via Martiri", "Roma", "Federico Stoppa", new DateTime(2023, 02, 11), 5000m, veicolo2, new List<TipoViolazione>() { violazione, violazione2, violazione4, violazione5, violazione3 });
            Verbale verbale3 = new Verbale(4, new DateTime(2023,01,10), "Viale San Gerardo", "Napoli", "Maresciallo Mimmo", new DateTime(2023, 01, 10), 2000m, veicolo3, new List<TipoViolazione>() { violazione4, violazione5, violazione2 });
            Verbale verbale4 = new Verbale(5, new DateTime(2023,02,8), "Viale Monte", "Roma", "Pietro Somma", new DateTime(2023, 02, 8), 500m, veicolo1, new List<TipoViolazione>() { violazione2 });

            Trasgressore trasgressore = new Trasgressore(1, "Lorenzo", "Pagani", "Via Laggiu", "Napoli", 100234, "LRPG", new List<Verbale>() { verbale, verbale3 });
            Trasgressore trasgressore1 = new Trasgressore(2, "Giancarlo", "Monti", "Via DaQui", "Milano", 100234, "GCMN", new List<Verbale>() { verbale1 });
            Trasgressore trasgressore2 = new Trasgressore(3, "Karim", "Musa", "Via Loreto", "Roma", 100234, "KMMU", new List<Verbale>() { verbale4 });
            Trasgressore trasgressore3 = new Trasgressore(4, "Mario", "Rossi", "Via Carafa", "Bologna", 100234, "MRRS", new List<Verbale>() { verbale2 });

            DatabasePolizia.listaTrasgressori.Add(trasgressore);
            DatabasePolizia.listaTrasgressori.Add(trasgressore1);
            DatabasePolizia.listaTrasgressori.Add(trasgressore2);
            DatabasePolizia.listaTrasgressori.Add(trasgressore3);

            DatabasePolizia db = new DatabasePolizia();
            db.Menu();
        }
    }
}
