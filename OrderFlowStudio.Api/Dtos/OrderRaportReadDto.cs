namespace OrderFlowStudio.Api.Dtos
{
    public class OrderRaportReadDto
    {
        public int Id { get; set; }
        public ProductionStatusReadDto Status { get; set; }     
        public OrderReadDto OrderDto { get; set; }
    }
}