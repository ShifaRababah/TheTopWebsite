using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class TimeSheet
    {
        public int Id { get; set;}
        public DateTime ? StartTime{ get; set; }
        public DateTime ? EndTime { get; set; }


        //public int Type { get; set; } //login=1; logout=2

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }





    }
}
