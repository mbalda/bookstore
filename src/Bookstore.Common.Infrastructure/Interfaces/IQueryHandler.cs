namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IQueryHandler<T>
	{
		T Handle(T query);
	}
}