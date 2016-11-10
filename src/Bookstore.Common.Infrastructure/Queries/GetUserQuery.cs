namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetUserQuery
	{
		public int Id { get; }

		public string Login { get; private set; }

		public bool IsIdKnown { get; }

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
	}
}