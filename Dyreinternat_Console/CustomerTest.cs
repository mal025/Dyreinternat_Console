using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library.Services;
using Dyreinternat_Library;

namespace Dyreinternat_Console
{
   public class CustomerTest

    {

        public CustomerService CustomerService;

        public CustomerTest(CustomerService customerService)
        {
            CustomerService = customerService;
        }
        public void CustomerTests()
        {
            Console.WriteLine("Oprettelse af kunde");
            Console.WriteLine("1. Opret dig som kunde");
            Console.WriteLine("2. Se profiler");
            Console.Write("Indtast dit valg: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateProfile();
                    break;
                case 2:
                    PrintAllProfiles();
                    break;              
                default:
                    break;
            }
        }

        public void CreateProfile()
        {
            Console.WriteLine("Du skal indtaste nogle informationer om kunden du ville oprette");
            Console.Write("Indtast Navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast email: ");
            string email = Console.ReadLine();
            Console.Write("Indtast tlf nr: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Indtast KundeID: ");
            int customerID = int.Parse(Console.ReadLine());


            Customer customer = new Customer(name, email, phoneNumber, customerID);

            CustomerService.Add(customer);

            Console.WriteLine("Oprettede følgende kunde i systemet: ");
            PrintProfile(customer);
        }

             public void PrintAllProfiles()  // Methode to print all customers
        {
            List<Customer> customers = CustomerService.GetAll();
            int i = 1;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"\nKunder {i}");
                PrintProfile(customer);
                i++;
            }
        }
        public void PrintProfile(Customer customer) // The methode that prints all the properties of customer
        {
            Console.WriteLine($"Navn: {customer.Name}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Telefon Nummer: {customer.PhoneNumber}");
            Console.WriteLine($"KundeID: {customer.CustomerID}");
           


        }

    }

    }

