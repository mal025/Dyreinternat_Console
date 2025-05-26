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

            BookingService bookingSerice = new BookingService(new BookingJsonRepo(@"..\..\..\JSON\")); // Service for booking with corrected path
            BookingTest bookingTest = new BookingTest(bookingSerice);

            ActivityService activityService = new ActivityService(new ActivityJsonRepo(@"..\..\..\JSON\")); // Service for activity with corrected path
            ActivityTest activityTest = new ActivityTest(activityService);

            BlogService blogService = new BlogService(new BlogJsonRepo(@"..\..\..\JSON\")); // Service for blog with corrected path
            BlogTest blogTest = new BlogTest(blogService);

            CustomerService customerService = new CustomerService(new CustomerJsonRepo(@"..\..\..\JSON\")); // Service for customer with corrected path
            CustomerTest customerTest = new CustomerTest(customerService);

            DoctorVisitService doctorVisitService = new DoctorVisitService(new DoctorVisitJsonRepo(@"..\..\..\JSON\")); // Service for doctor visit with corrected path
            DoctorVisitTest doctorVisitTest = new DoctorVisitTest(doctorVisitService);

            EmployeeService employeeService = new EmployeeService(new EmployeeJsonRepo(@"..\..\..\JSON\")); // Service for employee with corrected path
            EmployeeTest employeeTest = new EmployeeTest(employeeService);





            testProgram();

          

            void testProgram() // Main method to run the test program
            {
                while (true)
                {
                    // Display the menu options
                    Console.WriteLine("\nRoskilde dyreinternat test program. Hvad ville du teste?");
                    Console.WriteLine("1. Dyr");
                    Console.WriteLine("2. Booking");
                    Console.WriteLine("3. ActivityTest");
                    Console.WriteLine("4. BlogTest");
                    Console.WriteLine("5. EmployeeTest");
                    Console.WriteLine("6. DoctorVisitTest");
                    Console.WriteLine("7. CustomerTest");
                    Console.WriteLine("8. Afslut programmet");
                    Console.Write("Indsæt dit valg: ");

                    // Read user input and validate it
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("Ugyldigt input. Prøv igen.");
                        continue;
                    }
                    // Check if the input is within the valid range
                    try
                    {
                        switch (choice)
                        {
                            // Handle the user's choice
                            case 1:
                                animalTest.AnimalTests();
                                break;
                            case 2:
                                bookingTest.TestBooking();
                                break;
                            case 3:
                                activityTest.ActivityTests();
                                break;
                            case 4:
                                blogTest.BlogTests();
                                break;
                            case 5:
                                employeeTest.TestEmployee();
                                break;
                            case 6:
                                doctorVisitTest.TestDoctorVisit();
                                break;
                            case 7:
                                customerTest.CustomerTests();
                                break;
                            case 8:
                                Console.WriteLine("Programmet afsluttes.");
                                return;
                            default:
                                Console.WriteLine("Indtast venligst et gyldigt valg.");
                                break;
                        }
                    }
                    // Catch any exceptions that occur during the execution of the switch statement
                    catch (Exception ex)
                    {
                        Console.WriteLine("En fejl opstod under kørsel: " + ex.Message);
                    }
                }
            }

            testProgram();

                
            }
        }
    }


