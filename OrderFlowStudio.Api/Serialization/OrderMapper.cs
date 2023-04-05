using System.Collections.Generic;
using System.Linq;
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

        public static Order SerializeOrderReadDtoToOrder (OrderReadDto order)
        {
            return new Order 
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                ProductId = order.ProductDto.Id,
                RaportId = order.RaportDto.Id,
                Product = ProductMapper.SerializeProductReadDtoToProduct(order.ProductDto),
                Raport = OrderRaportMapper.SerializeOrderRaportReadDtoToOrderRaport(order.RaportDto)
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
                RaportDto = OrderRaportMapper.SerializeOrderRaportToOrderRaportReadDto(order.Raport)
            }).ToList();
        }


        public static Order SerializeOrderCreateDtoToOrder (OrderCreateDto order)
        {
            return new Order 
            {
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                ProductId = order.ProductId,
                RaportId = order.RaportId
            };
        }


    }
}