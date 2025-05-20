using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library.Models;
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
                            printAllAnimals();
                            break;
                        case 2:
                            searchAnimal();
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
                            printAllAnimals();
                            break;
                        case 2:
                            searchAnimal();
                            break;
                        case 3:
                            createAnimal();
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

        public void searchAnimal() // Methode to search an animal from the chipnumber 
        {
            Console.WriteLine("For at søge efter et dyr skal du bruge chipnummeret");
            Console.Write("Indsæt venligst dyrets chipnummer: ");
            int chipNum = int.Parse(Console.ReadLine());
            Animal animal = AnimalService.GetByID(chipNum);
            if (animal != null)  // Checks if there is an animal
            {
                printAnimal(animal);
            }
            else
            {
                Console.WriteLine("Der blev ikke fundet noget dyr med dette chipnummer");
            }

        }

        public void createAnimal() // Methode to insert all information on an animal and create it
        {
            Console.WriteLine("Du skal indtaste nogle informationer om dyret du ville oprette");
            Console.Write("Indtast navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast race: ");
            string race = Console.ReadLine();
            Console.Write("Indtast art: ");
            string species = Console.ReadLine();
            Console.Write("Indtast chipnummer (heltal): ");
            int chipNumber = int.Parse(Console.ReadLine());
            Console.Write("Indtast kendetegn: ");
            string characteristics = Console.ReadLine();
            Console.Write("Indtast størrelse: ");
            string size = Console.ReadLine();
            Console.Write("Indtast fødselsår (heltal): ");
            int birthYear = int.Parse(Console.ReadLine());
            Console.Write("Indtast medicinsk historik: ");
            string medicalHistory = Console.ReadLine();
            Console.Write("Indtast besøgslog: ");
            string visitorLog = Console.ReadLine();
            Animal animal = new Animal(name, race, species, chipNumber, characteristics, size, birthYear, medicalHistory, visitorLog);

            AnimalService.Add(animal);

            Console.WriteLine("Opretede følgende dyr i systemet: ");
            printAnimal(animal);
        }

        public void printAllAnimals()  // Methode to print all animals
        {
            List<Animal> animals = AnimalService.GetAll();
            int i = 1;
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"\nDyr {i}");
                printAnimal(animal);
                i++;
            }
        }
        public void printAnimal(Animal animal) // The methode that prints all the properties of the animal
        {
                Console.WriteLine($"Navn: {animal.Name}");
                Console.WriteLine($"Race: {animal.Race}");
                Console.WriteLine($"Art: {animal.Species}");
                Console.WriteLine($"ChipNummer: {animal.ChipNumber}");
                Console.WriteLine($"Kendetegn: {animal.Characteristics}");
                Console.WriteLine($"Størelse: {animal.Size}");
                Console.WriteLine($"Fødsels år: {animal.BirthYear}");
                Console.WriteLine($"Medicinsk Historie: {animal.MedicalHistory}");
                Console.WriteLine($"Besøgslog: {animal.VisitorLog}");
        }
    }
}
