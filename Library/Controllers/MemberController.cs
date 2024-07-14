using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        public MemberController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var members = _context.Members.ToList();
            return View(members);
        }

        public IActionResult Details(Guid id)
        {
            Member member = _context.Members
                    .Include(b => b.MemberBooks)
                    .ThenInclude(mb => mb.Member)
                    .FirstOrDefault(x => x.MemberId == id);
            return View(member);
        }
    }
}
