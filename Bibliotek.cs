
﻿using System;
using System.Collections.Generic;

namespace GruppProjektBibliotek
{
    public class Bibliotek
    {
        private List<Bok> Böcker;  // en lista som lagrar böcker 

        public Bibliotek()   
        {
            Böcker = new List<Bok>();
        }

        public void SökBokEnligtFörfattare()
        {
            string söktFörfattare;
            // säkrar att inmatningen är inte töm
            do
            {
                Console.WriteLine("Vänligen ange författarens namn");
                söktFörfattare = Console.ReadLine()!;

                if (string.IsNullOrEmpty(söktFörfattare))
                {
                    Console.WriteLine("Inmatning får inte vara töm");
                }
            }
            while (string.IsNullOrEmpty(söktFörfattare));

            bool sökträff = false;

            foreach (Bok bok in Böcker)
            {
                if (bok.BokFörfattare == söktFörfattare)
                {
                    Console.WriteLine("Boken hittades:");
                    Console.WriteLine($"Titel: {bok.BokTitel}, Författare {bok.BokFörfattare}, ISBN {bok.ISBN}");
                    sökträff = true;
                }
            }

            if (sökträff == false)
            {
                Console.WriteLine($"Ingen författare med namnet {söktFörfattare} kunde hittas.");
            }
        }

        public void CheckaUtBok()
        {
            Console.WriteLine("Ange titeln på boken du vill checka ut:");
            string söktTitel = Console.ReadLine()!;

            // Använd en foreach-loop för att söka efter boken
            Bok? bokAttCheckaUt = null;

            foreach (Bok bok in Böcker)
            {
                if (bok.BokTitel == söktTitel && !bok.IsCheckedOut)
                {
                    bokAttCheckaUt = bok;
                    break; // Avbryt loopen så fort vi hittar boken
                }
            }

            if (bokAttCheckaUt != null)
            {
                // Markera boken som utlånad
                bokAttCheckaUt.IsCheckedOut = true;
                Console.WriteLine($"Boken '{bokAttCheckaUt.BokTitel}' har checkats ut.");
            }
            else
            {
                Console.WriteLine($"Boken '{söktTitel}' finns inte tillgänglig eller är redan utlånad.");
            }
        }



        public void ReturneraBok()
        {
            Console.WriteLine("Ange titeln på boken du vill returnera:");
            string söktTitel = Console.ReadLine()!;

            // Använd en foreach-loop för att söka efter boken
            Bok? bokAttReturnera = null;

            foreach (Bok bok in Böcker)
            {
                if (bok.BokTitel == söktTitel && bok.IsCheckedOut)
                {
                    bokAttReturnera = bok;
                    break; // Avbryt loopen så fort vi hittar boken
                }
            }

            if (bokAttReturnera != null)
            {
                // Markera boken som återlämnad
                bokAttReturnera.IsCheckedOut = false;
                Console.WriteLine($"Boken '{bokAttReturnera.BokTitel}' har returnerats.");
            }
            else
            {
                Console.WriteLine($"Boken '{söktTitel}' finns inte i systemet eller är redan returnerad.");
            }
        }


        public void TakeAwayBook()
        {
            Console.Write("Skriv titeln på boken du vill radera: ");
            string titel = Console.ReadLine()!;

            var bok = Böcker.Find(b => b.BokTitel.Equals(titel, StringComparison.OrdinalIgnoreCase));

            if (bok == null)
            {
                Console.WriteLine($"Boken \"{titel}\" kunde tyvärr inte hittas.");
                return;
            }

            Böcker.Remove(bok);
            Console.WriteLine($"Boken \"{titel}\" har tagits bort från biblioteket.");
        }

        //Metode för att lägga till en ny bok.
        public void LäggTillBok(Bok nyBok)
        {
            Böcker.Add(nyBok);
            Console.WriteLine($"Boken med titel \"{nyBok.BokTitel}\" har lagts till biblioteket.");
        }
        // Metod för att lägga till en ny bok med tre steg samt felhantering vid inmatningen.

        public void LäggTillBok(Bibliotek bibliotek)
        {
            Console.Write("Vänligen ange bokens titel:");
            string boktitel = Console.ReadLine();
            Console.Write("Vänligen ange författarens namn: ");
            string bokförfatre = Console.ReadLine();
            Console.Write("Vänligen ange ISBN: ");
            string isbnInput = Console.ReadLine();
            int isbn;


            if (string.IsNullOrWhiteSpace(boktitel) || string.IsNullOrWhiteSpace(bokförfatre) || !int.TryParse(isbnInput, out isbn))
            {
                Console.WriteLine("Vänligen fyll alla fält tack. Försök igen.");
                return;
            }

            Bok nyBok = new Bok(boktitel, bokförfatre, isbn);
            bibliotek.LäggTillBok(nyBok);

        }

        public void VisaAllaBöcker()
        {
            // Kontrollera om det finns några böcker i biblioteket
            if (Böcker == null || Böcker.Count == 0)
            {
                Console.WriteLine("Inga böcker finns i biblioteket.");
                return;
            }

            Console.WriteLine("\nBöcker i biblioteket:");

            // Loopar igenom alla böcker och visar information
            foreach (var bok in Böcker)
            {
                // Validera att bokens uppgifter inte är tomma
                if (string.IsNullOrWhiteSpace(bok.BokTitel) ||
                    string.IsNullOrWhiteSpace(bok.BokFörfattare) ||
                    bok.ISBN <= 0)  // Kontrollera att ISBN är ett positivt heltal
                {
                    Console.WriteLine("Ogiltig bokinformation. Boken saknar titel, författare eller har ogiltigt ISBN.");
                    continue; // Hoppar över boken om den saknar nödvändig information
                }

                string status = bok.IsCheckedOut ? "Utlånad" : "Tillgänglig";
                Console.WriteLine($"- \"{bok.BokTitel}\" av {bok.BokFörfattare} (ISBN: {bok.ISBN}, Status: {status})");
            }
        }
    }
}