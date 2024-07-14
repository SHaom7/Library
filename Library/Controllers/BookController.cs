using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var book = _context.Books.ToList();
            return View(book);
        }
        public IActionResult Details(Guid id)
        {
            Book book = _context.Books
                    .Include(b => b.MemberBooks)
                    .ThenInclude(mb => mb.Member)
                    .FirstOrDefault(x => x.BookId == id);
            return View(book);
        }
    }
}
