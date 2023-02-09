using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlowStudio.Data.Models
{
    public class OrderRaport
    {
        [Key]
        public int Id { get; set; }
        public int QuantityFinished { get; set; }
   
        public int OrderId { get; set; }

        public int StatusId {get; set;}
        [ForeignKey("StatusId")]
        public ProductionStatus Status { get; set; }
    }
}