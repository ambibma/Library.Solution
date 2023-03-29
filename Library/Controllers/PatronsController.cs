using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers 
{
  [Authorize]
  public class PatronsController : Controller
  
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronsController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _db =db;
      _userManager = userManager;
    }
   public ActionResult Index()
   {
    List<Patron> model = _db.Patrons
                        .Include(patron => patron.Reservations)
                        .ToList();
    return View(model);

   }
   public ActionResult Create()
   {
    return View();
   }
   [HttpPost]
   public ActionResult Create(Patron patron)
   {
      _db.Patrons.Add(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
   }
    public ActionResult Details(int id)
    {
      Patron thisPatron = _db.Patrons
                        
                          .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);

    }
    public ActionResult Edit(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult Edit(Patron patron)
    {
      _db.Patrons.Update(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      _db.Patrons.Remove(thisPatron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    
    //[HttpPost]
    // public async Task<ActionResult> Create(Item item, int CategoryId)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //     return View(item);
    //   }
    //   else
    //   {
    //     string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    //     reservation.User = currentUser;
    //     _db.Items.Add(item);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    //   }
    // }
    public ActionResult Schedule(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisPatient);
    }
    [HttpPost]
    public async Task<ActionResult> CreateReservation(int patronId, int itemId)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "DisplayName");
        return View(itemId);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // build reservation id
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        patron.User = currentUser;
        // upload to database???
        _db.Reservations.Add(itemId);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }


    

  }
}