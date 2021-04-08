namespace OrderFlowStudio.Api.Dtos
{
    public class OrderReadDto 
    {     
        public int Id { get; set; } 
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public ProductReadDto ProductDto { get; set; }
        public OrderRaportReadDto RaportDto {get; set;}
    }
}