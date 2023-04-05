using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.OrderRaport_Service
{
    public interface IOrderRaportService
    {
         // CREATE
        public ServiceResponse<Raport> AddOrderRaport(Raport orderRaport);

        // READ
        public List<Raport> GetAllOrderRaports();
        public Raport GetOrderRaportById(int id);

        // UPDATE
        public ServiceResponse<bool> UpdateOrderRaportStatuses(Raport orderRaport);

        // DELETE
        public ServiceResponse<bool> DeleteOrderRaport(int id);

         
    }
}