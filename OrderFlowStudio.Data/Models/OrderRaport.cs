using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlowStudio.Data.Models
{
    public class OrderRaport
    {
        [Key]
        public int Id { get; set; }
        public int QuantityFinished { get; set; }
        public bool isStarted { get; set; } // Order is started and ready for masking
        public bool isMasked { get; set; } // Order is masked and ready for processing
        public bool isProcessed { get; set; } // Order processed and ready for quality inspection
        public bool isProcessOK { get; set; } // Is Q inspection OK
        public bool isCorrectionStarted { get; set; } // Q inspection NOK - start correction
        public bool isCorrectionFinished { get; set; } // Q inspection NOK - finish correction
        public bool isOrderFinished { get; set; } // order finished and sent to packing area
        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int StatusId {get; set;}
        [ForeignKey("StatusId")]
        public ProductionStatus Status { get; set; }
    }
}