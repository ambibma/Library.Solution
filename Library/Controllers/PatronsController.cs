using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers 
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;

    public PatronsController(LibraryContext db)
    {
      _db =db;
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
    

  }
}