using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.Order_Service
{
    public interface IOrderService
    {
        // CREATE
        public ServiceResponse<Order> AddOrder(Order order);

        // READ
        public List<Order> GetAllOrders();
        public Order GetOrderById(int id);
        public int GetOrderIdByOrderNb(int orderNb);
        public int GetOrderRaportIdByOrderNb(int id);
        public List<Order> GetOrdersWaitingForMasking();
        public List<Order> GetOrdersWithStatusMaskingInProgress();

        // UPDATE
        public ServiceResponse<bool> UpdateOrder(Order order);

        // DELETE
        public ServiceResponse<bool> DeleteOrder(int id);

    }
}