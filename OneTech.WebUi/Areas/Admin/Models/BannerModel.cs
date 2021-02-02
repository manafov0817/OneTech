using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class BannerModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Slogan { get; set; }
    }
}
