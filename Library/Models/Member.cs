using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Member
    {
        [Key]
        public Guid MemberId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<MemberBook> MemberBooks { get; set; }

    }
}
