using Microsoft.EntityFrameworkCore;
using robinhood_mvc.Models;

namespace robinhood_mvc.Data;

public class RobinhoodContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    
    public RobinhoodContext(DbContextOptions<RobinhoodContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
}