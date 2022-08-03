using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;
using robinhood_mvc.Repo;

namespace robinhood_mvc.Controllers;

[Authorize]
public class InstructorController : Controller
{
    private readonly InstructorRepo _instructorRepo;

    public InstructorController(RobinhoodContext context) { _instructorRepo = new InstructorRepo(context); }

    public IActionResult Index() { return View(_instructorRepo.GetAll()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Instructor instructor)
    {
        _instructorRepo.Create(instructor);
        return RedirectToAction("Index");
    }

    [HttpGet("Instructor/{id:int}")]
    public IActionResult Get(int id)
    {
        var instructor = _instructorRepo.Get(id);
        return View(instructor);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var instructor = _instructorRepo.Get(id);
        return View(instructor);
    }
    
    [HttpPost]
    public IActionResult Edit(Instructor instructor)
    {
        _instructorRepo.Edit(instructor);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _instructorRepo.Delete(id);
        return RedirectToAction("Index");
    }
}