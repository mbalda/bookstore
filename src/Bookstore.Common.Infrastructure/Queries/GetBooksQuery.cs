namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetBooksQuery
	{
		public bool OnlyAvailable { get; }

		public GetBooksQuery(bool onlyAvailable)
		{
			OnlyAvailable = onlyAvailable;
		}
	}
}