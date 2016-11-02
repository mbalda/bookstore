using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

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
		}

		public static void Register(Container container)
		{
			Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}
	}
}
