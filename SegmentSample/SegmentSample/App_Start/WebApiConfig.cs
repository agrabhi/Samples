using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using SegmentSample.Models;
using System;
using System.Collections.Generic;
using Microsoft.OData;
using System.Linq;
using System.Web.Http;

namespace SegmentSample
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

            config.SetUrlKeyDelimiter(ODataUrlKeyDelimiter.Slash);
            config.Expand();

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: GetEdmModel());
        }

        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
                        
            builder.Singleton<Trustframework>("trustframework");
            builder.EntitySet<TrustframeworkPolicy>("trustframeworkPolicies");

            AddRestoreAction(builder);

            builder.EnableLowerCamelCase();

            return builder.GetEdmModel();
        }

        private static void AddRestoreAction(ODataConventionModelBuilder builder)
        {
            var action = builder.EntityType<TrustframeworkPolicy>()
                .Action("Restore")
                .Parameter<string>("version");
        }
    }
}
