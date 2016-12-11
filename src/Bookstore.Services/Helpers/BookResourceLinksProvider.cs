using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;
using System.Net.Http;

namespace Bookstore.Services.Helpers
{
	public class BookResourceLinksProvider : LinkGenerator, ILinksProvider
	{
		public List<Link> GetLinks(int bookId)
		{
			var links = new List<Link>
			{
				GetLink("self", $"books/{bookId}", HttpMethod.Get),
				GetLink("all-books", "books", HttpMethod.Get),
				GetLink("available-books", "books/available", HttpMethod.Get),
				GetLink("details", $"books/{bookId}/details", HttpMethod.Get),
				GetLink("new", "books", HttpMethod.Post),
				GetLink("upload-image", $"books/{bookId}/image", HttpMethod.Post),
				GetLink("update", $"books/{bookId}", HttpMethod.Put)
			};

			return links;
		}
	}
}