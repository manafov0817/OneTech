using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
   public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
    }
}
