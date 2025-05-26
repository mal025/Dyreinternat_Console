using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyreinternat_Library;
using Dyreinternat_Library.Models;
using Dyreinternat_Library.Services;

namespace Dyreinternat_Console
{
    public class BlogTest
    {
        // This class is used to test the BlogService functionality
        public BlogService BlogService;
        // It contains methods to interact with the user and perform operations on blogs
        public BlogTest(BlogService blogService)
        {
            BlogService = blogService;
        }

        public void BlogTests() // Test for all blogs
        {
            // The functions  available for the customer
            Console.WriteLine("1. Se alle blogs");
            Console.WriteLine("2. Lav et nyt blog indlæg");
            Console.WriteLine("3. Redigere en blog");                  
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                // The switch statement determines the available options based on the user's choice
                case 1:
                    PrintAllBlogs();
                    break;                  
                case 2:
                    CreateBlog();
                    break;
                case 3:
                    EditBlog();
                    break;
                default:
                    Console.WriteLine("Indtast venligst et gyldigt tal");
                    break;
            }
        }
        public void PrintAllBlogs()  // Methode to print all blogs
        {
            List<Blog> blogs = BlogService.GetAll();
            int i = 1;
            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"\nBlogs {i}");
                PrintBlog(blog);
                i++;
            }
        }

        // This method prints the properties of a single blog
        public void PrintBlog(Blog blog) // The methode that prints all the properties of the blogs
        {
            Console.WriteLine($"Titel: {blog.Title}");
            Console.WriteLine($"Beskrivelse: {blog.Description}");
            Console.WriteLine($"Tid: {blog.DateTime}");
            Console.WriteLine($"Forfatter: {blog.Author}");
            Console.WriteLine($"BlogID: {blog.BlogID}");
          
           
        }
        // This method creates a new blog by prompting the user for input and adding it to the BlogService
        public void CreateBlog() // Methode to insert all information to a blog and create it
        {
            Console.WriteLine("Du skal indtaste nogle informationer om bloggen du ville oprette");
            Console.Write("Indtast titel: ");
            string title = Console.ReadLine();
            Console.Write("Indtast beskrivelse: ");
            string description = Console.ReadLine();
            Console.Write("Dato og tid (yyyy-mm-dd hh:mm): ");
            DateTime datetime = DateTime.Parse(Console.ReadLine());
            Console.Write("Indtast forfatter: ");         
            string author = Console.ReadLine();
            Console.Write("Indtast blogID: ");
            int blogID = int.Parse(Console.ReadLine());
            Console.Write("Indsæt billede: ");
            string image = Console.ReadLine();
            Blog blog = new Blog(title, description, datetime, image, author, blogID);

            BlogService.Add(blog);

            Console.WriteLine("Oprettede følgende blog i systemet: ");
            PrintBlog(blog);
        }
        // This method allows the user to edit an existing blog by selecting it from a list and updating its properties
        public void EditBlog()
        {
            List<Blog> blogs = BlogService.GetAll();
            // Display existing blogs to the user
            Console.WriteLine("Eksisterende blogs:");
            foreach (Blog b in blogs)
            {
                Console.WriteLine($"ID: {b.BlogID} | Titel: {b.Title}");
            }
            // Prompt the user to enter the ID of the blog they want to edit
            Console.Write("\nIndtast ID på bloggen du ønsker at redigere: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldigt ID format.");
                return;
            }
            // Find the blog with the specified ID
            Blog blog = blogs.FirstOrDefault(b => b.BlogID == id);

            if (blog == null)
            {
                Console.WriteLine("Ingen blog fundet med det ID.");
                return;
            }
            // Display the current details of the blog to the user
            Console.WriteLine("\nNu redigeres bloggen. Tryk Enter hvis du ikke ønsker at ændre et felt.");
            // Prompt the user for new values for each property of the blog
            Console.Write($"Ny titel ({blog.Title}): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
                blog.Title = newTitle;

            Console.Write($"Ny beskrivelse ({blog.Description}): ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
                blog.Description = newDescription;

            Console.Write($"Ny forfatter ({blog.Author}): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor))
                blog.Author = newAuthor;

            Console.Write($"Ny dato (nu: {blog.DateTime:yyyy-MM-dd HH:mm}): ");
            string newDate = Console.ReadLine();
            if (DateTime.TryParse(newDate, out DateTime parsedDate))
                blog.DateTime = parsedDate;

            Console.Write($"Nyt billede ({blog.Image}): ");
            string newImage = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newImage))
                blog.Image = newImage;
            // Update the blog in the BlogService with the new values
            BlogService.Update(blog); 
            Console.WriteLine("\nBloggen er blevet opdateret:");
            PrintBlog(blog);
        }

    }
}
