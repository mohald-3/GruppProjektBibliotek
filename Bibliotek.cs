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

            // Sök efter boken i listan
            Bok? bokAttCheckaUt = Böcker.FirstOrDefault(bok => bok.BokTitel == söktTitel && !bok.IsCheckedOut);

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

            // Sök efter boken i listan
            Bok? bokAttReturnera = Böcker.FirstOrDefault(bok => bok.BokTitel == söktTitel && bok.IsCheckedOut);

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
