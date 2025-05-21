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
    public class EmployeeTest
    {
       

        public EmployeeService EmployeeService;

        public EmployeeTest(EmployeeService employee)
        {
            EmployeeService = employee;
        }
        public void TestEmployee()
        {
            Console.WriteLine("Test af employee");
            Console.WriteLine("1. Se alle employees");
            Console.WriteLine("2. Søg efter employee");
            Console.WriteLine("3. Opret ny employee");
            Console.Write("Indtast dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
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
            string[] roleNames = Enum.GetNames(typeof(Role));
            for (int i = 0; i < roleNames.Length; i++)
            {
                Console.WriteLine($"- {roleNames[i]}");
            }

            Console.Write("Indtast rolle: ");
            string roleInput = Console.ReadLine();

            Role role;
            if (!Enum.TryParse(roleInput, true, out role))
            {
                Console.WriteLine("Ugyldig rolle. Oprettelse afbrudt.");
                return;
            }



            Employee employee = new Employee(name, email, phoneNumber, employeeID, role);

            EmployeeService.Add(employee);

            Console.WriteLine("Oprettede følgende kunde i systemet: ");
            PrintEmployee(employee);
        }

        public void PrintAllEmployess()  // Methode to print all employess
        {
            List<Employee> employees = EmployeeService.GetAll();
            int i = 1;
            foreach (Employee employee in employees)
            {
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
            Employee employee = EmployeeService.GetByID(employeeID);
            if (employee != null)
            {
                PrintEmployee(employee);
            }
            else
            {
                Console.WriteLine("Der blev ikke fundet en medarbejder med dette ID");
            }
        }
    }
}
