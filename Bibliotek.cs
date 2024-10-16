using System;
using System.Collections.Generic;

namespace GruppProjektBibliotek
{
    public class Bibliotek
    {
        private List<Bok> Böcker;  // en lista som lagrar böcker 

        public Bibliotek()   // konstarktor
        {
            Böcker = new List<Bok>();

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

    }
}