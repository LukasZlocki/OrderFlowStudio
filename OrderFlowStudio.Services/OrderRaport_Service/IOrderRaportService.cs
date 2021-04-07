using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.OrderRaport_Service
{
    public interface IOrderRaportService
    {
         // CREATE
        public ServiceResponse<OrderRaport> AddOrderRaport(OrderRaport orderRaport);

        // READ
        public List<OrderRaport> GetAllOrderRaports();
        public OrderRaport GetOrderRaportById(int id);

        // UPDATE
        public ServiceResponse<bool> UpdateOrderRaport(OrderRaport orderRaport);

        // DELETE
        public ServiceResponse<bool> DeleteOrderRaport(int id);

         
    }
}