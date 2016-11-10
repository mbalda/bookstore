namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IQueryHandler<in TQuery, out TResult>
	{
		TResult Handle(TQuery query);
	}
}