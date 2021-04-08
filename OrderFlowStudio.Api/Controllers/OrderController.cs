using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.Order_Service;

namespace OrderFlowStudio.Api.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        private readonly ILogger _logger;

        // CREATE
        [HttpPost("api/order")]
        public ActionResult CreateOrder(OrderRaportReadDto orderRaportDto)
        {
            return Ok();
        }

        // READ
        [HttpGet("api/order/{id}")]
        public ActionResult GetOrderById(int id)
        {
            var order = _orderservice.GetOrderById(id);
            var orderDto = OrderMapper.SerializeOrderToOrderReadDto(order);
            return Ok(orderDto);
        }

        // UPDATE

        // DELETE
        // nothink to code here !
        
    }
}