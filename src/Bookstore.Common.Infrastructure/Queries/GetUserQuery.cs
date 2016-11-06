using Bookstore.Common.Models.WebModels;

namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetUserQuery
	{
		public int UserId { get; private set; }

		public string Login { get; private set; }

		public User User { get; set; }

		public bool IsUserIdKnown { get; private set; }

		public bool ContainsUser => User != null;

		public GetUserQuery(int userId)
		{
			UserId = userId;
			IsUserIdKnown = true;
		}

		public GetUserQuery(string login)
		{
			Login = login;
			IsUserIdKnown = false;
		}

		public static bool IsValidUserId(int userId)
		{
			return userId >= 0;
		}
	}
}