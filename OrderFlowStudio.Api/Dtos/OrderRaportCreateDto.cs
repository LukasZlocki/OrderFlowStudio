namespace OrderFlowStudio.Api.Dtos
{
    public class OrderRaportCreateDto
    {
        public int QuantityFinished { get; set; }
        public ProductionStatusCreateDto StatusDto { get; set; }
    }
}
