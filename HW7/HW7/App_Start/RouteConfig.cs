﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "User",
                url: "api/user",
                defaults: new { controller = "Home", action = "User"}
            );

            routes.MapRoute(
                name: "Repo",
                url: "api/repositories",
                defaults: new { controller = "Home", action = "Repo"}
            );

            routes.MapRoute(
                name: "Commits",
                url: "api/commits",
                defaults: new { controller = "Home", action = "Commit"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
