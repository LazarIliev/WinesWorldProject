﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Services.Models
{
    public class ArticleServiceModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public List<ArticlePictureServiceModel> ArticlePictures { get; set; }
    }
}
