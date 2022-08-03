using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public class CourseRepo : ICourseRepo
{
    private readonly RobinhoodContext _context;

    public CourseRepo(RobinhoodContext context) { _context = context; }
    
    public void Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }
    
    public Course Get(int id) { return _context.Courses.Find(id); }

    public List<Course> GetAll() { return _context.Courses.ToList(); }

    public void Edit(Course newCourse)
    {
        var oldCourse = _context.Courses.Find(newCourse.Id);
        if (oldCourse != null) _context.Courses.Remove(oldCourse);
        _context.Courses.Add(newCourse);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return;
        _context.Courses.Remove(course);
        _context.SaveChanges();
    }
}