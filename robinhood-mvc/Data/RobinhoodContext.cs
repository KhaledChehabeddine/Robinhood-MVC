using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using robinhood_mvc.Models;

namespace robinhood_mvc.Data;

public class RobinhoodContext : IdentityDbContext<User>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Previous> Previouses { get; set; }
    
    // public DbSet<Instructor> Instructors { get; set; }

    public RobinhoodContext(DbContextOptions<RobinhoodContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<User>().HasKey(user => new { user.Email, user.PasswordHash });
        
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Instructor = "Imad Moukadem",
                Name = "CMPS 278",
                Rating = 5,
                Semester = "Summer",
                Year = "2021-2022"
            },
            new Course
            {
                Id = 2,
                Instructor = "Mahmoud Bdeir",
                Name = "CMPS 253",
                Rating = 3,
                Semester = "Spring",
                Year = "2021-2022"
            }
        );
    }

    public static async Task CreateAdminUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        const string username = "admin";
        const string password = "password";
        const string roleName = "Admin";

        if (await roleManager.FindByNameAsync(roleName) == null)
            await roleManager.CreateAsync(new IdentityRole(roleName));
        if (await userManager.FindByNameAsync(username) == null)
        {
            var user = new User { UserName = username };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, roleName);
        }
    }
}