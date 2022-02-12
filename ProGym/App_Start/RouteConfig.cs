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
                name: "Workouts",
                url: "ProGym/Workouts",
                defaults: new { controller = "Workout", action = "Index" }
                );

            routes.MapRoute(
                name: "Calculators",
                url: "ProGym/Calculators",
                defaults: new { controller = "Calculators", action = "Index" }
                );

            routes.MapRoute(
                name: "BuyTicket",
                url: "ProGym/Tickets/{typeTicket}/{periodOfValidity}/{ticketId}",
                defaults: new { controller = "Ticket", action = "BuyTicket" }
                );

            routes.MapRoute(
                name: "ChooseTicket",
                url: "ProGym/Tickets/Ticket-{type}",
                defaults: new { controller = "Ticket", action = "ChooseTicket" }
                );

            routes.MapRoute(
                name: "Tickets",
                url: "ProGym/Tickets",
                defaults: new { controller = "Ticket", action = "Index" }
                );

            routes.MapRoute(
               name: "ProductList",
               url: "ProGym/Store/Category/{categoryname}",
               defaults: new { controller = "Store", action = "Index" }
               );
            routes.MapRoute(
                name: "ProductDetalis",
                url: "ProGym/Store/product-{id}",
                defaults: new { controller = "Store", action = "Details" }
                );

            routes.MapRoute(
                name: "Store",
                url: "ProGym/Store",
                defaults: new { controller = "Store", action = "Index" }
                );

            routes.MapRoute(
                name: "ChangeProfile",
                url: "ProGym/Manage/{action}",
                defaults: new { controller = "Manage", action = "Index" }
                );        

            routes.MapRoute(
                name: "StaticPages",
                url: "ProGym/{viewname}",
                defaults: new { controller = "Home", action = "StaticContent" }
                );

            routes.MapRoute(
                name: "HomePage",
                url: "ProGym",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
