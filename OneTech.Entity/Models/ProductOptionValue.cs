using System.ComponentModel.DataAnnotations.Schema;

namespace OneTech.Entity.Models
{
    public class ProductOptionValue
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OptionValueId { get; set; }
        public OptionValue OptionValue { get; set; }
    }
}