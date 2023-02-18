namespace OrderFlowStudio.Api.Dtos
{
    public class OrderCreateDto
    {
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int RaportId { get; set; }
    }
}