using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Brief { get; set; }
        public int Copies { get; set; }
        public List<MemberBook> MemberBooks { get; set; }
    }
}
