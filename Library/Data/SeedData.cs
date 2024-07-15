using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUSer>>();

            if (userManager.Users.All(u => u.UserName != "admin@library.com"))
            {
                var adminUser = new AppUSer
                {
                    UserName = "admin@library.com",
                    Email = "admin@library.com",
                    Name = "Admin User"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create admin user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}