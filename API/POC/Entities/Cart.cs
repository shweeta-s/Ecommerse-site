using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using POC.Helpers;
namespace POC.Entities
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int cart_id { get; set; }
        public int user_id { get; set; }

        //[ModelBinder(BinderType = typeof(TypeBinder<List<Item>>))]
        //public List<Item> items { get; set; }

    }
}
