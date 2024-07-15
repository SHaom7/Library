using Library.Data;
using Library.Interfaces;
using Library.Models;
using Library.Services;
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

        public async Task<IActionResult> Detail(Guid id)
        {
            Member member = await _memberService.GetById(id);
            return View(member);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
                return View(member);
            }

            _memberService.AddMember(member);
            return RedirectToAction("Index");
        }
    }
}
