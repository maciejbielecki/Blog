using Blog.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using Blog.Domain.Entities;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository repository;
        public int PageSize = 6;

        public NewsController(INewsRepository newsRepository)
        {
            this.repository = newsRepository;
        }

        public ViewResult Show(string category, string search, int page = 1)
        {
            NewsViewModel viewModel = new NewsViewModel
            {
                News = repository.News
                .Where(p => category == null || p.Category == category)
                .Where(p => search == null || p.NewsTitle.Contains(search))
                .OrderByDescending(p => p.NewsID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Where(p => p.Visible == true),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = (category == null && search == null) ? 
                    repository.News.Count() :
                    repository.News.Where(e => e.Category == category && (e.NewsTitle.Contains(search) || e.Text.Contains(search))).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);

        }

        public ViewResult ShowPost(int Id = 1)
        {
            NewsViewModel viewModel = new NewsViewModel
            {
                News = repository.News
                .Where(p => p.NewsID == Id)
            };
            
            return View(viewModel);
        }

        public FileContentResult GetImage(int newsID)
        {
            News news = repository.News.FirstOrDefault(p => p.NewsID == newsID);
            if(news != null && news.ImageData != null)
            {
                return File(news.ImageData, news.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


        
        public PartialViewResult Search()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Search(string input = null)
        {            
             return RedirectToAction("Show", "News", new {search = input});            
        }
    }
}