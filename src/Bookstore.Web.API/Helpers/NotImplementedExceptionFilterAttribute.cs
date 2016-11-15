using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Bookstore.Web.API.Helpers
{
	public class NotImplementedExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception is NotImplementedException)
			{
				actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented)
				{
					ReasonPhrase = "Action has not been implemented yet.",
					Content = new StringContent(actionExecutedContext.Exception.Message)
				};
			}
		}
	}
}