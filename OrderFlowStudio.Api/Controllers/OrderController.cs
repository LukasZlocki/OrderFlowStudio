using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.Order_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;

        public OrderController(IOrderService orderService)
        {
            _orderservice = orderService;
        }

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

                // READ
        [HttpGet("api/order")]
        public ActionResult GetOrders(int id)
        {
            var orders = _orderservice.GetAllOrders();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // UPDATE

        // DELETE
        // nothink to code here !
        
    }
}