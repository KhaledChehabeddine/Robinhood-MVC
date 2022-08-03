using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;
using robinhood_mvc.Repo;

namespace robinhood_mvc.Controllers;

[Authorize]
public class CourseController : Controller
{
    private readonly CourseRepo _courseRepo;

    public CourseController(RobinhoodContext context) { _courseRepo = new CourseRepo(context); }

    public IActionResult Index() { return View(_courseRepo.GetAll()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        _courseRepo.Create(course);
        return RedirectToAction("Index");
    }

    [HttpGet("Course/{id:int}")]
    public IActionResult Get(int id)
    {
        var course = _courseRepo.Get(id);
        return View(course);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = _courseRepo.Get(id);
        return View(course);
    }
    
    [HttpPost]
    public IActionResult Edit(Course course)
    {
        _courseRepo.Edit(course);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _courseRepo.Delete(id);
        return RedirectToAction("Index");
    }
}