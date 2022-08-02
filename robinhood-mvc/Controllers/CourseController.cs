using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;

public class CourseController : Controller
{
    private readonly RobinhoodContext _context;

    public CourseController(RobinhoodContext context) { _context = context; }

    public IActionResult Index() { return View(_context.Courses.ToList()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("Course/{id:int}")]
    public IActionResult Get(int id)
    {
        var course = _context.Courses.Find(id);
        return View(course);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = _context.Courses.Find(id);
        return View(course);
    }
    
    [HttpPost]
    public IActionResult Edit(Course newCourse)
    {
        var oldCourse = _context.Courses.Find(newCourse.Id);
        if (oldCourse != null) _context.Courses.Remove(oldCourse);
        _context.Courses.Add(newCourse);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return RedirectToAction("Index");
        _context.Courses.Remove(course);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}