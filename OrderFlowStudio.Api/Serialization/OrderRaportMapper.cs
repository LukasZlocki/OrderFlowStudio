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
            };            
        }

    }
}