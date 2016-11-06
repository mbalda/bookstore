namespace Bookstore.Common.Infrastructure.Queries
{
	public interface IGetBaseInfoQuery<T>
	{
		T Result { get; }

		int Id { get; }

		void SetResult(T result);

		bool IsIdKnown { get; }

		bool ContainsResult { get; }
	}
}