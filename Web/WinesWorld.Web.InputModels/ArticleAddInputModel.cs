using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WinesWorld.Web.InputModels
{
    public class ArticleAddInputModel
    {
        public ArticleAddInputModel()
        {
            this.Pictures = new List<IFormFile>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; }        
                
        public List<IFormFile> Pictures { get; set; }
    }
}
