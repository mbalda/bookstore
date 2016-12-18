using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Http;

namespace Bookstore.Clients.ConsoleApp.Service
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
				//Prepare contet to send here

				return httpClient.PostAsync(resourceUrl, null).Result;
			}
		}

		public HttpResponseMessage UploadFileForBook(string resourceUrl, Stream image, string fileName)
		{
			var boundaryName = "Upload image----" + DateTime.Now.ToString(CultureInfo.InvariantCulture);
			const string contentDisposition = "fileUpload";

			using (var client = new HttpClient { BaseAddress = new Uri(_baseApiUrl) })
			{
				using (var content = new MultipartFormDataContent(boundaryName))
				{
					content.Add(new StreamContent(image), contentDisposition, fileName);
					// content.Add(new StringContent(bookId.ToString()), "bookId");

					return client.PostAsync(resourceUrl, content).Result;
				}
			}
		}
	}
}
