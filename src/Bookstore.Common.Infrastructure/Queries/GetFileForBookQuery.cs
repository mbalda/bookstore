namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetFileForBookQuery
	{
		public int BookId { get; }


		public GetFileForBookQuery(int bookId)
		{
			BookId = bookId;
		}
	}
}