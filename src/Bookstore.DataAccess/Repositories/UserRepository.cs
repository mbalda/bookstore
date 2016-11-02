using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly BookstoreContext _context;

		public UserRepository(BookstoreContext context)
		{
			this._context = context;
		}

		public User Get(int id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id);
		}

		public User Get(string login)
		{
			return _context.Users.FirstOrDefault(x => x.Login == login);
		}

		public ICollection<User> GetAll()
		{
			return _context.Users.ToList();
		}

		public void Insert(User entity)
		{
			if (entity != null)
			{
				_context.Users.Add(entity);

				_context.SaveChanges();
			}
		}

		public void Update(User entity)
		{
			if (entity != null)
			{
				var oldValue = _context.Users.FirstOrDefault(x => x.Id == entity.Id);

				if (oldValue != null)
				{
					oldValue = entity;

					_context.SaveChanges();
				}
			}
		}

		public void Remove(User entity)
		{
			if (entity != null)
			{
				_context.Users.Remove(entity);

				_context.SaveChanges();
			}
		}
	}
}