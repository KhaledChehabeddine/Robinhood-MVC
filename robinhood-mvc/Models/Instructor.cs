using System.ComponentModel.DataAnnotations;

namespace robinhood_mvc.Models;

public class Instructor
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter instructor's name.")]
    public string? InstructorName { get; set; }

    [Required(ErrorMessage = "Please enter a course name.")]
    public string? Coursename { get; set; }

    [Required(ErrorMessage = "Please enter a rating.")]
    public int Rating { get; set; }
}