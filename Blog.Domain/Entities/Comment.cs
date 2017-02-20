using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CNewsID { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Proszę podać treść komentarza.")]
        public string CommentText { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Proszę wpisać nick.")]
        public string Signature { get; set; }
        [AllowHtml]
        public string Email { get; set; }
        [AllowHtml]
        public string WebSite { get; set; }

        public string CommentDate { get; set; }
    }
}
