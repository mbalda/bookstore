using Bookstore.Web.API.Configuration;
using Bookstore.Web.API.ErrorHandling;
using System.Web;
using System.Web.Http;

namespace Bookstore.Web.API
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			DependencyConfiguration.Configure();
			ModelsMappings.Configuration();

			GlobalConfiguration.Configuration.Filters.Add(new NotImplementedExceptionFilterAttribute());
		}
	}
}
