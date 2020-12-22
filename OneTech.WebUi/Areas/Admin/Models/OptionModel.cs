using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class OptionModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class OptionEditModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
