using System;
using System.Collections.Generic;

namespace Bibliotekshantering
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotek bibliotek = new Bibliotek();
            bool kör = true;

            while (kör)
            {
                Console.WriteLine("\n--- Bibliotekshanteringssystem ---");
                Console.WriteLine("1. Lägg till en ny bok");
                Console.WriteLine("2. Ta bort en bok enligt titel");
                Console.WriteLine("3. Sök efter en bok enligt författare");
                Console.WriteLine("4. Visa alla böcker");
                Console.WriteLine("5. Checka ut/Returnera en bok");
                Console.WriteLine("6. Avsluta");
                Console.Write("Välj ett alternativ: ");

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        LäggTillBok(bibliotek);
                        break;
                    case "2":
                        TaBortBok(bibliotek);
                        break;
                    case "3":
                        SökEfterBok(bibliotek);
                        break;
                    case "4":
                        bibliotek.VisaAllaBöcker();
                        break;
                    case "5":
                        HanteraUtlåning(bibliotek);
                        break;
                    case "6":
                        kör = false;
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        static void LäggTillBok(Bibliotek bibliotek)
        {
            Console.Write("Ange titel: ");
            string titel = Console.ReadLine();
            Console.Write("Ange författare: ");
            string författare = Console.ReadLine();
            Console.Write("Ange ISBN: ");
            string isbn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(författare) || string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Alla fält måste fyllas i. Försök igen.");
                return;
            }

            Bok nyBok = new Bok(titel, författare, isbn);
            bibliotek.LäggTillBok(nyBok);
        }

        static void TaBortBok(Bibliotek bibliotek)
        {
            Console.Write("Ange titel på boken du vill ta bort: ");
            string titel = Console.ReadLine();
            bibliotek.TaBortBok(titel);
        }

        static void SökEfterBok(Bibliotek bibliotek)
        {
            Console.Write("Ange författarens namn: ");
            string författare = Console.ReadLine();
            bibliotek.SökEfterBok(författare);
        }

        static void HanteraUtlåning(Bibliotek bibliotek)
        {
            Console.Write("Ange titel på boken du vill checka ut/returnera: ");
            string titel = Console.ReadLine();
            bibliotek.HanteraUtlåning(titel);
        }
    }

    public class Bok
    {
        public string Titel { get; set; }
        public string Författare { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; set; }

        public Bok(string titel, string författare, string isbn)
        {
            Titel = titel;
            Författare = författare;
            ISBN = isbn;
            IsCheckedOut = false;
        }
    }

    public class Bibliotek
    {
        private List<Bok> böcker;

        public Bibliotek()
        {
            böcker = new List<Bok>();
        }

        public void LäggTillBok(Bok nyBok)
        {
            böcker.Add(nyBok);
            Console.WriteLine($"Boken \"{nyBok.Titel}\" har lagts till i biblioteket.");
        }

        public void TaBortBok(string titel)
        {
            var bok = böcker.Find(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
            if (bok != null)
            {
                böcker.Remove(bok);
                Console.WriteLine($"Boken \"{titel}\" har tagits bort från biblioteket.");
            }
            else
            {
                Console.WriteLine($"Boken med titeln \"{titel}\" kunde inte hittas.");
            }
        }

        public void SökEfterBok(string författare)
        {
            var resultat = böcker.FindAll(b => b.Författare.Equals(författare, StringComparison.OrdinalIgnoreCase));
            if (resultat.Count > 0)
            {
                Console.WriteLine($"\nBöcker av {författare}:");
                foreach (var bok in resultat)
                {
                    Console.WriteLine($"- \"{bok.Titel}\" (ISBN: {bok.ISBN})");
                }
            }
            else
            {
                Console.WriteLine($"Inga böcker av \"{författare}\" hittades.");
            }
        }

        public void VisaAllaBöcker()
        {
            Console.WriteLine("\nBöcker i biblioteket:");
            if (böcker.Count == 0)
            {
                Console.WriteLine("Inga böcker finns i biblioteket.");
            }
            else
            {
                foreach (var bok in böcker)
                {
                    string status = bok.IsCheckedOut ? "Utlånad" : "Tillgänglig";
                    Console.WriteLine($"- \"{bok.Titel}\" av {bok.Författare} (ISBN: {bok.ISBN}, Status: {status})");
                }
            }
        }

        public void HanteraUtlåning(string titel)
        {
            var bok = böcker.Find(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
            if (bok != null)
            {
                if (bok.IsCheckedOut)
                {
                    bok.IsCheckedOut = false;
                    Console.WriteLine($"Boken \"{titel}\" har returnerats.");
                }
                else
                {
                    bok.IsCheckedOut = true;
                    Console.WriteLine($"Boken \"{titel}\" har checkats ut.");
                }
            }
            else
            {
                Console.WriteLine($"Boken med titeln \"{titel}\" kunde inte hittas.");
            }
        }
    }
}

