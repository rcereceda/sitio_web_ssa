using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Data.Entity.Database;  // DbDatabase.SetInitialize
using SitioWeb.Models;              // NoticiaInitializer

namespace SitioWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                "Archivo", // Route name 
                "Home/Noticias/{year}/{month}/{day}", // URL with parameters 
                new
                {
                    controller = "Home",
                    action = "Noticias"
                },                
                new { page = @"\d+", year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
                // Parameter defaults 
                );*/

            routes.MapRoute(
                "Home", // Route name 
                "Home/Index/Page/{page}", // URL with parameters 
                new
                {
                    controller = "Home",
                    action = "Index"
                }// Parameter defaults 
                );

            routes.MapRoute(
                "Inversiones", // Route name 
                "Home/Inversiones/Page/{page}", // URL with parameters 
                new
                {
                    controller = "Home",
                    action = "Inversiones"
                }// Parameter defaults 
                );

            routes.MapRoute(
                "Archivo", // Route name 
                "Home/Noticias/Page/{page}", // URL with parameters 
                new
                {
                    controller = "Home",
                    action = "Noticias"
                }// Parameter defaults 
                );

            routes.MapRoute(
                "Admin", // Route name 
                "Noticias/Page/{page}", // URL with parameters 
                new
                {
                    controller = "Noticias",
                    action = "Index"
                }// Parameter defaults 
                );

            routes.MapRoute(
                "Slug", 
                "Home/Leer/{slug}", new
            {
                controller = "Home",
                action = "Leer"
            });
           
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            DbDatabase.SetInitializer<SitioWebEntities>(new SitioWebInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}