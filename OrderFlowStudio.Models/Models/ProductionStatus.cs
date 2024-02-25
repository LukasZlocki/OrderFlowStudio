using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Models.Models
{
    public class ProductionStatus
    {
        [Key]
        public int StatusId { get; set; }
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
    }
}
