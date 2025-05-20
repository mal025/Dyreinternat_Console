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
    public class BookingTest
    {
        public BookingService BookingService;

        public BookingTest(BookingService newBookingService)
        {
            BookingService = newBookingService;
        }
        public void TestBooking()
        {
            Console.WriteLine("Test af booking system");
            Console.WriteLine("1. Se alle bookings");
            Console.WriteLine("2. Søg efter booking via BookingID");
            Console.WriteLine("3. Opret ny booking");
            Console.Write("Indtast dit valg: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PrintAllBookings();
                    break;
                case 2:
                    SearchBooking();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

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

        public void PrintBooking(Booking booking) // Prints a specific booking
        {
            Console.WriteLine($"BookingID: {booking.BookingID}");
            Console.WriteLine($"Telefonnummer: {booking.PhoneNumber}");
        }

        public void SearchBooking() // Searches for a booking with an ID
        {
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
