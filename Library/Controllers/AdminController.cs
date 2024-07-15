using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUSer> _userManager;

        public AdminController(UserManager<AppUSer> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}