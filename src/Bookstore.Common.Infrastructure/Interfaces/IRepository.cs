using System.Collections.Generic;

namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface IRepository<T>
	{
		T Get(int id);

		ICollection<T> GetAll();

		void Insert(T entity);

		void Update(T entity);

		void Remove(T entity);
	}
}