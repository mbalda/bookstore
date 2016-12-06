using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Bookstore.Clients.ConsoleApp
{
	public class ServiceProvider
	{
		private readonly string _baseApiUrl;

		public ServiceProvider()
		{
			_baseApiUrl = ConfigurationManager.AppSettings["servicesBaseUrl"];
		}

		public HttpResponseMessage Post<TRequest>(string resourceUrl, TRequest requestData)
		{
			using (var httpClient = new HttpClient { BaseAddress = new Uri(_baseApiUrl) })
			{
				var httpContent = new StringContent(JsonConvert.SerializeObject(requestData));
				httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/json");

				return httpClient.PostAsync(resourceUrl, httpContent).Result;
			}
		}

		public HttpResponseMessage UploadFileForBook(string resourceUrl, Stream image, string fileName)
		{
			var boundaryName = "Upload image----" + DateTime.Now.ToString(CultureInfo.InvariantCulture);

			using (var client = new HttpClient { BaseAddress = new Uri(_baseApiUrl) })
			{
				using (var content = new MultipartFormDataContent(boundaryName))
				{
					content.Add(new StreamContent(image), "fileUpload", fileName);

					return client.PostAsync(resourceUrl, content).Result;
				}
			}
		}
	}
}
