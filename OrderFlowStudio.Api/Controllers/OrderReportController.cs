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

        public OrderRaportController(IOrderReportService orderReportService, IStatusService statusService)
        {
            _orderRaportService = orderReportService;
            _statusService = statusService;
        }

        // READ
        [HttpGet("api/raport/{id}")]
        public ActionResult GetRaport(int id)
        {
            var report = _orderRaportService.GetOrderReportById(id);
            var reportReadDto = OrderReportMapper.SerializeOrderReportToOrderReportReadDto(report);
            return Ok(reportReadDto);
        }

        // READ
        [HttpGet("api/raport")]
        public ActionResult GetRaports()
        {
            var reports = _orderRaportService.GetAllOrderReports();
            var reportsReadDto = OrderReportMapper.SerializeListOfOrderReportsToOrderReportReadDtoList(reports);
            return Ok(reportsReadDto);
        }

        // UPDATE
        [HttpPatch("api/raport")]
        public ActionResult UpdateRaportStatuses([FromBody] OrderReportReadDto reportReadDto)
        {
            var report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(reportReadDto);
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(report);
            return Ok(serviceResponse);

        }

        // UPDATE
        [HttpPatch("api/order/changestatusto/maskinginprogress")]
        public ActionResult UpdateReportStatusesToMaskinginProgress([FromBody] OrderReportReadDto reportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(reportReadDto);
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
        public ActionResult UpdateReportStatusesToProcessingInProgress([FromBody] OrderReportReadDto reportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(reportReadDto);
            int _statusProcessingInProgress = 35; // processing in progress status.
            // retriving status model by status number(code)
            var _status = _statusService.GetStatusModelByStatusNumber(_statusProcessingInProgress);
            _report.Status = _status;
            _report.StatusId = _status.StatusId;
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(_report);

            return Ok(serviceResponse);
        }

        [HttpPatch("api/order/changestatusto/correctionwaiting")]
        public ActionResult UpdateReportStatusesToCorrectionWaiting([FromBody] OrderReportReadDto reportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/correctioninprogress")]
        public ActionResult UpdateReportStatusesToCorrectionInProgress([FromBody] OrderReportReadDto reportReadDto)
        {
            return Ok();
        }

        [HttpPatch("api/order/changestatusto/packingwaiting")]
        public ActionResult UpdateReportStatusesToPackingWaiting([FromBody] OrderReportReadDto reportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(reportReadDto);
            int _statusPackingWaiting = 50; // waiting for packing status
            // retriving status model by status number(code)
            var _status = _statusService.GetStatusModelByStatusNumber(_statusPackingWaiting);
            _report.Status = _status;
            _report.StatusId = _status.StatusId;
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(_report);

            return Ok(serviceResponse);
        }

        [HttpPatch("api/order/changestatusto/packinginprogress")]
        public ActionResult UpdateReportStatusesToPackingInProgress([FromBody] OrderReportReadDto reportReadDto)
        {
            var _report = OrderReportMapper.SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport(reportReadDto);
            int _statusPackingWaiting = 55; // packing in progress status
            // retriving status model by status number(code)
            var _status = _statusService.GetStatusModelByStatusNumber(_statusPackingWaiting);
            _report.Status = _status;
            _report.StatusId = _status.StatusId;
            var serviceResponse = _orderRaportService.UpdateOrderReportStatuses(_report);

            return Ok(serviceResponse);
        }

        // DELETE
        // No need to code the functionality !

    }
}
