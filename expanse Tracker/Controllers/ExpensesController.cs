using expanse_Tracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpanseDbContext db;
        
        public ExpensesController(ExpanseDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            multipletable m = new multipletable();
            m.Expense_Categories = db.Expense_Categories.ToList();
            m.Expanses = db.Expanses.ToList();
            return View(m);
        }
        [Authorize]
        public IActionResult Create()
        {

            ViewBag.categories = db.Expense_Categories.ToList();
            return View();
        }
        public IActionResult Edit(int id)
         {

            var p = db.Expanses.Where(x => x.ExpansesId == id).FirstOrDefault();
            ViewBag.categories = db.Expense_Categories.ToList();
            return View(p);
        }
        [HttpPost]
        public IActionResult CreateorEdit(Expanses c)
        {
            if (c.ExpansesId > 0)
            {
                ViewBag.categories = db.Expense_Categories.ToList();
                db.Expanses.Update(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = db.Expense_Categories.ToList();
                db.Expanses.Add(c);         
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
           
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            ViewBag.categories = db.Expense_Categories.ToList();
            var p = db.Expanses.Where(x => x.ExpansesId == id).FirstOrDefault();
            db.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IList<Expanses> Expanses { get; set; }
        public void search(DateTime startdate,DateTime enddate)
        {
            Expanses = (from x in db.Expanses where(x.Date<=startdate)&&(x.Date>=enddate)select x).ToList();
        }

    }
}
