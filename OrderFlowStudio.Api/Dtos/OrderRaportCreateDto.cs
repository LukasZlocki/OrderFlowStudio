namespace OrderFlowStudio.Api.Dtos
{
    public class OrderRaportCreateDto
    {
        public int QuantityFinished { get; set; }
        public bool isStarted { get; set; } // Order is started and ready for masking
        public bool isMasked { get; set; } // Order is masked and ready for processing
        public bool isProcessed { get; set; } // Order processed and ready for quality inspection
        public bool isProcessOK { get; set; } // Is Q inspection OK
        public bool isCorrectionStarted { get; set; } // Q inspection NOK - start correction
        public bool isCorrectionFinished { get; set; } // Q inspection NOK - finish correction
        public bool isOrderFinished { get; set; } // order finished and sent to packing area
    }
}