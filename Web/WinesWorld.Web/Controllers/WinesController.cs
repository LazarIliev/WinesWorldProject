using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Web.InputModels;
using WinesWorld.Web.ViewModels.Wine;
using WinesWorld.Web.ViewModels.Wine.All;
using WinesWorld.Web.ViewModels.Wine.Details;

namespace WinesWorld.Web.Controllers
{
    public class WinesController : Controller
    {
        private readonly IWinesService winesService;
        private readonly IOrdersService ordersService;

        public WinesController(IWinesService winesService, IOrdersService ordersService)
        {
            this.winesService = winesService;
            this.ordersService = ordersService;
        }               

        public IActionResult All(WineAllViewModel wineAllViewModel)
        {
            ;




            //todo to get all wines from the db
            List<WineServiceModel> wines = this.winesService.GetAllWines();
            //List<WineServiceModel> winesViewModel = new List<WineServiceModel>();


            #region wineAllViewModel
            //if (wineAllViewModel.Colour != null)
            //{
            //    foreach (var item in wines)
            //    {
            //        if (item.Colour == wineAllViewModel.Colour)
            //        {
            //            winesViewModel.Add(item);
            //        }
            //    }
            //}

            //if (wineAllViewModel.Type != null)
            //{
            //    foreach (var item in wines)
            //    {
            //        if (item.Type == wineAllViewModel.Type)
            //        {
            //            winesViewModel.Add(item);
            //        }
            //    }
            //}

            //if (wineAllViewModel.Country != null)
            //{
            //    foreach (var item in wines)
            //    {
            //        if (item.Country == wineAllViewModel.Country)
            //        {
            //            winesViewModel.Add(item);
            //        }
            //    }
            //}

            //if (winesViewModel.Count == 0)
            //{
            //    wineAllViewModel.wineViewModels = wines
            //        .Select(x => new WineViewModel
            //        {
            //              Name = wineAddInputModel.Name,
            //    Country = wineAddInputModel.Country,
            //    Type = wineAddInputModel.Type,
            //    Year = wineAddInputModel.Year,
            //    Description = wineAddInputModel.Description,
            //    Picture = wineAddInputModel.Picture,
            //    Likes = 0,
            //    Rating = 0,
            //    Colour = wineAddInputModel.Colour
            //        })
            //        .ToList();

            //    return View(wineAllViewModel);
            //}
            #endregion 

            return View(wines);
        }

        public async Task<IActionResult> Details(string id)
        {
            //to get the wine data
            //

            var wineServiceModel = await this.winesService.GetWineDetails(id);

            WineDetailsViewModel wineDetailsViewModel = new WineDetailsViewModel
            {
                Id = wineServiceModel.Id,
                Name = wineServiceModel.Name,
                Type = wineServiceModel.Type,
                Picture = wineServiceModel.Picture,
                Description = wineServiceModel.Description,
                Country = wineServiceModel.Country,
                Colour = wineServiceModel.Colour,
                Year = wineServiceModel.Year,
                Price = wineServiceModel.Price,
                Likes= wineServiceModel.Likes

            };

            //var wine = this.winesService.GetWineDetails(id);
            //to pass it to the view in viewModel

            return this.View(wineDetailsViewModel);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
           

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(WineAddInputModel wineAddInputModel)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(wineAddInputModel);
            }


            byte[] picture = null;

            using (var pictureStream = wineAddInputModel.Picture.OpenReadStream())
            {
                using (var pictureMemoryStream = new MemoryStream())
                {
                    pictureStream.CopyTo(pictureMemoryStream);
                    picture = pictureMemoryStream.ToArray();
                }
            }                       

            WineServiceModel wineServiceModel = new WineServiceModel
            {
                Name = wineAddInputModel.Name,
                Country = wineAddInputModel.Country,
                Type = wineAddInputModel.Type,
                Year =wineAddInputModel.Year,
                Description = wineAddInputModel.Description,
                Picture = picture,
                Colour = wineAddInputModel.Colour,
                Price = wineAddInputModel.Price
            };

            await this.winesService.Add(wineServiceModel);

            return Redirect("/Wines/All");
        }

        [HttpPost]
        public async Task<IActionResult> Order(WineOrderInputModel wineOrderInputModel)
        {
            

            OrderServiceModel orderServiceModel = new OrderServiceModel
            {
                WineId = wineOrderInputModel.WineId,
                Quantity = wineOrderInputModel.Quantity
            };


            orderServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateOrder(orderServiceModel);


            return Redirect("/Wines/All");
        }
    }
}