namespace OrderFlowStudio.Api.Dtos
{
    public class OrderOnCreate
    {
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public string ProductNumber { get; set; }
    }
}