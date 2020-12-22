using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class CategoryModel
    {
        public List<MainCategory> MainCategory { get; set; }
    }
    public class CategoryAddModel
    {
        public List<MainCategory> MainCategory { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MainCategoryId { get; set; }
    }
    public class CategoryEditModel
    {
        public List<MainCategory> MainCategory { get; set; }


        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MainCategoryId { get; set; }
    }
}
