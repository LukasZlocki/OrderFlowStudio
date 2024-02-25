using Microsoft.EntityFrameworkCore;
using OrderFlowStudio.Models;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Services.OrderRaport_Service
{
    public class OrderRaportService : IOrderReportService
    {
        private readonly OrderDbContext _db;

        public OrderRaportService(OrderDbContext db)
        {
            _db = db;
        }

        // CREATE
        /// <summary>
        /// Add Order raport object to data base
        /// </summary>
        /// <param name="orderRaport"></param>
        /// <returns><ServiceResponse<OrderRaport></returns>
        public ServiceResponse<OrderReport> AddOrderRaport(OrderReport orderReport)
        {
            try
            {
                _db.OrderReports.Add(orderReport);
                _db.SaveChanges();
                return new ServiceResponse<OrderReport>
                {
                    IsSucess = true,
                    Message = "Order raport added.",
                    Time = DateTime.UtcNow,
                    Data = orderReport
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<OrderReport>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = orderReport
                };
            }
        }

        // READ
        /// <summary>
        /// Read all order raports
        /// </summary>
        /// <returns><List<OrderRaport></returns>
        public List<OrderReport> GetAllOrderReports()
        {
            var service = _db.OrderRaports
                                .Include(st => st.Status)
                                    .ToList();
            return service;
        }

        // READ
        /// <summary>
        /// Read order raport by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns><OrderRaport></returns>
        public OrderReport GetOrderReportById(int id)
        {
            //var service = _db.OrderRaports.Find(id);
            var service = _db.OrderReports
                .Include(st => st.Status)
                    .FirstOrDefault(x => x.Id == id);
            return service;
        }

        // UPDATE
        /// <summary>
        /// Update order raport object
        /// </summary>
        /// <param name="orderRaport"></param>
        /// <returns>ServiceResponse<bool></returns>
        public ServiceResponse<bool> UpdateOrderReportStatuses(OrderReport orderReport)
        {
            try
            {
                var orderReportToUpdate = _db.OrderReports.Find(orderReport.Id);
                orderReportToUpdate = orderReport;
                _db.OrderRaports.Update(orderReportToUpdate);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Order raport updated.",
                    Time = DateTime.UtcNow,
                    Data = true
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }

        // DELETE
        /// <summary>
        /// Delete order raport by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns><ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteOrderReport(int id)
        {
            var orderReport = _db.OrderReports.Find(id);

            if (orderReport == null)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = "No order report found.",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }

            try
            {
                _db.OrderRaports.Remove(orderReport);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Order Report removed.",
                    Time = DateTime.UtcNow,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };

            }
        } 
    }
}