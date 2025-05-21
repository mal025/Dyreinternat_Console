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
    class DoctorVisitTest
    {
        public DoctorVisitService DoctorVisitService;

        public DoctorVisitTest(DoctorVisitService newDoctorVisit)
        {
            DoctorVisitService = newDoctorVisit;
        }

        public void TestDoctorVisit()
        {
            Console.WriteLine("Test af dyrlæge besøg");
            Console.WriteLine("1. Se alle dyrlæge besøg");
            Console.WriteLine("2. Søg efter dyrlæge besøg via BookingID");
            Console.WriteLine("3. Opret ny dyrlæge besøg");
            Console.Write("Indtast dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
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



        public void SearchDoctorVisit()
        {
            Console.Write("Indtast BookingID: ");
            int bookingID = int.Parse(Console.ReadLine());
            DoctorVisit doctorVisit = DoctorVisitService.GetByID(bookingID);
            if (doctorVisit != null)
            {
                PrintDoctorVisit(doctorVisit);
            }
            else
            {
                Console.WriteLine("Ingen dyrlæge besøg fundet med dette BookingID.");
            }
        }

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
        public void PrintAllDoctorVisits()
        {
            List<DoctorVisit> doctorVisits = DoctorVisitService.GetAll();
            int i = 1;
            foreach (DoctorVisit doctorVisit in doctorVisits)
            {
                Console.WriteLine($"\nDyrlæge besøg {i}");
                PrintDoctorVisit(doctorVisit);
                i++;
            }
        }

        public void PrintDoctorVisit(DoctorVisit doctorVisit)
        {
            Console.WriteLine($"MedarbejderID: {doctorVisit.CreatedByEmployeeID}");
            Console.WriteLine($"Dyrlæge besøgs dato: {doctorVisit.Datetime}");
            Console.WriteLine($"Dyrlæge besøgs beskrivelse: {doctorVisit.Description}");
        }
    }
}
