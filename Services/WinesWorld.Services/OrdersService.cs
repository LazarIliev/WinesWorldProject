﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly WinesWorldDbContext context;

        public OrdersService(WinesWorldDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateOrder(OrderServiceModel orderServiceModel)
        {
            Order order = new Order
            {                               
                Quantity = orderServiceModel.Quantity,
                IssuerId = orderServiceModel.IssuerId,
                WineId = orderServiceModel.WineId,                
            };


            order.Status = await this.context.OrderStatuses
                .SingleOrDefaultAsync( orderStatus => orderStatus.Name =="Active" );

            order.IssuedOn = DateTime.UtcNow;

            this.context.Orders.Add(order);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OrderServiceModel> GetAll(string userId)
        {
            return this.context.Orders
                .Include(x => x.Wine)
                .Include(x => x.Status)
                .Where(order => order.Status.Name == "Active"
                && order.IssuerId == userId)
                .Select(order => new OrderServiceModel
                {
                    Id = order.Id,
                    IssuedOn = order.IssuedOn,
                    IssuerId = order.IssuerId,
                    Quantity = order.Quantity,
                    StatusId = order.StatusId,
                    Status = new OrderStatusServiceModel { Name = order.Status.Name },
                    WineId = order.WineId,
                    Wine = new WineServiceModel
                    {
                        Name = order.Wine.Name,
                        Price = order.Wine.Price,
                        Picture = order.Wine.Picture
                    }

                });            
        }


        public async Task SetOrdersToReceipt(Receipt receipt)
        {
            List<Order> ordersFromDb = await this.context.Orders
                .Where(order => order.IssuerId == receipt.RecipientId && order.Status.Name == "Active").ToListAsync();

            receipt.Orders = ordersFromDb;
        }

        public async Task<bool> CompleteOrder(string orderId)
        {
            Order orderFromDb = await this.context.Orders.Include(x=>x.Status)
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (orderFromDb == null || orderFromDb.Status.Name != "Active")
            {
                throw new ArgumentException(nameof(orderFromDb));
            }

            orderFromDb.Status = await this.context.OrderStatuses
                .SingleOrDefaultAsync(orderStatus => orderStatus.Name == "Completed");

            this.context.Update(orderFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
