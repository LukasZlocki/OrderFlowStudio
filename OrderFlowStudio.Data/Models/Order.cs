using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlowStudio.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
          
        [Required]
        [MaxLength(10)]
        public int OrderNumber { get; set; }
       
        [Required]
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public OrderRaport Raport {get; set;}
    }
}