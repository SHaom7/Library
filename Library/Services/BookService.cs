using Library.Data;
using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public bool AddBook(Book book)
        {
            _context.Add(book);
            return SaveBook();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return SaveBook();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Member>> GetBorrowers(Guid bookid)
        {
            return await _context.Books
                .Where(b => b.BookId == bookid)
                .SelectMany(b => b.MemberBooks)
                .Select(mb => mb.Member)
                .ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.Include(i => i.MemberBooks).FirstOrDefaultAsync(i => i.BookId == id);
        }

        public bool SaveBook()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return SaveBook();
        }
    }
}
