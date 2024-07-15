using Library.Data;
using Library.Interfaces;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        public BookController(IBookService bookService, IMemberService memberService)
        {
            _bookService = bookService;
            _memberService = memberService;
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

        //public async Task<IActionResult> Borrow(Guid id)
        //{
            
        //    Guid memberId = GetCurrentUserId(); // Replace with your user authentication logic

        //    var member = await _memberService.GetById(memberId);

        //    await _memberService.BorrowBook(member, id);

        //    return RedirectToAction("Detail", new { id = id });
        //}


    }
}
