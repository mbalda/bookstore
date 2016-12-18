using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Services.Helpers
{
	public class BookResourceLinksProvider : LinkGenerator, ILinksProvider
	{
		public List<Link> GetLinks(int bookId)
		{
			var links = new List<Link>
			{
				// Put links here
			};

			return links;
		}
	}
}