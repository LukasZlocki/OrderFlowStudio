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
        public ActionResult CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var order = OrderMapper.SerializeOrderCreateDtoToOrder(orderCreateDto);
            var serviceResponse = _orderservice.AddOrder(order);
            return Ok(serviceResponse);
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

        // READ
        [HttpGet("api/order/byordernumber/{id}")]
        public ActionResult GetOrderRaportIdByOrderNb(int id)
        {
            var orderRaportId = _orderservice.GetOrderRaportIdByOrderNb(id);
            return Ok(orderRaportId);
        }

        // READ
        [HttpGet("api/order/maskingmodule")]
        public ActionResult GetOrdersNotStartedInSystem()
        {
            var orders = _orderservice.GetOrdersFilteredForMaskingArea();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        /* NO NEED TO UPDATE ORDER , BUT IN FUTURE UPDATES ONLY ON SPECIFIC NEED AND DO IT BY Id 
        // UPDATE 
        [HttpPatch("/api/order")]
        public ActionResult UpdateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var order = OrderMapper.SerializeOrderCreateDtoToOrder(orderCreateDto);
            var serviceResponse = _orderservice.UpdateOrder(order);
            return Ok(serviceResponse);
        }
        */

        // DELETE
        // nothink to code here !
        
    }
}