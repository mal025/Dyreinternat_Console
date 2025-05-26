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

        public BlogService BlogService;

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

        public void PrintBlog(Blog blog) // The methode that prints all the properties of the blogs
        {
            Console.WriteLine($"Titel: {blog.Title}");
            Console.WriteLine($"Beskrivelse: {blog.Description}");
            Console.WriteLine($"Tid: {blog.DateTime}");
            Console.WriteLine($"Forfatter: {blog.Author}");
            Console.WriteLine($"BlogID: {blog.BlogID}");
          
           
        }

        public void CreateBlog() // Methode to insert all information to a blog and create it
        {
            Console.WriteLine("Du skal indtaste nogle informationer om bloggen du ville oprette");
            Console.Write("Indtast titel: ");
            string title = Console.ReadLine();
            Console.Write("Indtast beskrivelse: ");
            string description = Console.ReadLine();
            Console.Write("Indtast tid: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Indtast forfatter: ");         
            string author = Console.ReadLine();
            Console.Write("Indtast blogID: ");
            int blogID = int.Parse(Console.ReadLine());
            Console.Write("Indsæt billede: ");
            string image = Console.ReadLine();
            Blog blog = new Blog(title, description, dateTime, image, author, blogID);

            BlogService.Add(blog);

            Console.WriteLine("Oprettede følgende blog i systemet: ");
            PrintBlog(blog);
        }
        public void EditBlog()
        {
            List<Blog> blogs = BlogService.GetAll();

            Console.WriteLine("Eksisterende blogs:");
            foreach (Blog b in blogs)
            {
                Console.WriteLine($"ID: {b.BlogID} | Titel: {b.Title}");
            }

            Console.Write("\nIndtast ID på bloggen du ønsker at redigere: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldigt ID format.");
                return;
            }

            Blog blog = blogs.FirstOrDefault(b => b.BlogID == id);

            if (blog == null)
            {
                Console.WriteLine("Ingen blog fundet med det ID.");
                return;
            }

            Console.WriteLine("\nNu redigeres bloggen. Tryk Enter hvis du ikke ønsker at ændre et felt.");

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

            BlogService.Update(blog); 
            Console.WriteLine("\nBloggen er blevet opdateret:");
            PrintBlog(blog);
        }

    }
}
