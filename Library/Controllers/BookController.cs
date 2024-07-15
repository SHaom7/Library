using Library.Data;
using Library.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books = await _bookService.GetAll();
            return View(books);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            Book book = await _bookService.GetById(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
                return View(book);
            }

            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }


    }
}
