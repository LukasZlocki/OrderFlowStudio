using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Services.Status_Service
{
    public interface IStatusService
    {
        // READ
        public int GetStatusIdByStatusNumber(int statusNb);
        public ProductionStatus GetStatusModelByStatusId(int statusId);
        public ProductionStatus GetStatusModelByStatusNumber(int statusNumber);
    }
}