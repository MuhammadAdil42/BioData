using BioDataWeb.Data;
using BioDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BioDataWeb.Controllers
{
    public class BioDataController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BioDataController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Credentials> UserInfo = _db.PersonalData;
            return View(UserInfo);
        }

        //Get
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post
        public IActionResult CreateUser(Credentials obj)
        {
            if (obj.FirstName == obj.LastName && obj.LastName != null && obj.FirstName != null)
            {
                ModelState.AddModelError("CustomError", "First name and Last name can't be same!");
            }
            if (ModelState.IsValid)
            {
                _db.PersonalData.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var UserInfoFromDb = _db.PersonalData.Find(id);
            if(UserInfoFromDb == null)
            {
                return NotFound();
            }
            return View(UserInfoFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post
        public IActionResult EditUser(Credentials obj)
        {
            if (obj.FirstName == obj.LastName && obj.LastName != null && obj.FirstName != null)
            {
                ModelState.AddModelError("CustomError", "First name and Last name can't be same!");
            }
            if (ModelState.IsValid)
            {
                _db.PersonalData.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult RemoveUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var UserInfoFromDb = _db.PersonalData.Find(id);
            if (UserInfoFromDb == null)
            {
                return NotFound();
            }
            return View(UserInfoFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post
        public IActionResult RemoveUser(Credentials obj)
        {
            if (obj.FirstName == obj.LastName && obj.LastName != null && obj.FirstName != null)
            {
                ModelState.AddModelError("CustomError", "First name and Last name can't be same!");
            }
            if (ModelState.IsValid)
            {
                _db.PersonalData.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category removed successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
