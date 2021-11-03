using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class CustomersController : Controller
    {
        private readonly TopContext _context;
        const string id = "Id";
        public CustomersController(TopContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32(id);
            return View(await _context.Customers.ToListAsync());
            
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,PesonalImage")] Customer customer,string email ,string password)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                var LastId = _context.Customers.OrderByDescending(x => x.Id).FirstOrDefault().Id;

                Login login = new Login();
                login.TypeLogin = 9;
                login.Email = email;
                login.Password = password;
                login.UserId = LastId;
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");



            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,PesonalImage")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }






        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            ViewBag.Count = _context.Carts.Count();
            return View();
        }
        [HttpPost]
        public IActionResult SaveContactUs(ContactUs contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Masseges");
        }

        public IActionResult Masseges()
        {
            ViewBag.Count = _context.Carts.Count();
            return View(_context.Contacts.ToList());
        }



        public IActionResult ProductForSale()
        {
            ViewBag.Count = _context.Carts.Count();
            var Result = _context.Categories.ToList();
            return View(Result);
        }



        public IActionResult Products(int id)
        {
            ViewBag.Count = _context.Carts.Count();
            Category category = _context.Categories.Find(id);
            ViewBag.cat = category.Name;


            var Result = _context.Products.Where(x => x.CategoryId == id).OrderByDescending(x => x.Date).ToList();
            return View(Result);
        }


        public IActionResult ShowAllProducts()
        {
            ViewBag.Count = _context.Carts.Count();
            var Result = _context.Products.OrderByDescending(x => x.Date).ToList();
            return View(Result);
        }



       
    }
}
