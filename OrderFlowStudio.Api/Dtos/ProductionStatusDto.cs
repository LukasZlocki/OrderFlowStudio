namespace OrderFlowStudio.Api.Dtos
{
    public class ProductionStatusDto
    {
        public int StatusCode { get; set; }
    }
}

/*
Status Code:
10 - Not in area
20 - Masking
30 - Processing
40 - Correction 
50 - Correction finished
60 - Almost done
70 - Finished
*/