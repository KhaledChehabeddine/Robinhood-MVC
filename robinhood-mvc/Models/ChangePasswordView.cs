using System.ComponentModel.DataAnnotations;

namespace robinhood_mvc.Models;

public class ChangePasswordView
{
    public string? Username { get; set; }
    
    [Required(ErrorMessage = "Please enter password.")]
    public string? OldPassword { get; set; }
    
    [Required(ErrorMessage = "Please enter a new password.")]
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }
}