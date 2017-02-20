using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
    public interface ICommentsRepository
    {
        IQueryable<Comment> Comments { get; }

        void SaveComment(Comment comments);
        //Comment DeleteComment(int commentsID);
    }
}
