using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class OptionValueModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int OptionId { get; set; }
    }
    public class OptionValueEditModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int OptionId { get; set; }
    }
}
