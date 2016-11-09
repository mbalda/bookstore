using Bookstore.Common.Models.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class BookInStoreEntityConfiguration : EntityTypeConfiguration<BookInStore>
	{
		public BookInStoreEntityConfiguration()
		{
			ToTable("BooksInStore");
		}
	}
}
