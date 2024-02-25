using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Models.Models
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

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int RaportId { get; set; }
        [ForeignKey("RaportId")]
        public OrderReport? Raport { get; set; }
    }
}
