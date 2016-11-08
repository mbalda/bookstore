using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class BookInStoreEntityConfiguration : EntityTypeConfiguration<BookInStore>
	{
		public BookInStoreEntityConfiguration()
		{
			ToTable("BooksInStore");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired<BookDetails>(x => x.Book).WithRequiredPrincipal(x => x.BookInStore);
		}
	}
}
