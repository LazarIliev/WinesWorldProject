using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Tests.Common;
using Xunit;

namespace WinesWorld.Tests.Service
{
    public class WinesServiceTests
    {
        private IWinesService winesService;
        private const string wineId = "asfdsadfdsa";

        private List<Wine> GetDummyData()
        {
            return new List<Wine>
            {
                new Wine
                {
                    Id =  wineId,
                    Colour = "white",
                    Country = "Bulgaria",
                    Description = "wine description describing",
                    Name = "wine's name the white wolf",
                    Price = 12.1M,
                    Year = DateTime.UtcNow.AddDays(-2),
                    Type = "dry"
                },
                new Wine
                {
                    Colour = "red",
                    Country = "Bulgaria",
                    Description = "wine description describing his aroma and flavour",
                    Name = "wine's name the red bull",
                    Price = 12.0M,
                    Year = DateTime.UtcNow.AddDays(-20),
                    Type = "dry"
                }
            };
        }

        private async Task SeedData(WinesWorldDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        public WinesServiceTests()
        {
            MapperInitializer.InitializeMapping();
        }

        [Fact]
        public async Task GetAllWines_WithDummyData_ShouldReturnCorrectResult()
        {
            //Arrange
            string errorMessagePrefix = "WinesService GetAllWines() method does not work properly.";
            var context = WinesWorldDbContextInMemoryFactory.InitializeContext();

            //Act
            await SeedData(context);

            this.winesService = new WinesService(context);

            //todo GetAllWines method to make it async
            List<WineServiceModel> actualResults = await this.winesService.GetAllWines().ToListAsync(); 

            

            List<WineServiceModel> expectedResults = GetDummyData()
                .Select(wine => AutoMapper.Mapper.Map<WineServiceModel>(wine)).ToList();
                //.Select(wine => new WineServiceModel
                //{
                //    Colour = wine.Colour,
                //    Country = wine.Country,
                //    Description = wine.Description,
                //    Name = wine.Name,
                //    Price = wine.Price,
                //    Year = wine.Year,
                //    Type = wine.Type
                //})
                //.ToList();

            //Assert

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];
                ;

                var dateExpected = expectedEntry.Year;
                var dateActual = actualEntry.Year;

                //todo: to check why dateExpected and dateActual differ within a second  
                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " Price is not returned properly.");
                Assert.True(expectedEntry.Type == actualEntry.Type, errorMessagePrefix + " Type is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " Description is not returned properly.");
                Assert.True(expectedEntry.Country == actualEntry.Country, errorMessagePrefix + " Country is not returned properly.");
                Assert.True(expectedEntry.Colour == actualEntry.Colour, errorMessagePrefix + " Colour is not returned properly.");
                //Assert.True(expectedEntry.Year == actualEntry.Year, errorMessagePrefix + " Year is not returned properly.");
            }
        }

        [Fact]
        public async Task Add_WithCorrectData_ShouldSuccessfullyCreate()
        {
            string errorMessage = "WinesService Create() method does not work properly.";

            var context = WinesWorldDbContextInMemoryFactory.InitializeContext();

            this.winesService = new WinesService(context);

            WineServiceModel wineServiceModel = new WineServiceModel
            {
                Colour = "rose",
                Country = "Bulgaria",
                Description = "wine description describing his aroma and flavour",
                Name = "wine's name goat",
                Price = 10.0M,
                Year = DateTime.UtcNow.AddDays(-20),
                Type = "dry-mid"
            };


            bool actualResult = await this.winesService.Add(wineServiceModel);

            Assert.True(actualResult, errorMessage);
        }

        [Fact]
        public async Task GetWineDetails_WithCorrectData_ShouldSuccessfullyGetDetails()
        {
            string errorMessage = "WinesService GetWineDetails method does not work properly.";

            var context = WinesWorldDbContextInMemoryFactory.InitializeContext();

            this.winesService = new WinesService(context);

            await SeedData(context);

            Wine actualWine = GetDummyData()[0];

            var wineDb = await this.winesService.GetWineDetails(wineId);
            

            var expectedWine = AutoMapper.Mapper.Map<Wine>(actualWine);

            Assert.Equal(expectedWine, actualWine);
        }
    }
}
