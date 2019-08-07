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
    public class WinesService : IWinesService
    {
        private readonly WinesWorldDbContext context;

        public WinesService(WinesWorldDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(WineServiceModel wineAddInputModel)
        {
            Wine wine = new Wine
            {
                Name = wineAddInputModel.Name,
                Country = wineAddInputModel.Country,
                Type = wineAddInputModel.Type,
                Year = wineAddInputModel.Year,
                Description = wineAddInputModel.Description,
                Picture = wineAddInputModel.Picture,
                Likes = 0,
                Rating = 0,
                Colour = wineAddInputModel.Colour
            };

            this.context.Wines.Add(wine);
            await this.context.SaveChangesAsync();

            return true;
        }

        public List<WineServiceModel> GetAllWines()
        {
            var wines = this.context.Wines
                .Select(wineDb => new WineServiceModel
                {
                    Id = wineDb.Id,
                    Description = wineDb.Description,
                    Likes = wineDb.Likes,
                    Name = wineDb.Name,
                    Picture = wineDb.Picture,
                    Rating = wineDb.Rating,
                    Type = wineDb.Type,
                    Country = wineDb.Country,
                    Year = wineDb.Year,
                    Colour = wineDb.Colour
                })
                .ToList();

            return wines;
        }

        public async Task<WineServiceModel> GetWineDetails(string id)
        {
           var wineDb = await this.context.Wines.SingleOrDefaultAsync(wineFromDb => wineFromDb.Id == id);

            var wine = new WineServiceModel
            {
                Id = wineDb.Id,
                Description = wineDb.Description,
                Likes = wineDb.Likes,
                Name = wineDb.Name,
                Picture = wineDb.Picture,
                Rating = wineDb.Rating,
                Type = wineDb.Type,
                Country = wineDb.Country,
                Year = wineDb.Year
            };

            return wine;
        }
    }
}
