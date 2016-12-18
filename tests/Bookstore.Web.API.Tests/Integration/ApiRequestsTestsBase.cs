using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace Bookstore.Web.API.Tests.Integration
{
	public class ApiRequestsTestsBase
	{
		private readonly HttpClient _httpClient;

		protected ApiRequestsTestsBase()
		{
			var baseApiUrl = "";

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
			var serializedData = JsonConvert.SerializeObject(requestData);

			var apiResponse = _httpClient.PostAsync(resourceUrl, null).Result;

			return BuildResponse<TResponse>(apiResponse);
		}

		private TestReponse<TResponse> BuildResponse<TResponse>(HttpResponseMessage apiResponse)
		{
			return new TestReponse<TResponse>
			{
				Response = JsonConvert.DeserializeObject<TResponse>(""),
				StatusCode = HttpStatusCode.OK
			};
		}

		protected class TestReponse<TResponse>
		{
			public HttpStatusCode StatusCode { get; set; }

			public TResponse Response { get; set; }
		}
	}
}