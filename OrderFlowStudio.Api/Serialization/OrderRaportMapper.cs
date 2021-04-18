using System.Collections.Generic;
using System.Linq;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class OrderRaportMapper
    {
        public static OrderRaportReadDto SerializeOrderRaportToOrderRaportReadDto(OrderRaport raport)
        {
            return new OrderRaportReadDto
            {
                Id = raport.Id,
                QuantityFinished = raport.QuantityFinished,
                isStarted = raport.isStarted,
                isMasked = raport.isMasked,
                isProcessed = raport.isProcessed,
                isProcessOK = raport.isProcessOK,
                isCorrectionStarted = raport.isCorrectionStarted,
                isCorrectionFinished = raport.isCorrectionFinished,
                isOrderFinished = raport.isOrderFinished,
            };            
        }
        public static OrderRaport SerializeStatusesOnlyOfOrderRaportReadDtoToOrderRaport( OrderRaportReadDto raport)
        {
            return new OrderRaport
            {
                Id = raport.Id,
                QuantityFinished = raport.QuantityFinished,
                isStarted = raport.isStarted,
                isMasked = raport.isMasked,
                isProcessed = raport.isProcessed,
                isProcessOK = raport.isProcessOK,
                isCorrectionStarted = raport.isCorrectionStarted,
                isCorrectionFinished = raport.isCorrectionFinished,
                isOrderFinished = raport.isOrderFinished,
            };            
        }

        public static OrderRaport SerializeOrderRaportReadDtoToOrderRaport(OrderRaportReadDto raport)
        {
            return new OrderRaport
            {
                Id = raport.Id,
                QuantityFinished = raport.QuantityFinished,
                isStarted = raport.isStarted,
                isMasked = raport.isMasked,
                isProcessed = raport.isProcessed,
                isProcessOK = raport.isProcessOK,
                isCorrectionStarted = raport.isCorrectionStarted,
                isCorrectionFinished = raport.isCorrectionFinished,
                isOrderFinished = raport.isOrderFinished,
                // ToDo: How to handle with mapping Id and order object ?
                Order = OrderMapper.SerializeOrderReadDtoToOrder(raport.OrderDto)
            };            
        }

        public static OrderRaport SerializeOrderRaportReadDtoToOrderRaport(OrderRaportCreateDto raport)
        {
            return new OrderRaport
            {
                QuantityFinished = raport.QuantityFinished,
                isStarted = raport.isStarted,
                isMasked = raport.isMasked,
                isProcessed = raport.isProcessed,
                isProcessOK = raport.isProcessOK,
                isCorrectionStarted = raport.isCorrectionStarted,
                isCorrectionFinished = raport.isCorrectionFinished,
                isOrderFinished = raport.isOrderFinished,
                // ToDo: How to handle with mapping Id and order object ?
            };            
        }

        public static List<OrderRaportReadDto> SerializeListOfOrderRaportsToOrderRaportReadDtoList(IEnumerable<OrderRaport> orderRaports)
        {
            return orderRaports.Select(raport => new OrderRaportReadDto 
            {   
                Id = raport.Id,
                QuantityFinished = raport.QuantityFinished,
                isStarted = raport.isStarted,
                isMasked = raport.isMasked,
                isProcessed = raport.isProcessed,
                isProcessOK = raport.isProcessOK,
                isCorrectionStarted = raport.isCorrectionStarted,
                isCorrectionFinished = raport.isCorrectionFinished,
                isOrderFinished = raport.isOrderFinished
                // ToDo: How to handle with mapping Id and order object ?
            }).ToList();       
        }

    }
}