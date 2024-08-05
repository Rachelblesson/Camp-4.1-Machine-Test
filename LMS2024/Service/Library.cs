using LMS2024.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMS2024.Service
{
    public class Library : ILibrary
    {

        //Create a dictionary to store isbn and corresponding book details
        public static Dictionary <string, Book> books = new Dictionary <string, Book>();

        //starting with 10000 for 5 digit ISBN
        private static int isbnGenerator = 10000;

        #region Add Book

        public void AddBook()
        {
            //Exception handling
            try
            {
                //Get input from the user
                Console.WriteLine("Enter Book Details :");

                //Title
                string title;

                //Validation for not empty or number
                while (true)
                {
                    Console.WriteLine("Enter Title of the book :");
                    title = Console.ReadLine();

                    //Validation
                    if (!string.IsNullOrWhiteSpace(title) &&
                        !System.Text.RegularExpressions.Regex.IsMatch(title, @"\d"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for title.Please ensure it is not empty and not contain numbers");
                    }
                }

                //Author
                string author;

                //Validation for not empty or number
                while (true)
                {
                    Console.WriteLine("Enter Author of the book :");
                    author = Console.ReadLine();

                    //Validation
                    if (!string.IsNullOrWhiteSpace(author) &&
                        !System.Text.RegularExpressions.Regex.IsMatch(author, @"\d"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for author.Please ensure it is not empty and not contain numbers");
                    }
                }


                //Published Date
                DateTime publishedDate;

                //validation for published date
                while (true)
                {
                    Console.WriteLine("Published Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out publishedDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Published Date.Must be in YYYY-MM-DD format.Please try again");

                    }
                }



                // Auto - generate ISBN as a 5 - digit string
                string isbn = isbnGenerator.ToString("D5");
                isbnGenerator++; // Increment for the next book

                // Check if the ISBN already exists in the dictionary to avoid duplicates
                while (books.ContainsKey(isbn))
                {
                    isbn = isbnGenerator.ToString("D5");
                    isbnGenerator++;
                }

                Console.WriteLine($"Generated ISBN: {isbn}");

                // Create a book object to add it to the dictionary
                books.Add(isbn, new Book
                {
                    Isbn = isbn,
                    Title = title,
                    Author = author,
                    PublishedDate = publishedDate
                });

                Console.WriteLine("Book added successfully");
                Console.WriteLine($"Number Of Books : {books.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }


        }




        #endregion

        #region List All Books

        public void ListAllBooks()
        {
            //Exception handling
            try
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No books found");
                    return;
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("  | ISBN   |   Title     |    Author    |   Published Date   |  ");
                    Console.WriteLine("----------------------------------------------------------------");

                     //Displaying the values that contains in a dictionary
                    foreach (var book in books.Values)
                    {
                        Console.WriteLine($"  | {book.Isbn} | {book.Title} | {book.Author} | {book.PublishedDate} | ");
                    }
                    Console.WriteLine("----------------------------------------------------------------");


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        #endregion

        #region Edit Book

        public void EditBook(string isbn)
        {
            //Exception handling
            try
            {
                if (!books.ContainsKey(isbn))
                {
                    Console.WriteLine("Book not found");
                    return;

                }
                //Locating book
                var book = books[isbn];

                //published date
                Console.WriteLine($"The old published date is : {book.PublishedDate}");

                DateTime newPublishedDate;

                //validation for published date
                while (true)
                {
                    Console.WriteLine("Date of Joining (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out newPublishedDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Published Date.Must be in YYYY-MM-DD format.Please try again");

                    }
                }
                Console.WriteLine("Employee Updated Successfully....");



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Remove Book

        public void RemoveBook(string isbn)
        {
            // Exception handling
            try
            {

                // Check if the ISBN exists in the dictionary
                if (books.ContainsKey(isbn))
                {
                    // Remove the book from the dictionary
                    books.Remove(isbn);
                    Console.WriteLine("Book deleted successfully.");
                    Console.WriteLine($"Number Of Books: {books.Count}");
                }
                else
                {
                    Console.WriteLine("No book found with the provided ISBN.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            }



            #endregion

            #region Search By Author

            public void SearchByAuthor(string author)
        {

            try
            {
                if (books.TryGetValue(author, out Book book))
                {
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("  | ISBN   |   Title     |    Author    |   Published Date   |  ");
                    Console.WriteLine("----------------------------------------------------------------");                    
                    Console.WriteLine($"  | {book.Isbn} | {book.Title} | {book.Author} | {book.PublishedDate} | ");                    
                    Console.WriteLine("----------------------------------------------------------------");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        #endregion

        #region Search By Title

        public void SearchByTitle(string title)
        {

            try
            {
                if (books.TryGetValue(title, out Book book))
                {
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("  | ISBN   |   Title     |    Author    |   Published Date   |  ");
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine($"  | {book.Isbn} | {book.Title} | {book.Author} | {book.PublishedDate} | ");
                    Console.WriteLine("----------------------------------------------------------------");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion










    }
}
