using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library.Services;
using Dyreinternat_Library;

namespace Dyreinternat_Console
{
    // This class is used to test the CustomerService functionality
    public class CustomerTest

    {
        //  It contains methods to interact with the user and perform operations on customers
        public CustomerService CustomerService;

        // Constructor that initializes the CustomerService
        public CustomerTest(CustomerService customerService)
        {
            CustomerService = customerService;
        }
        // This method serves as the entry point for testing customer-related functionalities
        public void CustomerTests()
        {
            Console.WriteLine("Oprettelse af kunde");
            Console.WriteLine("1. Opret dig som kunde");
            Console.WriteLine("2. Se profiler");
            Console.Write("Indtast dit valg: ");
            // Read user input and validate it
            int choice = int.Parse(Console.ReadLine());
            // This switch statement determines the available options based on the user's choice
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
        // This method creates a new customer profile by prompting the user for input and adding it to the CustomerService
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

            // Create a new Customer object with the provided information
            Customer customer = new Customer(name, email, phoneNumber, customerID);
            // Add the new customer to the CustomerService
            CustomerService.Add(customer);
            // Print a confirmation message with the customer's details
            Console.WriteLine("Oprettede følgende kunde i systemet: ");
            PrintProfile(customer);
        }
        // This method prints all customer profiles in the system
        public void PrintAllProfiles()  // Methode to print all customers
        {
            // Retrieve all customers from the CustomerService and print their profiles
            List<Customer> customers = CustomerService.GetAll();
            int i = 1;
            foreach (Customer customer in customers)
            {
                // Print each customer's profile with a header indicating the customer number
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

