using Blog.Domain.Entities;
using System.Linq;

namespace Blog.Domain.Abstract
{
    public interface INewsRepository
    {
        IQueryable<News> News { get; }
        void SaveNews(News news);
        News DeleteNews(int newsID);
    }
}
