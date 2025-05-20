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
            BookingService bookingSerice = new BookingService(new BookingJsonRepo(@"..\..\..\JSON\"));
            BookingTest bookingTest = new BookingTest(bookingSerice);
            BlogService blogService = new BlogService(new BlogJsonRepo(@"..\..\..\JSON\")); // Service for blog with corrected path
            BlogTest blogTest = new BlogTest(blogService);


           

            testProgram();

            void testProgram() // Runs the test program
            {
                Console.WriteLine("Roskilde dyreinternat test program. Hvad ville du teste?");
                Console.WriteLine("1. Dyr");
                Console.WriteLine("2. Booking");
                Console.WriteLine("3. ActivityTest");
                Console.WriteLine("4. BlogTest");
                Console.WriteLine("5. EmployeeTest");
                Console.WriteLine("6. DoctorVisitTest");
                Console.WriteLine("7. CustomerTest");
                Console.Write("Indsæt dit valg: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        animalTest.AnimalTests();
                        break;
                    case 2:
                        bookingTest.TestBooking();
                        break;
                    case 3:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 4:
                        blogTest.BlogTests();
                        break;
                    case 5:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 6:
                        Console.WriteLine("Ikke lavet endnu");
                        break;
                    case 7:
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
