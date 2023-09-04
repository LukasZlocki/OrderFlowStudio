using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Data.Models {
    public class Product {
        public int ProductId { get; set; }     
        [Required]
        [MaxLength(10)]
        public string PartNumber { get; set; }  
        [Required]
        [MaxLength(10)]
        public string ProductDescription { get; set; }
    }
}