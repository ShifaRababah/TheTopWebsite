using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class ProductsController : Controller
    {

        private readonly TopContext _context;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ProductsController(TopContext context, IWebHostEnvironment _HostEnvironment)
        {
           this._context = context;
            this._HostEnvironment = _HostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var topContext = _context.Products.Include(p => p.Category);
            return View(await topContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,Date,Topic,Price,CategoryId,CustomerId,ImageFile")] Product product)
        {
            Console.WriteLine(product);
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    string wwwRootPath = _HostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() +"_"+ product.ImageFile.FileName;
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/imgs/" + fileName);
                     using (var fileStream= new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                    product.Image = fileName;

                   
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
           
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
          
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,Date,Topic,Price,CategoryId,CustomerId,ImageFile")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    string wwwRootPath = _HostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/imgs/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                    product.Image = fileName;


                }

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        
        public IActionResult SearchByName()
        {
            var dataHome = _context.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }
            return View ();
        }
        [HttpPost]
        public IActionResult SearchByName(string ProCategory)
        {
            var dataHome = _context.HomePages.ToList();
            foreach (var item in dataHome)
            {
                ViewBag.logo = item.Logo;
                ViewBag.call = item.CallUs;
                ViewBag.email = item.Email;
            }


            List<Product> list = _context.Products.Where(x => x.Title.Contains(ProCategory)).ToList();
            Console.WriteLine(list);

            return View(list);
        }



        public IActionResult SearchAfterLogin()
        {
            ViewBag.Count = _context.Carts.Count();
            return View();
        }
        [HttpPost]
        public IActionResult SearchAfterLogin(string ProCategory)
        {
            ViewBag.Count = _context.Carts.Count();
            List<Product> list = _context.Products.Where(x => x.Title.Contains(ProCategory)).ToList();
            Console.WriteLine(list);

            return View(list);
        }





        // Add new product for Customer
        // GET: Products/Create
        public IActionResult AddProduct()
        {
            ViewBag.Count = _context.Carts.Count();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([Bind("Id,Title,Image,Date,Topic,Price,CategoryId,CustomerId,ImageFile")] Product product)
        {
            Console.WriteLine(product);
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    string wwwRootPath = _HostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/imgs/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                    product.Image = fileName;


                }
                _context.Add(product);
                await _context.SaveChangesAsync();
               
                return RedirectToAction("ProductForSale", "Customers");
               
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        public async Task<ActionResult> AddCart(int id)
        {
            ViewBag.Count = _context.Carts.Count();
            var product = _context.Products.Where(p => p.Id == id).Include(p => p.Category)
                           .AsNoTracking().SingleOrDefault();

            _context.Carts.Add(
                   new Cart
                   {
                       ProductId = product.Id,
                       Date = DateTime.Now,
                       CustomerId = (int) HttpContext.Session.GetInt32("Id"),

                   }
                 );
            _context.SaveChanges();
            return RedirectToAction("ProductForSale", "Customers");
        }





    }
}
