namespace robinhood_mvc.Models;

public class Course
{
    public int Id { get; set; }

    public string? Instructor { get; set; }

    public string? Name { get; set; }

    public int Rating { get; set; }

    public string? Semester { get; set; }

    public string? Year { get; set; }
}