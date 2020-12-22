using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class ColorModel
    {
        [Required]
        public string HexCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class ColorEditModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string HexCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
