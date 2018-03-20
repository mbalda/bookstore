using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Bookstore.Common.Models.WebModels;
using Microsoft.OData.Edm;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Bookstore.Web.API
{
	public static class WebApiConfig
	{
		public static HttpConfiguration Configuration { get; set; }

		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			Configuration = config;

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// CORS

			// OData configuration
			config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
			config.MapODataServiceRoute("odata", null, GetEdmModel());
		}

		public static void Register(Container container)
		{
			Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}


		private static IEdmModel GetEdmModel()
		{
			var builder = new ODataConventionModelBuilder();

			builder.EntitySet<BookInfo>("BookInfo");
			return builder.GetEdmModel();
		}
	}
}
