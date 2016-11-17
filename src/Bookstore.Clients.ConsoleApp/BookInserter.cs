using System.Net;

namespace Bookstore.Clients.ConsoleApp
{
	public class BookInserter
	{
		const string ResourceUrl = "books";
		private readonly ServiceProvider _services;

		public BookInserter()
		{
			_services = new ServiceProvider();
		}

		public string InsertBooksToStore(Book book)
		{
			string message;

			var result = _services.Post(ResourceUrl, book);

			if (result.StatusCode == HttpStatusCode.Created)
			{
				message = $"Book: {book.Title}, has been uploaded to store.";
			}
			else
			{
				message = $"Some error occured uploading book: {book.Title}. Details: {result.ReasonPhrase}.";
			}

			return message;
		}
	}
}
