using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class ProductionStatusMapper
    {
        public static ProductionStatusReadDto SerializeProductionStatusToProductionStatusReadDto (Status status){
            return new ProductionStatusReadDto
            {
                StatusId = status.StatusId,
                StatusCode = status.StatusCode,
                StatusDescription = status.StatusDescription
            };
        }

        public static Status SerializeProductionStatusDtoToProductionStatus (ProductionStatusReadDto statusDto){
            return new Status{
                StatusId = statusDto.StatusId,
                StatusCode = statusDto.StatusCode,
                StatusDescription = statusDto.StatusDescription
            };
        }

         public static Status SerializeProductionStatusCreateDtoToProductionStatus (ProductionStatusCreateDto statusDto){
            return new Status{
                StatusId = statusDto.StatusId
            };
        }


    }
}