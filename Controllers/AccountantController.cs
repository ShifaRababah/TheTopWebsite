using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class AccountantController : Controller
    {
   
        private readonly TopContext _context;
        public AccountantController(TopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          

            return View();
        }
        // get CustomersInformation
        public IActionResult CustomersInfo()
        {
            var Result = _context.Customers.ToList();
            return View(Result);
        }
        // to save login time 
        [HttpPost]
        public IActionResult SaveStartTime(TimeSheet timeSheet)
        {
            if(HttpContext.Session.GetInt32("EmpId") == null)
            {
                return Content("Please Login");
            }
            int empId = (int)HttpContext.Session.GetInt32("EmpId");
            timeSheet.EmployeeId = empId;
            timeSheet.StartTime= DateTime.Now;
           
            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       // to save logout time
        [HttpPost]
        public IActionResult SaveEndTime(TimeSheet timeSheet)
        {

            int empId = (int)HttpContext.Session.GetInt32("EmpId");

            var row = _context.TimeSheets.Where(s => s.EmployeeId == empId && s.EndTime == null).SingleOrDefault();

            row.EndTime = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Account()
        {


            return View();
        }
    }
}
