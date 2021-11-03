using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class HomeController : Controller
    {

        TopContext DB;
        public HomeController(TopContext context)
        {
            DB = context;
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }

            return View();
        }
        
        public IActionResult ProductForSale()
        {
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            var Result = DB.Categories.ToList();
            return View(Result);           
        }

        public IActionResult ContactUs()
        {
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            return View();
        }
        [HttpPost]
        public IActionResult SaveContactUs(ContactUs contact)
        {
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            DB.Contacts.Add(contact);
            DB.SaveChanges();
            return RedirectToAction("Masseges");
        }

        public IActionResult Masseges()
        {
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            return View(DB.Contacts.ToList());
        }

        public IActionResult Products(int id)
        {
            //if(HttpContext.Session.GetInt32("Id") == null)
            //{
            //    return RedirectToAction("ProductForSale", "Home");
            //}
            var dataHome = DB.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            Category category = DB.Categories.Find(id);
            ViewBag.cat = category.Name;

          
            var Result =  DB.Products.Where(x => x.CategoryId == id).OrderByDescending(x=>x.Date).ToList();
            return View(Result);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult InfoHome()
        {
            var Result = DB.HomePages.ToList();
            return View(Result);
        }

    }
}
