using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Microservices.Inventary.Models;

namespace Contoso.Microservices.Inventary.Repository
{
    public interface IArticleRepository
    {
        List<Article> GetLatest();
    }

    public class ArticleRepository : IArticleRepository
    {
        private List<Article> articles = new List<Article>
        {
            new Article
            {
                Id=1,
                Title="Azure DevOps and Microservices",
                Author = "Dino Esposito",
                PublishedOn = new DateTime(2019,5,12),
                Content="This book is simple dummy text about Azure DevOps."
            }
        };

        List<Article> IArticleRepository.GetLatest()
        {
            return articles;
        }
    }
}
