
using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Application.Enums;
using Restaurant.Infrastructure.Identity.Entities;


namespace Api_restaurante.Infractructure.Identity.Seeds
{
    public class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "adminuser";
            defaultUser.Email = "admin@gmail.com";
            defaultUser.FirstName = "John";
            defaultUser.LastName = "Doe";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {

                    await userManager.CreateAsync(defaultUser, "123Pa$$");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Waiter.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());


                }
            }
        }
    }
}
