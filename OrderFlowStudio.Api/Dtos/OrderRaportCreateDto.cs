namespace OrderFlowStudio.Api.Dtos
{
    public class OrderRaportCreateDto
    {
        public int QuantityFinished { get; set; }
        public ProductionStatusReadDto Status { get; set; }
    }
}