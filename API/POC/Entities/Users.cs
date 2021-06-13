using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace POC.Entities
{
    public class Users
    {
        [Key]
        public string email { get; set; }
        [Required]             
        public string name { get; set; }

        
    }
}

