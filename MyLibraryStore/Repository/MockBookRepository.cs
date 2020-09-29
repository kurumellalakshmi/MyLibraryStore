using MyLibraryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Repository
{
    public class MockBookRepository : IBookRepository
    {
        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int? Id)
        {
            throw new NotImplementedException();
        }

        public void EditBook(int? id, Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            var books = GetBooks();
            return books.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{Id=1,BookName="2 States", Author="Chetan Bhagat", ISBN="1336357", PublishedDate=Convert.ToDateTime("09/04/1998")},
                new Book{Id=2,BookName="Worls India", Author="Rufson", ISBN="13946747", PublishedDate=Convert.ToDateTime("07/04/1997")},
                new Book{Id=3,BookName="Wings of World", Author="Abdul kalam", ISBN="16733277", PublishedDate=Convert.ToDateTime("09/04/1995")},
            };

        }

        public void UpdateBook(int? Id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
