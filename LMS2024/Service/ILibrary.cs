using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS2024.Service
{
    public interface ILibrary
    {

        //Crud Operations
        void AddBook();
        void ListAllBooks();
        void EditBook(string isbn);
        void RemoveBook(string isbn);
        void SearchByAuthor(string author);
        void SearchByTitle(string title);

    }
}
