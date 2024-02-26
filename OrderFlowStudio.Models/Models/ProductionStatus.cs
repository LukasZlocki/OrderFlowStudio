using System.ComponentModel.DataAnnotations;

namespace OrderFlowStudio.Models.Models
{
    public class ProductionStatus
    {
        [Key]
        public int StatusId { get; set; }
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
    }
}

/*
Status Code:
10 - Not started
20 - Masking
30 - Processing
40 - Correction 
50 - Packing
70 - Finished
*/
