using Bookstore.Common.Models.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class BookDetailsEntityConfiguration : EntityTypeConfiguration<BookDetails>
	{
		public BookDetailsEntityConfiguration()
		{
			Property(x => x.Pages).IsOptional();
		}
	}
}