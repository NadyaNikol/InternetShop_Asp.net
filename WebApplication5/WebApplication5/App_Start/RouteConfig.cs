using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Good", action = "Index", category = (string)null, page = 1 });

            routes.MapRoute(
                null,
                url: "Page{page}",
                defaults: new { controller = "Good", action = "Index", category = (string)null },
                constraints: new { page = @"\d+" });
            routes.MapRoute(null,
                "{category}",
                new { controller = "Good", action = "Index", page = 1 });

            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new { controller = "Good", action = "Index" },
                constraints: new { page = @"\d+" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
