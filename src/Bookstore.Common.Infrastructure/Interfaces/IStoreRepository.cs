using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IStoreRepository : IRepository<BookInStore>
	{
		BookInStore GetByBookId(int bookId);
	}
}