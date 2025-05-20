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
            Console.WriteLine("Muligheder til blog");
            Console.WriteLine("1. Blog");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1: // The functions  available for the customer
                    Console.WriteLine("1. Se alle blogs");
                    Console.WriteLine("2. Søg efter en blog");
                    Console.WriteLine("3. Lav et nyt blog indlæg");
                    Console.WriteLine("4. Vælg den blog du gerne vil slette");
                    Console.WriteLine("5. Vælg den blog du gerne vil redigere");
                    Console.Write("Indsæt dit valg: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            PrintAllBlogs();
                            break;
                        case 2:
                            SearchBlog();
                            break;
                        case 3:
                            createBlog();
                            break;
                        case 4:
                            DeleteBlog();
                            break;
                        case 5:
                            EditBlog();
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

        public void printAllBlogs()  // Methode to print all blogs
        {
            List<Blog> blogs = BlogService.GetAll();
            int i = 1;
            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"\nBlogs {i}");
                printBlog(blog);
                i++;
            }
        }

        public void printBlog(Blog blog) // The methode that prints all the properties of the blogs
        {
            Console.WriteLine($"Titel: {blog.Title}");
            Console.WriteLine($"Beskrivelse: {blog.Description}");
            Console.WriteLine($"Tid: {blog.DateTime}");
            Console.WriteLine($"Forfatter: {blog.Author}");
            Console.WriteLine($"BlogID: {blog.BlogID}");
          
           
        }

    }
}
