using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetBookQuery : IGetBaseInfoQuery<Book>
	{
		public Book Result { get; private set; }

		public int Id { get; }

		public bool IsIdKnown { get; }

		public bool ContainsResult => Result != null;

		public GetBookQuery(int id)
		{
			Id = id;
			IsIdKnown = true;
		}

		public static bool IsValidId(int bookId)
		{
			return bookId > 0;
		}
		public void SetResult(Book result)
		{
			Result = result;
		}
	}
}