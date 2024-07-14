using Library.Data;
using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _context;

        public MemberService(AppDbContext context)
        {
            _context = context;
        }
        public bool AddMember(Member member)
        {
            _context.Add(member);
            return SaveMember();
        }

        public async Task ReturnBook(Member member, Guid bookId)
        {
            var memberBook = await _context.MemberBooks
                .FirstOrDefaultAsync(mb => mb.MemberId == member.MemberId && mb.BookId == bookId);

            if (memberBook != null)
            {
                var book = await _context.Books.FindAsync(memberBook.BookId);
                if (book != null)
                {
                    book.Copies++;
                    _context.MemberBooks.Remove(memberBook);
                    await _context.SaveChangesAsync(); // Use SaveChangesAsync for asynchronous saving
                }
                else
                {
                    // Consider throwing an exception or returning an error message.
                    throw new Exception($"Book with ID {memberBook.BookId} not found.");
                }
            }
            else
            {
                // Consider throwing an exception or returning an error message.
                throw new Exception($"{member.Name} did not borrow {bookId}.");
            }
        }

        public bool DeleteMember(Member member)
        {
            _context.Remove(member);
            return SaveMember();
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.ToListAsync(); 
        }

        public async Task<IEnumerable<Book>> GetBorrowedBooks(Guid memberid)
        {
            return await _context.Members
                .Where(m => m.MemberId == memberid)
                .SelectMany(m => m.MemberBooks)
                .Select(mb => mb.Book)
                .ToListAsync();
        }

        public async Task<Member> GetById(Guid id)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.MemberId == id);
        }

        public async Task BorrowBook(Member member, Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                if (book.Copies > 0)
                {
                    book.Copies--;
                    MemberBook memberBook = new MemberBook { MemberId = member.MemberId, BookId = bookId };
                    _context.MemberBooks.Add(memberBook);
                    await _context.SaveChangesAsync(); // Use SaveChangesAsync for asynchronous saving
                }
                else
                {
                    // Instead of printing, you might want to throw an exception here
                    // or return a specific error message.
                    throw new Exception($"The book: {book.Title} is not available.");
                }
            }
            else
            {
                // Similar to above, consider throwing an exception or returning an error message.
                throw new Exception($"Book with ID {bookId} not found.");
            }
        }

        public bool SaveMember()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
