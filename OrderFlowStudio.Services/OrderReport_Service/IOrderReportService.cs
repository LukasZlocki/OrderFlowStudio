using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Services.OrderReport_Service
{
    public interface IOrderReportService
    {
         // CREATE
        public ServiceResponse<OrderReport> AddOrderRaport(OrderReport orderReport);

        // READ
        public List<OrderReport> GetAllOrderReports();
        public OrderReport GetOrderReportById(int id);

        // UPDATE
        public ServiceResponse<bool> UpdateOrderReportStatuses(OrderReport orderReport);

        // DELETE
        public ServiceResponse<bool> DeleteOrderReport(int id);

         
    }
}