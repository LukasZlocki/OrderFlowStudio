using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.OrderRaport_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderRaportController : ControllerBase
    {
        private readonly IOrderRaportService _orderRaportService;

        public OrderRaportController(IOrderRaportService orderRaportService)
        {
            _orderRaportService = orderRaportService;
        }

        // CREATE
        [HttpPost("api/raport")]
        public ActionResult CreateRaport([FromBody] OrderRaportCreateDto raportReadDto)
        {
            var orderRaport = OrderRaportMapper.SerializeOrderRaportReadDtoToOrderRaport(raportReadDto);
            var serviceResponse = _orderRaportService.AddOrderRaport(orderRaport);
            return Ok(serviceResponse);
        }

        // READ
        [HttpGet("api/raport/{id}")]
        public ActionResult GetRaport(int id)
        {
            var raport = _orderRaportService.GetOrderRaportById(id);
            var raportReadDto = OrderRaportMapper.SerializeOrderRaportToOrderRaportReadDto(raport);
            return Ok(raportReadDto);
        }

        // READ
        [HttpGet("api/raport")]
        public ActionResult GetRaports()
        {
            var raports = _orderRaportService.GetAllOrderRaports();
            var raportsReadDto = OrderRaportMapper.SerializeListOfOrderRaportsToOrderRaportReadDtoList(raports);
            return Ok(raportsReadDto);
        }

        // UPDATE
        [HttpPatch("api/raport")]
        public ActionResult UpdateRaportStatuses([FromBody] OrderRaportReadDto raportReadDto)
        {
            var raport = OrderRaportMapper.SerializeStatusesOnlyOfOrderRaportReadDtoToOrderRaport(raportReadDto);
            var serviceResponse = _orderRaportService.UpdateOrderRaportStatuses(raport);
            return Ok(serviceResponse);

        }

        // DELETE
        // No need to code the functionality !
        
    }
}