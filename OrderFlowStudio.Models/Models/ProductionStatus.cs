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
10 - Registered
20 - Waiting for masking
25 - Masking in progress
30 - Waiting for processing
35 - Processing in progress
40 - Waiting for correction
45 - Correction in progress
50 - Waiting for packing
55 - Packing in progress
60 - Finished
*/
