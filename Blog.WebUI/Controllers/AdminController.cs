using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private INewsRepository repository;

        public AdminController(INewsRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.News);
        }

        public ViewResult Edit(int newsID)
        {
            News news = repository.News
            .FirstOrDefault(prop => prop.NewsID == newsID);
            return View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase image)
        {
           if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        news.ImageMimeType = image.ContentType;
                        news.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(news.ImageData, 0, image.ContentLength);
                    }
                    repository.SaveNews(news);
                    TempData["message"] = string.Format("Zapisano {0}", news.NewsTitle);
                    return RedirectToAction("Index");
                }
            else
            {
                return View(news);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new News());
        }

        [HttpPost]
        public ActionResult Delete(int newsID)
        {
            News deletedNews = repository.DeleteNews(newsID);

            if(deletedNews != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedNews.NewsTitle);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Preview(int Id = 1)
        {
            NewsViewModel viewModel = new NewsViewModel
            {
                News = repository.News
                .Where(p => p.NewsID == Id)
            };

            return View(viewModel);
        }
    }
}