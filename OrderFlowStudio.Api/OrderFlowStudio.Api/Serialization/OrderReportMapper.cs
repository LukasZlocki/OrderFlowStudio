using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class OrderReportMapper
    {
        public static OrderReportReadDto SerializeOrderReportToOrderReportReadDto(OrderReport report)
        {
            return new OrderReportReadDto
            {
                Id = report.Id,
                QuantityFinished = report.QuantityFinished,
                StatusDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(report.Status),
            };            
        }
        public static OrderReport SerializeStatusesOnlyOfOrderReportReadDtoToOrderReport( OrderReportReadDto reportDto)
        {
            return new OrderReport
            {
                Id = reportDto.Id,
                QuantityFinished = reportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(reportDto.StatusDto)
            };            
        }

        public static OrderReport SerializeOrderReportReadDtoToOrderReport(OrderReportReadDto reportDto)
        {
            return new OrderReport
            {
                Id = reportDto.Id,
                QuantityFinished = reportDto.QuantityFinished,
                //Order = OrderMapper.SerializeOrderReadDtoToOrder(raportDto.OrderDto),
                Status = ProductionStatusMapper.SerializeProductionStatusDtoToProductionStatus(reportDto.StatusDto)
            };            
        }

        public static OrderReport SerializeOrderReportCreateDtoToOrderReport(OrderReportCreateDto reportDto)
        {
            return new OrderReport
            {
                QuantityFinished = reportDto.QuantityFinished,
                StatusId = reportDto.StatusId
            };
        }
        

        public static List<OrderReportReadDto> SerializeListOfOrderReportsToOrderReportReadDtoList(IEnumerable<OrderReport> orderReports)
        {
            return orderReports.Select(report => new OrderReportReadDto 
            {   
                Id = report.Id,
                QuantityFinished = report.QuantityFinished,
                StatusDto = ProductionStatusMapper.SerializeProductionStatusToProductionStatusReadDto(report.Status)
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