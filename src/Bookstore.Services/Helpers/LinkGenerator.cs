using Bookstore.Common.Models.WebModels;
using System.Configuration;
using System.Net.Http;

namespace Bookstore.Services.Helpers
{
	public class LinkGenerator
	{
		protected Link GetLink(string relValue, string resourcePath, HttpMethod httpMethod)
		{
			var baseApiUrl = ConfigurationManager.AppSettings["servicesBaseUrl"];

			var link = new Link
			{
				Href = $"{baseApiUrl}/{resourcePath}",
				Rel = relValue,
				Method = httpMethod.Method
			};

			return link;
		}
	}
}
