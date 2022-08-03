using System.ComponentModel.DataAnnotations;

namespace robinhood_mvc.Models;

public class Instructor
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? InstructorName { get; set; }
    
    [Required]
    public string? CourseName { get; set; }
    
    [Required]
    public int Rating { get; set; }
}