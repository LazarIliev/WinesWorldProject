using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Tests.Common;
using Xunit;

namespace WinesWorld.Tests.Service
{
    public class WinesServiceTests
    {
        private List<Wine> GetDummyData()
        {
            return new List<Wine>
            {
                new Wine
                {
                    Colour = "white",
                    Country = "Bulgaria",
                    Description = "wine description describing",
                    
                },
            };
        }

        private async Task SeedData(WinesWorldDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllWines_WithDummyData_ShouldReturnCorrectResult()
        {
            var context = WinesWorldDbContextInMemoryFactory.InitializeContext();

            await SeedData(context);
        }
    }
}
