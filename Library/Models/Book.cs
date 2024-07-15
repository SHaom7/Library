using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Brief { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "There must be at least one copy.")]
        public int Copies { get; set; }

        public List<MemberBook>? MemberBooks { get; set; }
    }
}