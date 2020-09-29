using MyLibraryStore.Data;
using MyLibraryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _dbContext = null;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.ToList().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }
        public void CreateBook(Book book)
        {
            if (book == null)
            {
                throw new AccessViolationException(nameof(book));
            }
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public void DeleteBook(int? Id)
        {
            if (Id == null)
            {
                throw new AccessViolationException(nameof(Id));
            }
            var book = _dbContext.Books.SingleOrDefault(mbox => mbox.Id == Id.Value);
            if (book == null)
            {
                throw new NullReferenceException();
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
       

        public void EditBook(int? Id, Book book)
        {
            if (Id == null || book == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            var bookInDb = _dbContext.Books.SingleOrDefault(mbox => mbox.Id == Id.Value);
            if (bookInDb == null)
            {
                throw new NullReferenceException();

            }
            bookInDb.BookName = book.BookName;
            bookInDb.Author = book.Author;
            bookInDb.ISBN = book.ISBN;
            bookInDb.PublishedDate = book.PublishedDate;
            _dbContext.SaveChanges();
        }
    }
}

