using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Text { get; set; }
        public int? Rate { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public List<ProductReview> ProductReviews { get; set; }

    }
}
