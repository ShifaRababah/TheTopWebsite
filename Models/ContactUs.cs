using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class ContactUs
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }             
        public string Subject { set; get; }
        public string Message { set; get; }
    }
}
