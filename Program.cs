﻿using System;



namespace GruppProjektBibliotek  
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej, välkommen till grupp 2 bibliotek!");
            bool start = true;

            Bibliotek bibliotek = new Bibliotek();  

            while (start)
            {
                Console.WriteLine("Vänligen ange ditt val");

                Console.WriteLine("1. Lägg till en bok");
                Console.WriteLine("2. Radera en bok");
                Console.WriteLine("3. Sök efter en bok enligt författaren");
                Console.WriteLine("4. Visa alla böcker");
                Console.WriteLine("5. Checka ut en bok");
                Console.WriteLine("6. Returnera en bok");
                Console.WriteLine("9. Avsluta programmet");
                
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        bibliotek.LäggTillBok(bibliotek);
                        break;

                    case "2":
                        bibliotek.TakeAwayBook();
                        break;

                    case "3":
                        bibliotek.SökBokEnligtFörfattare();
                        break;

                    case "4":
                        bibliotek.VisaAllaBöcker();
                        break;

                    case "5":
                        bibliotek.CheckaUtBok();
                        break;

                    case "6":
                        bibliotek.ReturneraBok();
                        break;

                    case "9":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Fel inmatning, försök igen");
                        break;


                }
            }
        }

    }
}




