using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Data.Models;

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
                RaportDto = OrderRaportMapper.SerializeOrderRaportToOrderRaportReadDto(order.Raport)
            };
        }
    }
}