using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class CommentViewModel
    {
        public IEnumerable<Comment> Comment { get; set; }
        
        public PagingInfo PagingInfo { get; set; }
    }
}