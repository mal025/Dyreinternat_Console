using Dyreinternat_Library.Services;
using Dyreinternat_Library.Models;
using Dyreinternat_Library.Repo;
using Dyreinternat_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library;
using System.Reflection.Metadata;

namespace Dyreinternat_Console
{
    class ActivityTest
    {
        // This class is used to test the ActivityService functionality
        private ActivityService _activityService;

        public ActivityTest(ActivityService activityService)
        {
            _activityService = activityService;
        }

        // This method provides a menu for testing activities
        public void ActivityTests()
        {
            Console.WriteLine("Muligheder til aktiviteter");
            Console.WriteLine("1. Aktiviteter");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                // The functions available for the customer
                case 1:
                    Console.WriteLine("1. Se alle aktiviteter");
                    Console.WriteLine("2. Søg efter aktivitet via ID");
                    Console.WriteLine("3. Opret ny aktivitet");
                    Console.WriteLine("4. Rediger en aktivitet");
                    Console.WriteLine("5. Tilmeld dig en aktivitet");
                    Console.Write("Indsæt dit valg: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        
                        case 1:
                            PrintAllActivities();
                            break;
                        case 2:
                            SearchActivityByID();
                            break;
                        case 3:
                            CreateActivity();
                            break;
                        case 4:
                            EditActivity();
                            break;
                        case 5:
                            RegisterCustomerToActivity();
                            break;
                        default:
                            Console.WriteLine("Indtast venligst et gyldigt tal");
                            break;
                    }
                    break;
                // The functions available for the employee
                default:
                    Console.WriteLine("Indtast venligst et gyldigt tal!");
                    break;
            }
        }

        // This method prints all activities
        public void PrintAllActivities()
        {
            // Fetch all activities from the service and print them
            List<Activity> activities = _activityService.GetAll();
            int i = 1;
            // If there are no activities, inform the user
            foreach (Activity activity in activities)
            {
                // Print the details of each activity
                Console.WriteLine($"\nAktivitet {i}:");
                PrintActivity(activity);
                i++;
            }
        }
        // This method prints the details of a single activity
        public void PrintActivity(Activity activity)
        {
            // Print the properties of the activity
            Console.WriteLine($"Titel: {activity.Title}");
            Console.WriteLine($"Beskrivelse: {activity.Description}");
            Console.WriteLine($"Tid: {activity.DateTime}");
            Console.WriteLine($"Antal deltagere: {activity.NumberOfPerticipants}");
            Console.WriteLine($"Forfatter: {activity.Author}");
            Console.WriteLine($"Aktivitets-ID: {activity.ActivityID}");
        }

        // This method searches for an activity by its ID
        public void SearchActivityByID()
        {
            // Prompt the user for an activity ID and fetch the activity from the service
            Console.Write("Indtast aktivitets ID: ");
            int id = int.Parse(Console.ReadLine());
            Activity activity = _activityService.GetByID(id);
            // If the activity is found, print its details; otherwise, inform the user
            if (activity != null)
            {
                PrintActivity(activity);
            }
            else
            {
                Console.WriteLine("Ingen aktivitet fundet med det ID.");
            }
        }
        // This method creates a new activity based on user input
        public void CreateActivity()
        {
            // Prompt the user for activity details and create a new Activity object
            Console.Write("Titel: ");
            string title = Console.ReadLine();

            Console.Write("Beskrivelse: ");
            string description = Console.ReadLine();

            Console.Write("Dato og tid (yyyy-mm-dd hh:mm): ");
            DateTime datetime = DateTime.Parse(Console.ReadLine());

            Console.Write("Antal deltagere: ");
            int participants = int.Parse(Console.ReadLine());

            Console.Write("Forfatter: ");
            string author = Console.ReadLine();

            Console.Write("Aktivitets-ID: ");
            int activityID = int.Parse(Console.ReadLine());

            Activity newActivity = new Activity(title, description, datetime, participants, author, activityID);
            _activityService.Add(newActivity);

            Console.WriteLine("Aktivitet oprettet!");
        }
        // This method allows the user to edit an existing activity
        public void EditActivity()
        {
            // Fetch all activities and prompt the user to select one for editing
            List<Activity> activities = _activityService.GetAll();

            // If there are no activities, inform the user
            Console.WriteLine("Eksisterende aktiviteter:");
            foreach (Activity a in activities)
            {
                Console.WriteLine($"ID: {a.ActivityID} | Titel: {a.Title}");
            }
            // If no activities are available, exit the method
            Console.Write("\nIndtast ID på aktiviteten du ønsker at redigere: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldigt ID format.");
                return;
            }
            // Find the activity with the specified ID
            Activity activity = activities.FirstOrDefault(a => a.ActivityID == id);
            // If the activity is not found, inform the user and exit the method
            if (activity == null)
            {
                Console.WriteLine("Ingen aktivitet fundet med det ID.");
                return;
            }
            // If the activity is found, print its details and prompt the user for changes
            Console.WriteLine("\nNu redigeres aktiviteten. Tryk Enter hvis du ikke ønsker at ændre et felt.");

            // Prompt the user for new values for each property of the activity
            Console.Write($"Ny titel ({activity.Title}): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
                activity.Title = newTitle;

            Console.Write($"Ny beskrivelse ({activity.Description}): ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
                activity.Description = newDescription;

            Console.Write($"Ny forfatter ({activity.Author}): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor))
                activity.Author = newAuthor;

            Console.Write($"Ny dato (nu: {activity.DateTime:yyyy-MM-dd HH:mm}): ");
            string newDate = Console.ReadLine();
            if (DateTime.TryParse(newDate, out DateTime parsedDate))
                activity.DateTime = parsedDate;

            Console.Write($"Nyt antal af deltager ({activity.NumberOfPerticipants}): ");
            string NumberOfPerticipants = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(NumberOfPerticipants))
                activity.Author = NumberOfPerticipants;

            Console.Write($"Nyt aktivitets ID ({activity.ActivityID}): ");
            string newActivityID = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newActivityID))
                activity.Author = newActivityID;


            // Update the activity in the service and print the updated details
            _activityService.UpdateActivity(activity);
            Console.WriteLine("\nAktiviteten er blevet opdateret:");
            PrintActivity(activity);
        }
        // This method allows a customer to register for an activity
        public void RegisterCustomerToActivity()
        {
            // Prompt the user for customer ID and activity ID to register for the activity
            Console.Write("Indtast KundeID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Ugyldigt kunde-ID.");
                return;
            }
            // Prompt the user for the activity ID they want to register for
            Console.Write("Indtast Aktivitetens ID: ");
            if (!int.TryParse(Console.ReadLine(), out int activityId))
            {
                Console.WriteLine("Ugyldigt aktivitet-ID.");
                return;
            }
            // Attempt to register the customer for the activity using the service
            bool success = _activityService.RegisterCustomerToActivity(activityId, customerId);
            if (success)
                Console.WriteLine("Du er nu tilmeldt aktiviteten.");
            else
                Console.WriteLine("Tilmelding mislykkedes.");
        }
    }
}
