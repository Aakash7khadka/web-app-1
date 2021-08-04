using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_app1.Models
{
    public class Users
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string name { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
