using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibraryStore.Models;
using MyLibraryStore.Repository;

namespace MyLibraryStore.Controllers
{
    public class BooksController : Controller
    {

        private IBookRepository _bookRepos = null;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepos = bookRepository;
        }
        public IActionResult Index()
        {
            var books = _bookRepos.GetBooks();
            return View(books);
        }


        public IActionResult Details(int id)
        {
            var book = _bookRepos.GetBookById(id);
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _bookRepos.CreateBook(book);

            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _bookRepos.DeleteBook(id);
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepos.GetBookById(id);
            return View(book);
        }


        [HttpPost]
        public IActionResult Edit(int? id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _bookRepos.EditBook(id, book);
            return RedirectToAction("Index", "Books");
        }
    }
}
    