using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database;
using System;
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
			Func<BookDetails, bool> query = x => x.Id == id;
			return GetBookForQuery(query);
		}

		public BookDetails Get(string isbn)
		{
			Func<BookDetails, bool> query = x => x.Isbn == isbn;
			return GetBookForQuery(query);
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

		private BookDetails GetBookForQuery(Func<BookDetails, bool> query)
		{
			return _context.Books.OfType<BookDetails>().FirstOrDefault(query);
		}
	}
}