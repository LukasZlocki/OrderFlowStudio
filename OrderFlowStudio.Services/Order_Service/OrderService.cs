using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Data;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.Order_Service
{
    public class OrderService : IOrderService
    {   
        private readonly ILogger _logger;
        private readonly OrderDbContext _db;

        public OrderService(ILogger logger, OrderDbContext db)
        {
            _logger = logger;
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
                    .Include(pr => pr.Product)
                        .ToList();
            return service;
        }

        // READ
        public Order GetOrderById(int id)
        {
            var service = _db.Orders
                .Include(or => or.Raport)
                    .Include(pr => pr.Product)
                        .FirstOrDefault(x => x.Id == id);
            return service;
        }

        
        // UPDATE
        /// <summary>
        /// Update order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns><ServiceResponse<bool></returns>
        public ServiceResponse<bool> UpdateOrder(Order order)
        {
            try
            {
                _db.Orders.Update(order);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Order updated.",
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
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = e.StackTrace  ,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }

        }



       
    }
}