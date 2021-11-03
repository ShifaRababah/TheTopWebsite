using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly TopContext _context;
        

        public AdminController(TopContext context)
        {
            this._context = context;
           
        }
        public IActionResult Index()
        {
            ViewBag.SumOfCustomer = _context.Customers.DefaultIfEmpty().Count();
            ViewBag.SumOfProduct = _context.Products.DefaultIfEmpty().Count();
            ViewBag.SumOfEmployees = _context.Employees.DefaultIfEmpty().Count();

            var dataHome = _context.HomePages.ToList();
              foreach(var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            //ViewBag.logo = _context.HomePages.SingleOrDefault(e =>e).;
            //ViewBag.call = _context.HomePages.SingleOrDefault().CallUs;
            //ViewBag.email = _context.HomePages.SingleOrDefault().CallUs;
           
            return View();
        }

       


        public IActionResult Products(int id)
        {
            Category category = _context.Categories.Find(id);
            ViewBag.cat = category.Name;


            var Result = _context.Products.Where(x => x.CategoryId == id).OrderByDescending(x => x.Date).ToList();
            return View(Result);
        }



        [HttpPost]
        public IActionResult SaveStartTime(TimeSheet timeSheet)
        {
            if (HttpContext.Session.GetInt32("EmpId") == null)
            {
                return Content("Please Login");
            }
            int empId = (int)HttpContext.Session.GetInt32("EmpId");
            timeSheet.EmployeeId = empId;
            timeSheet.StartTime = DateTime.Now;

            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveEndTime(TimeSheet timeSheet)
        {

            int empId = (int)HttpContext.Session.GetInt32("EmpId");

            var row = _context.TimeSheets.Where(s => s.EmployeeId == empId && s.EndTime == null).SingleOrDefault();

            row.EndTime = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
