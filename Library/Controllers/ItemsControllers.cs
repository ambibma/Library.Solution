using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize] //[Authorize(Roles = "Administrator")]
    public class ItemsController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ItemsController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _db = db;
        }
        [AllowAnonymous] 
        public ActionResult Index()
        {
            List<Item> model = _db.Items.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous] 
        public ActionResult Details(int id)
        {
            Item thisItem = _db.Items
                    .Include(item => item.JoinEntities)
                    .ThenInclude(join => join.Property)
                    .FirstOrDefault(item => item.ItemId == id);
            return View(thisItem);
        }

        public ActionResult Edit(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            _db.Items.Update(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            _db.Items.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}