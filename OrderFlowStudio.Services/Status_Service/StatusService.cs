using System.Linq;
using OrderFlowStudio.Data;

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
    }
}