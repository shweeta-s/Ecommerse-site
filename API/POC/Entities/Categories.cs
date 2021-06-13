using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace POC.Entities
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
       
        
    }
}

