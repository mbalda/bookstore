using Bookstore.Common.Models.DomainModels;
using Bookstore.DataAccess.Database.Configurations;
using System.Data.Entity;

namespace Bookstore.DataAccess.Database
{
	public class BookstoreContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Book> Books { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Order> Orders { get; set; }

		public BookstoreContext() : base("name=BookstoreConnectionString")
		{
			System.Data.Entity.Database.SetInitializer(new BookstoreInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserEntityConfiguration());
			modelBuilder.Configurations.Add(new ImageEntityConfiguration());
			modelBuilder.Configurations.Add(new BookEntityConfiguration());
			modelBuilder.Configurations.Add(new BookDetailsEntityConfiguration());
			modelBuilder.Configurations.Add(new OrderEntityConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
