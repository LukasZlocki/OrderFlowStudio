using OrderFlowStudio.Models;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Services.Status_Service
{
    public class StatusService : IStatusService
    {
        private readonly OrderDbContext _db;

        public StatusService(OrderDbContext db)
        {
            _db = db;
        }

        // READ
        public int GetStatusIdByStatusNumber(int statusNb)
        {
            var status = _db.Statuses.Where(st => st.StatusCode == statusNb).FirstOrDefault();
            int statusId = status.StatusId;
            return statusId;
        }

        public ProductionStatus GetStatusModelByStatusId(int statusId)
        {
            var status = _db.Statuses.Where(id => id.StatusId == statusId).FirstOrDefault();
            return status;
        }

        public ProductionStatus GetStatusModelByStatusNumber(int statusNumber)
        {
            var status = _db.Statuses.Where(nb => nb.StatusCode == statusNumber).FirstOrDefault();
            return status;
        }
    }
}