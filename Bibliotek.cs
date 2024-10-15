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
    }
}
