using MyLibraryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        Book GetBookById(int id);

        void CreateBook(Book book);

        
        void DeleteBook(int? Id);
        void EditBook(int? id, Book book);
    }
}
