using Microsoft.AspNetCore.Identity;

namespace Library.Models
{
    public class AppUSer : IdentityUser
    {
        public string Name { get; set; }
    }
}