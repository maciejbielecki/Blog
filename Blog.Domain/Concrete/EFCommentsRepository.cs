using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class EFCommentsRepository : ICommentsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public void SaveComment(Comment comments)
        {
            if(comments.CommentID == 0)
            {
                context.Comments.Add(comments);
            }
            else
            {
                Comment dbEntry = context.Comments.Find(comments.CommentID);
                if(dbEntry != null)
                {
                    dbEntry.CommentID = comments.CommentID;
                    dbEntry.CNewsID = comments.CNewsID;
                    dbEntry.CommentDate = comments.CommentDate;
                    dbEntry.CommentText = comments.CommentText;
                    dbEntry.Email = comments.Email;
                    dbEntry.Signature = comments.Signature;
                    dbEntry.WebSite = comments.WebSite;
                } 
            }
            context.SaveChanges();
        }

        
    }
}
