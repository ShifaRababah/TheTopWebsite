using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class TaskEmp
    {
        public int Id { set; get; }
        public string Name { set; get; }
   
        public DateTime Date { set; get; }
        public string Description { set; get; }

        [ForeignKey("Employee")]
        public int ? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
