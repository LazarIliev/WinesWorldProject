using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinesWorld.Web.InputModels
{
    public class WineAddInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Winery { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public IFormFile Picture { get; set; }
    }
}
