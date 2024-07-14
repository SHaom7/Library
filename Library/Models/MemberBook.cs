using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class MemberBook
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
