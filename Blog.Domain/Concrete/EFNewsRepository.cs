using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Blog.Domain.Concrete
{
    public class EFNewsRepository : INewsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<News> News
        {
            get { return context.News; }
        }

        public void SaveNews(News news)
        {
            if (news.NewsID == 0)
            {
                context.News.Add(news);
            }
            else
            {
                News dbEntry = context.News.Find(news.NewsID);
                if (dbEntry != null)
                {                   
                    dbEntry.Category = news.Category;
                    dbEntry.NewsTitle = news.NewsTitle;
                    dbEntry.Intro = news.Intro;
                    dbEntry.Text = news.Text;
                    dbEntry.Date = news.Date;
                    dbEntry.Writer = news.Writer;
                    dbEntry.Visible = news.Visible;
                    if (news.ImageData != null || news.ImageMimeType != null)
                        {
                            dbEntry.ImageData = news.ImageData;
                            dbEntry.ImageMimeType = news.ImageMimeType;
                        }               
                }
            }
            context.SaveChanges();
        }

        public News DeleteNews(int newsID)
        {
            News dbEntry = context.News.Find(newsID);
            if (dbEntry != null)
            {
                context.News.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
         }
    }
}
