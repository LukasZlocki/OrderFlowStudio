using System.Collections.Generic;
using System.Linq;
using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class OrderRaportMapper
    {
        public static OrderRaportReadDto SerializeOrderRaportToOrderRaportReadDto(Raport raport)
        {
            return new OrderRaportReadDto
            {
                Id = raport.RaportId,
                QuantityFinished = raport.QuantityFinished,
                StatusDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(raport.Status),
            };            
        }
        public static Raport SerializeStatusesOnlyOfOrderRaportReadDtoToOrderRaport( OrderRaportReadDto raportDto)
        {
            return new Raport
            {
                RaportId = raportDto.Id,
                QuantityFinished = raportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(raportDto.StatusDto)
            };            
        }

        public static Raport SerializeOrderRaportReadDtoToOrderRaport(OrderRaportReadDto raportDto)
        {
            return new Raport
            {
                RaportId = raportDto.Id,
                StatusId = raportDto.StatusDto.StatusId,
                QuantityFinished = raportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(raportDto.StatusDto)
            };            
        }

        public static Raport SerializeOrderRaportCreateDtoToOrderRaport(OrderRaportCreateDto raportDto)
        {
            return new Raport
            {
                QuantityFinished = raportDto.QuantityFinished,
                StatusId = raportDto.StatusId
            };
        }
        

        public static List<OrderRaportReadDto> SerializeListOfOrderRaportsToOrderRaportReadDtoList(IEnumerable<Raport> orderRaports)
        {
            return orderRaports.Select(raport => new OrderRaportReadDto 
            {   
                Id = raport.RaportId,
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