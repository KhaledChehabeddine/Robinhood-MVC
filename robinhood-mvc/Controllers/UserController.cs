using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using robinhood_mvc.Models;

namespace robinhood_mvc.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = new List<User>();
        foreach (var user in _userManager.Users)
        {
            user.RoleNames = await _userManager.GetRolesAsync(user);
            users.Add(user);
        }
        var model = new UserView
        {
            Users = users,
            Roles = _roleManager.Roles
        };
        return View(model);
    }
    
    public IActionResult Add()
    {
        return RedirectToAction("Register", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return RedirectToAction("Index");
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded) return RedirectToAction("Index");
        var errorMessage = result.Errors.Aggregate("", 
            (current, error) => current + (error.Description + " | "));
        TempData["message"] = errorMessage;
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddToAdmin(string id)
    {
        var adminRole = await _roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            TempData["message"] = "Admin role does not exist. Click 'Create Admin Role' button to create it.";
        }
        else
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, adminRole.Name);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromAdmin(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRole(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        await _roleManager.DeleteAsync(role);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdminRole()
    {
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordView model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = await _userManager.FindByNameAsync(model.Username);
        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (result.Succeeded) return RedirectToAction("Index");
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View(model);
    }
}