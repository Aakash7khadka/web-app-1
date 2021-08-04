using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app1.Models;

namespace web_app1.Controllers
{
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            ViewData["user"] = "Admin";
            ViewBag.time = "Evening";

            var user_list = _db.users.ToList();


            return View(user_list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Users usr = new Users();
            return View(usr);
        }
        [HttpPost]
        public IActionResult Create(Users usr)
        {
            if (usr == null)
            {
                return NotFound();

            }
           
               
            
            if (ModelState.IsValid)
            {
                _db.users.Add(usr);
                _db.SaveChanges();
                TempData["message"] = "User Creation sucessful";
                return RedirectToAction("index");
            }
            else
            {
                //ModelState.AddModelError("", "Name cannot be empty");
                return View(usr);
            }
           
           
        }
        public IActionResult Edit(int id)
        {
            var user = _db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(Users usr)
        {
            if (usr == null)
            {
                return NotFound();

            }
            _db.users.Update(usr);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var user = _db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(Users usr)
        {
            if (usr == null)
            {
                return NotFound();

            }
            _db.users.Remove(usr);
            _db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
