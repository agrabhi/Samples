using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Select().Expand();

            // New code:
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();

            builder.Namespace = "Microsoft.Graph";

            builder.Singleton<PoliciesRoot>("policies");
            builder.Singleton<IdentityContainer>("identity");

            builder.EntitySet<IdentityProvider>("identityProviders");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}
