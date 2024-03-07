using Microsoft.AspNetCore.Mvc;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Api.Serialization;
using OrderFlowStudio.Services.Order_Service;
using OrderFlowStudio.Services.OrderReport_Service;
using OrderFlowStudio.Services.Product_Service;
using OrderFlowStudio.Services.Status_Service;

namespace OrderFlowStudio.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderReportService _reportService;
        private readonly IProductService _productService;
        private readonly IStatusService _statusService;

        public OrderController(IOrderService orderService, IOrderReportService raportService, IProductService productService, IStatusService statusService)
        {
            _orderService = orderService;
            _reportService = raportService;
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
            int _statusNotStarted = 10;
            int StatusIdFromDb = _statusService.GetStatusIdByStatusNumber(_statusNotStarted);

            // 3 - create new raport in db and retrive its id (raport id)
            var raportCreateDto = new OrderReportCreateDto
            {
                QuantityFinished = 0, // it is starting raport
                StatusId = StatusIdFromDb
            };

            var raport = OrderReportMapper.SerializeOrderReportCreateDtoToOrderReport(raportCreateDto);

            var serviceResponseRaport = _reportService.AddOrderRaport(raport);

            // Get raport id in order to add it to new order
            int reportId = serviceResponseRaport.Data.Id;

            var orderCreateDto = new OrderCreateDto
            {
                OrderNumber = orderOnCreateDto.OrderNumber,
                Quantity = orderOnCreateDto.Quantity,
                ProductId = productId,
                ReportId = reportId
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
            return Ok(orderId);
        }

        // READ
        [HttpGet("api/order/byordernumber/{id}")]
        public ActionResult GetOrderRaportIdByOrderNb(int id)
        {
            var orderRaportId = _orderService.GetOrderReportIdByOrderNb(id);
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

        // READ
        [HttpGet("api/order/notstarted")]
        public ActionResult GetOrdersWithStatusNotStarted()
        {
            var orders = _orderService.GetOrdersFilteredNotStarted();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order/maskinginprogress")]
        public ActionResult GetOrdersWithStatusMaskingInProgress()
        {
            var orders = _orderService.GetOrdersFilteredMaskingInProgress();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order/processinginprogress")]
        public ActionResult GetOrdersWithStatusProcessingInProgress()
        {
            var orders = _orderService.GetOrdersFilteredProcessingInProgress();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order/correctioninprogress")]
        public ActionResult GetOrdersWithStatusCorrectionInProgress()
        {
            var orders = _orderService.GetOrdersFilteredCorrectionInProgress();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // READ
        [HttpGet("api/order/packinginprogress")]
        public ActionResult GetOrdersWithStatusPackingInProgress()
        {
            var orders = _orderService.GetOrdersFilteredPackingInProgress();
            var orderDto = OrderMapper.SerializeOrderToListOfOrderReadDto(orders);
            return Ok(orderDto);
        }

        // DELETE
        // nothink to code here !

    }
}
