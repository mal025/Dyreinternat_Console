using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library;
using Dyreinternat_Library.Services;
using Dyreinternat_Library.Models;
using Dyreinternat_Library.Repo;
using static Dyreinternat_Library.Employee;

namespace Dyreinternat_Console
{
    // This class is used to test the EmployeeService functionality
    public class EmployeeTest
    {

        // It contains methods to interact with the user and perform operations on employees
        public EmployeeService EmployeeService;
        // Constructor that initializes the EmployeeService
        public EmployeeTest(EmployeeService employee)
        {
            EmployeeService = employee;
        }
        // This method serves as the entry point for testing employee-related functionalities
        public void TestEmployee()
        {
            // Display the options for testing employees
            Console.WriteLine("Test af employee");
            Console.WriteLine("1. Se alle employees");
            Console.WriteLine("2. Søg efter employee");
            Console.WriteLine("3. Opret ny employee");
            Console.Write("Indtast dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                // The switch statement determines the available options based on the user's choice
                case 1:
                    PrintAllEmployess();
                    break;
                case 2:
                    SearchEmployee();
                    break;
                case 3:
                    CreateEmployee();
                    break;
                default:
                    break;
            }
        }
        // This method creates a new employee by prompting the user for input and adding it to the EmployeeService
        public void CreateEmployee()
        {
            Console.WriteLine("Du skal indtaste nogle informationer om medarbejderen du ville oprette");
            Console.Write("Indtast Navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast email: ");
            string email = Console.ReadLine();
            Console.Write("Indtast tlf nr: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Indtast medarbejderID: ");
            int employeeID = int.Parse(Console.ReadLine());
            Console.Write("Indtast rolle: ");
            Console.WriteLine("Mulige roller:");
            // Display the available roles for the employee
            string[] roleNames = Enum.GetNames(typeof(Role));
            for (int i = 0; i < roleNames.Length; i++)
            {// Loop through the roles and print them
                Console.WriteLine($"- {roleNames[i]}");
            }
            // Prompt the user to enter a role
            Console.Write("Indtast rolle: ");
            string roleInput = Console.ReadLine();
            // Try to parse the input into an enum value
            Role role;
            // If the parsing fails, inform the user and exit the method
            if (!Enum.TryParse(roleInput, true, out role))
            {
                Console.WriteLine("Ugyldig rolle. Oprettelse afbrudt.");
                return;
            }


            // Create a new Employee object with the provided information
            Employee employee = new Employee(name, email, phoneNumber, employeeID, role);
            // Add the new employee to the EmployeeService
            EmployeeService.Add(employee);
            // Print a confirmation message with the employee's details
            Console.WriteLine("Oprettede følgende kunde i systemet: ");
            PrintEmployee(employee);
        }
        // This method prints all employees in the system
        public void PrintAllEmployess()  // Methode to print all employess
        {
            // Retrieve all employees from the EmployeeService
            List<Employee> employees = EmployeeService.GetAll();
            int i = 1;// Initialize a counter for employee numbering
            foreach (Employee employee in employees)
            {
                // Print each employee's details with a number prefix
                Console.WriteLine($"\nMedarbejder{i}");
                PrintEmployee(employee);
                i++;
            }
        }
        public void PrintEmployee(Employee employee) // The methode that prints all the properties of employee
        {
            Console.WriteLine($"Navn: {employee.Name}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Telefon Nummer: {employee.PhoneNumber}");
            Console.WriteLine($"MedarbejderID: {employee.EmployeeID}");
            Console.WriteLine($"Rolle: {employee.EmployeeRole}");


        }

        public void SearchEmployee() // Searches for a booking with an ID
        {
            Console.Write("Indast medarbejderID: ");
            int employeeID = int.Parse(Console.ReadLine());
            Employee employee = EmployeeService.GetByID(employeeID);// Retrieve the employee by ID
            if (employee != null)
            {
                PrintEmployee(employee);// Print the employee's details if found
            }
            else
            {
                Console.WriteLine("Der blev ikke fundet en medarbejder med dette ID");// Print a message if no employee is found with the given ID
            }
        }
    }
}
