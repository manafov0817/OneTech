using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class SubCategoryModel
    {

    }
    public class SubCategoryAddModel
    {
        public List<MainCategory> MainCategories { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
    public class SubCategoryEditModel
    {
        public List<MainCategory> MainCategories { get; set; }

        public int MainCategoryId { get; set; }


        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
