using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class TopContext : DbContext
    {
        public TopContext(DbContextOptions<TopContext> options)
            : base(options)
        {
        }



       
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
       
        
        public DbSet<Product> Products { get; set; }
       
        public DbSet<TaskEmp> Tasks { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Login> Logins { get; set; }
        
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Bank> Banks { get; set; }
       
        public DbSet<InfoHomePage> HomePages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Account> Accounts { get; set; }











    }
}
