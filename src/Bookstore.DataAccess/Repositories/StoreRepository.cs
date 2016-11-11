using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.DataAccess.Repositories
{
	public class StoreRepository : IStoreRepository
	{
		private readonly BookstoreContext _context;

		public StoreRepository(BookstoreContext context)
		{
			this._context = context;
		}

		public BookInStore Get(int id)
		{
			return _context.BooksInStore.FirstOrDefault(x => x.Id == id);
		}

		public BookInStore GetByBookId(int bookId)
		{
			return _context.BooksInStore.FirstOrDefault(x => x.BookId == bookId);
		}

		public ICollection<BookInStore> GetAvailableBooks()
		{
			return _context.BooksInStore.Where(x => x.IsAvailable).ToList();
		}

		public ICollection<BookInStore> GetAll()
		{
			return _context.BooksInStore.ToList();
		}

		public void Insert(BookInStore entity)
		{
			if (entity != null)
			{
				_context.BooksInStore.Add(entity);

				_context.SaveChanges();
			}
		}

		public void Update(BookInStore entity)
		{
			if (entity != null)
			{
				var oldValue = _context.BooksInStore.FirstOrDefault(x => x.Id == entity.Id);

				if (oldValue != null)
				{
					oldValue = entity;

					_context.SaveChanges();
				}
			}
		}

		public void Remove(BookInStore entity)
		{
			if (entity != null)
			{
				_context.BooksInStore.Remove(entity);

				_context.SaveChanges();
			}
		}
	}
}