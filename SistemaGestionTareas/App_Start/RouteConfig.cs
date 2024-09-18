using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaGestionTareas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ruta para la API
            routes.MapRoute(
                name: "Api",
                url: "api/{controller}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );

            // Ruta para el controlador Home
            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index" }
            );


        }
    }
}
