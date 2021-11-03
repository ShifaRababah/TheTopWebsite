using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class LoginController : Controller
    {
        private readonly TopContext _context;
        public LoginController(TopContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var dataHome = _context.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            return View();
        }
        [HttpPost]
        //input from user 
        public IActionResult Login(string email, string password)
        {

            var dataHome = _context.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
           


            //if the user is correct 


            var Auth = _context.Logins.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (Auth != null)
            {
                switch (Auth.TypeLogin)
                {
                   //Admin 
                    case 1:
                        {
                            var EmpId = _context.Employees.Where(s => s.Email == email).Select(s => s.Id).SingleOrDefault();
                            HttpContext.Session.SetInt32("EmpId", EmpId);
                            return RedirectToAction("Index", "Admin");
                        }
                   // Accountant
                    case 2:
                        {
                            var EmpId = _context.Employees.Where(s => s.Email == email).Select(s => s.Id).SingleOrDefault();
                            HttpContext.Session.SetInt32("EmpId", EmpId);
                            return RedirectToAction("Index", "Accountant");
                        }
                   //Employee
                    case 3:
                        {
                            var EmpId = _context.Employees.Where(s => s.Email == email).Select(s => s.Id).SingleOrDefault();
                            HttpContext.Session.SetInt32("EmpId", EmpId);
                            return RedirectToAction("Index", "Employee");
                        }

                    //Customer                   
                    case 9:
                        {
                            HttpContext.Session.SetInt32("Id", Auth.UserId.Value);
                            return RedirectToAction("ProductForSale", "Customers");
                        }

                }

            }
            return View();
        }

       

    }
}
