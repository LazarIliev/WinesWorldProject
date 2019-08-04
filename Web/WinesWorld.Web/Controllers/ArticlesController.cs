using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Services;
using WinesWorld.Services.Models;
using WinesWorld.Web.InputModels;
using WinesWorld.Web.ViewModels.Article.All;

namespace WinesWorld.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly ICloudinaryService cloudinaryService;

        public ArticlesController(IArticlesService articlesService, ICloudinaryService cloudinaryService)
        {
            this.articlesService = articlesService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return this.View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ArticleAddInputModel articleAddInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(articleAddInputModel);
            }            

            List<string> urlsPicture = new List<string>();           

            foreach (IFormFile picture in articleAddInputModel.Pictures)
            {
                string pictureUrl = null;

                if (picture != null)
                {
                     pictureUrl = await this.cloudinaryService.UploadPictureAsync(picture, articleAddInputModel.Title);
                }

                urlsPicture.Add(pictureUrl);
            }

            ArticleServiceModel articleServiceModel = new ArticleServiceModel
            {
                Title = articleAddInputModel.Title,
                Author = articleAddInputModel.Author,
                Content = articleAddInputModel.Content,
                Date = articleAddInputModel.Date,
                Category = articleAddInputModel.Category,
                ArticlePictures = new List<ArticlePictureServiceModel>
                {
                   new ArticlePictureServiceModel{ ImageUrl = urlsPicture[0]},
                   new ArticlePictureServiceModel{ ImageUrl = urlsPicture[1]},
                   new ArticlePictureServiceModel{ ImageUrl = urlsPicture[2]},
                   new ArticlePictureServiceModel{ ImageUrl = urlsPicture[3]},
                   new ArticlePictureServiceModel{ ImageUrl = urlsPicture[4]}
                }
            };


            await this.articlesService.Add(articleServiceModel);
                        
            return this.Redirect("/Acticle/All");
        }        

        public IActionResult All()
        {


            List<ArticleAllViewModel> viewModel = this.articlesService.GetAllArticles()
                .Select(articleServiceModel => new ArticleAllViewModel
                {
                    Id = articleServiceModel.Id,
                    BrefContent = articleServiceModel.Content,
                    Title = articleServiceModel.Title,
                    LinkMainPicture = articleServiceModel.ArticlePictures[0].ImageUrl
                })
                .ToList();

            return this.View(viewModel);
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
