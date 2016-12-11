using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IUserResourceLinksProvider
	{
		List<Link> GetLinksForUser(int userId);
	}
}