using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class ProductReview
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}