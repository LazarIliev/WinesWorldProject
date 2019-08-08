using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinesWorld.Data.Models;


namespace WinesWorld.Data
{
    public class WinesWorldDbContext : IdentityDbContext<WinesWorldUser, IdentityRole, string>
    {
        //TODO: to add db sets
        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Wine> Wines { get; set; }

        public DbSet<ArticlePicture> ArticlePictures { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public WinesWorldDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
