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

		public BookDetails Get(int id)
		{
			return _context.Books.OfType<BookDetails>().FirstOrDefault(x => x.Id == id);
		}

		public BookDetails Get(string isbn)
		{
			return _context.Books.OfType<BookDetails>().FirstOrDefault(x => x.Isbn == isbn);
		}

		public ICollection<BookDetails> GetAll()
		{
			return _context.Books.OfType<BookDetails>().ToList();
		}

		public void Insert(BookDetails entity)
		{
			if (entity != null)
			{
				_context.Books.Add(entity);

				_context.SaveChanges();
			}
		}

		public void Update(BookDetails entity)
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

		public void Remove(BookDetails entity)
		{
			if (entity != null)
			{
				_context.Books.Remove(entity);

				_context.SaveChanges();
			}
		}
	}
}