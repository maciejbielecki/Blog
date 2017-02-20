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
    public class CommentsController : Controller
    {
        private ICommentsRepository repository;
        public int PageSize = 6;

        public CommentsController(ICommentsRepository commentsRepository)
        {
            this.repository = commentsRepository;
        }

        public PartialViewResult ShowComments(int page = 1,int Id = 1)
        {
            CommentViewModel viewModel = new CommentViewModel
            {
                Comment = repository.Comments
                .Where(p => p.CNewsID == Id)
                .OrderByDescending(p => p.CommentID)
                .Take(repository.Comments.Where(e => e.CNewsID == Id).Count())
            };        

            return PartialView(viewModel);
        }


        [ValidateInput(false)]
        public PartialViewResult SaveComment(int Id = 1)
        {
            return PartialView("SaveComment", new Comment { CNewsID = Id });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveComment(Comment comment)
        {
            if (ModelState.IsValid)
            {                
                repository.SaveComment(comment);
                return RedirectToAction("ShowPost", "News", new { Id = comment.CNewsID });
            }
            else
            {
                return RedirectToAction("ShowPost", "News", new { Id = comment.CNewsID });
            }
        }



    }
}