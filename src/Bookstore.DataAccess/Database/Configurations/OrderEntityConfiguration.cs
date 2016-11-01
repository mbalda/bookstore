using Bookstore.Common.Models.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class OrderEntityConfiguration : EntityTypeConfiguration<Order>
	{
		public OrderEntityConfiguration()
		{
			HasMany<BookDetails>(s => s.OrderedBooks)
				.WithMany(c => c.Orders)
				.Map(cs =>
				{
					cs.MapLeftKey("OrderId");
					cs.MapRightKey("BookId");
					cs.ToTable("OrderedBooks");
				});
		}
	}
}
