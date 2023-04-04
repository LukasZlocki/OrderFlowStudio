using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Services.Status_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class ProductionStatusController : ControllerBase {
        private readonly IStatusService _statusService;
        
        public ProductionStatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // READ
        [HttpGet("api/statusobject/{id}")]
        public ActionResult GetStatusObjectByStatusCode(int id) {
            var statusService = _statusService.GetProductionStatusObjectByStatusCode(id);
            return Ok(statusService);
        }

    }
}
