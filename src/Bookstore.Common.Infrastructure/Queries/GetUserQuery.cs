using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetUserQuery
	{
		public int UserId { get; set; }
		public User User { get; set; }
	}
}