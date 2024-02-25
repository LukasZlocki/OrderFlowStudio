using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Models.Models
{
    public class OrderReport
    {
        [Key]
        public int Id { get; set; }
        public int QuantityFinished { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ProductionStatus? Status { get; set; }
    }
}
