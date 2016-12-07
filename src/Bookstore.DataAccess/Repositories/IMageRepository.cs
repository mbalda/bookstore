using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.DataAccess.Repositories
{
	public class ImageRepository : IImageRepository
	{
		private readonly BookstoreContext _context;

		public ImageRepository(BookstoreContext context)
		{
			this._context = context;
		}

		public Image Get(int id)
		{
			return _context.Images.SingleOrDefault(x => x.Id == id);
		}

		public ICollection<Image> GetAll()
		{
			return _context.Images.ToList();
		}

		public void Insert(Image entity)
		{
			if (entity != null)
			{
				_context.Images.Add(entity);

				_context.SaveChanges();
			}
		}

		public void Update(Image entity)
		{
			throw new System.NotImplementedException();
		}

		public void Remove(Image entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
