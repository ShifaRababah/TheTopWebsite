using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Account
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { set; get; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }


    }
}
