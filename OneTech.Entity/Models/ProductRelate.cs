using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class ProductRelate
    {
        public Relate Relate { get; set; }
        public int RelateId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
