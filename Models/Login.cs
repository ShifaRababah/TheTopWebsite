using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Login
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public int TypeLogin { set; get; }
      

        [ForeignKey("Customer")]

        public int ? UserId { get; set; }
        public Customer Customer { get; set; }
    }
}
