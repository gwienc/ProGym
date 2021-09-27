using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProGym
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                name: "ProductDetalis",
                url: "{controller}/product-{id}",
                defaults: new { controller = "Store", action = "Details" }
                );


            routes.MapRoute(
                name: "StaticPages",
                url: "ProGym/{viewname}",
                defaults: new { controller = "Home", action = "StaticContent" }
                );


            routes.MapRoute(
                name: "ProductList",
                url: "{controller}/Kategoria/{categoryname}",
                defaults: new { controller = "Store", action = "List" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
