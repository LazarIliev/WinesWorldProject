using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Web.ViewModels.Order;

namespace WinesWorld.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService orderService;

        

        public OrdersController(IOrdersService orderService)
        {
            this.orderService = orderService;
            
        }

        [HttpGet()]
        
        public async Task<IActionResult> Cart()
        {
            ;

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            IQueryable<OrderServiceModel> ordersDb =  this.orderService.GetAll(userId);




            List<OrderCartViewModel> orders = await ordersDb
                //.Where(order => order.Status.Name == "Active"
                //&& order.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .Select( ordersServiceModel => new OrderCartViewModel
                {
                    Id = ordersServiceModel.Id,
                    Name = ordersServiceModel.Wine.Name,
                    Price = ordersServiceModel.Wine.Price,
                    Picture = ordersServiceModel.Wine.Picture,
                    Quantity = ordersServiceModel.Quantity                    

                })
                .ToListAsync();

            return this.View(orders);
        }


        [HttpPost]
        public IActionResult Complete()
        {
            return this.View();
        }

    }
}