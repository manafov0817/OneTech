using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public List<ProductPhoto> ProductPhotos { get; set; }
    }
}
