using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface ILinksProvider
	{
		List<Link> GetLinks(int entityId);
	}
}