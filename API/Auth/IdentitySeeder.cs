using Microsoft.AspNetCore.Identity;

public static class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
    {
        // Seed roles
        string[] roles = { "Admin", "Employee", "Receptionist", "Facilities Manager" };
        
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var admin = await userManager.FindByNameAsync("Skye");

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "Skye",
                Email = "Skye@Calculator.com"
            };

            await userManager.CreateAsync(admin, "Skye123!");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}