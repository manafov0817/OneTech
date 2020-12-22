using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class OptionValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
        public List<ProductOptionValue> ProductOptionValues { get; set; }
    }
}
