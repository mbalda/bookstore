using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Services.Helpers
{
	public class UserResourceLinksProvider : LinkGenerator, ILinksProvider
	{
		public List<Link> GetLinks(int userId)
		{
			var links = new List<Link>
			{
				// Put links here
			};

			return links;
		}
	}
}