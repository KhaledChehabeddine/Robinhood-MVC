using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class PreviousController : ControllerBase
{
    private readonly RobinhoodContext _context;

    public PreviousController(RobinhoodContext context)
    {
        _context = context;
    }

    [HttpPost]
    public JsonResult Create(Previous previous)
    {
        if (previous.Id == 0) _context.Previouses.Add(previous);
        else
        {
            var previousInDb = _context.Previouses.Find(previous.Id);
            if (previousInDb == null)
                return new JsonResult(NotFound());
            previousInDb = previous;
        }
        _context.SaveChanges();
        return new JsonResult(Ok(previous));
    }

    [HttpGet]
    public JsonResult Get(int id)
    {
        var previous = _context.Previouses.Find(id);
        return previous == null ? new JsonResult(NotFound()) : new JsonResult(Ok(previous));
    }

    [HttpGet]
    public JsonResult GetAll()
    {
        var previouses = _context.Previouses.ToList();
        return new JsonResult(Ok(previouses));
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        var previous = _context.Previouses.Find(id);
        if (previous == null)
            return new JsonResult(NotFound());
        _context.Previouses.Remove(previous);
        _context.SaveChanges();
        return new JsonResult(NoContent());
    }
}