using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library;
using Dyreinternat_Library.Services;

namespace Dyreinternat_Console
{
    // This class is used to test the BookingService functionality
    public class BookingTest
    {
        // It contains methods to interact with the user and perform operations on bookings
        public BookingService BookingService;
        // Constructor that initializes the BookingService
        public BookingTest(BookingService newBookingService)
        {
            BookingService = newBookingService;
        }
        // This method serves as the entry point for testing booking-related functionalities
        public void TestBooking()
        {
            Console.WriteLine("Test af booking system");
            Console.WriteLine("1. Se alle bookings");
            Console.WriteLine("2. Søg efter booking via BookingID");
            Console.WriteLine("3. Opret ny booking");
            Console.Write("Indtast dit valg: ");

            int choice = int.Parse(Console.ReadLine());
            // This switch statement determines the available options based on the user's choice
            switch (choice)
            {
                case 1:
                    PrintAllBookings();
                    break;
                case 2:
                    SearchBooking();
                    break;
                case 3:
                    CreateBooking();
                    break;
                default:
                    break;
            }
        }
        // This method prints all bookings in the system
        public void PrintAllBookings() // Prints all bookings
        {
            List<Booking> bookings = BookingService.GetAll();
            int i = 1;
            foreach (Booking booking in bookings)
            {
                Console.WriteLine($"\nBooking {i}");
                PrintBooking(booking);
                i++;
            }
        }
        // This method prints the properties of a single booking
        public void PrintBooking(Booking booking) // Prints a specific booking
        {
            Console.WriteLine($"BookingID: {booking.BookingID}");
            Console.WriteLine($"Telefonnummer: {booking.PhoneNumber}");
        }
        // This method searches for a booking by its ID and prints the details if found
        public void SearchBooking() // Searches for a booking with an ID
        {
            // Prompt the user for the BookingID to search for
            Console.Write("Indast BookingID: ");
            int bookingID = int.Parse(Console.ReadLine());
            Booking booking = BookingService.GetByID(bookingID);
            if (booking != null)
            {
                PrintBooking(booking);
            }
            else
            {
                Console.WriteLine("Der blev ikke fundet en booking med dette ID");
            }
        }
        // This method creates a new booking by prompting the user for details and adding it to the system
        public void CreateBooking() // Creates a new booking
        {
            Console.WriteLine("For at oprette en booking skal du indtaste nogle informationer om booking");
            Console.Write("Indtast telefonnummer: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Indtast BookingID (heltal): ");
            int bookingID = int.Parse(Console.ReadLine());
            Booking booking = new Booking(phoneNumber, bookingID);
            BookingService.Add(booking);
            Console.WriteLine("Der er nu oprettet følgende booking i systemet:");
            PrintBooking(booking);
        }
    }
}
