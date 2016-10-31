using Bookstore.Common.Models.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class UserEntityConfiguration : EntityTypeConfiguration<User>
	{
		public UserEntityConfiguration()
		{
			ToTable("Users");

			Property(x => x.Login).HasMaxLength(20);
			Property(x => x.Email).HasMaxLength(100);
		}
	}
}
