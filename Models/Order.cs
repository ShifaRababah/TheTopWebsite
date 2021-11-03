using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public DateTime Date { get; set; }
        public float Profit { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public List<OrderProduct> OrderProducts { get; set; }

    }
}
