using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PagingInfo pagingInfo,
                                                Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {   
                TagBuilder tag = new TagBuilder("a");
                // tworzenie znacznika <a>
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();               

                TagBuilder li = new TagBuilder("li");
                li.InnerHtml += tag;
                result.Append(li.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}