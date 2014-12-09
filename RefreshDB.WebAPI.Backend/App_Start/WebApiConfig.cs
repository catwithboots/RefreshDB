using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RefreshDB.WebAPI.Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Environments",
                routeTemplate: "api/environments/{id}",
                defaults: new { controller = "environments", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Scripts",
                routeTemplate: "api/scripts/{id}",
                defaults: new { controller = "scripts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Instances",
                routeTemplate: "api/instances/{id}",
                defaults: new { controller = "instances", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Databases",
                routeTemplate: "api/databases/{id}",
                defaults: new { controller = "databases", id = RouteParameter.Optional }
            );
            // Begin Rundeck routes
            config.Routes.MapHttpRoute(
                name: "RundeckGetBoolean",
                routeTemplate: "api/rundeck/GetBoolean",
                defaults: new { controller = "rundeck", action = "GetBoolean" }
            );

            config.Routes.MapHttpRoute(
                name: "Rundeck",
                routeTemplate: "api/rundeck",
                defaults: new { controller = "rundeck", action = "Get" }
            );
            
            config.Routes.MapHttpRoute(
                name: "RundeckMultiValue",
                routeTemplate: "api/{controller}/{action}/{id}/{name}",
                defaults: new { controller = "rundeck", id = RouteParameter.Optional,  name = RouteParameter.Optional},
                constraints: new { id = @"^[0-9]+$", name = @"^[a-z]+$" }
            );
            
            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: null,
               constraints: new { id = @"^[0-9]+$" }
            );

            // End Rundeck routes
        }
    }
}
