using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Web.ViewModels.Wine.Details
{
    public class WineDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Colour { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public byte[] Picture { get; set; }

        public decimal Price { get; set; }

        public DateTime Year { get; set; }

        public int Likes { get; set; }
    }
}
