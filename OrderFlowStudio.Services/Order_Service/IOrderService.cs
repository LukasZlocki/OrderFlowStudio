using OrderFlowStudio.Models.Models;

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
        public int GetOrderReportIdByOrderNb(int id);
        public List<Order> GetOrdersFilteredForMaskingArea();

        // DELETE
        public ServiceResponse<bool> DeleteOrder(int id);
    }
}
