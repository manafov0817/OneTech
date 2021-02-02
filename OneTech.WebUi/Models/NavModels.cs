using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Models
{
    public class Nav2Model
    {
        public int ItemCount { get; set; }
        public int ItemsTotal { get; set; }
        public string UserId { get; set; }
        public List<MainCategory> MainCategories { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
