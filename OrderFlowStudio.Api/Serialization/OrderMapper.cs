using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class OrderMapper
    {
        public static OrderReadDto SerializeOrderToOrderReadDto(Order order)
        {
            return new OrderReadDto 
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                ProductDto = ProductMapper.SerializeProductToProductReadDto(order.Product),
                ReportDto = OrderReportMapper.SerializeOrderReportToOrderReportReadDto(order.Report)
            };
        }

        public static Order SerializeOrderReadDtoToOrder (OrderReadDto order)
        {
            return new Order 
            {
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                Product = ProductMapper.SerializeProductReadDtoToProduct(order.ProductDto),
                Report = OrderReportMapper.SerializeOrderReportReadDtoToOrderReport(order.ReportDto)
            };
        }

        public static List<OrderReadDto> SerializeOrderToListOfOrderReadDto(IEnumerable<Order> orders)
        {
            return orders.Select(order => new OrderReadDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                ProductDto = ProductMapper.SerializeProductToProductReadDto(order.Product),
                ReportDto = OrderReportMapper.SerializeOrderReportToOrderReportReadDto(order.Report)
            }).ToList();
        }


        public static Order SerializeOrderCreateDtoToOrder (OrderCreateDto order)
        {
            return new Order 
            {
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                ProductId = order.ProductId,
                ReportId = order.ReportId
            };
        }


    }
}