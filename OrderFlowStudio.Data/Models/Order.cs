using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Data.Models {
    public class Order {
        public int Id { get; set; } 
        [Required]
        [MaxLength(10)]
        public int OrderNumber { get; set; } 
        [Required]
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int RaportId { get; set; }
        public Raport Raport {get; set;}
    }
}