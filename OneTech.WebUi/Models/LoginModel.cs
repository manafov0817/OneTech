using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
