using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlowStudio.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string PartNumber { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string ProductDescription { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order {get; set;}
    }
}