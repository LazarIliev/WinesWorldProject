using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WinesWorld.Data;

namespace WinesWorld.Tests.Common
{
    public static class WinesWorldDbContextInMemoryFactory
    {

        public static WinesWorldDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<WinesWorldDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new WinesWorldDbContext(options);
        }
    }
}
