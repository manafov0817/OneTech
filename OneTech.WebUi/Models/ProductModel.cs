using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
