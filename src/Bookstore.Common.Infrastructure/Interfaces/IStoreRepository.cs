using Bookstore.Common.Models.DomainModels;
using System.Collections.Generic;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IStoreRepository : IRepository<BookInStore>
	{
		BookInStore GetByBookId(int bookId);
		ICollection<BookInStore> GetAvailableBooks();
	}
}