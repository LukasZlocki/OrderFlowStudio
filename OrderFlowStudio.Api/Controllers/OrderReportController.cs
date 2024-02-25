using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.OrderReport_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderRaportController : ControllerBase
    {
        private readonly IOrderReportService _orderRaportService;

        public OrderRaportController(IOrderReportService orderRaportService)
        {
            _orderRaportService = orderRaportService;
        }

        // READ
        [HttpGet("api/raport/{id}")]
        public ActionResult GetRaport(int id)
        {
            var raport = _orderRaportService.GetOrderReportById(id);
            var raportReadDto = OrderReportMapper.SerializeOrderReportToOrderReportReadDto(raport);
            return Ok(raportReadDto);
        }

        // READ
        [HttpGet("api/raport")]
        public ActionResult GetRaports()
        {
            var raports = _orderRaportService.GetAllOrderReports();
            var raportsReadDto = OrderReportMapper.SerializeListOfOrderReportsToOrderReportReadDtoList(raports);
            return Ok(raportsReadDto);
        }

        // UPDATE
        [HttpPatch("api/raport")]
        public ActionResult UpdateRaportStatuses([FromBody] OrderReportReadDto raportReadDto)
        {
            var raport = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(raportReadDto);
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(raport);
            return Ok(serviceResponse);

        }

        // DELETE
        // No need to code the functionality !

    }
}
