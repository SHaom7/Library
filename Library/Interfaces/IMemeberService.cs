using Library.Models;

namespace Library.Interfaces
{
    public interface IMemeberService
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(Guid id);
        Task<IEnumerable<Book>> GetBorrowedBooks(Guid memberid);
        bool AddMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(Member member);
        bool SaveMember();
        Task BorrowBook(Member member, Guid bookId);
        Task ReturnBook(Member member, Guid bookId);

    }
}
