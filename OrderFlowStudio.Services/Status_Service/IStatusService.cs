using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.Status_Service
{
    public interface IStatusService
    {
         // READ
         public int GetStatusIdByStatusNumber(int statusNb);
         public List<ProductionStatus> GetListOfProductionStatuses();
         public ProductionStatus GetProductionStatusByStatusCode(int statusCode);
    }
}