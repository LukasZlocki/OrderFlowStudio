namespace OrderFlowStudio.Frontend.Data
{
    public class Report
    {
        public int Id { get; set; }
        public int QuantityFinished { get; set; }
        public int OrderId { get; set; }
        public ProductionStatus statusDto { get; set; }
    }
}
