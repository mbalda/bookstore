namespace Bookstore.Common.Infrastructure.Interfaces
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