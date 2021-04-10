namespace OrderFlowStudio.Api.Dtos
{
    public class OrderCreateDto
    {
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public ProductCreateDto ProductDto { get; set; }
        public OrderRaportCreateDto RaportDto {get; set;}
    }
}