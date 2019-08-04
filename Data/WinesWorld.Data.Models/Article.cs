using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Data.Models
{
    public class Article
    {
        public Article()
        {
            this.ArticlePictures = new List<ArticlePicture>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public string Category { get; set; }//maybe enum

        public DateTime Date { get; set; }

        public List<ArticlePicture> ArticlePictures { get; set; }

        //TODO: comments
    }
}
