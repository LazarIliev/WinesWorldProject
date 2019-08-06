using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Web.InputModels;

namespace WinesWorld.Web.Controllers
{
    public class WinesController : Controller
    {
        private readonly IWinesService winesService;

        public WinesController(IWinesService winesService)
        {
            this.winesService = winesService;
        }               

        public IActionResult All( string Colour, string Type, string Country)
        {
            ;




            //todo to get all wines from the db
            List<WineServiceModel> wines = this.winesService.GetAllWines();
            
            //to pass viewModel

            return View(wines);
        }

        public IActionResult Details(string id)
        {
            //to get the wine data
            //

            var wine = this.winesService.GetWineDetails(id);
            //to pass it to the view in viewModel

            return this.View(wine);
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
                Picture = picture
            };

            await this.winesService.Add(wineServiceModel);

            return Redirect("/Wines/All");
        }
    }
}