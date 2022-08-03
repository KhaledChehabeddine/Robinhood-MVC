using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;

[Authorize]
public class InstructorController : Controller
{
    private readonly RobinhoodContext _context;

    public InstructorController(RobinhoodContext context) { _context = context; }

    [HttpGet]
    public IActionResult Index() { return View(_context.Instructors.ToList()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Instructor instructor)
    {
        _context.Instructors.Add(instructor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("Instructor/{id:int}")]
    public IActionResult Get(int id)
    {
        var instructor = _context.Instructors.Find(id);
        return View(instructor);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var instructor = _context.Instructors.Find(id);
        return View(instructor);
    }

    [HttpPost]
    public IActionResult Edit(Instructor newInstructor)
    {
        var oldInstructor = _context.Instructors.Find(newInstructor.Id);
        if (oldInstructor != null) _context.Instructors.Remove(oldInstructor);
        _context.Instructors.Add(newInstructor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return RedirectToAction("Index");
        _context.Instructors.Remove(instructor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}