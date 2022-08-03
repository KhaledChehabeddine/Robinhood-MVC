using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;

[Authorize]
public class PreviousController : Controller
{
    private readonly RobinhoodContext _context;

    public PreviousController(RobinhoodContext context) { _context = context; }

    [HttpGet]
    public IActionResult Index() { return View(_context.Previouses.ToList()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Previous previous)
    {
        _context.Previouses.Add(previous);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("Previous/{id:int}")]
    public IActionResult Get(int id)
    {
        var previous = _context.Previouses.Find(id);
        return View(previous);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var previous = _context.Previouses.Find(id);
        return View(previous);
    }

    [HttpPost]
    public IActionResult Edit(Previous newPrevious)
    {
        var oldPrevious = _context.Previouses.Find(newPrevious.Id);
        if (oldPrevious != null) _context.Previouses.Remove(oldPrevious);
        _context.Previouses.Add(newPrevious);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var previous = _context.Previouses.Find(id);
        if (previous == null) return RedirectToAction("Index");
        _context.Previouses.Remove(previous);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}