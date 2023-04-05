namespace OrderFlowStudio.Data.Models {
    public class Raport {
        public int RaportId { get; set; }
        public int QuantityFinished { get; set; }
   
        public int StatusId {get; set;}
        public Status Status { get; set; }
    }
}