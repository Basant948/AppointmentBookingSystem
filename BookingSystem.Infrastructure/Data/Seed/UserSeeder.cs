using BookingSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Data.Seed
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager)
        {
            await CreateUserAsync(
                userManager,
                "admin",
                "admin@gmail.com",
                "Admin"
            );

            await CreateUserAsync(
                userManager,
                "employee",
                "employee@gmail.com",
                "Employee"
            );
        }

        private static async Task CreateUserAsync(
            UserManager<ApplicationUser> userManager,
            string username,
            string email,
            string role)
        {
            var existingUser = await userManager.FindByNameAsync(username);

            if (existingUser != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(
                user,
                "Admin@123"
            );

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}