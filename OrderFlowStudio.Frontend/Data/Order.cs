namespace OrderFlowStudio.Frontend.Data
{
    public class Order
    {
        public int Id { get; set; } 
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public Product productDto{ get; set; }
        public Report reportDto {get; set;}
    }
}

