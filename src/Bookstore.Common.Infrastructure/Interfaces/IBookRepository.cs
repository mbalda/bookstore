using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IBookRepository : IRepository<BookDetails>
	{
		BookDetails Get(string isbn);
	}
}