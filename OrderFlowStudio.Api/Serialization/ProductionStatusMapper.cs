using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class ProductionStatusMapper
    {
        public static ProductionStatusReadDto SerializeProductionStatusToProductionStatusReadDto (ProductionStatus status){
            return new ProductionStatusReadDto
            {
                StatusCode = status.StatusCode,
                StatusDescription = status.StatusDescription
            };
        }

        public static ProductionStatus SerializeProductionStatusDtoToProductionStatus (ProductionStatusReadDto statusDto){
            return new ProductionStatus{
                StatusCode = statusDto.StatusCode,
                StatusDescription = statusDto.StatusDescription
            };
        }

         public static ProductionStatus SerializeProductionStatusCreateDtoToProductionStatus (ProductionStatusCreateDto statusDto){
            return new ProductionStatus{
                StatusId = statusDto.StatusId
            };
        }


    }
}