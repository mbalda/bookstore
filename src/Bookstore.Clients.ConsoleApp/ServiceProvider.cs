using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Bookstore.Clients.ConsoleApp
{
	public class ServiceProvider
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseApiUrl;

		public ServiceProvider()
		{
			_baseApiUrl = ConfigurationManager.AppSettings["servicesBaseUrl"];

			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(_baseApiUrl)
			};
		}

		public HttpResponseMessage Post<TRequest>(string resourceUrl, TRequest requestData)
		{
			StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestData));
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/json");

			return _httpClient.PostAsync(resourceUrl, httpContent).Result;
		}
	}
}
