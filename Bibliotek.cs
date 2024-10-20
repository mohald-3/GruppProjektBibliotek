namespace GruppProjektBibliotek
{
    public class Bibliotek
    {
        private List<Bok> Böcker;  // en lista som lagrar böcker 

        public Bibliotek()   // konstarktor
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
