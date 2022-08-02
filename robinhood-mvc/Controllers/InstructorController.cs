using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;

public class InstructorController : Controller
{
    private readonly ILogger<InstructorController> _logger;

    public InstructorController(ILogger<InstructorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}