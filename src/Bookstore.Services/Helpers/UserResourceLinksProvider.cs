using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;
using System.Net.Http;

namespace Bookstore.Services.Helpers
{
	public class UserResourceLinksProvider : LinkGenerator, ILinksProvider
	{
		public List<Link> GetLinks(int userId)
		{
			var links = new List<Link>
			{
				GetLink("self", $"users/{userId}", HttpMethod.Get),
				GetLink("new", "users/", HttpMethod.Post),
				GetLink("remove", $"users/{userId}", HttpMethod.Delete)
			};

			return links;
		}
	}
}