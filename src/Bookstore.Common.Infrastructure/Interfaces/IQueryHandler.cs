namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IQueryHandler<T>
	{
		void Handle(T query);
	}
}