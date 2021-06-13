using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC.Entities
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public string imageurl { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public int category_id { get; set; }
    }
}
