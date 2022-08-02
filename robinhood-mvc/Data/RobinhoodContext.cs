using Microsoft.EntityFrameworkCore;
using robinhood_mvc.Models;

namespace robinhood_mvc.Data;

public class RobinhoodContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    
    public RobinhoodContext(DbContextOptions<RobinhoodContext> options) : base(options) { }
}