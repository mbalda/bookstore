using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class OrderEntityConfiguration : EntityTypeConfiguration<Order>
	{
		public OrderEntityConfiguration()
		{
			ToTable("Orders");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasMany<BookDetails>(s => s.OrderedBooks)
				.WithMany(c => c.Orders)
				.Map(cs =>
				{
					cs.MapLeftKey("OrderId");
					cs.MapRightKey("BookId");
					cs.ToTable("OrderedBooks");
				});

			HasRequired<User>(x => x.User).WithMany(x => x.Orders);
		}
	}
}
