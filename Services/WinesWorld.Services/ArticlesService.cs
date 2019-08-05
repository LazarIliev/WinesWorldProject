using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinesWorld.Data;
using WinesWorld.Data.Models;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly WinesWorldDbContext context;

        public ArticlesService(WinesWorldDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(ArticleServiceModel articleServiceModel)
        {
            Article article = new Article
            {
                Title = articleServiceModel.Title,
                Author = articleServiceModel.Author,
                Category = articleServiceModel.Category,
                Content = articleServiceModel.Content,
                Date = articleServiceModel.Date,
                Likes = 0,
                ArticlePictures = new List<ArticlePicture>
                {
                    new ArticlePicture{ ImageUrl = articleServiceModel.ArticlePictures[0].ImageUrl},
                    new ArticlePicture{ ImageUrl = articleServiceModel.ArticlePictures[1].ImageUrl},
                    new ArticlePicture{ ImageUrl = articleServiceModel.ArticlePictures[2].ImageUrl},
                    new ArticlePicture{ ImageUrl = articleServiceModel.ArticlePictures[3].ImageUrl},
                    new ArticlePicture{ ImageUrl = articleServiceModel.ArticlePictures[4].ImageUrl},
                }
            };

            

            this.context.Articles.Add(article);
            await this.context.SaveChangesAsync();

            return true;
        }

        public List<ArticleServiceModel> GetAllArticles()
        {
            List<ArticleServiceModel> articles = this.context.Articles
                .Include(x => x.ArticlePictures)
                .Select(articleFromDb => new ArticleServiceModel
                {
                    Id = articleFromDb.Id,
                    Title = articleFromDb.Title,
                    Content = articleFromDb.Content.Substring(0, 250),
                    ArticlePictures = new List<ArticlePictureServiceModel>
                    {
                       new ArticlePictureServiceModel
                       {
                           ImageUrl = articleFromDb.ArticlePictures[0].ImageUrl
                       }
                    }
                })
                .ToList();

            return articles;
        }

        public ArticleServiceModel GetArticleDetails(string id)
        {
            ArticleServiceModel articleServiceModel = this.context.Articles
                .Include(x => x.ArticlePictures)
                .Where(articleDb => articleDb.Id == id)
                .Select(x => new ArticleServiceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Category = x.Category,
                    Content = x.Content,
                    Date = x.Date,
                    ArticlePictures = new List<ArticlePictureServiceModel>
                    {
                        new ArticlePictureServiceModel
                        {
                            Id = x.ArticlePictures[0].Id,
                            ImageUrl = x.ArticlePictures[0].ImageUrl
                        },
                        new ArticlePictureServiceModel
                        {
                            Id = x.ArticlePictures[1].Id,
                            ImageUrl = x.ArticlePictures[1].ImageUrl
                        },
                        new ArticlePictureServiceModel
                        {
                            Id = x.ArticlePictures[2].Id,
                            ImageUrl = x.ArticlePictures[2].ImageUrl
                        },
                        new ArticlePictureServiceModel
                        {
                            Id = x.ArticlePictures[3].Id,
                            ImageUrl = x.ArticlePictures[3].ImageUrl
                        },
                        new ArticlePictureServiceModel
                        {
                            Id = x.ArticlePictures[4].Id,
                            ImageUrl = x.ArticlePictures[4].ImageUrl
                        }
                    }
                }).FirstOrDefault();

            return articleServiceModel;
        }
    }
}
