using Dyreinternat_Library.Models;
using Dyreinternat_Library.Services;
using Dyreinternat_Library.Repo;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Dyreinternat_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalService animalService = new AnimalService(new AnimalJsonRepo(@"..\..\..\JSON\")); // Service for animal with corrected path
            AnimalTest animalTest = new AnimalTest(animalService);


            testProgram();

            void testProgram() // Runs the test program
            {
                Console.WriteLine("Roskilde dyreinternat test program. Hvad ville du teste?");
                Console.WriteLine("1. Dyr");
                Console.WriteLine("2. Booking");
                Console.WriteLine("3. ActivityTest");
                Console.WriteLine("4. Blogs");
                Console.WriteLine("5. Ansatte");
                Console.Write("Indsæt dit valg: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        animalTest.animalTest();
                        break;
                    case 2:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 3:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 4:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 5:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    default:
                        Console.WriteLine("Indtast venligst et gyldigt tal!");
                        break;
                }
                testProgram();
            }
        }
    }
}
