using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library.Services;
using Dyreinternat_Library.Models;
using Dyreinternat_Library;

namespace Dyreinternat_Console
{
    // This class is used to test the DoctorVisitService functionality
    class DoctorVisitTest
    {
        public DoctorVisitService DoctorVisitService;
        // It contains methods to interact with the user and perform operations on doctor visits
        public DoctorVisitTest(DoctorVisitService newDoctorVisit)
        {
            DoctorVisitService = newDoctorVisit;
        }
        // This method serves as the entry point for testing doctor visit-related functionalities
        public void TestDoctorVisit()
        {
            // Display the options for testing doctor visits
            Console.WriteLine("Test af dyrlæge besøg");
            Console.WriteLine("1. Se alle dyrlæge besøg");
            Console.WriteLine("2. Søg efter dyrlæge besøg via BookingID");
            Console.WriteLine("3. Opret ny dyrlæge besøg");
            Console.Write("Indtast dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                // The switch statement determines the available options based on the user's choice
                case 1:
                    PrintAllDoctorVisits();
                    break;
                case 2:
                    SearchDoctorVisit();
                    break;
                case 3:
                    CreateDoctorVisit();
                    break;
                default:
                    break;
            }
        }


        // This method searches for a doctor visit by its BookingID and prints the details if found
        public void SearchDoctorVisit()
        {
            Console.Write("Indtast BookingID: ");
            int bookingID = int.Parse(Console.ReadLine());
            // Retrieve the doctor visit by BookingID
            DoctorVisit doctorVisit = DoctorVisitService.GetByID(bookingID);
            if (doctorVisit != null)
            {
                PrintDoctorVisit(doctorVisit);
            }
            // If no doctor visit is found with the given BookingID, print a message
            else
            {
                Console.WriteLine("Ingen dyrlæge besøg fundet med dette BookingID.");
            }
        }
        // This method creates a new doctor visit by prompting the user for input and adding it to the DoctorVisitService
        public void CreateDoctorVisit() {
            Console.Write("Indtast MedarbejderID: ");
            int createdByEmployeeID = int.Parse(Console.ReadLine());
            Console.Write("Indtast dyrID: ");
            int animalID = int.Parse(Console.ReadLine());
            Console.Write("Indtast dyrlæge besøgs dato (yyyy-mm-dd): ");
            DateTime datetime = DateTime.Parse(Console.ReadLine());
            Console.Write("Indtast dyrlæge besøgs beskrivelse: ");
            string description = Console.ReadLine();
            DoctorVisit newDoctorVisit = new DoctorVisit(datetime, description, animalID, createdByEmployeeID);
            DoctorVisitService.Add(newDoctorVisit);
            Console.WriteLine("Dyrlæge besøg oprettet.");
        }
        // This method prints all doctor visits in the system
        public void PrintAllDoctorVisits()
        {
            List<DoctorVisit> doctorVisits = DoctorVisitService.GetAll();
            int i = 1;
            // Iterate through the list of doctor visits and print each one
            foreach (DoctorVisit doctorVisit in doctorVisits)
            {
                Console.WriteLine($"\nDyrlæge besøg {i}");
                PrintDoctorVisit(doctorVisit);
                i++;
            }
        }
        // This method prints the properties of a single doctor visit
        public void PrintDoctorVisit(DoctorVisit doctorVisit)
        {
            Console.WriteLine($"MedarbejderID: {doctorVisit.CreatedByEmployeeID}");
            Console.WriteLine($"Dyrlæge besøgs dato: {doctorVisit.Datetime}");
            Console.WriteLine($"Dyrlæge besøgs beskrivelse: {doctorVisit.Description}");
        }
    }
}
