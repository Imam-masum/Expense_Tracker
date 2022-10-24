using expanse_Tracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpanseDbContext db;
        public HomeController(ExpanseDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            
            return View(db.Expense_Categories.ToList());
        }
        
        [Authorize]
        public IActionResult Create()
        {
            
            return View();
            
        }
        public IActionResult Edit(int id)
        {
            var p = db.Expense_Categories.Where(x => x.Id == id).FirstOrDefault();
             return View(p);
        }
        [HttpPost]
        public IActionResult CreateorEdit(Expense_Category c)
        {
            if (c.Id > 0)
            {
                db.Expense_Categories.Update(c);
                db.SaveChanges();
            }
            else
            {
                db.Expense_Categories.Add(c);
                db.SaveChanges();
            }

                return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var p = db.Expense_Categories.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}
