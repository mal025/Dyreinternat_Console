using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library.Services;

namespace Dyreinternat_Console
{
    public class AnimalTest
    {

        public AnimalService AnimalService;

        public AnimalTest(AnimalService animalService)
        {
            AnimalService = animalService;
        }

        public void animalTest() // Test for all animals
        {
            Console.WriteLine("Test af dyr");
            Console.WriteLine("Hvilken rolle har du?");
            Console.WriteLine("1. Kunde");
            Console.WriteLine("2. Medarbejder");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: // The functions  available for the customer
                    Console.WriteLine("Du er kunde og har disse muligheder");
                    Console.WriteLine("1. Se alle dyr");
                    Console.WriteLine("2. Søg efter dyr ud fra chipnummer");
                    Console.Write("Indsæt dit valg: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Se alle dyr");
                            break;
                        case 2:
                            Console.WriteLine("Søg dyr");
                            break;
                        default:
                            Console.WriteLine("Indtast venligst et gyldigt tal");
                            break;
                    }
                    break;
                case 2: // The functions available for the employee
                    Console.WriteLine("Du er ansat og har disse muligheder");
                    Console.WriteLine("1. Se alle dyr");
                    Console.WriteLine("2. Søg efter dyr ud fra chipnummer");
                    Console.WriteLine("3. Lav et nyt dyr");
                    Console.Write("Indsæt dit valg: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Se alle dyr");
                            break;
                        case 2:
                            Console.WriteLine("Søg dyr");
                            break;
                        default:
                            Console.WriteLine("Indtast venligst et gyldigt tal");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Indtast venligst et gyldigt tal!");
                    break;
            }
        }
    }
}
