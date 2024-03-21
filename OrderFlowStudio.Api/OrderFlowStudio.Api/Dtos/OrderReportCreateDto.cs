namespace OrderFlowStudio.Api.Dtos
{
    public class OrderReportCreateDto
    {
        public int QuantityFinished { get; set; }
        public int StatusId {get; set;}
        public ProductionStatusCreateDto StatusDto { get; set; }
    }
}
