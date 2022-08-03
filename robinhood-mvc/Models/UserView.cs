using Microsoft.AspNetCore.Identity;

namespace robinhood_mvc.Models;

public class UserView
{
    public IEnumerable<User> Users { get; set; }
    
    public IEnumerable<IdentityRole> Roles { get; set; } 
}