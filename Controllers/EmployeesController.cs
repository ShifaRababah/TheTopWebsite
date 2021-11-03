using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopWebsite.Models;

namespace TheTopWebsite.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly TopContext _context;
       
        public EmployeesController(TopContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SalarySlip()
        {
            // to return Current month

            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            int empId = (int) HttpContext.Session.GetInt32("EmpId");
            double salary = _context.Employees.Where(s => s.Id == empId).Select(s => s.Salary).SingleOrDefault();
            var account = _context.Accounts.Where(s => s.EmployeeId == empId && s.Date >= firstDayOfMonth && s.Date <= lastDayOfMonth).ToList();
            double AccountSum = _context.Accounts.Where(s => s.EmployeeId == empId && s.Date >= firstDayOfMonth && s.Date <= lastDayOfMonth).Sum(s=> s.Value);
            double sum = salary + AccountSum;
            
            dynamic myModel = new ExpandoObject();
            myModel.Salary = salary;
            myModel.Account = account;
            myModel.sum = sum;
            
            return View(myModel);
        }
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Salary,Position,StatusInWebsite")] Employee employee, string email, string password)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
               
                var loginType = _context.Employees.OrderByDescending(x => x.StatusInWebsite).FirstOrDefault().StatusInWebsite;

                Login login = new Login();
                login.TypeLogin = loginType;
                login.Email = email;
                login.Password = password;
                login.UserId = null;
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employees");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Salary,Position,StatusInWebsite")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }


        public async Task<IActionResult> SalaryReport()
        {

            ViewBag.SumSalary = _context.Employees.Sum(s=>s.Salary);
           

            return View(await _context.Employees.ToListAsync());

        }
        public async Task<IActionResult> SalaryReportAcc()
        {

            ViewBag.SumSalary = _context.Employees.Sum(s => s.Salary);


            return View(await _context.Employees.ToListAsync());

        }




    }
}
