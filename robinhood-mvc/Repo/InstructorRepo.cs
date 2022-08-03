using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public class InstructorRepo : IInstructorRepo
{
    private readonly RobinhoodContext _context;

    public InstructorRepo(RobinhoodContext context) { _context = context; }
    
    public void Create(Instructor instructor)
    {
        _context.Instructors.Add(instructor);
        _context.SaveChanges();
    }
    
    public Instructor Get(int id) { return _context.Instructors.Find(id); }

    public List<Instructor> GetAll() { return _context.Instructors.ToList(); }

    public void Edit(Instructor newInstructor)
    {
        var oldInstructor = _context.Instructors.Find(newInstructor.Id);
        if (oldInstructor != null) _context.Instructors.Remove(oldInstructor);
        _context.Instructors.Add(newInstructor);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return;
        _context.Instructors.Remove(instructor);
        _context.SaveChanges();
    }
}