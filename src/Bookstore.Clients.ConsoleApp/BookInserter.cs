using Bookstore.Clients.ConsoleApp.DataExtractor;
using Bookstore.Clients.ConsoleApp.Service;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Bookstore.Clients.ConsoleApp
{
	public class BookInserter
	{
		const string ResourceBaseUrl = "books";
		private readonly ServiceProvider _service;

		public BookInserter()
		{
			_service = new ServiceProvider();
		}

		public string InsertBooksToStore(Book book)
		{
			// Send request here
			HttpResponseMessage response;

			if (true)
			{
				var message = $"Book: {book.Title}, has been uploaded to store.\r\n";
				message += UploadImage(0, book.ImageName);

				return message;
			}

			return $"Some error occured uploading book: {book.Title}. Details: {response.ReasonPhrase}.";
		}

		private Stream ReadFile(string fileName)
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Images", fileName);
			return File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		private string UploadImage(int bookId, string fileName)
		{
			string resourceImageUrl = "";

			var image = ReadFile(fileName);

			var result = _service.UploadFileForBook(resourceImageUrl, image, fileName);

			if (result.StatusCode == HttpStatusCode.OK)
			{
				return $"File '{fileName}' for book with ID {bookId}, has been uploaded to store.";
			}

			return $"Some error occured uploading image '{fileName}'. Details: {result.ReasonPhrase}.";
		}
	}
}
