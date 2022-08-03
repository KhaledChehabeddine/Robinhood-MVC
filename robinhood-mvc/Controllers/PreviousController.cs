using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Data;
using robinhood_mvc.Models;
using robinhood_mvc.Repo;

namespace robinhood_mvc.Controllers;

[Authorize]
public class PreviousController : Controller
{
    private readonly PreviousRepo _previousRepo;

    public PreviousController(RobinhoodContext context) { _previousRepo = new PreviousRepo(context); }

    public IActionResult Index() { return View(_previousRepo.GetAll()); }

    [HttpGet]
    public IActionResult Create() { return View(); }

    [HttpPost]
    public IActionResult Create(Previous previous)
    {
        _previousRepo.Create(previous);
        return RedirectToAction("Index");
    }

    [HttpGet("Previous/{id:int}")]
    public IActionResult Get(int id)
    {
        var instructor = _previousRepo.Get(id);
        return View(instructor);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var instructor = _previousRepo.Get(id);
        return View(instructor);
    }
    
    [HttpPost]
    public IActionResult Edit(Previous previous)
    {
        _previousRepo.Edit(previous);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _previousRepo.Delete(id);
        return RedirectToAction("Index");
    }
}