namespace OrderFlowStudio.Frontend.Data {
    public class OrderReportReadDto {
        public int Id { get; set; }
        public int QuantityFinished { get; set; }
        public ProductionStatusReadDto StatusDto { get; set; }     
    }
}