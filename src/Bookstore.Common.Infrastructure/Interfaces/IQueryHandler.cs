namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IQueryHandler<in T>
	{
		void Handle(T query);
	}
}