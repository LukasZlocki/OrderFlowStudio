using OrderFlowStudio.Models.Models;
using OrderFlowStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderFlowStudio.Services.Order_Service
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _db;

        public OrderService(OrderDbContext db)
        {
            _db = db;
        }

        // CREATE
        /// <summary>
        /// Create order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns><Order></returns>
        public ServiceResponse<Order> AddOrder(Order order)
        {
            try
            {
                _db.Orders.Add(order);
                // Add
                _db.SaveChanges();
                return new ServiceResponse<Order>
                {
                    IsSucess = true,
                    Message = "Order added.",
                    Time = DateTime.UtcNow,
                    Data = order
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Order>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = order
                };
            }
        }

        // READ
        /// <summary>
        /// returns orders list
        /// </summary>
        /// <returns>List<Order></returns>
        public List<Order> GetAllOrders()
        {
            var service = _db.Orders
                .Include(or => or.Raport)
                    .ThenInclude(st => st.Status)
                        .Include(pr => pr.Product)
                            .ToList();
            return service;
        }

        // READ
        public Order GetOrderById(int id)
        {
            var service = _db.Orders
                .Include(or => or.Raport)
                    .ThenInclude(st => st.Status)
                        .Include(pr => pr.Product)
                            .FirstOrDefault(x => x.Id == id);
            return service;
        }

        // READ
        /// <summary>
        /// returns order id by order number
        /// </summary>
        /// <param name="orderNb"></param>
        /// <returns>int order id</returns>
        public int GetOrderIdByOrderNb(int orderNb)
        {
            var service = _db.Orders.FirstOrDefault(nb => nb.OrderNumber == orderNb);
            return service.Id;
        }

        // READ
        public Order GetOrderByOrderNb(int id)
        {
            var service = _db.Orders.FirstOrDefault(nb => nb.OrderNumber == id);
            return service;
        }

        // READ
        public int GetOrderReportIdByOrderNb(int id)
        {
            var service = _db.Orders
                .Include(or => or.Raport)
                    .FirstOrDefault(nb => nb.OrderNumber == id);
            Order order = service;
            int orderId = order.Raport.Id;
            return orderId;
        }

        // READ
        /// <summary>
        /// Returns orders list with order not started in system
        /// </summary>
        /// <returns>List<Order></returns>
        public List<Order> GetOrdersFilteredForMaskingArea()
        {
            var service = _db.Orders
                .Include(or => or.Raport).Where(r => r.Raport.Status.StatusCode == 20)
                    .Include(p => p.Product)
                        .ToList();
            return service;
        }

        // DELETE
        /// <summary>
        /// Delete order object by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns><ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = "No order found",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
            try
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Order removed.",
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
