using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("1. Opret en blog");
            Console.WriteLine("2. Slet en blog");
            Console.WriteLine("3. Rediger en blog");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1: // The functions  available for the customer
                    Console.WriteLine("1. Du kan nu lave et nyt blog indlæg");
                    Console.WriteLine("2. Vælg den blog du gerne vil slette");
                    Console.WriteLine("3. Vælg den blog du gerne vil redigere");
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




    }
}
