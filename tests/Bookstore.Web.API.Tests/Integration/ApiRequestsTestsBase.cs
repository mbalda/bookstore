using System;
using System.Net.Http;

namespace Bookstore.Web.API.Tests.Integration
{
	public class ApiRequestsTestsBase
	{
		protected HttpClient httpClient;

		public ApiRequestsTestsBase()
		{
			var baseApiUrl = "http://localhost:1000/api/";

			httpClient = new HttpClient
			{
				BaseAddress = new Uri(baseApiUrl)
			};
		}
	}
}