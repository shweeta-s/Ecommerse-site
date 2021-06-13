using System.ComponentModel.DataAnnotations;
namespace POC.Entities
{
    
    public class Item
    {
        public int cart_id { get; set; }
        public  int product_id { get; set; }
        public int quantity { get; set; }
    }
}
