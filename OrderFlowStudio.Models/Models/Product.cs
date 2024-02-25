using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? PartNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string? ProductDescription { get; set; }
    }
}
