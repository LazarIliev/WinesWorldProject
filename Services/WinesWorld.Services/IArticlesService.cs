using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public interface IArticlesService
    {
        List<ArticleServiceModel> GetAllArticles();

        void GetArticleDetails();

        Task<bool> Add(ArticleServiceModel articleServiceModel);

    }
}
