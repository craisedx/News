using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.App_Start.Interfaces;
using News.ViewModels;
using System.Collections.Generic;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly INewsService newsService;
        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                newsService.AddNews(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditNews(int id)
        {
            var news = newsService.GetNewsById(id);

            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                newsService.EditNews(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult News(int id)
        {
            var news = newsService.GetNewsById(id);

            return View(news);
        }

        [HttpGet]
        [Authorize]
        public IActionResult RemoveNews(int id)
        {
            newsService.RemoveNews(id);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var items = newsService.GetLastSixNews();

            return View(items);
        }

        public IActionResult AllNews()
        {
            var items = newsService.GetItemsPage(5);

            return View(items);
        }

        [HttpPost]
        public JsonResult LoadAdditionalNews(int? skipCount)
        {
            var items = newsService.GetNewNews(skipCount);

            return Json(items);
        }
    }
}
