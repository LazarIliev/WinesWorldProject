using System;
using WinesWorld.Data.Models;
using WinesWorld.Services.Mapping;

namespace WinesWorld.Services.Models
{
    public class WineServiceModel : IMapFrom<Wine>, IMapTo<Wine>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }//maybe enum

        public string Colour { get; set; }

        public int Likes { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

        public string Country { get; set; }

        public DateTime Year { get; set; }

        public byte[] Picture { get; set; }
    }
}
