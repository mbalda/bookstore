using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Bookstore.Web.API.Tests.Integration
{
	public class ApiRequestsTestsBase
	{
		private readonly HttpClient _httpClient;

		protected ApiRequestsTestsBase()
		{
			var baseApiUrl = "http://localhost:1000/api/";

			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(baseApiUrl)
			};
		}

		protected TestReponse<TResponse> Get<TResponse>(string resourceUrl)
		{
			var apiResponse = _httpClient.GetAsync(resourceUrl).Result;

			return BuildResponse<TResponse>(apiResponse);
		}

		protected TestReponse<TResponse> Post<TRequest, TResponse>(string resourceUrl, TRequest requestData)
		{
			StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestData));
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/json");

			var apiResponse = _httpClient.PostAsync(resourceUrl, httpContent).Result;

			return BuildResponse<TResponse>(apiResponse);
		}

		private TestReponse<TResponse> BuildResponse<TResponse>(HttpResponseMessage apiResponse)
		{
			return new TestReponse<TResponse>
			{
				Response = JsonConvert.DeserializeObject<TResponse>(apiResponse.Content.ReadAsStringAsync().Result),
				StatusCode = apiResponse.StatusCode
			};
		}

		protected class TestReponse<TResponse>
		{
			public HttpStatusCode StatusCode { get; set; }

			public TResponse Response { get; set; }
		}
	}
}