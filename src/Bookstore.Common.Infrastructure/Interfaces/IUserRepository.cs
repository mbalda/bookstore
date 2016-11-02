using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		User Get(string login);
	}
}