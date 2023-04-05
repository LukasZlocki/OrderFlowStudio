using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderFlowStudio.Data;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.OrderRaport_Service
{
    public class OrderRaportService : IOrderRaportService
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
        public ServiceResponse<Raport> AddOrderRaport(Raport raport)
        {
            try
            {
                _db.Raports.Add(raport);
                _db.SaveChanges();
                return new ServiceResponse<Raport>
                {
                    IsSucess = true,
                    Message = "Order raport added.",
                    Time = DateTime.UtcNow,
                    Data = raport
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<Raport>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = raport
                };
            }
        }


        // READ
        /// <summary>
        /// Read all order raports
        /// </summary>
        /// <returns><List<OrderRaport></returns>
        public List<Raport> GetAllOrderRaports()
        {
            var service = _db.Raports
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
        public Raport GetOrderRaportById(int id)
        {
            //var service = _db.OrderRaports.Find(id);
            var service = _db.Raports
                .Include(st => st.Status)
                    .FirstOrDefault(x => x.StatusId == id);
            return service;
        }


        // UPDATE
        /// <summary>
        /// Update order raport object
        /// </summary>
        /// <param name="orderRaport"></param>
        /// <returns>ServiceResponse<bool></returns>
        public ServiceResponse<bool> UpdateOrderRaportStatuses(Raport Raport)
        {
            try
            {
                var orderRaportToUpdate = _db.Raports.Find(Raport.RaportId);
                orderRaportToUpdate = Raport;
                _db.Raports.Update(orderRaportToUpdate);
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
        public ServiceResponse<bool> DeleteOrderRaport(int id)
        {
            var orderRaport = _db.Raports.Find(id);

            if (orderRaport == null)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = "No order raport found.",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }

            try
            {
                _db.Raports.Remove(orderRaport);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Order Raport removed.",
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