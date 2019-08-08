using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly WinesWorldDbContext context;
        private readonly IOrdersService ordersService;

        public ReceiptsService(WinesWorldDbContext context, IOrdersService ordersService)
        {
            this.context = context;
            this.ordersService = ordersService;
        }

        public async Task<string> CreateReceipt(string recipientId)
        {
            Receipt receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                RecipientId = recipientId
            };

            await this.ordersService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await this.ordersService.CompleteOrder(order.Id);
            }


            this.context.Receipts.Add(receipt);
            int result = await this.context.SaveChangesAsync();

            return receipt.Id;
        }

        public IQueryable<ReceiptServiceModel> GetAll()
        {
            var allReceipts = this.context
               .Receipts
               .Select(receiptDb => new ReceiptServiceModel
               {
                   Id = receiptDb.Id,
                   IssuedOn = receiptDb.IssuedOn,
                   RecipientId = receiptDb.RecipientId,
                   Recipient = new WinesWorldUserServiceModel
                   {
                       UserName = receiptDb.Recipient.UserName
                   },

                   Orders = receiptDb.Orders.Select(order =>new OrderServiceModel
                   {
                       Wine = new WineServiceModel
                       {
                           Name = order.Wine.Name,
                           Price = order.Wine.Price
                       },
                       Quantity = order.Quantity
                   }).ToList()
                });

            //WineName = order.Wine.Name,
            //        WinePrice = order.Wine.Price,
            //        Quantity = order.Quantity

            return allReceipts;
        }
    }
}
