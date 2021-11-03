using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Employee
    {
        
        public int Id { set; get; }       
        public string Name { set; get; }       
        public string Email { set; get; }
        public int PhoneNumber { set; get; }
        public int Salary { set; get; }
        public string Position { get; set; }
        public int StatusInWebsite { get; set; }

        public List<TimeSheet> TimeSheet { get; set; }
        public List<TaskEmp> Task { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
