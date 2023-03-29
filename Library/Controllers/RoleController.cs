using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Library.Controllers //maybe Identity?
{
  public class RoleController : Controller
  {
    private readonly LibraryContext _db;
    private RoleManager<IdentityRole> roleManager;
    public RoleController(RoleManager<IdentityRole> roleMgr, LibraryContext db)
    {
      _db = db;
      roleManager = roleMgr;
    }
    public ViewResult Index() => View(roleManager.Roles);

    private void Errors(IdentityResult result)
    {
      foreach(IdentityError error in result.Errors)
          ModelState.AddModelError("", error.Description);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create([Required] string name)
    {
    if (ModelState.IsValid)
    {
        var newRole = new IdentityRole(name);
        var result = await roleManager.CreateAsync(newRole);
        if (result.Succeeded)
        {
            // Add new role to the database
            _db.Roles.Add(newRole);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else
        {
            Errors(result);
        }
    }

    return View(name);
}
  }
}