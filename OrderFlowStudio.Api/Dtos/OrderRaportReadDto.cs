namespace OrderFlowStudio.Api.Dtos
{
    public class OrderRaportReadDto
    {
        public int Id { get; set; }
        public int QuantityFinished { get; set; }
        public ProductionStatusReadDto StatusDto { get; set; }     
    }
}