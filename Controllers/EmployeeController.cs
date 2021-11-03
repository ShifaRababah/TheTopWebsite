using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TopContext _context;


        public EmployeeController(TopContext context)
        {
            this._context = context;

        }

        public IActionResult Index()
        {
            return View();
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
