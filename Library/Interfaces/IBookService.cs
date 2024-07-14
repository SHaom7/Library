using Library.Models;

namespace Library.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(Guid id);
        Task<IEnumerable<Member>> GetBorrowers(Guid bookid);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool SaveBook();
    }
}
