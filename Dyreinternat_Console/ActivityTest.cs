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
        private ActivityService _activityService;

        public ActivityTest(ActivityService activityService)
        {
            _activityService = activityService;
        }

        public void ActivityTests()
        {
            Console.WriteLine("Muligheder til aktiviteter");
            Console.WriteLine("1. Aktiviteter");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("1. Se alle aktiviteter");
                    Console.WriteLine("2. Søg efter aktivitet via ID");
                    Console.WriteLine("3. Opret ny aktivitet");
                    Console.WriteLine("4. Rediger en aktivitet");
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

        public void PrintAllActivities()
        {
            List<Activity> activities = _activityService.GetAll();
            int i = 1;
            foreach (Activity activity in activities)
            {
                Console.WriteLine($"\nAktivitet {i}:");
                PrintActivity(activity);
                i++;
            }
        }

        public void PrintActivity(Activity activity)
        {
            Console.WriteLine($"Titel: {activity.Title}");
            Console.WriteLine($"Beskrivelse: {activity.Description}");
            Console.WriteLine($"Tid: {activity.DateTime}");
            Console.WriteLine($"Antal deltagere: {activity.NumberOfPerticipants}");
            Console.WriteLine($"Forfatter: {activity.Author}");
            Console.WriteLine($"Aktivitets-ID: {activity.ActivityID}");
        }

        public void SearchActivityByID()
        {
            Console.Write("Indtast aktivitets ID: ");
            int id = int.Parse(Console.ReadLine());
            Activity activity = _activityService.GetByID(id);

            if (activity != null)
            {
                PrintActivity(activity);
            }
            else
            {
                Console.WriteLine("Ingen aktivitet fundet med det ID.");
            }
        }

        public void CreateActivity()
        {
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
        public void EditActivity()
        {
            List<Activity> activities = _activityService.GetAll();

            Console.WriteLine("Eksisterende aktiviteter:");
            foreach (Activity a in activities)
            {
                Console.WriteLine($"ID: {a.ActivityID} | Titel: {a.Title}");
            }

            Console.Write("\nIndtast ID på aktiviteten du ønsker at redigere: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldigt ID format.");
                return;
            }

            Activity activity = activities.FirstOrDefault(a => a.ActivityID == id);

            if (activity == null)
            {
                Console.WriteLine("Ingen aktivitet fundet med det ID.");
                return;
            }

            Console.WriteLine("\nNu redigeres aktiviteten. Tryk Enter hvis du ikke ønsker at ændre et felt.");

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



            _activityService.UpdateActivity(activity);
            Console.WriteLine("\nAktiviteten er blevet opdateret:");
            PrintActivity(activity);
        }
    }
}
