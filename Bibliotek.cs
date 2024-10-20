namespace GruppProjektBibliotek
{
    public class Bibliotek
    {
        private List<Bok> Böcker;  // en lista som lagrar böcker 

        public Bibliotek()   
        {
            Böcker = new List<Bok>();

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


    }
}
