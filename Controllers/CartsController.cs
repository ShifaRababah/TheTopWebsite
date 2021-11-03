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
    public class CartsController : Controller
    {
        private readonly TopContext _context;

        public CartsController(TopContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
          
            var topContext = _context.Carts.Include(c => c.Customer).Include(c => c.Product);
            return View(await topContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Price");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,CustomerId,ProductId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Price", cart.ProductId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Price", cart.ProductId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,CustomerId,ProductId")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Price", cart.ProductId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CheckOut));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
        // to view balace of customer and total price of all product in his cart

        public async Task<IActionResult> CheckOut()
        {

            int customerId = (int)HttpContext.Session.GetInt32("Id");
            float sum = 0;
            foreach (Cart cart in _context.Carts)
            {
                int p_id = cart.ProductId;
                int price = _context.Products.Where(s => s.Id == p_id).Select(s => s.Price).SingleOrDefault();
                sum += price;


            }
            // to show sum of product and balance for this customer
            ViewBag.SumPrice = sum;
            ViewBag.SumBalance = _context.Banks.Where(c => c.CustomerId == customerId).Sum(c => c.Balance);
            

            var topContext = _context.Carts.Include(c => c.Customer).Include(c => c.Product);
            return View(await topContext.ToListAsync());
        }
        

        // To Buy Product & update balance and order tables

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut([Bind("Cupon")] int? cupon)
        {
            
            int customerId = (int) HttpContext.Session.GetInt32("Id");
           
            var balance =  _context.Banks.Where(s => s.CustomerId == customerId).Select(s => s.Balance).SingleOrDefault();
            var bank =  _context.Banks.Where(s => s.CustomerId == customerId).SingleOrDefault();
            float sum = 0;
            foreach( Cart cart in _context.Carts.Where(s=>s.CustomerId == customerId))
            {
                int p_id = cart.ProductId;
                int price = _context.Products.Where(s => s.Id == p_id).Select(s=> s.Price).SingleOrDefault();
                sum += price;


            }
            
            if (cupon!= null)
            {
                if (_context.Coupons.Where(s => s.Code == Convert.ToInt32(cupon)).Select(s => s.Discount).Count() != 0)
                {
                    float cuponValue = _context.Coupons.Where(s => s.Code == Convert.ToInt32(cupon)).Select(s => s.Discount).SingleOrDefault();
                    sum = sum * (1-cuponValue);
                }
                else
                {
                    return Content("Invalid Coupon"+cupon);
                }
            }
            if (balance < sum)
            {

              
                return RedirectToAction("FailedPurchase", "Carts");
            }

           

            float profit = 0.1F;
            _context.Orders.Add(new Order
            {
                Total = sum,
                Date = DateTime.Now,
                CustomerId = customerId,
                Profit = sum * profit
            }
                ) ;

            _context.Carts.RemoveRange(_context.Carts.Where(s => s.CustomerId == customerId));

            bank.Balance = balance - sum;

            _context.SaveChanges();
         
            return RedirectToAction("SuccessPurchase","Carts");



           
          


        }



        public async Task<IActionResult> SuccessPurchase()
        {
          
            return View();
        }

        public async Task<IActionResult> FailedPurchase()
        {

            return View();
        }

    }
}
