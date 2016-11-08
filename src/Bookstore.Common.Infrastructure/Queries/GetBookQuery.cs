using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Common.Infrastructure.Queries
{
	public class GetBookQuery : IGetBaseInfoQuery<BookInfo>
	{
		public BookInfo Result { get; private set; }

		public int Id { get; }

		public bool IsIdKnown { get; }

		public bool ContainsResult => Result != null;

		public GetBookQuery(int id)
		{
			Id = id;
			IsIdKnown = true;
		}

		public void SetResult(BookInfo result)
		{
			Result = result;
		}
	}
}