﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Services.Mapping;
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
            Wine wine1 = AutoMapper.Mapper.Map<Wine>(wineAddInputModel);

            //Wine wine = new Wine
            //{
            //    Name = wineAddInputModel.Name,
            //    Country = wineAddInputModel.Country,
            //    Type = wineAddInputModel.Type,
            //    Year = wineAddInputModel.Year,
            //    Description = wineAddInputModel.Description,
            //    Picture = wineAddInputModel.Picture,
            //    Likes = 0,
            //    Rating = 0,
            //    Colour = wineAddInputModel.Colour,
            //    Price = wineAddInputModel.Price
            //};

            this.context.Wines.Add(wine1);
            await this.context.SaveChangesAsync();

            return true;
        }

        public IQueryable<WineServiceModel> GetAllWines()
        {
            var wines = this.context.Wines
                .To<WineServiceModel>();
                //.Select(wineDb => new WineServiceModel
                //{
                //    Id = wineDb.Id,
                //    Description = wineDb.Description,
                //    Likes = wineDb.Likes,
                //    Name = wineDb.Name,
                //    Picture = wineDb.Picture,
                //    Rating = wineDb.Rating,
                //    Type = wineDb.Type,
                //    Country = wineDb.Country,
                //    Year = wineDb.Year,
                //    Colour = wineDb.Colour,
                //    Price = wineDb.Price
                //});
                

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
                Year = wineDb.Year,
                Price = wineDb.Price
            };

            return wine;
        }
    }
}
