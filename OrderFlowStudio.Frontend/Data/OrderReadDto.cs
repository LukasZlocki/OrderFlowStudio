namespace OrderFlowStudio.Frontend.Data {
    public class OrderReadDto {     
        public int Id { get; set; } 
        public int OrderNumber { get; set; } 
        public int Quantity { get; set; }
        public ProductReadDto ProductDto { get; set; }
        public OrderReportReadDto ReportDto {get; set;}
    }
}