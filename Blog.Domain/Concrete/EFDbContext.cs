using System.Data.Entity;
using Blog.Domain.Entities;

namespace Blog.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
