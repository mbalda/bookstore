using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.DataAccess.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BookstoreContext _context;

		public BookRepository(BookstoreContext context)
		{
			this._context = context;
		}

		public Book Get(int id)
		{
			return _context.Books.FirstOrDefault(x => x.Id == id);
		}

		public Book Get(string isbn)
		{
			return _context.Books.FirstOrDefault(x => x.Isbn == isbn);
		}

		public ICollection<Book> GetAll()
		{
			return _context.Books.ToList();
		}

		public void Insert(Book entity)
		{
			if (entity != null)
			{
				_context.Books.Add(entity);

				_context.SaveChanges();
			}
		}

		public void Update(Book entity)
		{
			if (entity != null)
			{
				var oldValue = _context.Books.FirstOrDefault(x => x.Id == entity.Id);

				if (oldValue != null)
				{
					oldValue = entity;

					_context.SaveChanges();
				}
			}
		}

		public void Remove(Book entity)
		{
			if (entity != null)
			{
				_context.Books.Remove(entity);

				_context.SaveChanges();
			}
		}
	}
}