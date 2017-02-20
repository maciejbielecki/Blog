using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog.Domain.Entities

{
    public class News
    {
        //news
        [HiddenInput(DisplayValue = false)]
        public int NewsID { get; set; }

        public bool Visible { get; set; }

        [Required(ErrorMessage = "Proszę określić kategorię.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Proszę napisać tytuł.")]
        [DataType(DataType.MultilineText)]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "Proszę napisać tytuł.")]
        [DataType(DataType.MultilineText)]
        public string Intro { get; set; }

        [Required(ErrorMessage = "Proszę napisać treść posta.")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required(ErrorMessage = "Proszę uzupełnić datę")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Proszę określić autora")]
        public string Writer { get; set; }


        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

    }
}
