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
    public class TaskEmpsController : Controller
    {
        private readonly TopContext _context;

        public TaskEmpsController(TopContext context)
        {
            _context = context;
        }

        // GET: TaskEmps
        public async Task<IActionResult> Index()
        {
            var topContext = _context.Tasks.Include(t => t.Employee);
            return View(await topContext.ToListAsync());
        }

        public async Task<IActionResult> TaskForEmp()
        {
            
            if(HttpContext.Session.GetInt32("EmpId") == null)
            {
                return Content("Please Login");
            }
            int empId = (int)HttpContext.Session.GetInt32("EmpId");


            var topContext = _context.Tasks.Where(s => s.EmployeeId == empId).Include(t => t.Employee);
            return View(await topContext.ToListAsync());
        }

        // GET: TaskEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEmp = await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEmp == null)
            {
                return NotFound();
            }

            return View(taskEmp);
        }

        // GET: TaskEmps/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
            return View();
        }

        // POST: TaskEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Description,EmployeeId")] TaskEmp taskEmp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskEmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", taskEmp.EmployeeId);
            return View(taskEmp);
        }

        // GET: TaskEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEmp = await _context.Tasks.FindAsync(id);
            if (taskEmp == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", taskEmp.EmployeeId);
            return View(taskEmp);
        }

        // POST: TaskEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Description,EmployeeId")] TaskEmp taskEmp)
        {
            if (id != taskEmp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEmpExists(taskEmp.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", taskEmp.EmployeeId);
            return View(taskEmp);
        }

        // GET: TaskEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEmp = await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEmp == null)
            {
                return NotFound();
            }

            return View(taskEmp);
        }

        // POST: TaskEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskEmp = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEmpExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

    }
}
