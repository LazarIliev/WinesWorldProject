using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Web.ViewModels.Receipts.All;
using WinesWorld.Web.ViewModels.Receipts.Details;

namespace WinesWorld.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptService = receiptsService;
        }


        public async Task<IActionResult> All()
        {

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<ReceiptServiceModel> receiptServiceModel = await this.receiptService.GetAll()
              .Where(receipt => receipt.RecipientId == userId)
              .ToListAsync();

            List<ReceiptAllViewModel> receiptAllViewModels = receiptServiceModel
                .Select(receipt => new ReceiptAllViewModel
                {
                    Id = receipt.Id,
                    IssuedOn = receipt.IssuedOn,
                    Wines = receipt.Orders.Sum(order => order.Quantity),
                    Total = receipt.Orders.Sum(order => order.Quantity * order.Wine.Price)
                })
                .ToList();


            return this.View(receiptAllViewModels);
        }



        public async Task<IActionResult> Details(string id)
        {
            
            ReceiptServiceModel receiptServiceModel = await this.receiptService.GetAll()
              .SingleOrDefaultAsync(receipt => receipt.Id == id);

            
            ReceiptDetailsViewModel receiptDetailsViewModel = new ReceiptDetailsViewModel
            {
                Id = receiptServiceModel.Id,
                IssuedOn = receiptServiceModel.IssuedOn,
                Recipient = receiptServiceModel.Recipient.UserName,
                Orders = receiptServiceModel.Orders.Select(order => new ReceiptDetailsOrderViewModel
                {
                    WineName = order.Wine.Name,
                    WinePrice = order.Wine.Price,
                    Quantity = order.Quantity

                }).ToList()
            };

            return this.View(receiptDetailsViewModel);
        }
    }
}