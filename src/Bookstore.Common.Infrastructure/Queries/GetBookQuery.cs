namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetBookQuery
	{
		public int Id { get; }

		public GetBookQuery(int id)
		{
			Id = id;
		}
	}
}