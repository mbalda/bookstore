namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetBookQuery
	{
		public int Id { get; }

		public string Isbn { get; }

		public bool IsIdKnown { get; }

		public GetBookQuery(int id)
		{
			Id = id;
			IsIdKnown = true;
		}

		public GetBookQuery(string isbn)
		{
			Isbn = isbn;
			IsIdKnown = false;
		}
	}
}