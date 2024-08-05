using LMS2024.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLMS2024
{
    public class LMSV2024
    {
        //field(interface object)
        private readonly ILibrary _library;

        //Constructor with interface object
        public LMSV2024(ILibrary library)
        {
            _library = library;

        }

        static void Main(string[] args)
        {
            //object for LMSV2024 
            //variable = Anonymous object
            var bookApp = new LMSV2024(new Library());

            //Menu Driven
            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. List All Books");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice :");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice.Please try again...");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        //Function for adding book
                        bookApp._library.AddBook();
                        break;
                    case 2:
                        //Function for editing book
                        Console.WriteLine("Enter ISBN to Edit Book :");
                        string editIsbn = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(editIsbn))
                        {
                            Console.WriteLine("Invalid ISBN.Please try again..");
                        }
                        else
                        {
                            bookApp._library.EditBook(editIsbn);
                        }
                        break;

                    case 3:
                        
                        //Menu Driven for search
                        while (true)
                        {
                            Console.WriteLine("\nSearch Book");
                            Console.WriteLine("1. Search By Author");
                            Console.WriteLine("2. Search By Title");

                            if (!int.TryParse(Console.ReadLine(), out int searchChoice) || searchChoice < 1 || searchChoice > 2)
                            {
                                Console.WriteLine("Invalid choice.Please try again...");
                                continue;
                            }
                            switch (searchChoice)
                            {
                                case 1:
                                    //Function for searching book using Author
                                    Console.WriteLine("Enter Name of Author :");
                                    string authorName = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(authorName))
                                    {
                                        Console.WriteLine("Invalid Name of Author.Please try again..");
                                    }
                                    else
                                    {
                                        bookApp._library.SearchByAuthor(authorName);
                                    }
                                    break;
                                case 2:
                                    //Function for searching book using title
                                    Console.WriteLine("Enter Title of the Book :");
                                    string title = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(title))
                                    {
                                        Console.WriteLine("Invalid Title of the Book.Please try again..");
                                    }
                                    else
                                    {
                                        bookApp._library.SearchByAuthor(title);
                                    }
                                    break;
                            }
                        }
                    case 4:
                        //Function for removing book
                        Console.WriteLine("Enter ISBN to Remove Book :");
                        string deleteIsbn = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(deleteIsbn))
                        {
                            Console.WriteLine("Invalid ISBN.Please try again..");
                        }
                        else
                        {
                            bookApp._library.RemoveBook(deleteIsbn);
                        }
                        break;
                    case 5:
                        //Function for listing all books
                        bookApp._library.ListAllBooks();
                        break;
                    case 6:
                        return;

                }

            }
        }
    }
}






























                
            
    
