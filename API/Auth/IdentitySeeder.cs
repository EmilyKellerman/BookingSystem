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
                Email = "Skye@booking.com"
            };

            await userManager.CreateAsync(admin, "Skye123!");//creating the user with a password
            await userManager.AddToRoleAsync(admin, "Admin");//assigning the user to the admin role
        }

        // Create one user for each non-admin role
        var employee = await userManager.FindByNameAsync("employee1");
        if (employee == null)
        {
            employee = new ApplicationUser
            {
                UserName = "employee1",
                Email = "employee1@booking.com"
            };
            await userManager.CreateAsync(employee, "Employee123!");
            await userManager.AddToRoleAsync(employee, "Employee");
        }

        // Create one user for each non-admin role
        var employee = await userManager.FindByNameAsync("employee2");
        if (employee == null)
        {
            employee = new ApplicationUser
            {
                UserName = "employee2",
                Email = "employee2@booking.com"
            };
            await userManager.CreateAsync(employee, "Employee123!");
            await userManager.AddToRoleAsync(employee, "Employee");
        }

        var receptionist = await userManager.FindByNameAsync("reception1");
        if (receptionist == null)
        {
            receptionist = new ApplicationUser
            {
                UserName = "reception1",
                Email = "reception@booking.com"
            };
            await userManager.CreateAsync(receptionist, "Reception123!");
            await userManager.AddToRoleAsync(receptionist, "Receptionist");
        }

        var facilities = await userManager.FindByNameAsync("facilities1");
        if (facilities == null)
        {
            facilities = new ApplicationUser
            {
                UserName = "facilities1",
                Email = "facilities@booking.com"
            };
            await userManager.CreateAsync(facilities, "Facilities123!");
            await userManager.AddToRoleAsync(facilities, "Facilities Manager");
        }
    }
}