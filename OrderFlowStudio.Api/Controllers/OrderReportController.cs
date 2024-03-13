using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.OrderReport_Service;
using OrderFlowStudio.Services.Status_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderRaportController : ControllerBase
    {
        private readonly IOrderReportService _orderRaportService;
        private readonly IStatusService _statusService;

        public OrderRaportController(IOrderReportService orderRaportService, IStatusService statusService)
        {
            _orderRaportService = orderRaportService;
            _statusService = statusService;
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

        // UPDATE
        [HttpPatch("api/order/changestatusto/maskinginprogress")]
        public ActionResult UpdateReportStatusesToMaskinginProgress([FromBody] OrderReportReadDto raportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(raportReadDto);
            int _statusMaskingInProgress = 25; // masking in progress status.
            // retriving status model by status number(code)
            var _status = _statusService.GetStatusModelByStatusNumber(_statusMaskingInProgress);
            _report.Status = _status;
            _report.StatusId = _status.StatusId;
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(_report);

            return Ok(serviceResponse);
        }

        // UPDATE
        [HttpPatch("api/order/changestatusto/processingwaiting")]
        public ActionResult UpdateReportStatusesToProcessingWaiting([FromBody] OrderReportReadDto raportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(raportReadDto);
            int _statusProcessingWaiting = 30; // waiting for processing status.
            // retriving status model by status number(code)
            var _status = _statusService.GetStatusModelByStatusNumber(_statusProcessingWaiting);
            _report.Status = _status;
            _report.StatusId = _status.StatusId;
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(_report);

            return Ok(serviceResponse);
        }

        // UPDATE
        [HttpPatch("api/order/changestatusto/processinginprogress")]
        public ActionResult UpdateReportStatusesToProcessingInProgress([FromBody] OrderReportReadDto raportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/correctionwaiting")]
        public ActionResult UpdateReportStatusesToCorrectionWaiting([FromBody] OrderReportReadDto raportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/correctioninprogress")]
        public ActionResult UpdateReportStatusesToCorrectionInProgress([FromBody] OrderReportReadDto raportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/packingwaiting")]
        public ActionResult UpdateReportStatusesToPackingWaiting([FromBody] OrderReportReadDto raportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/packinginprogress")]
        public ActionResult UpdateReportStatusesToPackingInProgress([FromBody] OrderReportReadDto raportReadDto)
        {
            return Ok();
        }

        // DELETE
        // No need to code the functionality !

    }
}
