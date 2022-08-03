using System.ComponentModel.DataAnnotations;

namespace robinhood_mvc.Models;

public class RegisterView
{
    [Required(ErrorMessage = "Please enter a username.")]
    [StringLength(255)]
    public string? Username { get; set; }
    
    [Required(ErrorMessage = "Please enter a first name.")]
    [StringLength(255)]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter a last name.")]
    [StringLength(255)]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "Please enter a password.")]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword")]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPassword { get; set; }
}