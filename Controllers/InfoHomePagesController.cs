using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class InfoHomePagesController : Controller
    {
        private readonly TopContext _context;
        private readonly IWebHostEnvironment _HostEnvironment;


        public InfoHomePagesController(TopContext context, IWebHostEnvironment _HostEnvironment)
        {
            this._context = context;
            this._HostEnvironment = _HostEnvironment;
        }

        // GET: InfoHomePages
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.HomePages.ToListAsync());
        }

        // GET: InfoHomePages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoHomePage = await _context.HomePages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoHomePage == null)
            {
                return NotFound();
            }

            return View(infoHomePage);
        }

        // GET: InfoHomePages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoHomePages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CallUs,Email,Logo,ImageFile")] InfoHomePage infoHomePage)
        {
            if (ModelState.IsValid)
            {
                if (infoHomePage.ImageFile != null)
                {
                    string wwwRootPath = _HostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + infoHomePage.ImageFile.FileName;
                    string extension = Path.GetExtension(infoHomePage.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/imgs/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await infoHomePage.ImageFile.CopyToAsync(fileStream);
                    }
                    infoHomePage.Logo = fileName;

                  
                }
               
                _context.Add(infoHomePage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoHomePage);
        }

        // GET: InfoHomePages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoHomePage = await _context.HomePages.FindAsync(id);
            if (infoHomePage == null)
            {
                return NotFound();
            }
            return View(infoHomePage);
        }

        // POST: InfoHomePages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CallUs,Email,Logo,ImageFile")] InfoHomePage infoHomePage)
        {
            if (id != infoHomePage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (infoHomePage.ImageFile != null)
                {
                    string wwwRootPath = _HostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + infoHomePage.ImageFile.FileName;
                    string extension = Path.GetExtension(infoHomePage.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/imgs/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await infoHomePage.ImageFile.CopyToAsync(fileStream);
                    }
                    infoHomePage.Logo = fileName;


                }
                try
                {
                    _context.Update(infoHomePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoHomePageExists(infoHomePage.Id))
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
            return View(infoHomePage);
        }

        // GET: InfoHomePages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoHomePage = await _context.HomePages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoHomePage == null)
            {
                return NotFound();
            }

            return View(infoHomePage);
        }

        // POST: InfoHomePages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoHomePage = await _context.HomePages.FindAsync(id);
            _context.HomePages.Remove(infoHomePage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoHomePageExists(int id)
        {
            return _context.HomePages.Any(e => e.Id == id);
        }




        public IActionResult InfoHome()
        {

            var Result = _context.HomePages.ToList();
            return View(Result);
        }


    }


}
