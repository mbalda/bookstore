using System;

namespace Bookstore.Clients.ConsoleApp
{
	public class BookInserter
	{
		const string ResourceUrl = "users";
		private readonly ServiceProvider _services;

		public BookInserter()
		{
			_services = new ServiceProvider();
		}

		public void InsertBooksToStore()
		{
			var result = _services.Post(ResourceUrl, new Object());
		}
	}
}
