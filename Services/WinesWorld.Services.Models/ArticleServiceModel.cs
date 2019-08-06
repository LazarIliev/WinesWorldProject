using System;
using System.Collections.Generic;
using WinesWorld.Services.Models.Enums;

namespace WinesWorld.Services.Models
{
    public class ArticleServiceModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public ArticleCategorySetviceModel Category { get; set; }

        public DateTime Date { get; set; }

        public List<ArticlePictureServiceModel> ArticlePictures { get; set; }
    }
}
