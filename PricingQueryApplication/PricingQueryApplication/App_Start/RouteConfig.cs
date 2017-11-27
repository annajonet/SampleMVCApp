using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PricingQueryApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             routes.MapRoute(
             name: "PricingQuerySuc",
             url: "pricingquery/Success",
             defaults: new { controller = "PricingQuery", action = "Success" }
             ); routes.MapRoute(
              name: "PricingQueryFail",
              url: "pricingquery/Failure",
              defaults: new { controller = "PricingQuery", action = "Failure" }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "PricingQuery", action = "Index"}
            );
        }
    }
}
