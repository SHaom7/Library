using Library.Data;
using Library.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Member> members = await _memberService.GetAll();
            return View(members);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Member member = await _memberService.GetById(id);
            return View(member);
        }
    }
}
