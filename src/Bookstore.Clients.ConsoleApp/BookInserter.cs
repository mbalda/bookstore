using System;
using System.IO;
using System.Xml.Serialization;

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
			var books = GetBooks();

			foreach (var book in books.BookList)
			{
				var result = _services.Post(ResourceUrl, book);
			}
		}

		private Books GetBooks()
		{
			Books books;

			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Books.xml");
			var serializer = new XmlSerializer(typeof(Books));

			using (StreamReader reader = new StreamReader(path))
			{
				books = (Books)serializer.Deserialize(reader);
			}

			return books;
		}
	}
}
