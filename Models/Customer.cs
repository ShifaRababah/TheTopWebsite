using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Customer
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public int PhoneNumber { set; get; }
        public string PesonalImage { set; get; }


       
        public List<Login> Logins { get; set; }
       
        public List<Bank> Banks { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }

    }
}
