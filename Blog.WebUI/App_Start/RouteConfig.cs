using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(null, "Kontakt", new
            {
                controller = "Nav",
                action = "Contact"
            });

            routes.MapRoute(null, "O_mnie", new
            {
                controller = "Nav",
                action = "About"
            });
           

            routes.MapRoute(null, "", new
            {
                controller = "News",
                action = "Show",
                category = (string)null,
                search = (string)null,
                page = 1
            });

           /* routes.MapRoute(null, "{search}",
                new
                {
                    controller = "News",
                    action = "Show",
                    category = (string)null,
                    page = 1
                });*/

            routes.MapRoute(null, "Strona{page}",
                new { controller = "News", action = "Show", category = (string)null, search = (string)null },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{category}",
                new { controller = "News", action = "Show", page = 1, search = (string)null });
            
            routes.MapRoute(null, "{category}/Strona{page}",
                new { controller = "News", action = "Show", search = (string)null },
                new { page = @"\d+" });


            /*routes.MapRoute(null, "Post_nr{id}",
                new
                {
                    controller = "News",
                    action = "ShowPost"
                },
                new { id = @"\d+" });*/

            

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
