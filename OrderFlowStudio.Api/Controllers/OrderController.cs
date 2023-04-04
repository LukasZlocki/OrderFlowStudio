using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Data.Models;
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
             // 1 - extract product id from db by product number
            int productId = _productService.GetProductIdByProductNumber(orderOnCreateDto.ProductNumber);

            // 2 - extract status id from db : status "Not started" - status nb: '15' by retriving its id from db.
            int StatusIdFromDb = _statusService.GetStatusIdByStatusNumber(15);

            // 3 - create new raport in db and retrive its id (raport id)
            var raportCreateDto = new OrderRaportCreateDto
            {
                QuantityFinished = 0, // it is starting raport
                StatusId = StatusIdFromDb
            };

            var raport = OrderRaportMapper.SerializeOrderRaportCreateDtoToOrderRaport(raportCreateDto);

            var serviceResponseRaport = _raportService.AddOrderRaport(raport);       

            // Get raport id in order to add it to new order
            int raportId = serviceResponseRaport.Data.Id;

            var orderCreateDto = new OrderCreateDto 
            {
                OrderNumber = orderOnCreateDto.OrderNumber,
                Quantity = orderOnCreateDto.Quantity,
                ProductId = productId,
                RaportId = raportId
            };
            var order = OrderMapper.SerializeOrderCreateDtoToOrder(orderCreateDto);
            
            // create new order in db
            var serviceResponse = _orderService.AddOrder(order);

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
        [HttpGet("api/order/maskingareanotstarted")]
        public ActionResult GetOrdersWithStatusNotStarted()
        {
            var orders = _orderService.GetOrdersWaitingForMasking();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order/maskingareainprogress")]
        public ActionResult GetOrdersWithStatusMaskingInProgress()
        {
            var orders = _orderService.GetOrdersWithStatusMaskingInProgress();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // UPDATE 
        [HttpPatch("/api/order")]
        public ActionResult UpdateOrder([FromBody] OrderReadDto orderReadDto)
        {
            var order = OrderMapper.SerializeOrderReadDtoToOrder(orderReadDto);
            var serviceResponse = _orderService.UpdateOrder(order);
            return Ok(serviceResponse);
        }

        // UPDATE
        [HttpPatch("/api/order/maskinginprogress")]
        public ActionResult UpdateOrderByMaskingInProgressStatus([FromBody] OrderReadDto orderReadDto)
        {
            int _maskingInProgressStatusCode = 20;
            // retriving status object by status code
            var statusObject = _statusService.GetProductionStatusObjectByStatusCode(_maskingInProgressStatusCode);
            // transfering object into Dto
            var productionStatusReadDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(statusObject);
            // Add Dto status object into order read Dto
            orderReadDto.RaportDto.StatusDto = productionStatusReadDto;

            // update order in db
            var order = OrderMapper.SerializeOrderReadDtoToOrder(orderReadDto);
            var serviceResponse = _orderService.UpdateOrder(order);
            return Ok(serviceResponse);
        }

        // DELETE
        // nothink to code here !
        
    }
}