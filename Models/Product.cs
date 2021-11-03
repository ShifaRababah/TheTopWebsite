using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTopWebsite.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Image { set; get; }
        public DateTime Date { set; get; }
        public string Topic { set; get; }
        public int Price { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
  
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
