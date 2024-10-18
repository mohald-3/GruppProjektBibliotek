using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace GruppProjektBibliotek
{
    public class Bibliotek
    {
        private List<Bok> Böcker;  // en lista som lagrar böcker 

        public Bibliotek()   // konstarktor
        {
            Böcker = new List<Bok>();

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
    }
    }
