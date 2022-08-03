using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public class PreviousRepo : IPreviousRepo
{
    private readonly RobinhoodContext _context;

    public PreviousRepo(RobinhoodContext context) { _context = context; }
    
    public void Create(Previous previous)
    {
        _context.Previouses.Add(previous);
        _context.SaveChanges();
    }
    
    public Previous Get(int id) { return _context.Previouses.Find(id); }

    public List<Previous> GetAll() { return _context.Previouses.ToList(); }

    public void Edit(Previous newPrevious)
    {
        var oldPrevious = _context.Previouses.Find(newPrevious.Id);
        if (oldPrevious != null) _context.Previouses.Remove(oldPrevious);
        _context.Previouses.Add(newPrevious);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var previous = _context.Previouses.Find(id);
        if (previous == null) return;
        _context.Previouses.Remove(previous);
        _context.SaveChanges();
    }
}