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
                StatusDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(raport.Status),
            };            
        }
        public static OrderRaport SerializeStatusesOnlyOfOrderRaportReadDtoToOrderRaport( OrderRaportReadDto raportDto)
        {
            return new OrderRaport
            {
                Id = raportDto.Id,
                QuantityFinished = raportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(raportDto.StatusDto)
            };            
        }

        public static OrderRaport SerializeOrderRaportReadDtoToOrderRaport(OrderRaportReadDto raportDto)
        {
            return new OrderRaport
            {
                Id = raportDto.Id,
                QuantityFinished = raportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(raportDto.StatusDto)
            };            
        }

        public static OrderRaport SerializeOrderRaportCreateDtoToOrderRaport(OrderRaportCreateDto raportDto)
        {
            return new OrderRaport
            {
                QuantityFinished = raportDto.QuantityFinished,
                Status = ProductionStatusMapper.SerializeProductionStatusCreateDtoToProductionStatus(raportDto.Status)
            };
        }
        

        public static List<OrderRaportReadDto> SerializeListOfOrderRaportsToOrderRaportReadDtoList(IEnumerable<OrderRaport> orderRaports)
        {
            return orderRaports.Select(raport => new OrderRaportReadDto 
            {   
                Id = raport.Id,
                QuantityFinished = raport.QuantityFinished,
                StatusDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(raport.Status)
                // ToDo: How to handle with mapping Id and order object ?
            }).ToList();       
        }

/*
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

       
*/

    }
}