using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IBookRepository : IRepository<Book>
	{
		Book Get(string isbn);
	}
}