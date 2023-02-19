using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.Order_Service;
using OrderFlowStudio.Services.OrderRaport_Service;
using OrderFlowStudio.Services.Product_Service;
using OrderFlowStudio.Services.Status_Service;
using static System.Convert;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRaportService _raportService; 
        private readonly IProductService _productService;
        private readonly IStatusService _statusService;

        public OrderController(IOrderService orderService, IOrderRaportService raportService, IProductService productService, IStatusService statusService)
        {
            _orderService = orderService;
            _raportService = raportService;
            _productService = productService;
            _statusService = statusService;
        }


        // CREATE
        [HttpPost("api/addorder")]
        public ActionResult CreateOrder([FromBody] OrderOnCreate orderOnCreateDto)
        {  
            /* I 've just find out that I need to remodel db in order to be able to create new orders. - I wll remodel db on separate branch and get back as soon as remodeling is prepared
            // 1 - extract product id from db by product number
            int productId = _productService.GetProductIdByProductNumber(orderOnCreateDto.ProductNumber);

            // 2 - extract status id from db : status "Not started" - status nb: '15' by retriving its id from db.
            int StatusIdFromDb = _statusService.GetStatusIdByStatusNumber(15);

            // 3 - create new raport in db and retrive its id (raport id)
            OrderRaportCreateDto raportCreateDto = new OrderRaportCreateDto() { StatusDto = new ProductionStatusCreateDto() };
            raportCreateDto.QuantityFinished = 0; // it is starting raport
            raportCreateDto.StatusDto.StatusId = StatusIdFromDb;
            var raport = OrderRaportMapper.SerializeOrderRaportCreateDtoToOrderRaport(raportCreateDto);
            var serviceResponseRaport = _raportService.AddOrderRaport(raport);       
            // Get raport id in order to add it to new order
            int raportId = serviceResponseRaport.Data.OrderId;

            // 4- Assembly all needed data to orderCreateDto object and create new order in db
            OrderCreateDto orderCreateDto = new OrderCreateDto();
            orderCreateDto.OrderNumber = orderOnCreateDto.OrderNumber;
            orderCreateDto.Quantity = orderOnCreateDto.Quantity;
            orderCreateDto.ProductId = productId;
            orderCreateDto.RaportId = raportId;
            // serialize data to order object
            var order = OrderMapper.SerializeOrderCreateDtoToOrder(orderCreateDto);
            // create new order in db
            var serviceResponse = _orderService.AddOrder(order);
            */
            var serviceResponse = false;
            return Ok(serviceResponse);
        }

        // READ
        [HttpGet("api/order/{id}")]
        public ActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            var orderDto = OrderMapper.SerializeOrderToOrderReadDto(order);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order")]
        public ActionResult GetOrders(int id)
        {
            var orders = _orderService.GetAllOrders();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ 
        [HttpGet("api/order/getorderid/{id}")]
        public ActionResult GetOrderIdByOrderNb(int id)
        {
            int _intOrderNb = id;
            int orderId = _orderService.GetOrderIdByOrderNb(_intOrderNb);
            return Ok (orderId);
        }

        // READ
        [HttpGet("api/order/byordernumber/{id}")]
        public ActionResult GetOrderRaportIdByOrderNb(int id)
        {
            var orderRaportId = _orderService.GetOrderRaportIdByOrderNb(id);
            return Ok(orderRaportId);
        }

        // READ
        [HttpGet("api/order/maskingmodule")]
        public ActionResult GetOrdersNotStartedInSystem()
        {
            var orders = _orderService.GetOrdersFilteredForMaskingArea();
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