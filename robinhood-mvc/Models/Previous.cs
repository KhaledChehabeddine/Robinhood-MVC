using System.ComponentModel.DataAnnotations;

namespace robinhood_mvc.Models;

public class Previous
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a file name.")]
    public string? Filename { get; set; }
    
    [Required(ErrorMessage = "Please enter a course name.")]
    public string? CourseName { get; set; }
    
    [Required(ErrorMessage = "Please enter a rating.")]
    public int Rating { get; set; }
}