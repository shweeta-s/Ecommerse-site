using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC.DTOs
{
    public class CartCreationDTO
    {
        [Key]
        public int cart_id { get; set; }        // date time
        public int user_id { get; set; }
    }
}
