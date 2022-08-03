using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace robinhood_mvc.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? Instructor { get; set; }
    
    [Required]
    public string? Name { get; set; }

    [Required]
    public int Rating { get; set; }
    
    [Required]
    public string? Semester { get; set; }

    [Required]
    public string? Year { get; set; }
}