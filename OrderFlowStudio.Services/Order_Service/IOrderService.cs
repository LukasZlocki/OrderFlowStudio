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
        public List<Order> GetOrdersFilteredNotStarted();
        public List<Order> GetOrdersFilteredForMaskingArea();
        public List<Order> GetOrdersFilteredMaskingInProgress();
        public List<Order> GetOrdersFilteredProcessingInProgress();
        public List<Order> GetOrdersFilteredCorrectionInProgress();

        // DELETE
        public ServiceResponse<bool> DeleteOrder(int id);
    }
}
