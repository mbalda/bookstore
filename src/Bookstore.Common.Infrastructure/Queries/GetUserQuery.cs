using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetUserQuery : IGetBaseInfoQuery<User>
	{
		public int Id { get; }

		public string Login { get; private set; }

		public User Result { get; private set; }

		public bool IsIdKnown { get; }

		public bool ContainsResult => Result != null;

		public GetUserQuery(int id)
		{
			Id = id;
			IsIdKnown = true;
		}

		public GetUserQuery(string login)
		{
			Login = login;
			IsIdKnown = false;
		}
		public void SetResult(User result)
		{
			Result = result;
		}

		public static bool IsValidUserId(int userId)
		{
			return userId > 0;
		}
	}
}