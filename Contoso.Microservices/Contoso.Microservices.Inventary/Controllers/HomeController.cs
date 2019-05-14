using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contoso.Microservices.Inventary.Models;
using Contoso.Microservices.Inventary.Repository;

namespace Contoso.Microservices.Inventary.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository articleRepository;
        public HomeController()
        {
            articleRepository = new ArticleRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Articles()
        {
            var model = new ArticlesViewModel
            {
                Articles = articleRepository.GetLatest()
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
